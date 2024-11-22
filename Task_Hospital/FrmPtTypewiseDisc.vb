Imports System.Data.SqlClient

Public Class FrmPtTypewiseDisc
    'Dim connectionString As String = "Data Source=DESKTOP-NUDMVOB\SQLEXPRESS; Initial Catalog=VbDotNet; Integrated Security=True"

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCmbPtTypeWiseDisc()
        LoadDgvPtTypeWiseDisc()
        ' Set Active checkbox checked by default
        chkIsActive.Checked = True

    End Sub

    Private Sub LoadCmbPtTypeWiseDisc()
        Using con As SqlConnection = DatabaseHelper.GetConnection()
            Dim query As String = "SELECT * FROM mst_PtType WHERE IsActive = 1"
            Dim cmd As New SqlCommand(query, con)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()

            Try
                con.Open()
                adapter.Fill(table)

                cmbPtTypeWiseDiscount.DataSource = table
                cmbPtTypeWiseDiscount.DisplayMember = "PtType"
                cmbPtTypeWiseDiscount.ValueMember = "PtTypeId"
                cmbPtTypeWiseDiscount.SelectedIndex = -1
            Catch ex As Exception
                MessageBox.Show("An error occurred while loading data: " & ex.Message)
            End Try
        End Using
    End Sub

    Dim opIpType As Boolean

    Private Sub rbtnOPD_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOPD.CheckedChanged
        opIpType = rbtnOPD.Checked
    End Sub

    Private Sub rbtnIPD_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnIPD.CheckedChanged
        opIpType = Not rbtnIPD.Checked
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Check if a PtType is selected
        If cmbPtTypeWiseDiscount.SelectedIndex = -1 Then
            MessageBox.Show("Please select a PtType.")
            Return
        End If

        ' Check if a valid discount value is entered
        Dim discountValue As Integer
        If Not Integer.TryParse(txtDiscount.Text, discountValue) Then
            MessageBox.Show("Please enter a valid discount value.")
            Return
        End If

        ' Check if either OPD or IPD is selected
        If Not rbtnOPD.Checked AndAlso Not rbtnIPD.Checked Then
            MessageBox.Show("Please select either OPD or IPD.")
            Return
        End If
        ' Validate Active/Deactive selection
        If Not (chkIsActive.Checked Or chkIsDeactive.Checked) Then
            MessageBox.Show("Please select at least one status: Active or Deactive.")
            Return
        End If
        ' Get selected values
        Dim selectedPtTypeId As Integer = CInt(cmbPtTypeWiseDiscount.SelectedValue)
        Dim isActive As Boolean = chkIsActive.Checked
        Dim opIpType As Boolean = rbtnOPD.Checked ' OPD is true, IPD is false

        Using con As SqlConnection = DatabaseHelper.GetConnection()
            Dim query As String = "INSERT INTO mst_PtTypeWiseDiscount (OpIpType, PtTypeId, Discount, IsActive) VALUES (@OpIpType, @PtTypeId, @Discount, @IsActive)"
            Dim cmd As New SqlCommand(query, con)

            cmd.Parameters.AddWithValue("@OpIpType", opIpType)
            cmd.Parameters.AddWithValue("@PtTypeId", selectedPtTypeId)
            cmd.Parameters.AddWithValue("@Discount", discountValue)
            cmd.Parameters.AddWithValue("@IsActive", If(isActive, 1, 0))

            Try
                con.Open()
                Dim result As Integer = cmd.ExecuteNonQuery()

                If result > 0 Then
                    MessageBox.Show("Data inserted successfully.")
                    LoadDgvPtTypeWiseDisc()
                Else
                    MessageBox.Show("Data insertion failed.")
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub


    Private Sub LoadDgvPtTypeWiseDisc()
        Using con As SqlConnection = DatabaseHelper.GetConnection()
            Dim query As String = "SELECT d.Id, " &
                              "IIF(d.OpIpType = 1, 'OPD', 'IPD') AS OpIpType, " &
                              "p.PtType AS PatientType, " &
                              "p.PtTypeId, " &
                              "d.Discount, " &
                              "d.IsActive " &
                              "FROM mst_PtTypeWiseDiscount d " &
                              "JOIN mst_PtType p ON d.PtTypeId = p.PtTypeId"
            Dim cmd As New SqlCommand(query, con)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()

            Try
                con.Open()
                adapter.Fill(table)

                ' Add "Sr.No" column
                table.Columns.Add("Sr.No", GetType(Integer))
                For i As Integer = 0 To table.Rows.Count - 1
                    table.Rows(i)("Sr.No") = i + 1
                Next

                dgvPtTypeWiseDiscount.DataSource = table

                ' Set display order and visibility of columns
                dgvPtTypeWiseDiscount.Columns("Sr.No").DisplayIndex = 0
                dgvPtTypeWiseDiscount.Columns("Id").Visible = False
                dgvPtTypeWiseDiscount.Columns("PtTypeId").Visible = False

                dgvPtTypeWiseDiscount.Columns("Sr.No").ReadOnly = True
                dgvPtTypeWiseDiscount.Columns("OpIpType").ReadOnly = True
                dgvPtTypeWiseDiscount.Columns("PatientType").ReadOnly = True
                dgvPtTypeWiseDiscount.Columns("Discount").ReadOnly = True
                dgvPtTypeWiseDiscount.Columns("IsActive").ReadOnly = True

                dgvPtTypeWiseDiscount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub

    Private selectedPtTypeId As Integer
    Private Sub dgvPtTypeWiseDiscount_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPtTypeWiseDiscount.CellClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvPtTypeWiseDiscount.Rows(e.RowIndex)

            Dim ptTypeId As Object = selectedRow.Cells("PtTypeId").Value
            If ptTypeId IsNot Nothing AndAlso IsNumeric(ptTypeId) Then
                cmbPtTypeWiseDiscount.SelectedValue = Convert.ToInt32(ptTypeId)
            Else
                MessageBox.Show("Invalid Patient Type ID.")
                Return
            End If

            selectedPtTypeId = CInt(selectedRow.Cells("Id").Value)

            Dim opIpTypeValue As Object = selectedRow.Cells("OpIpType").Value
            If opIpTypeValue IsNot Nothing Then
                If opIpTypeValue.ToString() = "OPD" Then
                    rbtnOPD.Checked = True
                    rbtnIPD.Checked = False
                ElseIf opIpTypeValue.ToString() = "IPD" Then
                    rbtnOPD.Checked = False
                    rbtnIPD.Checked = True
                End If
            End If
            Dim discountValue As Object = selectedRow.Cells("Discount").Value
            If discountValue IsNot Nothing Then
                txtDiscount.Text = Convert.ToString(discountValue)
            End If

            ' Handle Active/Deactive checkbox selection
            ' Handle Active/Deactive checkbox selection
            Dim isActiveValue As Object = selectedRow.Cells("IsActive").Value
            If isActiveValue IsNot DBNull.Value Then
                Dim isActive As Boolean = Convert.ToBoolean(isActiveValue)
                chkIsActive.Checked = isActive
                chkIsDeactive.Checked = Not isActive
            Else
                chkIsActive.Checked = False
                chkIsDeactive.Checked = False
            End If
        End If
    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedPtTypeId = 0 Then
            MessageBox.Show("Please select a record to update.")
            Return
        End If
        If Not (chkIsActive.Checked Or chkIsDeactive.Checked) Then
            MessageBox.Show("Please select at least one status: Active or Deactive.")
            Return
        End If
        Dim opIpType As Boolean = rbtnOPD.Checked

        Using con As SqlConnection = DatabaseHelper.GetConnection()
            Dim cmd As New SqlCommand("UPDATE mst_PtTypeWiseDiscount SET PtTypeId = @PtTypeId, OpIpType = @OpIpType, Discount = @Discount WHERE Id = @Id", con)

            Dim ptTypeId As Integer
            If cmbPtTypeWiseDiscount.SelectedValue IsNot Nothing Then
                ptTypeId = Convert.ToInt32(cmbPtTypeWiseDiscount.SelectedValue)
            Else
                MessageBox.Show("Please select a valid PtType from the ComboBox.")
                Return
            End If

            Dim discountValue As Integer
            If Not Integer.TryParse(txtDiscount.Text, discountValue) Then
                MessageBox.Show("Please enter a valid discount value.")
                Return
            End If
            cmd.Parameters.AddWithValue("@PtTypeId", ptTypeId)
            cmd.Parameters.AddWithValue("@OpIpType", opIpType)
            cmd.Parameters.AddWithValue("@Discount", discountValue)
            cmd.Parameters.AddWithValue("@Id", selectedPtTypeId)

            Try
                con.Open()
                Dim result As Integer = cmd.ExecuteNonQuery()

                If result > 0 Then
                    MessageBox.Show("Data updated successfully.")
                    LoadDgvPtTypeWiseDisc()
                Else
                    MessageBox.Show("Data update failed.")
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub CheckBoxActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsActive.CheckedChanged
        If chkIsActive.Checked Then
            chkIsDeactive.Checked = False
        End If
    End Sub

    Private Sub CheckBoxDeactive_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsDeactive.CheckedChanged
        If chkIsDeactive.Checked Then
            chkIsActive.Checked = False
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        cmbPtTypeWiseDiscount.SelectedIndex = -1
        txtDiscount.Clear()
        rbtnOPD.Checked = False
        rbtnIPD.Checked = False
        chkIsActive.Checked = True
        chkIsDeactive.Checked = False
        selectedPtTypeId = 0
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSearchPtType_Click(sender As Object, e As EventArgs) Handles btnSearchPtType.Click
        Dim searchText As String = txtSearchPtType.Text.Trim()

        If String.IsNullOrWhiteSpace(searchText) Then
            MessageBox.Show("Please enter a search term.")
            Return
        End If

        Using con As SqlConnection = DatabaseHelper.GetConnection()
            Dim query As String = "SELECT d.Id, " &
                                  "IIF(d.OpIpType = 1, 'OPD', 'IPD') AS OpIpType, " &
                                  "p.PtType AS PatientType, " &
                                  "p.PtTypeId, " &
                                  "d.Discount, " &
                                  "d.IsActive " &
                                  "FROM mst_PtTypeWiseDiscount d " &
                                  "JOIN mst_PtType p ON d.PtTypeId = p.PtTypeId " &
                                  "WHERE p.PtType LIKE @SearchText AND d.IsActive = 1"

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@searchText", "%" & searchText & "%")
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()

            Try
                con.Open()
                adapter.Fill(table)

                If table.Rows.Count > 0 Then
                    table.Columns.Add("Sr.No", GetType(Integer))
                    For i As Integer = 0 To table.Rows.Count - 1
                        table.Rows(i)("Sr.No") = i + 1
                    Next
                    dgvPtTypeWiseDiscount.DataSource = table

                    dgvPtTypeWiseDiscount.Columns("Sr.No").DisplayIndex = 0
                    dgvPtTypeWiseDiscount.Columns("Id").Visible = False
                    dgvPtTypeWiseDiscount.Columns("PtTypeId").Visible = False
                    dgvPtTypeWiseDiscount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                Else
                    MessageBox.Show("No matching records found.")
                    dgvPtTypeWiseDiscount.DataSource = Nothing
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub
End Class