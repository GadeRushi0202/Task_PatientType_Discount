﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPatientType
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(FrmPatientType))
        Panel1 = New Panel()
        btnPtTypeWiseDisc = New Button()
        chkIsDeactive = New CheckBox()
        chkIsActive = New CheckBox()
        btnClose = New Button()
        btnSave = New Button()
        btnUpdate = New Button()
        btnNew = New Button()
        txtPtType = New TextBox()
        Label2 = New Label()
        Panel2 = New Panel()
        btnSearchPtType = New Button()
        txtSearchPtType = New TextBox()
        Label3 = New Label()
        dgvPtType = New DataGridView()
        Label1 = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(dgvPtType, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Panel1.BackColor = Color.FromArgb(CByte(186), CByte(231), CByte(254))
        Panel1.Controls.Add(btnPtTypeWiseDisc)
        Panel1.Controls.Add(chkIsDeactive)
        Panel1.Controls.Add(chkIsActive)
        Panel1.Controls.Add(btnClose)
        Panel1.Controls.Add(btnSave)
        Panel1.Controls.Add(btnUpdate)
        Panel1.Controls.Add(btnNew)
        Panel1.Controls.Add(txtPtType)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(5, 57)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(338, 676)
        Panel1.TabIndex = 0
        ' 
        ' btnPtTypeWiseDisc
        ' 
        btnPtTypeWiseDisc.Location = New Point(7, 463)
        btnPtTypeWiseDisc.Name = "btnPtTypeWiseDisc"
        btnPtTypeWiseDisc.Size = New Size(230, 29)
        btnPtTypeWiseDisc.TabIndex = 11
        btnPtTypeWiseDisc.Text = "Pt Type Wise Discount"
        btnPtTypeWiseDisc.UseVisualStyleBackColor = True
        ' 
        ' chkIsDeactive
        ' 
        chkIsDeactive.AutoSize = True
        chkIsDeactive.BackColor = Color.FromArgb(CByte(186), CByte(231), CByte(254))
        chkIsDeactive.Font = New Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        chkIsDeactive.ForeColor = Color.DarkMagenta
        chkIsDeactive.Location = New Point(135, 103)
        chkIsDeactive.Name = "chkIsDeactive"
        chkIsDeactive.Size = New Size(95, 23)
        chkIsDeactive.TabIndex = 10
        chkIsDeactive.Text = "Deactive"
        chkIsDeactive.UseVisualStyleBackColor = False
        ' 
        ' chkIsActive
        ' 
        chkIsActive.AutoSize = True
        chkIsActive.BackColor = Color.FromArgb(CByte(186), CByte(231), CByte(254))
        chkIsActive.Font = New Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        chkIsActive.ForeColor = Color.DarkMagenta
        chkIsActive.Location = New Point(15, 103)
        chkIsActive.Name = "chkIsActive"
        chkIsActive.Size = New Size(78, 23)
        chkIsActive.TabIndex = 9
        chkIsActive.Text = "Active"
        chkIsActive.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.DarkOrange
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        btnClose.ForeColor = SystemColors.ButtonHighlight
        btnClose.Image = CType(resources.GetObject("btnClose.Image"), Image)
        btnClose.ImageAlign = ContentAlignment.MiddleLeft
        btnClose.Location = New Point(174, 607)
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
        btnSave.Location = New Point(8, 607)
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
        btnUpdate.Location = New Point(174, 528)
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
        btnNew.Location = New Point(8, 528)
        btnNew.Name = "btnNew"
        btnNew.Size = New Size(149, 61)
        btnNew.TabIndex = 5
        btnNew.Text = "New"
        btnNew.TextAlign = ContentAlignment.MiddleRight
        btnNew.UseVisualStyleBackColor = False
        ' 
        ' txtPtType
        ' 
        txtPtType.Font = New Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        txtPtType.ForeColor = Color.DeepPink
        txtPtType.Location = New Point(8, 43)
        txtPtType.Name = "txtPtType"
        txtPtType.Size = New Size(303, 27)
        txtPtType.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.DarkMagenta
        Label2.Location = New Point(7, 18)
        Label2.Name = "Label2"
        Label2.Size = New Size(106, 20)
        Label2.TabIndex = 3
        Label2.Text = "Patient Type"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(186), CByte(231), CByte(254))
        Panel2.Controls.Add(btnSearchPtType)
        Panel2.Controls.Add(txtSearchPtType)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(dgvPtType)
        Panel2.Location = New Point(349, 58)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(781, 675)
        Panel2.TabIndex = 1
        ' 
        ' btnSearchPtType
        ' 
        btnSearchPtType.BackColor = Color.DarkOrange
        btnSearchPtType.Font = New Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        btnSearchPtType.ForeColor = SystemColors.ButtonHighlight
        btnSearchPtType.Location = New Point(598, 70)
        btnSearchPtType.Name = "btnSearchPtType"
        btnSearchPtType.Size = New Size(145, 46)
        btnSearchPtType.TabIndex = 6
        btnSearchPtType.Text = "Search"
        btnSearchPtType.UseVisualStyleBackColor = False
        ' 
        ' txtSearchPtType
        ' 
        txtSearchPtType.Location = New Point(171, 27)
        txtSearchPtType.Name = "txtSearchPtType"
        txtSearchPtType.Size = New Size(572, 27)
        txtSearchPtType.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.DarkMagenta
        Label3.Location = New Point(25, 27)
        Label3.Name = "Label3"
        Label3.Size = New Size(106, 20)
        Label3.TabIndex = 4
        Label3.Text = "Patient Type"
        ' 
        ' dgvPtType
        ' 
        dgvPtType.BackgroundColor = Color.FromArgb(CByte(186), CByte(231), CByte(254))
        dgvPtType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPtType.Location = New Point(3, 122)
        dgvPtType.Name = "dgvPtType"
        dgvPtType.RowHeadersWidth = 51
        dgvPtType.RowTemplate.Height = 29
        dgvPtType.Size = New Size(759, 545)
        dgvPtType.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Times New Roman", 22.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.ButtonHighlight
        Label1.Location = New Point(12, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(216, 42)
        Label1.TabIndex = 2
        Label1.Text = "Patient Type"
        ' 
        ' FrmPatientType
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(0), CByte(102), CByte(102))
        ClientSize = New Size(1513, 737)
        Controls.Add(Label1)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "FrmPatientType"
        Text = "Form Patient Type"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(dgvPtType, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnNew As Button
    Friend WithEvents txtPtType As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents dgvPtType As DataGridView
    Friend WithEvents chkIsActive As CheckBox
    Friend WithEvents chkIsDeactive As CheckBox
    Friend WithEvents btnPtTypeWiseDisc As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSearchPtType As TextBox
    Friend WithEvents btnSearchPtType As Button
End Class
