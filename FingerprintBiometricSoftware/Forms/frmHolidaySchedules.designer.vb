﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHolidaySchedules
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHolidaySchedules))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.gbxEmployeeInfo = New System.Windows.Forms.GroupBox()
        Me.dgvDepartments = New System.Windows.Forms.DataGridView()
        Me.txtDescription = New C1.Win.C1Input.C1TextBox()
        Me.rdbSpecial = New System.Windows.Forms.RadioButton()
        Me.rdbRegular = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpSchedDate = New System.Windows.Forms.DateTimePicker()
        Me.department_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.isChecked = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbxEmployeeInfo.SuspendLayout()
        CType(Me.dgvDepartments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(332, 471)
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
        Me.btnBack.Location = New System.Drawing.Point(426, 471)
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
        Me.Label6.Size = New System.Drawing.Size(159, 26)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "Holiday Schedules"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Location = New System.Drawing.Point(238, 471)
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
        Me.btnBrowse.Location = New System.Drawing.Point(475, 21)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(26, 26)
        Me.btnBrowse.TabIndex = 142
        Me.btnBrowse.TabStop = False
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'gbxEmployeeInfo
        '
        Me.gbxEmployeeInfo.BackColor = System.Drawing.Color.Transparent
        Me.gbxEmployeeInfo.Controls.Add(Me.dgvDepartments)
        Me.gbxEmployeeInfo.Controls.Add(Me.txtDescription)
        Me.gbxEmployeeInfo.Controls.Add(Me.rdbSpecial)
        Me.gbxEmployeeInfo.Controls.Add(Me.rdbRegular)
        Me.gbxEmployeeInfo.Controls.Add(Me.Label3)
        Me.gbxEmployeeInfo.Controls.Add(Me.Label1)
        Me.gbxEmployeeInfo.Controls.Add(Me.Label2)
        Me.gbxEmployeeInfo.Controls.Add(Me.dtpSchedDate)
        Me.gbxEmployeeInfo.Controls.Add(Me.btnBrowse)
        Me.gbxEmployeeInfo.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxEmployeeInfo.Location = New System.Drawing.Point(5, 27)
        Me.gbxEmployeeInfo.Name = "gbxEmployeeInfo"
        Me.gbxEmployeeInfo.Size = New System.Drawing.Size(509, 440)
        Me.gbxEmployeeInfo.TabIndex = 44
        Me.gbxEmployeeInfo.TabStop = False
        '
        'dgvDepartments
        '
        Me.dgvDepartments.AllowUserToAddRows = False
        Me.dgvDepartments.AllowUserToDeleteRows = False
        Me.dgvDepartments.AllowUserToResizeColumns = False
        Me.dgvDepartments.AllowUserToResizeRows = False
        Me.dgvDepartments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDepartments.BackgroundColor = System.Drawing.Color.White
        Me.dgvDepartments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDepartments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvDepartments.ColumnHeadersHeight = 20
        Me.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDepartments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.department_id, Me.isChecked, Me.description})
        Me.dgvDepartments.Location = New System.Drawing.Point(113, 117)
        Me.dgvDepartments.MultiSelect = False
        Me.dgvDepartments.Name = "dgvDepartments"
        Me.dgvDepartments.RowHeadersVisible = False
        Me.dgvDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDepartments.Size = New System.Drawing.Size(390, 317)
        Me.dgvDepartments.TabIndex = 212
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(112, 21)
        Me.txtDescription.MaxLength = 20
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(357, 26)
        Me.txtDescription.TabIndex = 211
        Me.txtDescription.Tag = Nothing
        Me.txtDescription.TextDetached = True
        '
        'rdbSpecial
        '
        Me.rdbSpecial.AutoSize = True
        Me.rdbSpecial.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!)
        Me.rdbSpecial.Location = New System.Drawing.Point(233, 83)
        Me.rdbSpecial.Name = "rdbSpecial"
        Me.rdbSpecial.Size = New System.Drawing.Size(81, 24)
        Me.rdbSpecial.TabIndex = 210
        Me.rdbSpecial.Text = "Special"
        Me.rdbSpecial.UseVisualStyleBackColor = True
        '
        'rdbRegular
        '
        Me.rdbRegular.AutoSize = True
        Me.rdbRegular.Checked = True
        Me.rdbRegular.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!)
        Me.rdbRegular.Location = New System.Drawing.Point(113, 83)
        Me.rdbRegular.Name = "rdbRegular"
        Me.rdbRegular.Size = New System.Drawing.Size(83, 24)
        Me.rdbRegular.TabIndex = 209
        Me.rdbRegular.TabStop = True
        Me.rdbRegular.Text = "Regular"
        Me.rdbRegular.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(62, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 20)
        Me.Label3.TabIndex = 208
        Me.Label3.Text = "Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 20)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(62, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 20)
        Me.Label2.TabIndex = 202
        Me.Label2.Text = "Date"
        '
        'dtpSchedDate
        '
        Me.dtpSchedDate.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSchedDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSchedDate.Location = New System.Drawing.Point(112, 50)
        Me.dtpSchedDate.Name = "dtpSchedDate"
        Me.dtpSchedDate.Size = New System.Drawing.Size(115, 27)
        Me.dtpSchedDate.TabIndex = 200
        '
        'department_id
        '
        Me.department_id.DataPropertyName = "department_id"
        Me.department_id.HeaderText = "Department ID"
        Me.department_id.Name = "department_id"
        Me.department_id.ReadOnly = True
        Me.department_id.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.department_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.department_id.Visible = False
        '
        'isChecked
        '
        Me.isChecked.DataPropertyName = "isChecked"
        Me.isChecked.HeaderText = ""
        Me.isChecked.Name = "isChecked"
        Me.isChecked.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.isChecked.TrueValue = ""
        Me.isChecked.Width = 20
        '
        'description
        '
        Me.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.description.DataPropertyName = "description"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description.DefaultCellStyle = DataGridViewCellStyle1
        Me.description.FillWeight = 98.47716!
        Me.description.HeaderText = "Department"
        Me.description.Name = "description"
        Me.description.ReadOnly = True
        Me.description.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'frmHolidaySchedules
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(521, 535)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gbxEmployeeInfo)
        Me.Font = New System.Drawing.Font("HelveticaNeueLT Com 45 Lt", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmHolidaySchedules"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbxEmployeeInfo.ResumeLayout(False)
        Me.gbxEmployeeInfo.PerformLayout()
        CType(Me.dgvDepartments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents gbxEmployeeInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpSchedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdbSpecial As System.Windows.Forms.RadioButton
    Friend WithEvents rdbRegular As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As C1.Win.C1Input.C1TextBox
    Friend WithEvents dgvDepartments As System.Windows.Forms.DataGridView
    Friend WithEvents department_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isChecked As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents description As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
