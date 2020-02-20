Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmImportDTR

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Call Close()
    End Sub

    Private Sub frmImportDTR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim mIDs As String
        'Dim mDateTime As String
        'Dim mInString As Integer
        'For Each line As String In System.IO.File.ReadAllLines("e:\1_attlog.dat")
        '    If Microsoft.VisualBasic.Left(line.ToString, 1) <> "S" And Microsoft.VisualBasic.Left(line.ToString, 1) <> "C" Then
        '        mInString = InStr(line.ToString, CChar(vbTab))
        '        mIDs = Microsoft.VisualBasic.Left(line.ToString, mInString - 1)
        '        mDateTime = Microsoft.VisualBasic.Mid(line.ToString, mInString + 1, 19)
        '        'MsgBox("Employee ID: " & mIDs & vbCrLf & "Date & Time : " & mDateTime)
        '        'DataGridView1.Rows.Add(line.Split(CChar(vbTab)))
        '    End If
        'Next
        lblIPAddress.Text = SysParam.BioIpAddress
        lblPortNo.Text = SysParam.BioPortNo
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        btnSave.Enabled = False

        Dim axCZKEM1 As New zkemkeeper.CZKEM
        Dim mTrans As MySqlTransaction
        Dim mCommand As New MySqlCommand
        Dim dtEmployees As New DataTable
        Dim mIDs As String
        Dim mDateTime As String
        Dim mInString As Integer
        Dim mLogStat As Integer

        Dim iMachineNumber As Integer 'the serial number of the device.After connecting the device ,this value will be changed.
        Dim sdwEnrollNumber As String = ""
        Dim idwVerifyMode As Integer
        Dim idwInOutMode As Integer
        Dim idwYear As Integer
        Dim idwMonth As Integer
        Dim idwDay As Integer
        Dim idwHour As Integer
        Dim idwMinute As Integer
        Dim idwSecond As Integer
        Dim idwWorkcode As Integer
        Dim idwErrorCode As Integer

        If optFile.Checked Then
            With My.Computer.FileSystem
                If Trim(lblPath.Text) <> "" Then
                    If Not .FileExists(lblPath.Text) Then
                        MsgBox("Invalid file format.", MsgBoxStyle.Exclamation)
                        btnSave.Enabled = True
                        Exit Sub
                    End If
                Else
                    MsgBox("Invalid file format.", MsgBoxStyle.Exclamation)
                    btnSave.Enabled = True
                    Exit Sub
                End If
            End With
        Else
            If Not HasAttLog(SysParam.BioIpAddress, SysParam.BioPortNo, axCZKEM1, iMachineNumber) Then
                axCZKEM1.GetLastError(idwErrorCode)
                If idwErrorCode <> 0 Then
                    MsgBox("Reading data from terminal failed,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
                Else
                    MsgBox("No data from terminal!", MsgBoxStyle.Exclamation, "Error")
                End If
            End If
        End If

        mTrans = Cn.Connection.BeginTransaction

        Try
            mCommand.Transaction = mTrans
            mCommand.Connection = Cn.Connection
            If optFile.Checked Then
                For Each line As String In System.IO.File.ReadAllLines(lblPath.Text)
                    'MsgBox(line.ToArray.Count)
                    If Microsoft.VisualBasic.Left(line.ToString, 1) <> "S" And Microsoft.VisualBasic.Left(line.ToString, 1) <> "C" Then
                        mInString = InStr(line.ToString, CChar(vbTab))
                        mIDs = Microsoft.VisualBasic.Left(line.ToString, mInString - 1)
                        mDateTime = Microsoft.VisualBasic.Mid(line.ToString, mInString + 1, 19)
                        'If CType(Format(dtpDateFrom.Value, "MM/dd/yyyy"), Date) <= CType(mDateTime, Date) Then
                        If dtpDateFrom.Value.Date <= CType(mDateTime, Date) Then
                            mLogStat = CType(Microsoft.VisualBasic.Mid(line.ToString, mInString + 23, 1), Integer)

                            'If chk.Checked = True Then
                            '    If mLogStat = 1 Then
                            '        mLogStat = 1
                            '    Else
                            '        mLogStat = 0
                            '    End If
                            'Else
                            '    If mLogStat <= 1 Or mLogStat = 3 Then
                            '        mLogStat = 1
                            '    Else
                            '        mLogStat = 0
                            '    End If
                            'End If

                            If chk.Checked = True Then
                                If mLogStat = 1 Then
                                    mLogStat = 1
                                Else
                                    mLogStat = 0
                                End If
                            Else
                                If mLogStat = 0 Then
                                    mLogStat = 1
                                Else
                                    mLogStat = 0
                                End If
                            End If

                            mCommand.CommandText = "insert into employee_logs(employee_bio_id,datetime_log,log_status) values ('" & CType(Trim(mIDs), String) & "'," & _
                                                           "'" & Format(CType(mDateTime, Date), "yyyy-MM-dd HH:mm:ss") & "'," & mLogStat & ") " & _
                                                           "on duplicate key update log_status= " & mLogStat & ""
                            mCommand.ExecuteNonQuery()

                        End If
                    End If
                Next
            Else

                While axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, sdwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode)
                    'iGLCount += 1
                    'lvItem = lvLogs.Items.Add(iGLCount.ToString())
                    'lvItem.SubItems.Add(sdwEnrollNumber)
                    'lvItem.SubItems.Add(idwVerifyMode.ToString())
                    'lvItem.SubItems.Add(idwInOutMode.ToString())
                    'lvItem.SubItems.Add(idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString())
                    'lvItem.SubItems.Add(idwWorkcode.ToString())

                    mIDs = sdwEnrollNumber
                    mDateTime = idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString()
                    If dtpDateFrom.Value.Date <= CType(mDateTime, Date) Then
                        mLogStat = CType(idwInOutMode.ToString(), Integer)

                        If chk.Checked = True Then
                            If mLogStat = 1 Then
                                mLogStat = 1
                            Else
                                mLogStat = 0
                            End If
                        Else
                            If mLogStat = 0 Then
                                mLogStat = 1
                            Else
                                mLogStat = 0
                            End If
                        End If

                        mCommand.CommandText = "insert into employee_logs(employee_bio_id,datetime_log,log_status) values ('" & CType(Trim(sdwEnrollNumber), String) & "'," & _
                                                               "'" & Format(CType(mDateTime, Date), "yyyy-MM-dd HH:mm:ss") & "'," & mLogStat & ") " & _
                                                               "on duplicate key update log_status= " & mLogStat & ""
                        mCommand.ExecuteNonQuery()
                    End If
                End While

            End If

            mCommand.CommandText = "update employee_logs set employee_id = (select employee_id from employees where employee_bio_id = employee_logs.employee_bio_id);"
            mCommand.ExecuteNonQuery()

            mTrans.Commit()
            Call Create_DTR()
            If NetOpen(dtEmployees, "select a.employee_id,b.department_id from " & _
                                "(select employee_id from employee_dtrs where work_date BETWEEN '" & Format(dtpDateFrom.Value.Date, "yyyy-MM-dd") & "' AND '" & Format(Now.Date, "yyyy-MM-dd") & "' group by employee_id) a " & _
                                "left outer join employees b on a.employee_id=b.employee_id") Then
                If dtEmployees.Rows.Count > 0 Then
                    For Each mEmpIDs As DataRow In dtEmployees.Rows
                        'MsgBox(dtpDateFrom.Value & "  -   " & Now.Date)                        
                        ComputeDTR(CType(mEmpIDs.Item("employee_id"), Integer), dtpDateFrom.Value.Date, Now.Date, CType(mEmpIDs.Item("department_id"), Integer))
                    Next
                End If
            End If
            MsgBox("Upload complete!", MsgBoxStyle.Information)
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Importing DTR Error!")
            If Not (mTrans Is Nothing) Then
                mTrans.Rollback()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Importing DTR Error!")
            If Not (mTrans Is Nothing) Then
                mTrans.Rollback()
            End If

        Finally
            Try
                mCommand.Dispose()
                mTrans.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Importing DTR Error!")
            Finally
                btnSave.Enabled = True
            End Try
        End Try
    End Sub

    Private Sub Create_DTR()

        Dim mTrans As MySqlTransaction
        Dim mCommand As New MySqlCommand
        Dim mDateFrom As Date
        Dim mCurrDate As Date
        Dim previousLog As DateTime
        Dim mEmployee_IDs As New DataTable
        Dim employee_logs As New DataTable
        Dim mHolidays As New DataTable
        Dim mFirstIN As Boolean = True
        Dim mColNum As Integer = 1
        Dim minuteDiff As Double

        mTrans = Cn.Connection.BeginTransaction

        Try

            mDateFrom = dtpDateFrom.Value.Date

            mCommand.Transaction = mTrans
            mCommand.Connection = Cn.Connection

            'delete existing dtrs for the selected period
            mCommand.CommandText = "delete from employee_dtrs where work_date >= '" & Format(mDateFrom, "yyyy-MM-dd") & "'"
            mCommand.ExecuteNonQuery()
            mCommand.CommandText = "delete from schedules_assignment where work_date >= '" & Format(mDateFrom, "yyyy-MM-dd") & "' and schedule_id=0"
            mCommand.ExecuteNonQuery()
            mCommand.CommandText = "update schedules_assignment set department_id=(select department_id from employees where employee_id=schedules_assignment.employee_id) " & _
                                                "where work_date >= '" & Format(mDateFrom, "yyyy-MM-dd") & "'"
            mCommand.ExecuteNonQuery()
            'create new dtrs       

            NetOpen(mEmployee_IDs, "select a.*,b.schedule_id,b.department_id from (select employee_id from employee_logs where employee_id in (select employee_id from employees) and " & _
                                   "date(datetime_log) >='" & Format(mDateFrom, "yyyy-MM-dd") & "'group by employee_id) a " & _
                                   "left outer join employees b on a.employee_id=b.employee_id ", Cn.Connection)

            For Each mEmpID As DataRow In mEmployee_IDs.Rows
                NetOpen(employee_logs, "select * from employee_logs where employee_id = " & CType(mEmpID.Item("employee_id"), String) & " and " & _
                                    "date(datetime_log) >= '" & Format(mDateFrom, "yyyy-MM-dd") & "' order by datetime_log", Cn.Connection)

                NetOpen(mHolidays, "select b.* from holidays_line a " & _
                                    "left outer join holidays_header b on a.holiday_id=b.holiday_id " & _
                                    "where b.work_date >= '" & Format(mDateFrom, "yyyy-MM-dd") & "' and a.department_id=" & CType(mEmpID.Item("department_id"), Integer))
                For Each mHldys As DataRow In mHolidays.Rows
                    mCommand.CommandText = "insert ignore into schedules_assignment (employee_id,schedule_id,work_date,department_id) values (" & _
                                        "" & CType(mEmpID.Item("employee_id"), String) & "," & CType(mEmpID.Item("schedule_id"), String) & ",'" & Format(CType(mHldys.Item("work_date"), Date), "yyyy-MM-dd") & "'," & CType(mEmpID.Item("department_id"), Integer) & ")"
                    mCommand.ExecuteNonQuery()
                Next

                mFirstIN = True
                For Each mLog As DataRow In employee_logs.Rows
                    minuteDiff = 0
                    If Not mFirstIN Then
                        If mCurrDate <> CType(mLog.Item("datetime_log"), Date).Date Then
                            If CType(mLog.Item("log_status"), Integer) = 1 Then
                                minuteDiff = CType(DateDiff(DateInterval.Minute, previousLog, CType(mLog.Item("datetime_log"), DateTime)), Double)
                                
                                'Create a new DTR entry for time logs with more than the specified number of hours difference.
                                If minuteDiff > SysParam.NextDayMinuteDifference Then
                                    mColNum = 1
                                    mCurrDate = CType(mLog.Item("datetime_log"), Date).Date
                                    mCommand.CommandText = "insert ignore into schedules_assignment (employee_id,schedule_id,work_date,department_id) values (" & _
                                                "" & CType(mEmpID.Item("employee_id"), String) & "," & CType(mEmpID.Item("schedule_id"), String) & ",'" & Format(mCurrDate, "yyyy-MM-dd") & "'," & CType(mEmpID.Item("department_id"), Integer) & ")"
                                    mCommand.ExecuteNonQuery()
                                    mCommand.CommandText = "insert into employee_dtrs (employee_id,work_date,log1) values " & _
                                                "(" & CType(mEmpID.Item("employee_id"), String) & ",'" & Format(mCurrDate, "yyyy-MM-dd") & "'," & _
                                                "'" & Format(CType(mLog.Item("datetime_log"), Date), "yyyy-MM-dd HH:mm:ss") & "')"
                                    mCommand.ExecuteNonQuery()
                                    mColNum = mColNum + 1
                                Else
                                    If mColNum = 3 Or mColNum = 5 Then
                                        mCommand.CommandText = "update employee_dtrs set log" & mColNum & "='" & Format(CType(mLog.Item("datetime_log"), Date), "yyyy-MM-dd HH:mm:ss") & "' " & _
                                                    "where employee_id=" & CType(mEmpID.Item("employee_id"), String) & " and work_date='" & Format(mCurrDate, "yyyy-MM-dd") & "'"
                                        mCommand.ExecuteNonQuery()
                                        mColNum = mColNum + 1
                                    Else
                                        If mColNum + 1 < 6 Then
                                            mCommand.CommandText = "update employee_dtrs set log" & mColNum + 1 & "='" & Format(CType(mLog.Item("datetime_log"), Date), "yyyy-MM-dd HH:mm:ss") & "' " & _
                                                    "where employee_id=" & CType(mEmpID.Item("employee_id"), String) & " and work_date='" & Format(mCurrDate, "yyyy-MM-dd") & "'"
                                            mCommand.ExecuteNonQuery()
                                            mColNum = mColNum + 2
                                        End If
                                    End If
                                End If
                            Else
                                If mColNum = 2 Or mColNum = 4 Or mColNum = 6 Then
                                    mCommand.CommandText = "update employee_dtrs set log" & mColNum & "='" & Format(CType(mLog.Item("datetime_log"), Date), "yyyy-MM-dd HH:mm:ss") & "' " & _
                                                    "where employee_id=" & CType(mEmpID.Item("employee_id"), String) & " and work_date='" & Format(mCurrDate, "yyyy-MM-dd") & "'"
                                    mCommand.ExecuteNonQuery()
                                    mColNum = mColNum + 1
                                End If
                            End If
                        Else
                            If CType(mLog.Item("log_status"), Integer) = 1 Then
                                If mColNum = 3 Or mColNum = 5 Then
                                    mCommand.CommandText = "update employee_dtrs set log" & mColNum & "='" & Format(CType(mLog.Item("datetime_log"), Date), "yyyy-MM-dd HH:mm:ss") & "' " & _
                                                "where employee_id=" & CType(mEmpID.Item("employee_id"), String) & " and work_date='" & Format(mCurrDate, "yyyy-MM-dd") & "'"
                                    mCommand.ExecuteNonQuery()
                                    mColNum = mColNum + 1
                                Else
                                    If mColNum + 1 < 6 Then
                                        mCommand.CommandText = "update employee_dtrs set log" & mColNum + 1 & "='" & Format(CType(mLog.Item("datetime_log"), Date), "yyyy-MM-dd HH:mm:ss") & "' " & _
                                                "where employee_id=" & CType(mEmpID.Item("employee_id"), String) & " and work_date='" & Format(mCurrDate, "yyyy-MM-dd") & "'"
                                        mCommand.ExecuteNonQuery()
                                        mColNum = mColNum + 2
                                    End If
                                End If
                            Else
                                If mColNum = 2 Or mColNum = 4 Or mColNum = 6 Then
                                    mCommand.CommandText = "update employee_dtrs set log" & mColNum & "='" & Format(CType(mLog.Item("datetime_log"), Date), "yyyy-MM-dd HH:mm:ss") & "' " & _
                                                "where employee_id=" & CType(mEmpID.Item("employee_id"), String) & " and work_date='" & Format(mCurrDate, "yyyy-MM-dd") & "'"
                                    mCommand.ExecuteNonQuery()
                                    mColNum = mColNum + 1
                                Else
                                    If mColNum < 6 Then
                                        mCommand.CommandText = "update employee_dtrs set log" & mColNum + 1 & "='" & Format(CType(mLog.Item("datetime_log"), Date), "yyyy-MM-dd HH:mm:ss") & "' " & _
                                                "where employee_id=" & CType(mEmpID.Item("employee_id"), String) & " and work_date='" & Format(mCurrDate, "yyyy-MM-dd") & "'"
                                        mCommand.ExecuteNonQuery()
                                        mColNum = mColNum + 2
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If mFirstIN Then
                        If CType(mLog.Item("log_status"), Integer) = 1 Then
                            mFirstIN = False
                            mColNum = 2
                            mCurrDate = CType(mLog.Item("datetime_log"), Date).Date
                            mCommand.CommandText = "insert ignore into schedules_assignment (employee_id,schedule_id,work_date,department_id) values (" & _
                                            "" & CType(mEmpID.Item("employee_id"), String) & "," & CType(mEmpID.Item("schedule_id"), String) & ",'" & Format(mCurrDate, "yyyy-MM-dd") & "'," & CType(mEmpID.Item("department_id"), Integer) & ")"
                            mCommand.ExecuteNonQuery()
                            mCommand.CommandText = "insert into employee_dtrs (employee_id,work_date,log1) values " & _
                                        "(" & CType(mEmpID.Item("employee_id"), String) & ",'" & Format(mCurrDate, "yyyy-MM-dd") & "','" & Format(CType(mLog.Item("datetime_log"), Date), "yyyy-MM-dd HH:mm:ss") & "')"
                            mCommand.ExecuteNonQuery()
                        End If
                    End If
                    previousLog = CType(mLog.Item("datetime_log"), DateTime)
                Next
            Next
            mTrans.Commit()
        Catch ex As MySqlException
            If Not (mTrans Is Nothing) Then
                mTrans.Rollback()
            End If
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Creating DTR Error!")
        Catch ex As Exception
            If Not (mTrans Is Nothing) Then
                mTrans.Rollback()
            End If
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Creating DTR Error!")
            MsgBox(ex.Data)
        Finally
            Try
                mCommand.Dispose()
                mTrans.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Creating DTR Error!")
            Finally
                btnNew.Enabled = True
            End Try
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim dtEmployees As New DataTable
        Call Create_DTR()
        If NetOpen(dtEmployees, "select a.employee_id,b.department_id from " & _
                            "(select x1.* from (select employee_id from employee_dtrs where work_date BETWEEN '" & Format(dtpDateFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(Now.Date, "yyyy-MM-dd") & "' " & _
                            "union all " & _
                            "select employee_id from employee_dtr_adjustments where work_date BETWEEN '" & Format(dtpDateFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(Now.Date, "yyyy-MM-dd") & "') x1 group by x1.employee_id) a " & _
                            "left outer join employees b on a.employee_id=b.employee_id") Then
            If dtEmployees.Rows.Count > 0 Then
                For Each mEmpIDs As DataRow In dtEmployees.Rows
                    'MsgBox(dtpDateFrom.Value & "  -   " & Now.Date)
                    ComputeDTR(CType(mEmpIDs.Item("employee_id"), Integer), dtpDateFrom.Value, Now.Date, CType(mEmpIDs.Item("department_id"), Integer))
                Next
            End If
        End If
        MsgBox("Process complete!", MsgBoxStyle.Information)
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        If ofdLogs.ShowDialog() = DialogResult.OK Then
            lblPath.Text = ofdLogs.FileName
        End If
    End Sub

End Class