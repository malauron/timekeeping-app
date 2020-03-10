Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data.MySqlClient

Module modRoutines

    Private Enum ScheduleStatus
        Computed = 0
        LogNotComputed = 1
        LogInvalid = 2
        NoSchedule = 3
        Undefined = 4
    End Enum

    Public Sub GetSysParam()
        Dim mSysParam As New DataTable
        If NetOpen(mSysParam, "select * from system_parameters", Cn.Connection) = True Then
            If mSysParam.Rows.Count > 0 Then
                For Each mRow As DataRow In mSysParam.Rows

                    SysParam.GracePeriod = CType(mRow.Item("gracePeriod"), Integer)
                    SysParam.RoundMinutes = CType(mRow.Item("roundMinutes"), Integer)
                    SysParam.DTRReport = CType(mRow.Item("dtr_report"), String)
                    SysParam.AddEMployee = CType(mRow.Item("add_employee"), Integer)
                    SysParam.CanImportEmployees = CType(mRow.Item("autoImportEmployees"), Boolean)
                    SysParam.CanImportUsers = CType(mRow.Item("autoImportUsers"), Boolean)
                    SysParam.CanImportPayrollPeriod = CType(mRow.Item("autoImportPayrollPeriods"), Boolean)
                    SysParam.PayrollDatabase = CType(mRow.Item("payroll_db"), String)
                    SysParam.EmployeeBioIdPayrollMap = CType(mRow.Item("employee_bio_id_payroll_map"), String)
                    SysParam.BioIpAddress = CType(mRow.Item("bio_ipaddress"), String)
                    SysParam.BioPortNo = CType(mRow.Item("bio_portno"), String)
                    SysParam.FlexiBreakHours = CType(mRow.Item("flexibreak_hrs"), Double)
                    SysParam.NextDayMinuteDifference = CType(mRow.Item("nextDayMinDiff"), Double)
                    SysParam.EditDTREntry = CType(mRow.Item("editDTR"), Boolean)
                    SysParam.ExportDTRSummary = CType(mRow.Item("exportDTR"), Boolean)

                Next
            End If
        End If
    End Sub

    Public Sub ImportUsers()

        If Not SysParam.CanImportUsers Then Exit Sub

        Dim mTrans As MySqlTransaction
        Dim mCommand As New MySqlCommand
        mTrans = Cn.Connection.BeginTransaction
        Try
            mCommand.Transaction = mTrans
            mCommand.Connection = Cn.Connection

            If SysParam.CanImportUsers Then
                mCommand.CommandText = "INSERT INTO users (user_id,fullname,username,user_password) " & _
                                        "SELECT user_id,fullname,username,PASSWORD FROM " & SysParam.PayrollDatabase & ".users ON DUPLICATE KEY UPDATE " & _
                                        "fullname=VALUES(fullname),username=VALUES(username),user_password=VALUES(user_password);"
                mCommand.ExecuteNonQuery()
            End If
            mTrans.Commit()
        Catch ex As MySqlException
            If Not (mTrans Is Nothing) Then
                mTrans.Rollback()
            End If
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Catch ex As Exception
            If Not (mTrans Is Nothing) Then
                mTrans.Rollback()
            End If
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Try
                mCommand.Dispose()
                mTrans.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Finally

            End Try

        End Try
    End Sub

    Public Sub ImportEmployees()

        If Not SysParam.CanImportEmployees Then Exit Sub

        Dim mTrans As MySqlTransaction
        Dim mCommand As New MySqlCommand
        mTrans = Cn.Connection.BeginTransaction
        Try
            mCommand.Transaction = mTrans
            mCommand.Connection = Cn.Connection

            If SysParam.CanImportEmployees Then
                mCommand.CommandText = "INSERT INTO departments (department_id,description) " & _
                                       "SELECT costcentercode, costcenter FROM " & SysParam.PayrollDatabase & ".costcenter ON DUPLICATE KEY UPDATE " & _
                                       "description=VALUES(description);"
                mCommand.ExecuteNonQuery()
                mCommand.CommandText = "INSERT INTO employees (employee_id,employee_bio_id,lastname,firstname,middlename,department_id,pay_type)" & _
                                       "SELECT employeecode,trim(" & SysParam.EmployeeBioIdPayrollMap & "),lastname,firstname,middlename,costcentercode, " & _
                                       "IF(ratetypecode=4,'M','D') " & _
                                       "FROM " & SysParam.PayrollDatabase & ".employee ON DUPLICATE KEY UPDATE " & _
                                       "employee_bio_id=VALUES(employee_bio_id), lastname=VALUES(lastname), firstname=VALUES(firstname), " & _
                                       "middlename=VALUES(middlename), department_id=VALUES(department_id), pay_type=VALUES(pay_type);"
                mCommand.ExecuteNonQuery()
            End If
            mTrans.Commit()
        Catch ex As MySqlException
            If Not (mTrans Is Nothing) Then
                mTrans.Rollback()
            End If
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Catch ex As Exception
            If Not (mTrans Is Nothing) Then
                mTrans.Rollback()
            End If
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Try
                mCommand.Dispose()
                mTrans.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Finally

            End Try

        End Try
    End Sub

    Public Sub ImportPayrollPeriods()

        If Not SysParam.CanImportPayrollPeriod Then Exit Sub

        Dim mTrans As MySqlTransaction
        Dim mCommand As New MySqlCommand
        mTrans = Cn.Connection.BeginTransaction
        Try
            mCommand.Transaction = mTrans
            mCommand.Connection = Cn.Connection

            If SysParam.CanImportPayrollPeriod Then
                mCommand.CommandText = "INSERT INTO cutoff_periods (cutoff_period_id,start_date,end_date) " & _
                                       "SELECT percode,wrkdatefrom,wrkdateto FROM " & SysParam.PayrollDatabase & ".payrollperiod ON DUPLICATE KEY UPDATE " & _
                                       "start_date = VALUES(start_date), end_date = VALUES(end_date);"
                mCommand.ExecuteNonQuery()
            End If
            mTrans.Commit()
        Catch ex As MySqlException
            If Not (mTrans Is Nothing) Then
                mTrans.Rollback()
            End If
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Catch ex As Exception
            If Not (mTrans Is Nothing) Then
                mTrans.Rollback()
            End If
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Try
                mCommand.Dispose()
                mTrans.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Finally

            End Try

        End Try
    End Sub

    Public Sub populateComboBox(ByRef cbo As ComboBox, ByVal mQry As String, ByVal mValueMember As String, ByVal mDisplayMember As String)
        Dim mData As New DataTable
        cbo.DataSource = Nothing
        If NetOpen(mData, mQry, Cn.Connection) = True Then
            cbo.DisplayMember = mDisplayMember
            cbo.ValueMember = mValueMember
            cbo.DataSource = mData
        End If
    End Sub

    Public Function NetOpen(ByRef vData As DataTable, ByVal vSQL As String, Optional ByVal mConn As MySqlConnection = Nothing) As Boolean

        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter

        NetOpen = True

        vData = Nothing
        vData = New DataTable

        Try
            If IsNothing(mConn) Then
                myCommand.Connection = Cn.Connection
            Else
                myCommand.Connection = mConn
            End If
            myCommand.CommandText = vSQL
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(vData)
            myCommand.Dispose()
            myAdapter.Dispose()
        Catch myError As MySqlException
            MsgBox("There was an error in executing your query: " & myError.Message)
            Return False
        End Try

    End Function

    Public Sub NetRead(ByRef vReader As MySqlDataReader, ByVal vSQL As String, Optional ByVal mConn As MySqlConnection = Nothing)
        Dim myCommand As New MySqlCommand
        Try
            If IsNothing(mConn) Then
                myCommand.Connection = Cn.Connection
            Else
                myCommand.Connection = mConn
            End If

            myCommand.CommandText = vSQL
            vReader = myCommand.ExecuteReader
            myCommand.Dispose()
        Catch myError As MySqlException
            MsgBox("There was an error in executing your query: " & myError.Message)
        End Try

    End Sub

    Public Function ConSwap(ByVal mString As String) As String
        If IsDBNull(mString) Then mString = ""
        mString = Replace(mString, "'", "''")
        mString = Replace(mString, "\", "")
        mString = Replace(mString, "?", "")
        mString = Replace(mString, ";", "")
        mString = Replace(mString, "/", "")
        mString = Replace(mString, ":", "")
        mString = Replace(mString, "|", "")
        mString = Replace(mString, "}", "")
        mString = Replace(mString, "{", "")
        mString = Replace(mString, "!", "")
        mString = Replace(mString, ">", "")
        mString = Replace(mString, "<", "")
        mString = Replace(mString, "^", "")
        mString = Replace(mString, "!", "")
        mString = Replace(mString, ",", "")
        ConSwap = mString
    End Function

    Public Function IsReportExist(ByVal mReportName As String) As Boolean
        Dim mExists As Boolean = False

        With My.Computer.FileSystem
            If Not .DirectoryExists(Application.StartupPath & "\Reports") Then
                mExists = False
                MsgBox("Invalid report directory.", MsgBoxStyle.Exclamation)
            Else
                If Not .FileExists(Application.StartupPath & "\Reports\" & mReportName) Then
                    mExists = False
                    MsgBox("Invalid report directory.", MsgBoxStyle.Exclamation)
                Else
                    mExists = True
                End If
            End If
        End With
        Return mExists
    End Function

    Public Sub SetDBLogonForReport(ByRef mReportDoc As ReportDocument, ByVal myConnectionInfo As ConnectionInfo)
        Dim myTables As Tables = mReportDoc.Database.Tables
        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            myTableLogonInfo.ConnectionInfo = myConnectionInfo
            myTable.ApplyLogOnInfo(myTableLogonInfo)
        Next
    End Sub

    Public Sub SetParam(ByRef mReportDoc As ReportDocument, ByVal mParamValue As String, ByVal mParamField As String)
        Dim currentParameterValues As ParameterValues = New ParameterValues()
        Dim myParameterDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue()
        myParameterDiscreteValue.Value = mParamValue
        currentParameterValues.Add(myParameterDiscreteValue)
        Dim myParameterFieldDefinitions As ParameterFieldDefinitions = mReportDoc.DataDefinition.ParameterFields
        Dim myParameterFieldDefinition As ParameterFieldDefinition = myParameterFieldDefinitions(mParamField)
        myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues)
    End Sub

    Public Function Get_ID(mFormName As String) As Integer
        mSearchFormName = mFormName
        mSearchID = 0
        Dim mForm As Form
        mForm = New frmSearch
        mForm.ShowDialog()
        mForm.Dispose()
        Return mSearchID
    End Function

    Public Sub SearchC1Combo(ByRef mCBO As C1.Win.C1List.C1Combo, ByRef e As System.Windows.Forms.KeyPressEventArgs)
        Dim mCurrentText As String = ""
        Dim mTypedText As String = ""
        Dim mSelStart As Integer
        Dim mSelLength As Integer
        Dim mFoundIndex As Integer
        Dim mPrevIndex As Integer

        mPrevIndex = mCBO.SelectedIndex
        mSelStart = mCBO.SelectionStart
        mSelLength = mCBO.SelectionLength

        mCurrentText = Mid(mCBO.Text, 1, mSelStart)
        If e.KeyChar = Convert.ToChar(Keys.Back) Then
            If mSelStart > 0 Then
                mTypedText = mCurrentText.Remove(mSelStart - 1, 1)
                mSelStart = mSelStart - 2
            Else
                mSelStart = -1
            End If
        Else
            mTypedText = mCurrentText.Insert(mSelStart, e.KeyChar)
        End If

        If Trim(mTypedText) = "" Then
            If e.KeyChar = Convert.ToChar(Keys.Space) Then
                mSelStart = -1
            End If
            mFoundIndex = mPrevIndex
        Else
            mFoundIndex = mCBO.FindString(mTypedText)
        End If

        If mFoundIndex >= 0 Then
            mCBO.SelectedIndex = mFoundIndex
            mCBO.Select(mSelStart + 1, mCBO.Text.Length)
        End If
        e.Handled = True
    End Sub

    Public Sub ComputeDTR(ByVal mEmployeeID As Integer, ByVal mDateFrom As Date, ByVal mDateUntil As Date, Optional ByVal mDeptID As Integer = 0)

        Dim mTrans As MySqlTransaction
        Dim mCommand As New MySqlCommand
        'Dim mDateFrom As Date
        'Dim mDateUntil As Date
        Dim mWorkDate As Date
        Dim dtEmployeeDTR As New DataTable
        Dim mLate As Double
        Dim mUndertime As Double
        Dim mRegHrs As Double = 8
        Dim mGracePeriod As Double
        Dim mRoundMinutes As Double
        Dim mDaysWork As Double
        Dim mDaysAbsent As Double
        Dim mHrsWrkd As Double
        Dim mRegHoliday As Double
        Dim mSpcHoliday As Double
        Dim mSchedStatus As ScheduleStatus
        Dim mWasAbsent As Boolean = False

        mGracePeriod = SysParam.GracePeriod
        mRoundMinutes = SysParam.RoundMinutes

        mTrans = Cn.Connection.BeginTransaction
        Try
            'mDateFrom = CType(Mid(txtCutoffPeriod.Text, 1, 10), Date)
            'mDateUntil = CType(Mid(txtCutoffPeriod.Text, 14, 10), Date)
            mWorkDate = mDateFrom
            mCommand.Transaction = mTrans
            mCommand.Connection = Cn.Connection
            If mDeptID > 0 Then
                Do While mWorkDate <= mDateUntil
                    mCommand.CommandText = "insert ignore into schedules_assignment(employee_id,schedule_id,work_date,department_id) values (" & _
                                        "" & mEmployeeID & ",0," & _
                                        "'" & Format(mWorkDate, "yyyy-MM-dd") & "'," & mDeptID & ")"
                    mCommand.ExecuteNonQuery()
                    mWorkDate = DateAdd(DateInterval.Day, 1, mWorkDate)
                Loop
            End If
            mCommand.CommandText = "delete from dtr_summary where  work_date BETWEEN '" & Format(mDateFrom, "yyyy-MM-dd") & "' AND '" & Format(mDateUntil, "yyyy-MM-dd") & "' AND employee_id=" & mEmployeeID & ""
            mCommand.ExecuteNonQuery()
            mCommand.CommandText = "update schedules_assignment set department_id=" & mDeptID & " " & _
                                                "where employee_id=" & mEmployeeID & " and " & _
                                                "work_date >= '" & Format(mDateFrom, "yyyy-MM-dd") & "'"
            mCommand.ExecuteNonQuery()
            If NetOpen(dtEmployeeDTR, "SELECT a.*, " & _
                 "STR_TO_DATE(IF(ISNULL(e.employee_id),b.log1,e.log1),'%Y-%m-%d %H:%i:%S') log1,STR_TO_DATE(IF(ISNULL(e.employee_id),b.log2,e.log2),'%Y-%m-%d %H:%i:%S') `log2`, " & _
                 "STR_TO_DATE(IF(ISNULL(e.employee_id),b.log3,e.log3),'%Y-%m-%d %H:%i:%S') log3,STR_TO_DATE(IF(ISNULL(e.employee_id),b.log4,e.log4),'%Y-%m-%d %H:%i:%S') log4,  " & _
                 "STR_TO_DATE(IF(ISNULL(e.employee_id),b.log5,e.log5),'%Y-%m-%d %H:%i:%S') log5,STR_TO_DATE(IF(ISNULL(e.employee_id),b.log6,e.log6),'%Y-%m-%d %H:%i:%S') log6,  " & _
                 "c.1st_insched sched1,c.1st_outsched sched2,c.2nd_insched sched3,c.2nd_outsched sched4,c.3rd_insched sched5,c.3rd_outsched sched6," & _
                 "IF(ISNULL(c.flexibreak),0,c.flexibreak) flexibreak,f.holiday_type,g.pay_type " & _
                    "FROM (SELECT * FROM schedules_assignment WHERE work_date BETWEEN '" & Format(mDateFrom, "yyyy-MM-dd") & "' AND '" & Format(mDateUntil, "yyyy-MM-dd") & "' AND employee_id=" & mEmployeeID & ") a " & _
                    "LEFT OUTER JOIN (SELECT * FROM employee_dtrs WHERE work_date BETWEEN '" & Format(mDateFrom, "yyyy-MM-dd") & "' AND '" & Format(mDateUntil, "yyyy-MM-dd") & "' AND employee_id=" & mEmployeeID & ") b ON a.employee_id=b.employee_id AND a.work_date=b.work_date " & _
                    "LEFT OUTER JOIN schedules c ON a.schedule_id=c.schedule_id " & _
                    "LEFT OUTER JOIN (SELECT * FROM employee_dtr_adjustments WHERE work_date BETWEEN '" & Format(mDateFrom, "yyyy-MM-dd") & "' AND '" & Format(mDateUntil, "yyyy-MM-dd") & "' AND employee_id=" & mEmployeeID & ") e ON a.employee_id=e.employee_id AND a.work_date=e.work_date " & _
                    "LEFT OUTER JOIN (SELECT employee_id,pay_type from employees where employee_id=" & mEmployeeID & ") g on a.employee_id=g.employee_id " & _
                    "LEFT OUTER JOIN (select b.* from holidays_line a " & _
                    "                 left outer join holidays_header b on a.holiday_id=b.holiday_id " & _
                    "                 where a.department_id=(select department_id from employees where employee_id=" & mEmployeeID & ")) f on a.work_date=f.work_date " & _
                    "ORDER BY a.work_date") Then

                '"LEFT OUTER JOIN (SELECT pay_type from employees where employee_id=" & mEmployeeID & ") g on a.employee_id=g.employee_id " & _

                If dtEmployeeDTR.Rows.Count > 0 Then
                    For Each mDTR As DataRow In dtEmployeeDTR.Rows
                        mLate = 0
                        mUndertime = 0
                        mDaysAbsent = 0
                        mDaysWork = 0
                        mHrsWrkd = 0
                        mRegHoliday = 0
                        mSpcHoliday = 0
                        mSchedStatus = ScheduleStatus.Undefined
                        If CType(mDTR.Item("flexibreak"), Integer) = 0 Then

                            computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched1"), mDTR.Item("sched2"), mDTR.Item("log1"), mDTR.Item("log2"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                            If mSchedStatus = ScheduleStatus.Computed Then
                                mDaysWork = 1
                                mHrsWrkd = mRegHrs
                                computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched3"), mDTR.Item("sched4"), mDTR.Item("log3"), mDTR.Item("log4"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                If mSchedStatus = ScheduleStatus.Computed Then
                                    computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched5"), mDTR.Item("sched6"), mDTR.Item("log5"), mDTR.Item("log6"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                    If mSchedStatus = ScheduleStatus.LogInvalid Or mSchedStatus = ScheduleStatus.LogNotComputed Then
                                        computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched5"), mDTR.Item("sched6"), mUndertime)
                                    End If
                                ElseIf mSchedStatus = ScheduleStatus.LogNotComputed Then
                                    computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched3"), mDTR.Item("sched4"), mUndertime)
                                    computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched5"), mDTR.Item("sched6"), mDTR.Item("log3"), mDTR.Item("log4"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                    If mSchedStatus = ScheduleStatus.LogNotComputed Then
                                        computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched5"), mDTR.Item("sched6"), mDTR.Item("log5"), mDTR.Item("log6"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                        If mSchedStatus = ScheduleStatus.LogInvalid Or mSchedStatus = ScheduleStatus.LogNotComputed Then
                                            computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched5"), mDTR.Item("sched6"), mUndertime)
                                        End If
                                    End If
                                ElseIf mSchedStatus = ScheduleStatus.LogInvalid Then
                                    computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched3"), mDTR.Item("sched4"), mUndertime)
                                    computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched5"), mDTR.Item("sched6"), mDTR.Item("log5"), mDTR.Item("log6"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                    If mSchedStatus = ScheduleStatus.LogInvalid Or mSchedStatus = ScheduleStatus.LogNotComputed Then
                                        computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched5"), mDTR.Item("sched6"), mUndertime)
                                    End If
                                End If
                            ElseIf mSchedStatus = ScheduleStatus.LogNotComputed Then
                                computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched3"), mDTR.Item("sched4"), mDTR.Item("log1"), mDTR.Item("log2"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                If mSchedStatus = ScheduleStatus.Computed Then
                                    mDaysWork = 1
                                    mHrsWrkd = mRegHrs
                                    computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched2"), mLate)
                                    computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched5"), mDTR.Item("sched6"), mDTR.Item("log3"), mDTR.Item("log4"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                    If mSchedStatus = ScheduleStatus.LogNotComputed Or mSchedStatus = ScheduleStatus.LogInvalid Then
                                        computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched5"), mDTR.Item("sched6"), mDTR.Item("log5"), mDTR.Item("log6"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                        If mSchedStatus = ScheduleStatus.LogInvalid Or mSchedStatus = ScheduleStatus.LogNotComputed Then
                                            computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched5"), mDTR.Item("sched6"), mUndertime)
                                        End If
                                    End If
                                ElseIf mSchedStatus = ScheduleStatus.LogNotComputed Then
                                    computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched5"), mDTR.Item("sched6"), mDTR.Item("log1"), mDTR.Item("log2"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                    If mSchedStatus = ScheduleStatus.Computed Then
                                        mDaysWork = 1
                                        mHrsWrkd = mRegHrs
                                        computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched2"), mLate)
                                        computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched3"), mDTR.Item("sched4"), mLate)
                                    ElseIf mSchedStatus = ScheduleStatus.LogNotComputed Or mSchedStatus = ScheduleStatus.LogInvalid Then
                                        computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched5"), mDTR.Item("sched6"), mDTR.Item("log3"), mDTR.Item("log4"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                        If mSchedStatus = ScheduleStatus.Computed Then
                                            mDaysWork = 1
                                            mHrsWrkd = mRegHrs
                                            computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched2"), mLate)
                                            computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched3"), mDTR.Item("sched4"), mLate)
                                        ElseIf mSchedStatus = ScheduleStatus.LogNotComputed Or mSchedStatus = ScheduleStatus.LogInvalid Then
                                            computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched5"), mDTR.Item("sched6"), mDTR.Item("log5"), mDTR.Item("log6"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                            If mSchedStatus = ScheduleStatus.Computed Then
                                                mDaysWork = 1
                                                mHrsWrkd = mRegHrs
                                                computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched2"), mLate)
                                                computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched3"), mDTR.Item("sched4"), mLate)
                                            Else
                                                mDaysAbsent = 1
                                            End If
                                        Else
                                            mDaysAbsent = 1
                                        End If
                                    Else
                                        mDaysAbsent = 1
                                    End If
                                Else
                                    mDaysAbsent = 1
                                End If
                            ElseIf mSchedStatus = ScheduleStatus.LogInvalid Then
                                computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched3"), mDTR.Item("sched4"), mDTR.Item("log3"), mDTR.Item("log4"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                If mSchedStatus = ScheduleStatus.Computed Then
                                    mDaysWork = 1
                                    mHrsWrkd = mRegHrs
                                    computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched2"), mLate)
                                    computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched5"), mDTR.Item("sched6"), mDTR.Item("log5"), mDTR.Item("log6"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                    If mSchedStatus = ScheduleStatus.LogInvalid Or mSchedStatus = ScheduleStatus.LogNotComputed Then
                                        computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched5"), mDTR.Item("sched6"), mUndertime)
                                    End If
                                ElseIf mSchedStatus = ScheduleStatus.LogNotComputed Then
                                    computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched5"), mDTR.Item("sched6"), mDTR.Item("log3"), mDTR.Item("log4"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                    If mSchedStatus = ScheduleStatus.Computed Then
                                        mDaysWork = 1
                                        mHrsWrkd = mRegHrs
                                        computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched2"), mLate)
                                        computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched3"), mDTR.Item("sched4"), mLate)
                                    ElseIf mSchedStatus = ScheduleStatus.LogNotComputed Then
                                        computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched5"), mDTR.Item("sched6"), mDTR.Item("log5"), mDTR.Item("log6"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                        If mSchedStatus = ScheduleStatus.Computed Then
                                            mDaysWork = 1
                                            mHrsWrkd = mRegHrs
                                            computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched2"), mLate)
                                            computeLtUt(mDTR.Item("work_date"), mDTR.Item("sched3"), mDTR.Item("sched4"), mLate)
                                        Else
                                            mDaysAbsent = 1
                                        End If
                                    Else
                                        mDaysAbsent = 1
                                    End If
                                Else
                                    mDaysAbsent = 1
                                End If
                            End If

                        Else

                            If Not IsDBNull(mDTR.Item("log2")) And Not IsDBNull(mDTR.Item("log3")) Then
                                computeSched(mDTR.Item("work_date"), mDTR.Item("sched1"), mDTR.Item("sched1"), mDTR.Item("sched2"), mDTR.Item("log1"), mDTR.Item("log4"), mLate, mUndertime, mGracePeriod, mRoundMinutes, mSchedStatus)
                                If mSchedStatus = ScheduleStatus.Computed Then
                                    mDaysWork = 1
                                    mHrsWrkd = mRegHrs
                                    Dim tempLates As Double = mLate
                                    'mLate = CType(DateDiff(DateInterval.Minute, CType(Format(mDTR.Item("log2"), "MM/dd/yyyy HH:mm"), DateTime), CType(Format(mDTR.Item("log3"), "MM/dd/yyyy HH:mm"), DateTime)), Double)
                                    mLate = CType(DateDiff(DateInterval.Minute, CType(mDTR.Item("log2"), DateTime), CType(mDTR.Item("log3"), DateTime)), Double)
                                    If mLate > (SysParam.FlexiBreakHours * 60) Then

                                        mLate = mLate - (SysParam.FlexiBreakHours * 60)

                                        If mLate > mGracePeriod Then
                                            Dim mLateInMinutes As Double = mLate

                                            mLate = 0
                                            If mLateInMinutes <= mRoundMinutes Then
                                                mLate = mRoundMinutes / 60
                                            Else
                                                Do While mLateInMinutes > 0
                                                    mLate = mLate + mRoundMinutes
                                                    mLateInMinutes = mLateInMinutes - mRoundMinutes
                                                Loop
                                                mLate = mLate / 60
                                            End If
                                        End If

                                    Else
                                        mLate = 0
                                    End If
                                    mLate = mLate + tempLates

                                Else
                                    mDaysAbsent = 1
                                End If
                            Else
                                mDaysAbsent = 1
                            End If
                            


                        End If


                        If mHrsWrkd - (mLate + mUndertime) > 0 Then
                            mHrsWrkd = mHrsWrkd - (mLate + mUndertime)
                        Else
                            mHrsWrkd = 0
                        End If

                        'If Not mWasAbsent Then
                        '    If Not IsDBNull(mDTR.Item("holiday_type")) Then
                        '        If CType(mDTR.Item("holiday_type"), String) = "REG" Then
                        '            mRegHoliday = 8
                        '        Else
                        '            If CType(mDTR.Item("pay_type"), String) = "D" Then
                        '                mSpcHoliday = mHrsWrkd
                        '            Else
                        '                mSpcHoliday = 8
                        '            End If
                        '        End If
                        '        mDaysAbsent = 0
                        '    End If
                        'End If

                        If Not mWasAbsent Then
                            If Not IsDBNull(mDTR.Item("holiday_type")) Then
                                If CType(mDTR.Item("holiday_type"), String) = "REG" Then
                                    If mDaysWork > 0 Then
                                        mRegHoliday = 8
                                    Else
                                        If CType(mDTR.Item("pay_type"), String) = "D" Then
                                            mDaysWork = 1
                                        End If
                                    End If
                                Else
                                    mSpcHoliday = mHrsWrkd
                                End If
                                If CType(mDTR.Item("pay_type"), String) = "M" Then
                                    mLate = 0
                                    mUndertime = 0
                                End If
                                mDaysAbsent = 0
                            End If
                        End If

                        If mDaysWork + mDaysAbsent + mHrsWrkd + mLate + mUndertime + mRegHoliday + mSpcHoliday <> 0 Then
                            mCommand.CommandText = "insert into dtr_summary(employee_id,work_date,days_wrkd,days_absent,hrs_wrkd,late,undertime,reg_holiday,spc_holiday) values (" & _
                                    "" & mEmployeeID & ",'" & Format(CType(mDTR.Item("work_date"), Date), "yyyy-MM-dd") & "'," & _
                                    "" & mDaysWork & "," & mDaysAbsent & "," & mHrsWrkd & "," & mLate & "," & mUndertime & "," & mRegHoliday & "," & mSpcHoliday & ")"
                            mCommand.ExecuteNonQuery()
                        End If
                        If Not IsDBNull(mDTR.Item("holiday_type")) Then
                            If mWasAbsent Then
                                mWasAbsent = True
                            End If
                        Else
                            If mDaysAbsent <> 0 Then
                                mWasAbsent = True
                            Else
                                mWasAbsent = False
                            End If
                        End If
                    Next
                End If
            End If
            mTrans.Commit()
        Catch ex As MySqlException
            If Not (mTrans Is Nothing) Then
                mTrans.Rollback()
            End If
            MsgBox(ex.Message & " " & ex.ToString, MsgBoxStyle.Critical, "Computing DTR Error!")
        Catch ex As Exception
            If Not (mTrans Is Nothing) Then
                mTrans.Rollback()
            End If
            MsgBox(ex.Message & " " & ex.ToString, MsgBoxStyle.Critical, "Computing DTR Error!")
        Finally
            Try
                mCommand.Dispose()
                mTrans.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message & " " & ex.ToString, MsgBoxStyle.Exclamation, "Computing DTR Error!")
            Finally

            End Try
        End Try
    End Sub

    Private Sub computeSched(ByVal mWorkDate As Object, ByVal mRaw1stInSched As Object, ByVal mRawInSched As Object, ByVal mRawOutSched As Object, ByVal mRawLogIn As Object, ByVal mRawLogOut As Object, _
                             ByRef mLate As Double, ByRef mUndertime As Double, ByVal mGracePeriod As Double, ByVal mRoundMinutes As Double, ByRef mSchedStatus As ScheduleStatus)

        Dim m1stInSched As DateTime
        Dim mInSched As DateTime
        Dim mOutSched As DateTime
        Dim mLogIn As DateTime
        Dim mLogOut As DateTime
        Dim mLateInMinutes As Double
        Dim mUndertimeInMinutes As Double

        

        Try
            If Not IsDBNull(mRawInSched) And Not IsDBNull(mRawOutSched) Then
                'm1stInSched = CType(Format(mWorkDate, "MM/dd/yyyy") & " " & mRaw1stInSched.ToString, DateTime)
                'mInSched = CType(Format(mWorkDate, "MM/dd/yyyy") & " " & mRawInSched.ToString, DateTime)
                'mOutSched = CType(Format(mWorkDate, "MM/dd/yyyy") & " " & mRawOutSched.ToString, DateTime)

                m1stInSched = CType(CType(mWorkDate, Date) & " " & mRaw1stInSched.ToString, DateTime)
                mInSched = CType(CType(mWorkDate, Date) & " " & mRawInSched.ToString, DateTime)
                mOutSched = CType(CType(mWorkDate, Date) & " " & mRawOutSched.ToString, DateTime)

                If mInSched < m1stInSched Then
                    mInSched = DateAdd(DateInterval.Day, 1, mInSched)
                End If
                If mOutSched < mInSched Then
                    mOutSched = DateAdd(DateInterval.Day, 1, mOutSched)
                End If
                If Not IsDBNull(mRawLogIn) And Not IsDBNull(mRawLogOut) Then
                    'mLogIn = CType(Format(mRawLogIn, "MM/dd/yyyy HH:mm"), DateTime)
                    'mLogOut = CType(Format(mRawLogOut, "MM/dd/yyyy HH:mm"), DateTime)

                    mLogIn = CType(mRawLogIn, DateTime)
                    mLogOut = CType(mRawLogOut, DateTime)
                    If mOutSched >= mLogIn And mInSched <= mLogOut Then

                        Dim mTempLate As Double = mLate
                        Dim mTempUndertime As Double = mUndertime

                        mLate = 0
                        mUndertime = 0

                        mLateInMinutes = CType(DateDiff(DateInterval.Minute, mInSched, mLogIn), Integer)
                        mUndertimeInMinutes = CType(DateDiff(DateInterval.Minute, mLogOut, mOutSched), Integer)

                        If mLateInMinutes > mGracePeriod Then
                            If mLateInMinutes <= mRoundMinutes Then
                                mLate = mRoundMinutes / 60
                            Else
                                Do While mLateInMinutes > 0
                                    mLate = mLate + mRoundMinutes
                                    mLateInMinutes = mLateInMinutes - mRoundMinutes
                                Loop
                                mLate = mLate / 60
                            End If
                        End If

                        If mUndertimeInMinutes > 0 Then
                            Do While mUndertimeInMinutes > 0
                                mUndertime = mUndertime + mRoundMinutes
                                mUndertimeInMinutes = mUndertimeInMinutes - mRoundMinutes
                            Loop
                            mUndertime = mUndertime / 60
                        End If

                        mLate = mLate + mTempLate
                        mUndertime = mUndertime + mTempUndertime
                        mSchedStatus = ScheduleStatus.Computed
                    Else
                        mSchedStatus = ScheduleStatus.LogNotComputed
                    End If
                Else
                    mSchedStatus = ScheduleStatus.LogInvalid
                End If
            Else
                mSchedStatus = ScheduleStatus.NoSchedule
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Computing Schedule Error!")
        End Try
    End Sub

    Private Sub computeLtUt(ByVal mWordDate As Object, ByVal mRawInSched As Object, ByVal mRawOutSched As Object, ByRef mLtUt As Double)
        Dim mInSched As DateTime
        Dim mOutSched As DateTime
        Dim mLtUTTemp As Double = mLtUt
        
        Try
            mLtUt = 0
            'mInSched = CType(Format(mWordDate, "MM/dd/yyyy") & " " & mRawInSched.ToString, DateTime)
            'mOutSched = CType(Format(mWordDate, "MM/dd/yyyy") & " " & mRawOutSched.ToString, DateTime)

            mInSched = CType(CType(mWordDate, Date) & " " & mRawInSched.ToString, DateTime)
            mOutSched = CType(CType(mWordDate, Date) & " " & mRawOutSched.ToString, DateTime)

            If mOutSched < mInSched Then
                mOutSched = DateAdd(DateInterval.Day, 1, mOutSched)
            End If
            mLtUt = (CType(DateDiff(DateInterval.Minute, mInSched, mOutSched), Double) / 60) + mLtUTTemp
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Computing Late/UT Error!")
        End Try
    End Sub

    Public Sub exportDTR(ByVal employeeID As Integer, ByVal mDateFrom As Date, ByVal mDateUntil As Date, ByVal cutoff_period_id As Integer, ByVal payType As String)
        Dim mTrans As MySqlTransaction
        Dim mCommand As New MySqlCommand
        Dim dtrSummary As New DataTable

        mTrans = Cn.Connection.BeginTransaction

        Try
            If NetOpen(dtrSummary, "SELECT SUM(days_wrkd) dayswork,SUM(days_absent) absdays, " & _
                                   "SUM(late) late,SUM(undertime) undertime," & _
                                   "SUM(reg_holiday) legdays,SUM(spc_holiday) spcdays " & _
                                   "FROM dtr_summary " & _
                                   "WHERE employee_id=" & employeeID & " " & _
                                   "AND work_date BETWEEN '" & Format(mDateFrom, "yyyy-MM-dd") & "' AND '" & Format(mDateUntil, "yyyy-MM-dd") & "' " & _
                                   "GROUP BY employee_id") Then

                If dtrSummary.Rows.Count > 0 Then
                    mCommand.Transaction = mTrans
                    mCommand.Connection = Cn.Connection
                    mCommand.Parameters.AddWithValue("@employee_id", employeeID)
                    mCommand.Parameters.AddWithValue("@cutoffPeriodID", cutoff_period_id)
                    For Each sumRow As DataRow In dtrSummary.Rows

                        mCommand.Parameters.AddWithValue("@daysWork", IIf(payType = "D", CType(sumRow.Item("dayswork"), Double), 0))
                        mCommand.Parameters.AddWithValue("@absDays", IIf(payType = "M", CType(sumRow.Item("absdays"), Double), 0))
                        mCommand.Parameters.AddWithValue("@late", CType(sumRow.Item("late"), Double))
                        mCommand.Parameters.AddWithValue("@undertime", CType(sumRow.Item("undertime"), Double))
                        mCommand.Parameters.AddWithValue("@legDays", CType(sumRow.Item("legdays"), Double))
                        mCommand.Parameters.AddWithValue("@spcDays", CType(sumRow.Item("spcdays"), Double))
                        mCommand.CommandText = "insert into " & SysParam.PayrollDatabase & ".dtr " & _
                                    "(employeecode,percode,dayswork,absdays,late,undertime,legdays,spcdays) values (" & _
                                    "@employee_id,@cutoffPeriodID,@daysWork,@absDays,@late,@undertime,@legDays,@spcDays) on duplicate key update " & _
                                    "dayswork=@daysWork,absdays=@absDays,late=@late,undertime=@undertime,legdays=@legDays,spcdays=@spcDays "
                        mCommand.ExecuteNonQuery()
                    Next
                End If

            End If

            mTrans.Commit()
        Catch ex As MySqlException
            If Not (mTrans Is Nothing) Then
                mTrans.Rollback()
            End If
            'MsgBox(ex.Message & " " & ex.ToString, MsgBoxStyle.Critical, "Computing DTR Error!")
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exporting DTR error!")
        Catch ex As Exception
            If Not (mTrans Is Nothing) Then
                mTrans.Rollback()
            End If
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exporting DTR error!")
            'MsgBox(ex.Message & " " & ex.ToString, MsgBoxStyle.Critical, "Computing DTR Error!")
        Finally
            Try
                mCommand.Dispose()
                mTrans.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Exporting DTR error!")
                'MsgBox(ex.Message & " " & ex.ToString, MsgBoxStyle.Exclamation, "Computing DTR Error!")
            Finally

            End Try
        End Try
    End Sub

End Module