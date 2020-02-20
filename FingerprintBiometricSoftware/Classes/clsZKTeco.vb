Module clsZKTeco

    'Private axCZKEM1 As New zkemkeeper.CZKEM
    Private bIsConnected As Boolean 'the boolean value identifies whether the device is connected
    'Private iMachineNumber As Integer 'the serial number of the device.After connecting the device ,this value will be changed.

    Public Function HasAttLog(ByVal ipAddress As String, ByVal portNo As String, ByRef axCZKEM1 As zkemkeeper.CZKEM, ByRef iMachineNumber As Integer) As Boolean

        'Dim idwErrorCode As Integer
        Dim iGLCount = 0

        HasAttLog = False

        axCZKEM1.Disconnect()

        bIsConnected = axCZKEM1.Connect_Net(ipAddress, Convert.ToInt32(portNo))

        If bIsConnected = True Then
            axCZKEM1.RegEvent(iMachineNumber, 65535)
            iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            axCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)

            axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device

            If axCZKEM1.ReadGeneralLogData(iMachineNumber) Then 'read all the attendance records to the memory
                HasAttLog = True
                'Else
                '    'Cursor = Cursors.Default
                '    axCZKEM1.GetLastError(idwErrorCode)
                '    If idwErrorCode <> 0 Then
                '        'MsgBox("Reading data from terminal failed,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
                '    Else
                '        'MsgBox("No data from terminal returns!", MsgBoxStyle.Exclamation, "Error")
                '    End If
            End If

            axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device

            'Else
            '    axCZKEM1.GetLastError(idwErrorCode)
            'MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If

        Return HasAttLog

    End Function


End Module
