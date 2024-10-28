<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form2))
        Panel1 = New Panel()
        CheckBoxDeactive = New CheckBox()
        CheckBoxActive = New CheckBox()
        txtDiscount = New TextBox()
        Label4 = New Label()
        btnClose = New Button()
        btnSave = New Button()
        btnUpdate = New Button()
        btnNew = New Button()
        ComboBoxPtType = New ComboBox()
        Label3 = New Label()
        RadioButtonIPD = New RadioButton()
        RadioButtonOPD = New RadioButton()
        Label2 = New Label()
        Panel2 = New Panel()
        DataGridView1 = New DataGridView()
        Label1 = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(186), CByte(231), CByte(254))
        Panel1.Controls.Add(CheckBoxDeactive)
        Panel1.Controls.Add(CheckBoxActive)
        Panel1.Controls.Add(txtDiscount)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(btnClose)
        Panel1.Controls.Add(btnSave)
        Panel1.Controls.Add(btnUpdate)
        Panel1.Controls.Add(btnNew)
        Panel1.Controls.Add(ComboBoxPtType)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(RadioButtonIPD)
        Panel1.Controls.Add(RadioButtonOPD)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(7, 72)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(338, 662)
        Panel1.TabIndex = 0
        ' 
        ' CheckBoxDeactive
        ' 
        CheckBoxDeactive.AutoSize = True
        CheckBoxDeactive.Font = New Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        CheckBoxDeactive.ForeColor = Color.DarkMagenta
        CheckBoxDeactive.Location = New Point(149, 310)
        CheckBoxDeactive.Name = "CheckBoxDeactive"
        CheckBoxDeactive.Size = New Size(95, 23)
        CheckBoxDeactive.TabIndex = 12
        CheckBoxDeactive.Text = "Deactive"
        CheckBoxDeactive.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxActive
        ' 
        CheckBoxActive.AutoSize = True
        CheckBoxActive.Font = New Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        CheckBoxActive.ForeColor = Color.DarkMagenta
        CheckBoxActive.Location = New Point(32, 310)
        CheckBoxActive.Name = "CheckBoxActive"
        CheckBoxActive.Size = New Size(78, 23)
        CheckBoxActive.TabIndex = 11
        CheckBoxActive.Text = "Active"
        CheckBoxActive.UseVisualStyleBackColor = True
        ' 
        ' txtDiscount
        ' 
        txtDiscount.Font = New Font("Times New Roman", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        txtDiscount.Location = New Point(14, 254)
        txtDiscount.Name = "txtDiscount"
        txtDiscount.Size = New Size(283, 25)
        txtDiscount.TabIndex = 10
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.ForeColor = Color.Navy
        Label4.Location = New Point(14, 216)
        Label4.Name = "Label4"
        Label4.Size = New Size(91, 19)
        Label4.TabIndex = 9
        Label4.Text = "Discount%"
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.DarkOrange
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        btnClose.ForeColor = SystemColors.ButtonHighlight
        btnClose.Image = CType(resources.GetObject("btnClose.Image"), Image)
        btnClose.ImageAlign = ContentAlignment.MiddleLeft
        btnClose.Location = New Point(179, 609)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(149, 61)
        btnClose.TabIndex = 8
        btnClose.Text = "Close"
        btnClose.TextAlign = ContentAlignment.MiddleRight
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.DarkOrange
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        btnSave.ForeColor = SystemColors.ButtonHighlight
        btnSave.Image = CType(resources.GetObject("btnSave.Image"), Image)
        btnSave.ImageAlign = ContentAlignment.MiddleLeft
        btnSave.Location = New Point(14, 609)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(149, 61)
        btnSave.TabIndex = 7
        btnSave.Text = "Save"
        btnSave.TextAlign = ContentAlignment.MiddleRight
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.DarkOrange
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font = New Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        btnUpdate.ForeColor = SystemColors.ButtonHighlight
        btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), Image)
        btnUpdate.ImageAlign = ContentAlignment.MiddleLeft
        btnUpdate.Location = New Point(179, 537)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(149, 61)
        btnUpdate.TabIndex = 6
        btnUpdate.Text = "Update"
        btnUpdate.TextAlign = ContentAlignment.MiddleRight
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnNew
        ' 
        btnNew.BackColor = Color.DarkOrange
        btnNew.FlatStyle = FlatStyle.Flat
        btnNew.Font = New Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        btnNew.ForeColor = SystemColors.ButtonHighlight
        btnNew.Image = CType(resources.GetObject("btnNew.Image"), Image)
        btnNew.ImageAlign = ContentAlignment.MiddleLeft
        btnNew.Location = New Point(14, 537)
        btnNew.Name = "btnNew"
        btnNew.Size = New Size(149, 61)
        btnNew.TabIndex = 5
        btnNew.Text = "New"
        btnNew.TextAlign = ContentAlignment.MiddleRight
        btnNew.UseVisualStyleBackColor = False
        ' 
        ' ComboBoxPtType
        ' 
        ComboBoxPtType.BackColor = SystemColors.ScrollBar
        ComboBoxPtType.FormattingEnabled = True
        ComboBoxPtType.Location = New Point(14, 157)
        ComboBoxPtType.Name = "ComboBoxPtType"
        ComboBoxPtType.Size = New Size(283, 28)
        ComboBoxPtType.TabIndex = 4
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.Navy
        Label3.Location = New Point(14, 114)
        Label3.Name = "Label3"
        Label3.Size = New Size(106, 20)
        Label3.TabIndex = 3
        Label3.Text = "Patient Type"
        ' 
        ' RadioButtonIPD
        ' 
        RadioButtonIPD.AutoSize = True
        RadioButtonIPD.Font = New Font("Times New Roman", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
        RadioButtonIPD.ForeColor = Color.Navy
        RadioButtonIPD.Location = New Point(216, 54)
        RadioButtonIPD.Name = "RadioButtonIPD"
        RadioButtonIPD.Size = New Size(59, 23)
        RadioButtonIPD.TabIndex = 2
        RadioButtonIPD.TabStop = True
        RadioButtonIPD.Text = "IPD"
        RadioButtonIPD.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonOPD
        ' 
        RadioButtonOPD.AutoSize = True
        RadioButtonOPD.Font = New Font("Times New Roman", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
        RadioButtonOPD.ForeColor = Color.Navy
        RadioButtonOPD.Location = New Point(49, 54)
        RadioButtonOPD.Name = "RadioButtonOPD"
        RadioButtonOPD.Size = New Size(66, 23)
        RadioButtonOPD.TabIndex = 1
        RadioButtonOPD.TabStop = True
        RadioButtonOPD.Text = "OPD"
        RadioButtonOPD.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.Navy
        Label2.Location = New Point(14, 18)
        Label2.Name = "Label2"
        Label2.Size = New Size(125, 20)
        Label2.TabIndex = 0
        Label2.Text = "OPD/IPD Type"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(186), CByte(231), CByte(254))
        Panel2.Controls.Add(DataGridView1)
        Panel2.Location = New Point(359, 72)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(744, 662)
        Panel2.TabIndex = 1
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = Color.FromArgb(CByte(186), CByte(231), CByte(254))
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(17, 157)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.RowTemplate.Height = 29
        DataGridView1.Size = New Size(708, 505)
        DataGridView1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Times New Roman", 22.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.ButtonHighlight
        Label1.Location = New Point(12, 13)
        Label1.Name = "Label1"
        Label1.Size = New Size(448, 42)
        Label1.TabIndex = 2
        Label1.Text = "Patient Type Wise Discount"
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(0), CByte(102), CByte(102))
        ClientSize = New Size(1115, 743)
        Controls.Add(Label1)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Form2"
        Text = "Form2"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents RadioButtonOPD As RadioButton
    Friend WithEvents RadioButtonIPD As RadioButton
    Friend WithEvents ComboBoxPtType As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnNew As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDiscount As TextBox
    Friend WithEvents CheckBoxActive As CheckBox
    Friend WithEvents CheckBoxDeactive As CheckBox
End Class
