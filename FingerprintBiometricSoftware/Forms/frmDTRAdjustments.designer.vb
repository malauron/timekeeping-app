<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDTRAdjustments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDTRAdjustments))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.gbxEmployeeInfo = New System.Windows.Forms.GroupBox()
        Me.lb = New System.Windows.Forms.ListBox()
        Me.btnOut03 = New System.Windows.Forms.Button()
        Me.btnIn03 = New System.Windows.Forms.Button()
        Me.btnOut02 = New System.Windows.Forms.Button()
        Me.btnIn02 = New System.Windows.Forms.Button()
        Me.btnOut01 = New System.Windows.Forms.Button()
        Me.btnIn01 = New System.Windows.Forms.Button()
        Me.txt3rd_outsched = New C1.Win.C1Input.C1DateEdit()
        Me.txt3rd_insched = New C1.Win.C1Input.C1DateEdit()
        Me.txt2nd_outsched = New C1.Win.C1Input.C1DateEdit()
        Me.txt2nd_insched = New C1.Win.C1Input.C1DateEdit()
        Me.txt1st_outsched = New C1.Win.C1Input.C1DateEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt1st_insched = New C1.Win.C1Input.C1DateEdit()
        Me.gbxEmployeeInfo.SuspendLayout()
        CType(Me.txt3rd_outsched, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt3rd_insched, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt2nd_outsched, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt2nd_insched, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt1st_outsched, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt1st_insched, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(231, 234)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 61)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Image = CType(resources.GetObject("btnBack.Image"), System.Drawing.Image)
        Me.btnBack.Location = New System.Drawing.Point(325, 234)
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
        Me.Label6.Size = New System.Drawing.Size(140, 26)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "DTR Adjustment"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(63, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 20)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "IN"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(237, 34)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(141, 20)
        Me.Label13.TabIndex = 131
        Me.Label13.Text = "OUT"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbxEmployeeInfo
        '
        Me.gbxEmployeeInfo.BackColor = System.Drawing.Color.Transparent
        Me.gbxEmployeeInfo.Controls.Add(Me.lb)
        Me.gbxEmployeeInfo.Controls.Add(Me.btnOut03)
        Me.gbxEmployeeInfo.Controls.Add(Me.btnIn03)
        Me.gbxEmployeeInfo.Controls.Add(Me.btnOut02)
        Me.gbxEmployeeInfo.Controls.Add(Me.btnIn02)
        Me.gbxEmployeeInfo.Controls.Add(Me.btnOut01)
        Me.gbxEmployeeInfo.Controls.Add(Me.btnIn01)
        Me.gbxEmployeeInfo.Controls.Add(Me.txt3rd_outsched)
        Me.gbxEmployeeInfo.Controls.Add(Me.txt3rd_insched)
        Me.gbxEmployeeInfo.Controls.Add(Me.txt2nd_outsched)
        Me.gbxEmployeeInfo.Controls.Add(Me.txt2nd_insched)
        Me.gbxEmployeeInfo.Controls.Add(Me.txt1st_outsched)
        Me.gbxEmployeeInfo.Controls.Add(Me.Label5)
        Me.gbxEmployeeInfo.Controls.Add(Me.Label4)
        Me.gbxEmployeeInfo.Controls.Add(Me.Label3)
        Me.gbxEmployeeInfo.Controls.Add(Me.txt1st_insched)
        Me.gbxEmployeeInfo.Controls.Add(Me.Label13)
        Me.gbxEmployeeInfo.Controls.Add(Me.Label2)
        Me.gbxEmployeeInfo.Location = New System.Drawing.Point(5, 27)
        Me.gbxEmployeeInfo.Name = "gbxEmployeeInfo"
        Me.gbxEmployeeInfo.Size = New System.Drawing.Size(408, 201)
        Me.gbxEmployeeInfo.TabIndex = 44
        Me.gbxEmployeeInfo.TabStop = False
        '
        'lb
        '
        Me.lb.FormatString = "g"
        Me.lb.ItemHeight = 20
        Me.lb.Location = New System.Drawing.Point(63, 155)
        Me.lb.Name = "lb"
        Me.lb.Size = New System.Drawing.Size(156, 84)
        Me.lb.TabIndex = 229
        Me.lb.Visible = False
        '
        'btnOut03
        '
        Me.btnOut03.BackgroundImage = CType(resources.GetObject("btnOut03.BackgroundImage"), System.Drawing.Image)
        Me.btnOut03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOut03.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOut03.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOut03.ForeColor = System.Drawing.Color.Black
        Me.btnOut03.Location = New System.Drawing.Point(377, 121)
        Me.btnOut03.Name = "btnOut03"
        Me.btnOut03.Size = New System.Drawing.Size(26, 26)
        Me.btnOut03.TabIndex = 228
        Me.btnOut03.TabStop = False
        Me.btnOut03.UseVisualStyleBackColor = True
        '
        'btnIn03
        '
        Me.btnIn03.BackgroundImage = CType(resources.GetObject("btnIn03.BackgroundImage"), System.Drawing.Image)
        Me.btnIn03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnIn03.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnIn03.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIn03.ForeColor = System.Drawing.Color.Black
        Me.btnIn03.Location = New System.Drawing.Point(203, 121)
        Me.btnIn03.Name = "btnIn03"
        Me.btnIn03.Size = New System.Drawing.Size(26, 26)
        Me.btnIn03.TabIndex = 227
        Me.btnIn03.TabStop = False
        Me.btnIn03.UseVisualStyleBackColor = True
        '
        'btnOut02
        '
        Me.btnOut02.BackgroundImage = CType(resources.GetObject("btnOut02.BackgroundImage"), System.Drawing.Image)
        Me.btnOut02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOut02.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOut02.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOut02.ForeColor = System.Drawing.Color.Black
        Me.btnOut02.Location = New System.Drawing.Point(377, 89)
        Me.btnOut02.Name = "btnOut02"
        Me.btnOut02.Size = New System.Drawing.Size(26, 26)
        Me.btnOut02.TabIndex = 226
        Me.btnOut02.TabStop = False
        Me.btnOut02.UseVisualStyleBackColor = True
        '
        'btnIn02
        '
        Me.btnIn02.BackgroundImage = CType(resources.GetObject("btnIn02.BackgroundImage"), System.Drawing.Image)
        Me.btnIn02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnIn02.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnIn02.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIn02.ForeColor = System.Drawing.Color.Black
        Me.btnIn02.Location = New System.Drawing.Point(203, 89)
        Me.btnIn02.Name = "btnIn02"
        Me.btnIn02.Size = New System.Drawing.Size(26, 26)
        Me.btnIn02.TabIndex = 225
        Me.btnIn02.TabStop = False
        Me.btnIn02.UseVisualStyleBackColor = True
        '
        'btnOut01
        '
        Me.btnOut01.BackgroundImage = CType(resources.GetObject("btnOut01.BackgroundImage"), System.Drawing.Image)
        Me.btnOut01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOut01.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOut01.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOut01.ForeColor = System.Drawing.Color.Black
        Me.btnOut01.Location = New System.Drawing.Point(377, 57)
        Me.btnOut01.Name = "btnOut01"
        Me.btnOut01.Size = New System.Drawing.Size(26, 26)
        Me.btnOut01.TabIndex = 224
        Me.btnOut01.TabStop = False
        Me.btnOut01.UseVisualStyleBackColor = True
        '
        'btnIn01
        '
        Me.btnIn01.BackgroundImage = CType(resources.GetObject("btnIn01.BackgroundImage"), System.Drawing.Image)
        Me.btnIn01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnIn01.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnIn01.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIn01.ForeColor = System.Drawing.Color.Black
        Me.btnIn01.Location = New System.Drawing.Point(203, 57)
        Me.btnIn01.Name = "btnIn01"
        Me.btnIn01.Size = New System.Drawing.Size(26, 26)
        Me.btnIn01.TabIndex = 223
        Me.btnIn01.TabStop = False
        Me.btnIn01.UseVisualStyleBackColor = True
        '
        'txt3rd_outsched
        '
        Me.txt3rd_outsched.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txt3rd_outsched.Calendar.DayNameLength = 1
        Me.txt3rd_outsched.CustomFormat = "M/dd/yyyy HH:mm"
        Me.txt3rd_outsched.DisplayFormat.EmptyAsNull = False
        Me.txt3rd_outsched.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType Or C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txt3rd_outsched.EditFormat.EmptyAsNull = False
        Me.txt3rd_outsched.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType Or C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txt3rd_outsched.EmptyAsNull = True
        Me.txt3rd_outsched.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txt3rd_outsched.Location = New System.Drawing.Point(237, 121)
        Me.txt3rd_outsched.Name = "txt3rd_outsched"
        Me.txt3rd_outsched.Size = New System.Drawing.Size(141, 26)
        Me.txt3rd_outsched.TabIndex = 222
        Me.txt3rd_outsched.Tag = Nothing
        Me.txt3rd_outsched.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'txt3rd_insched
        '
        Me.txt3rd_insched.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txt3rd_insched.Calendar.DayNameLength = 1
        Me.txt3rd_insched.CustomFormat = "M/dd/yyyy HH:mm"
        Me.txt3rd_insched.DisplayFormat.EmptyAsNull = False
        Me.txt3rd_insched.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType Or C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txt3rd_insched.EditFormat.EmptyAsNull = False
        Me.txt3rd_insched.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType Or C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txt3rd_insched.EmptyAsNull = True
        Me.txt3rd_insched.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txt3rd_insched.Location = New System.Drawing.Point(63, 121)
        Me.txt3rd_insched.Name = "txt3rd_insched"
        Me.txt3rd_insched.Size = New System.Drawing.Size(141, 26)
        Me.txt3rd_insched.TabIndex = 221
        Me.txt3rd_insched.Tag = Nothing
        Me.txt3rd_insched.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'txt2nd_outsched
        '
        Me.txt2nd_outsched.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txt2nd_outsched.Calendar.DayNameLength = 1
        Me.txt2nd_outsched.CustomFormat = "M/dd/yyyy HH:mm"
        Me.txt2nd_outsched.DisplayFormat.EmptyAsNull = False
        Me.txt2nd_outsched.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType Or C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txt2nd_outsched.EditFormat.EmptyAsNull = False
        Me.txt2nd_outsched.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType Or C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txt2nd_outsched.EmptyAsNull = True
        Me.txt2nd_outsched.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txt2nd_outsched.Location = New System.Drawing.Point(237, 89)
        Me.txt2nd_outsched.Name = "txt2nd_outsched"
        Me.txt2nd_outsched.Size = New System.Drawing.Size(141, 26)
        Me.txt2nd_outsched.TabIndex = 220
        Me.txt2nd_outsched.Tag = Nothing
        Me.txt2nd_outsched.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'txt2nd_insched
        '
        Me.txt2nd_insched.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txt2nd_insched.Calendar.DayNameLength = 1
        Me.txt2nd_insched.CustomFormat = "M/dd/yyyy HH:mm"
        Me.txt2nd_insched.DisplayFormat.EmptyAsNull = False
        Me.txt2nd_insched.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType Or C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txt2nd_insched.EditFormat.EmptyAsNull = False
        Me.txt2nd_insched.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType Or C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txt2nd_insched.EmptyAsNull = True
        Me.txt2nd_insched.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txt2nd_insched.Location = New System.Drawing.Point(63, 89)
        Me.txt2nd_insched.Name = "txt2nd_insched"
        Me.txt2nd_insched.Size = New System.Drawing.Size(141, 26)
        Me.txt2nd_insched.TabIndex = 219
        Me.txt2nd_insched.Tag = Nothing
        Me.txt2nd_insched.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'txt1st_outsched
        '
        Me.txt1st_outsched.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txt1st_outsched.Calendar.DayNameLength = 1
        Me.txt1st_outsched.CustomFormat = "M/dd/yyyy HH:mm"
        Me.txt1st_outsched.DisplayFormat.EmptyAsNull = False
        Me.txt1st_outsched.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType Or C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txt1st_outsched.EditFormat.EmptyAsNull = False
        Me.txt1st_outsched.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType Or C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txt1st_outsched.EmptyAsNull = True
        Me.txt1st_outsched.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txt1st_outsched.Location = New System.Drawing.Point(237, 57)
        Me.txt1st_outsched.Name = "txt1st_outsched"
        Me.txt1st_outsched.Size = New System.Drawing.Size(141, 26)
        Me.txt1st_outsched.TabIndex = 218
        Me.txt1st_outsched.Tag = Nothing
        Me.txt1st_outsched.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 20)
        Me.Label5.TabIndex = 217
        Me.Label5.Text = "3RD"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 20)
        Me.Label4.TabIndex = 216
        Me.Label4.Text = "2ND"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 20)
        Me.Label3.TabIndex = 215
        Me.Label3.Text = "1ST"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt1st_insched
        '
        Me.txt1st_insched.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txt1st_insched.Calendar.DayNameLength = 1
        Me.txt1st_insched.CustomFormat = "M/dd/yyyy HH:mm"
        Me.txt1st_insched.DisplayFormat.EmptyAsNull = False
        Me.txt1st_insched.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType Or C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txt1st_insched.EditFormat.EmptyAsNull = False
        Me.txt1st_insched.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType Or C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txt1st_insched.EmptyAsNull = True
        Me.txt1st_insched.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txt1st_insched.Location = New System.Drawing.Point(63, 57)
        Me.txt1st_insched.Name = "txt1st_insched"
        Me.txt1st_insched.Size = New System.Drawing.Size(141, 26)
        Me.txt1st_insched.TabIndex = 201
        Me.txt1st_insched.Tag = Nothing
        Me.txt1st_insched.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'frmDTRAdjustments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(425, 302)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gbxEmployeeInfo)
        Me.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmDTRAdjustments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbxEmployeeInfo.ResumeLayout(False)
        CType(Me.txt3rd_outsched, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt3rd_insched, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt2nd_outsched, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt2nd_insched, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt1st_outsched, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt1st_insched, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents gbxEmployeeInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txt1st_insched As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt3rd_outsched As C1.Win.C1Input.C1DateEdit
    Friend WithEvents txt3rd_insched As C1.Win.C1Input.C1DateEdit
    Friend WithEvents txt2nd_outsched As C1.Win.C1Input.C1DateEdit
    Friend WithEvents txt2nd_insched As C1.Win.C1Input.C1DateEdit
    Friend WithEvents txt1st_outsched As C1.Win.C1Input.C1DateEdit
    Friend WithEvents btnOut03 As System.Windows.Forms.Button
    Friend WithEvents btnIn03 As System.Windows.Forms.Button
    Friend WithEvents btnOut02 As System.Windows.Forms.Button
    Friend WithEvents btnIn02 As System.Windows.Forms.Button
    Friend WithEvents btnOut01 As System.Windows.Forms.Button
    Friend WithEvents btnIn01 As System.Windows.Forms.Button
    Friend WithEvents lb As System.Windows.Forms.ListBox
End Class
