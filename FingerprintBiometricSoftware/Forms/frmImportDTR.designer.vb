<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportDTR
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportDTR))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.gbxEmployeeInfo = New System.Windows.Forms.GroupBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.ofdLogs = New System.Windows.Forms.OpenFileDialog()
        Me.chk = New System.Windows.Forms.CheckBox()
        Me.optFile = New System.Windows.Forms.RadioButton()
        Me.optDevice = New System.Windows.Forms.RadioButton()
        Me.lblIPAddress = New System.Windows.Forms.Label()
        Me.lblPortNo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbxEmployeeInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(355, 157)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 61)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Import"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Image = CType(resources.GetObject("btnBack.Image"), System.Drawing.Image)
        Me.btnBack.Location = New System.Drawing.Point(449, 157)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(88, 61)
        Me.btnBack.TabIndex = 46
        Me.btnBack.Text = "Back"
        Me.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Helvetica Condensed", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(-1, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(338, 26)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "Import Biometric Log From Other Devices"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Location = New System.Drawing.Point(261, 157)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(88, 61)
        Me.btnNew.TabIndex = 124
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.BackgroundImage = CType(resources.GetObject("btnBrowse.BackgroundImage"), System.Drawing.Image)
        Me.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBrowse.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.ForeColor = System.Drawing.Color.Black
        Me.btnBrowse.Location = New System.Drawing.Point(490, 44)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(26, 26)
        Me.btnBrowse.TabIndex = 142
        Me.btnBrowse.TabStop = False
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'gbxEmployeeInfo
        '
        Me.gbxEmployeeInfo.BackColor = System.Drawing.Color.Transparent
        Me.gbxEmployeeInfo.Controls.Add(Me.lblPortNo)
        Me.gbxEmployeeInfo.Controls.Add(Me.lblIPAddress)
        Me.gbxEmployeeInfo.Controls.Add(Me.optDevice)
        Me.gbxEmployeeInfo.Controls.Add(Me.optFile)
        Me.gbxEmployeeInfo.Controls.Add(Me.ProgressBar1)
        Me.gbxEmployeeInfo.Controls.Add(Me.Label1)
        Me.gbxEmployeeInfo.Controls.Add(Me.lblPath)
        Me.gbxEmployeeInfo.Controls.Add(Me.dtpDateFrom)
        Me.gbxEmployeeInfo.Controls.Add(Me.btnBrowse)
        Me.gbxEmployeeInfo.Controls.Add(Me.Label5)
        Me.gbxEmployeeInfo.Controls.Add(Me.Label4)
        Me.gbxEmployeeInfo.Location = New System.Drawing.Point(5, 27)
        Me.gbxEmployeeInfo.Name = "gbxEmployeeInfo"
        Me.gbxEmployeeInfo.Size = New System.Drawing.Size(532, 127)
        Me.gbxEmployeeInfo.TabIndex = 44
        Me.gbxEmployeeInfo.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 107)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(520, 12)
        Me.ProgressBar1.TabIndex = 207
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(210, 20)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "Start Date of Payroll Period"
        '
        'lblPath
        '
        Me.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPath.Location = New System.Drawing.Point(133, 44)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(354, 26)
        Me.lblPath.TabIndex = 205
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateFrom.Location = New System.Drawing.Point(223, 75)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(115, 27)
        Me.dtpDateFrom.TabIndex = 203
        '
        'ofdLogs
        '
        Me.ofdLogs.Filter = "DAT Files (*.dat)|*.dat"
        Me.ofdLogs.Title = "Log File"
        '
        'chk
        '
        Me.chk.AutoSize = True
        Me.chk.Location = New System.Drawing.Point(10, 162)
        Me.chk.Name = "chk"
        Me.chk.Size = New System.Drawing.Size(181, 24)
        Me.chk.TabIndex = 125
        Me.chk.Text = "1=IN,Otherwise OUT"
        Me.chk.UseVisualStyleBackColor = True
        Me.chk.Visible = False
        '
        'optFile
        '
        Me.optFile.AutoSize = True
        Me.optFile.Checked = True
        Me.optFile.Location = New System.Drawing.Point(11, 46)
        Me.optFile.Name = "optFile"
        Me.optFile.Size = New System.Drawing.Size(93, 24)
        Me.optFile.TabIndex = 208
        Me.optFile.TabStop = True
        Me.optFile.Text = "From File"
        Me.optFile.UseVisualStyleBackColor = True
        '
        'optDevice
        '
        Me.optDevice.AutoSize = True
        Me.optDevice.Location = New System.Drawing.Point(11, 17)
        Me.optDevice.Name = "optDevice"
        Me.optDevice.Size = New System.Drawing.Size(119, 24)
        Me.optDevice.TabIndex = 209
        Me.optDevice.Text = "From Device"
        Me.optDevice.UseVisualStyleBackColor = True
        '
        'lblIPAddress
        '
        Me.lblIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIPAddress.Location = New System.Drawing.Point(221, 15)
        Me.lblIPAddress.Name = "lblIPAddress"
        Me.lblIPAddress.Size = New System.Drawing.Size(182, 26)
        Me.lblIPAddress.TabIndex = 210
        '
        'lblPortNo
        '
        Me.lblPortNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPortNo.Location = New System.Drawing.Point(447, 15)
        Me.lblPortNo.Name = "lblPortNo"
        Me.lblPortNo.Size = New System.Drawing.Size(70, 26)
        Me.lblPortNo.TabIndex = 211
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(134, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 20)
        Me.Label4.TabIndex = 212
        Me.Label4.Text = "IP Address"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(408, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 20)
        Me.Label5.TabIndex = 213
        Me.Label5.Text = "Port"
        '
        'frmImportDTR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(543, 222)
        Me.ControlBox = False
        Me.Controls.Add(Me.chk)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gbxEmployeeInfo)
        Me.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmImportDTR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbxEmployeeInfo.ResumeLayout(False)
        Me.gbxEmployeeInfo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents gbxEmployeeInfo As System.Windows.Forms.GroupBox
    Friend WithEvents dtpDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents ofdLogs As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents chk As System.Windows.Forms.CheckBox
    Friend WithEvents lblPortNo As System.Windows.Forms.Label
    Friend WithEvents lblIPAddress As System.Windows.Forms.Label
    Friend WithEvents optDevice As System.Windows.Forms.RadioButton
    Friend WithEvents optFile As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
