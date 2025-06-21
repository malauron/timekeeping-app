Public Class clsSystemParameters

    Private gracePeriodD As Integer
    Private roundMinutesD As Integer
    Private dtrReportS As String
    Private autoImportEmployees As Boolean
    Private autoImportUsers As Boolean
    Private autoImportPayrollPeriod As Boolean
    Private mAddEmployee As Integer
    Private payrollDB As String
    Private bioDeviceIp As String
    Private bioDevicePort As String
    Private employeeBioIdPayrollMapValue As String
    Private flexiBreakHoursValue As Double
    Private nextDayMinDiff As Double
    Private editDTR As Boolean
    Private editDateTime As Boolean
    Private exportDTR As Boolean

    Public Property GracePeriod() As Integer
        Get
            Return gracePeriodD
        End Get
        Set(value As Integer)
            gracePeriodD = value
        End Set
    End Property

    Public Property RoundMinutes() As Integer
        Get
            Return roundMinutesD
        End Get
        Set(value As Integer)
            roundMinutesD = value
        End Set
    End Property

    Public Property DTRReport() As String
        Get
            Return dtrReportS
        End Get
        Set(value As String)
            dtrReportS = value
        End Set
    End Property

    Public Property AddEMployee() As Integer
        Get
            Return mAddEmployee
        End Get
        Set(ByVal value As Integer)
            mAddEmployee = value
        End Set
    End Property

    Public Property CanImportEmployees() As Boolean
        Get
            Return autoImportEmployees
        End Get
        Set(value As Boolean)
            autoImportEmployees = value
        End Set
    End Property

    Public Property CanImportUsers() As Boolean
        Get
            Return autoImportUsers
        End Get
        Set(value As Boolean)
            autoImportUsers = value
        End Set
    End Property

    Public Property CanImportPayrollPeriod() As Boolean
        Get
            Return autoImportPayrollPeriod
        End Get
        Set(value As Boolean)
            autoImportPayrollPeriod = value
        End Set
    End Property

    Public Property PayrollDatabase() As String
        Get
            Return payrollDB
        End Get
        Set(value As String)
            payrollDB = value
        End Set
    End Property

    Public Property EmployeeBioIdPayrollMap() As String
        Get
            Return employeeBioIdPayrollMapValue
        End Get
        Set(value As String)
            employeeBioIdPayrollMapValue = value
        End Set
    End Property

    Public Property BioIpAddress() As String
        Get
            Return bioDeviceIp
        End Get
        Set(value As String)
            bioDeviceIp = value
        End Set
    End Property

    Public Property BioPortNo() As String
        Get
            Return bioDevicePort
        End Get
        Set(value As String)
            bioDevicePort = value
        End Set
    End Property

    Public Property FlexiBreakHours() As Double
        Get
            Return flexiBreakHoursValue
        End Get
        Set(value As Double)
            flexiBreakHoursValue = value
        End Set
    End Property

    Public Property NextDayMinuteDifference() As Double
        Get
            Return nextDayMinDiff
        End Get
        Set(value As Double)
            nextDayMinDiff = value
        End Set
    End Property

    Public Property EditDTREntry() As Boolean
        Get
            Return editDTR
        End Get
        Set(value As Boolean)
            editDTR = value
        End Set
    End Property

    Public Property EditDateTimeEntry() As Boolean
        Get
            Return editDateTime
        End Get
        Set(value As Boolean)
            editDateTime = value
        End Set
    End Property

    Public Property ExportDTRSummary() As Boolean
        Get
            Return exportDTR
        End Get
        Set(value As Boolean)
            exportDTR = value
        End Set
    End Property

End Class
