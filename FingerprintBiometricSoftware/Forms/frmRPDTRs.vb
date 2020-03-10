Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmRPDTRs

    Dim myData As New DataTable
    Private mReportDoc As ReportDocument

    Private Sub rptMembersList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Icon = CType(Icon.Clone, Drawing.Icon)
        populateComboBox(cboCutoffPeriods, "SELECT cutoff_period_id id,CONCAT(DATE_FORMAT(start_date,'%m/%d/%Y'),' - ',DATE_FORMAT(end_date,'%m/%d/%Y')) description FROM cutoff_periods ORDER BY cutoff_period_id DESC", "cutoff_period_id", "description")
        With cboSortBy
            .Items.Add("Barcode")
            .Items.Add("Description")
            .Text = "Description"
        End With
        If NetOpen(myData, "select department_id,1 isChecked,description from departments order by description", Cn.Connection) = True Then
            dgvDepartments.DataSource = myData
        End If
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        GroupBox1.Enabled = False

        If IsReportExist(SysParam.DTRReport) Then
            If Not (rpv.ReportSource Is Nothing) Then
                rpv.ReportSource = Nothing
            End If
            Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
            Dim mAdquery As String = ""

            Dim cutOffPeriod As New DataTable

            Dim dateFrom As Date
            Dim dateUntil As Date

            If (NetOpen(cutOffPeriod, "select * from cutoff_periods where cutoff_period_id = " & CType(cboCutoffPeriods.SelectedValue, DataRowView).Row.Item("id").ToString)) Then
                For Each dRow As DataRow In cutOffPeriod.Rows
                    dateFrom = CType(dRow.Item("start_date"), Date)
                    dateUntil = CType(dRow.Item("end_date"), Date)
                Next
            End If

            With dgvDepartments
                If .RowCount > 0 Then
                    For i = 0 To .RowCount - 1
                        If Not IsDBNull(.Item("isChecked", i).Value) Then
                            If Trim(mAdquery) = "" Then
                                mAdquery = " and department_id in (" & CStr(.Item("department_id", i).Value)
                            Else
                                mAdquery = mAdquery & "," & CStr(.Item("department_id", i).Value)
                            End If
                        End If
                    Next
                    If Trim(mAdquery) <> "" Then
                        mAdquery = mAdquery & ") "
                    Else
                        mAdquery = " and department_id =0 "
                    End If
                Else
                    mAdquery = " and department_id =0 "
                End If
            End With
            myConnectionInfo.ServerName = ";DRIVER={MySQL ODBC 3.51 Driver};SERVER=" & Cn.Host & ";DATABASE=" & Cn.Database & ";UID=" & Cn.Username & ";PWD=" & Cn.Password & ";PORT=" & Cn.Port & ";OPTION=3"
            mReportDoc = New ReportDocument()
            Dim reportPath As String = Application.StartupPath & "\Reports\" & SysParam.DTRReport
            mReportDoc.Load(reportPath)
            SetParam(mReportDoc, mAdquery, "mDepartment_ID")
            'SetParam(mReportDoc, Mid(cboCutoffPeriods.Text, 1, 10), "mDateFrom")
            'SetParam(mReportDoc, Mid(cboCutoffPeriods.Text, 14, 23), "mDateUntil")
            SetParam(mReportDoc, dateFrom.ToShortDateString, "mDateFrom")
            SetParam(mReportDoc, dateUntil.ToShortDateString, "mDateUntil")
            SetParam(mReportDoc, "", "CompanyName")
            SetParam(mReportDoc, "", "CompanyAddress")
            SetDBLogonForReport(mReportDoc, myConnectionInfo)
            rpv.ReportSource = mReportDoc
        End If
        GroupBox1.Enabled = True
    End Sub

    Private Sub txtSearchDept_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchDept.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If NetOpen(myData, "select department_id,1 isChecked,description from departments where description like '%" & ConSwap(txtSearchDept.Text) & "%' order by description", Cn.Connection) = True Then
                dgvDepartments.DataSource = myData
            End If
        End If
    End Sub

    Private Sub txtSearchDept_TextChanged(sender As Object, e As System.EventArgs) Handles txtSearchDept.TextChanged
        If txtSearchDept.Text = "" Then
            If NetOpen(myData, "select department_id,1 isChecked,description from departments order by description", Cn.Connection) = True Then
                dgvDepartments.DataSource = myData
            End If
        End If
    End Sub
End Class