Imports MySql.Data.MySqlClient

Module modPublicVariables
    Public mEmployeeFP As New clsFPID
    Public Cn As clsConnectionDetails
    Public cnLock As clsConnectionDetails
    Public User As New clsUser
    Public SysParam As New clsSystemParameters
    Public mReportType As String = ""
    Public mSearchFormName As String = ""
    Public mSearchID As Integer = 0
    Public mNewLog1 As String = ""
    Public mNewLog2 As String = ""
    Public mNewLog3 As String = ""
    Public mNewLog4 As String = ""
    Public mNewLog5 As String = ""
    Public mNewLog6 As String = ""
    Public mLogUpdated As Boolean = False
    Public dateStartWork As Date
    Public dateEndWork As Date
End Module
