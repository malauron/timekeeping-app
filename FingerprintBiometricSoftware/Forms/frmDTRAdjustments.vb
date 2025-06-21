Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmDTRAdjustments

    Dim mSchedule_ID As Integer
    Dim txt As C1.Win.C1Input.C1DateEdit

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        mLogUpdated = False
        Call Close()
    End Sub

    Private Sub Clear_Fields()
        mSchedule_ID = 0
        txt1st_insched.Value = vbNull
        txt1st_outsched.Value = vbNull
        txt2nd_insched.Value = vbNull
        txt2nd_outsched.Value = vbNull
        txt3rd_insched.Value = vbNull
        txt3rd_outsched.Value = vbNull
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        btnSave.Enabled = False
        mLogUpdated = True
        mNewLog1 = ""
        mNewLog2 = ""
        mNewLog3 = ""
        mNewLog4 = ""
        mNewLog5 = ""
        mNewLog6 = ""
        If Not IsDBNull(txt1st_insched.Value) Then mNewLog1 = CType(txt1st_insched.Value, String)
        If Not IsDBNull(txt1st_outsched.Value) Then mNewLog2 = CType(txt1st_outsched.Value, String)
        If Not IsDBNull(txt2nd_insched.Value) Then mNewLog3 = CType(txt2nd_insched.Value, String)
        If Not IsDBNull(txt2nd_outsched.Value) Then mNewLog4 = CType(txt2nd_outsched.Value, String)
        If Not IsDBNull(txt3rd_insched.Value) Then mNewLog5 = CType(txt3rd_insched.Value, String)
        If Not IsDBNull(txt3rd_outsched.Value) Then mNewLog6 = CType(txt3rd_outsched.Value, String)
        Call Close()

    End Sub

    Private Sub frmDTRAdjustments_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Trim(mNewLog1) <> "" Then txt1st_insched.Value = CType(mNewLog1, DateTime)
        If Trim(mNewLog2) <> "" Then txt1st_outsched.Value = CType(mNewLog2, DateTime)
        If Trim(mNewLog3) <> "" Then txt2nd_insched.Value = CType(mNewLog3, DateTime)
        If Trim(mNewLog4) <> "" Then txt2nd_outsched.Value = CType(mNewLog4, DateTime)
        If Trim(mNewLog5) <> "" Then txt3rd_insched.Value = CType(mNewLog5, DateTime)
        If Trim(mNewLog6) <> "" Then txt3rd_outsched.Value = CType(mNewLog6, DateTime)

        If SysParam.EditDateTimeEntry Then
            txt1st_insched.ReadOnly = False
            txt1st_outsched.ReadOnly = False
            txt2nd_insched.ReadOnly = False
            txt2nd_outsched.ReadOnly = False
            txt3rd_insched.ReadOnly = False
            txt3rd_outsched.ReadOnly = False
        End If
    End Sub

    Private Sub loadTimeLogs(lbTop As Integer, lbLeft As Integer, lbWidth As Integer)
        Dim employeeLogs As New DataTable
        With lb
            If NetOpen(employeeLogs, "select distinct employee_id,DATE_FORMAT(datetime_log,'%m/%d/%Y %H:%i')  emplogs from employee_logs " & _
                                     "where employee_id = " & mSearchID & " and " & _
                                     "datetime_log between '" & Format(dateStartWork, "yyyy-MM-dd") & "' and '" & Format(dateEndWork, "yyyy-MM-dd") & "' " & _
                                     "order by datetime_log", Cn.Connection) = True Then
                .DataSource = Nothing
                .DisplayMember = "emplogs"
                .ValueMember = "employee_id"
                .DataSource = employeeLogs
            End If
            .Top = lbTop
            .Left = lbLeft
            .Width = lbWidth
            .Visible = True
            .Focus()
        End With
    End Sub

    Private Sub lb_Click(sender As Object, e As System.EventArgs) Handles lb.Click
        'txt.Text = CType(lb.Text, String)
        txt.Value = CType(lb.Text, String)
        lb.Visible = False
        txt.Focus()
    End Sub

    Private Sub lb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb.LostFocus
        lb.Visible = False
    End Sub

    'Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call Get_ID(Me.Name)
    '    If mSearchID > 0 Then
    '        Dim dtSchedules As New DataTable
    '        If NetOpen(dtSchedules, "select * from schedules where schedule_id =" & mSearchID) = True Then
    '            If dtSchedules.Rows.Count > 0 Then
    '                Call Clear_Fields()
    '                For Each drSchedule As DataRow In dtSchedules.Rows
    '                    mSchedule_ID = mSearchID
    '                    txt1st_insched.Value = CType(drSchedule.Item("1st_insched"), TimeSpan)
    '                    txt1st_outsched.Value = CType(drSchedule.Item("1st_outsched"), TimeSpan)
    '                    If Not IsDBNull(drSchedule.Item("2nd_insched")) Then
    '                        txt2nd_insched.Value = CType(drSchedule.Item("2nd_insched"), TimeSpan)
    '                    End If
    '                    If Not IsDBNull(drSchedule.Item("2nd_outsched")) Then
    '                        txt2nd_outsched.Value = CType(drSchedule.Item("2nd_outsched"), TimeSpan)
    '                    End If
    '                    If Not IsDBNull(drSchedule.Item("3rd_insched")) Then
    '                        txt3rd_insched.Value = CType(drSchedule.Item("3rd_insched"), TimeSpan)
    '                    End If
    '                    If Not IsDBNull(drSchedule.Item("3rd_outsched")) Then
    '                        txt3rd_outsched.Value = CType(drSchedule.Item("3rd_outsched"), TimeSpan)
    '                    End If
    '                Next
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub btnIn01_Click(sender As System.Object, e As System.EventArgs) Handles btnIn01.Click
        Dim lbTop, lbLeft, lbWidth As Integer
        lbTop = txt1st_insched.Top + txt1st_insched.Height
        lbLeft = txt1st_insched.Left
        lbWidth = txt1st_insched.Width + btnIn01.Width
        Call loadTimeLogs(lbTop, lbLeft, lbWidth)
        txt = txt1st_insched
    End Sub

    Private Sub btnIn02_Click(sender As System.Object, e As System.EventArgs) Handles btnIn02.Click
        Dim lbTop, lbLeft, lbWidth As Integer
        lbTop = txt2nd_insched.Top + txt2nd_insched.Height
        lbLeft = txt2nd_insched.Left
        lbWidth = txt2nd_insched.Width + btnIn02.Width
        Call loadTimeLogs(lbTop, lbLeft, lbWidth)
        txt = txt2nd_insched
    End Sub

    Private Sub btnIn03_Click(sender As System.Object, e As System.EventArgs) Handles btnIn03.Click
        Dim lbTop, lbLeft, lbWidth As Integer
        lbTop = txt3rd_insched.Top - lb.Height
        lbLeft = txt3rd_insched.Left
        lbWidth = txt3rd_insched.Width + btnIn03.Width
        Call loadTimeLogs(lbTop, lbLeft, lbWidth)
        txt = txt3rd_insched
    End Sub

    Private Sub btnOut01_Click(sender As System.Object, e As System.EventArgs) Handles btnOut01.Click
        Dim lbTop, lbLeft, lbWidth As Integer
        lbTop = txt1st_outsched.Top + txt1st_outsched.Height
        lbLeft = txt1st_outsched.Left
        lbWidth = txt1st_outsched.Width + btnOut01.Width
        Call loadTimeLogs(lbTop, lbLeft, lbWidth)
        txt = txt1st_outsched
    End Sub

    Private Sub btnOut02_Click(sender As System.Object, e As System.EventArgs) Handles btnOut02.Click
        Dim lbTop, lbLeft, lbWidth As Integer
        lbTop = txt2nd_outsched.Top + txt2nd_outsched.Height
        lbLeft = txt2nd_outsched.Left
        lbWidth = txt2nd_outsched.Width + btnOut02.Width
        Call loadTimeLogs(lbTop, lbLeft, lbWidth)
        txt = txt2nd_outsched
    End Sub

    Private Sub btnOut03_Click(sender As System.Object, e As System.EventArgs) Handles btnOut03.Click
        Dim lbTop, lbLeft, lbWidth As Integer
        lbTop = txt3rd_outsched.Top - lb.Height
        lbLeft = txt3rd_outsched.Left
        lbWidth = txt3rd_outsched.Width + btnOut03.Width
        Call loadTimeLogs(lbTop, lbLeft, lbWidth)
        txt = txt3rd_outsched
    End Sub

    Private Sub txt1st_insched_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txt1st_insched.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                txt1st_insched.Value = vbNull
        End Select
    End Sub

    Private Sub txt1st_outsched_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txt1st_outsched.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                txt1st_outsched.Value = vbNull
        End Select
    End Sub

    Private Sub txt2nd_insched_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txt2nd_insched.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                txt2nd_insched.Value = vbNull
        End Select
    End Sub

    Private Sub txt2nd_outsched_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txt2nd_outsched.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                txt2nd_outsched.Value = vbNull
        End Select
    End Sub

    Private Sub txt3rd_insched_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txt3rd_insched.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                txt3rd_insched.Value = vbNull
        End Select
    End Sub

    Private Sub txt3rd_outsched_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txt3rd_outsched.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                txt3rd_outsched.Value = vbNull
        End Select
    End Sub
End Class