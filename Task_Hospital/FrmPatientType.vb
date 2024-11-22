Imports System.Data.SqlClient

Public Class FrmPatientType
    Private selectedPtTypeId As Integer

    Private Sub FrmPatientType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDgvPtType()

        ' Set Active checkbox checked by default
        chkIsActive.Checked = True
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtPtType.Text) Then
            MessageBox.Show("Please fill in the PtType.")
            Return
        End If
        ' Validate Active/Deactive selection
        If Not (chkIsActive.Checked Or chkIsDeactive.Checked) Then
            MessageBox.Show("Please select at least one status: Active or Deactive.")
            Return
        End If

        Dim ptTypeName As String = txtPtType.Text.Trim()
        Dim isActive As Boolean = chkIsActive.Checked

        Using con As SqlConnection = DatabaseHelper.GetConnection()
            Try
                con.Open()

                ' Check all existing PtType records
                Dim checkQuery As String = "SELECT IsActive FROM mst_PtType WHERE PtType = @PtType"
                Using checkCmd As New SqlCommand(checkQuery, con)
                    checkCmd.Parameters.AddWithValue("@PtType", ptTypeName)

                    Dim hasActive As Boolean = False
                    Dim hasDeactive As Boolean = False

                    Using reader As SqlDataReader = checkCmd.ExecuteReader()
                        While reader.Read()
                            Dim status As Boolean = reader.GetBoolean(0)
                            If status Then
                                hasActive = True
                            Else
                                hasDeactive = True
                            End If
                        End While
                    End Using

                    ' Decision based on the existing records
                    If hasActive And hasDeactive Then
                        MessageBox.Show("Pt Type already exists both as active and Deactive. Cannot insert duplicate data.")
                        Return
                    ElseIf hasActive Then
                        MessageBox.Show("Pt Type is already added and active.")
                        Return
                    ElseIf hasDeactive Then
                        MessageBox.Show("Pt Type exists as Deactive and will be added again.")
                    End If
                End Using

                ' Insert a new PtType record
                Dim insertQuery As String = "INSERT INTO mst_PtType (PtType, IsActive) VALUES (@PtType, @IsActive)"
                Using insertCmd As New SqlCommand(insertQuery, con)
                    insertCmd.Parameters.AddWithValue("@PtType", ptTypeName)
                    insertCmd.Parameters.AddWithValue("@IsActive", If(isActive, 1, 0))

                    Dim result As Integer = insertCmd.ExecuteNonQuery()
                    If result >= 1 Then
                        MessageBox.Show("Data inserted successfully.")
                        LoadDgvPtType()
                    Else
                        MessageBox.Show("Data insertion failed.")
                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try

            ClearFields()
        End Using
    End Sub

    Private Sub LoadDgvPtType()
        Using con As SqlConnection = DatabaseHelper.GetConnection()
            Dim query As String = "SELECT * FROM mst_PtType"
            Dim cmd As New SqlCommand(query, con)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()

            Try
                con.Open()
                adapter.Fill(table)

                ' Add a serial number column
                table.Columns.Add("Sr.No", GetType(Integer))
                For i As Integer = 0 To table.Rows.Count - 1
                    table.Rows(i)("Sr.No") = i + 1
                Next

                dgvPtType.DataSource = table
                dgvPtType.Columns("Sr.No").DisplayIndex = 0
                dgvPtType.Columns("PtTypeId").Visible = False ' Hide the PtTypeId column
                dgvPtType.Columns("Sr.No").ReadOnly = True ' Make Sr.No column read-only
                dgvPtType.Columns("PtType").ReadOnly = True
                dgvPtType.Columns("IsActive").ReadOnly = True
                dgvPtType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtPtType.Clear()

        ' Set Active checkbox checked by default
        chkIsActive.Checked = True
        chkIsDeactive.Checked = False
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

        Dim isActive As Boolean = chkIsActive.Checked
        Using con As SqlConnection = DatabaseHelper.GetConnection()
            Dim cmd As New SqlCommand("UPDATE mst_PtType SET PtType = @PtType, IsActive = @IsActive WHERE PtTypeId = @PtTypeId", con)
            cmd.Parameters.AddWithValue("@PtType", txtPtType.Text)
            cmd.Parameters.AddWithValue("@IsActive", If(isActive, 1, 0))
            cmd.Parameters.AddWithValue("@PtTypeId", selectedPtTypeId)

            Try
                con.Open()
                Dim result As Integer = cmd.ExecuteNonQuery()

                If result > 0 Then
                    MessageBox.Show("Data updated successfully.")
                    LoadDgvPtType()
                Else
                    MessageBox.Show("Data update failed.")
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub dgvPtType_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPtType.CellClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvPtType.Rows(e.RowIndex)
            txtPtType.Text = selectedRow.Cells("PtType").Value.ToString()
            selectedPtTypeId = CInt(selectedRow.Cells("PtTypeId").Value)
            Dim isActive As Boolean = CBool(selectedRow.Cells("IsActive").Value)
            chkIsActive.Checked = isActive
            chkIsDeactive.Checked = Not isActive
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chkIsActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsActive.CheckedChanged
        If chkIsActive.Checked Then
            chkIsDeactive.Checked = False
        End If
    End Sub

    Private Sub chkIsDeactive_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsDeactive.CheckedChanged
        If chkIsDeactive.Checked Then
            chkIsActive.Checked = False
        End If
    End Sub

    Private Sub btnSearchPtType_Click(sender As Object, e As EventArgs) Handles btnSearchPtType.Click
        Dim searchText As String = txtSearchPtType.Text.Trim()

        If String.IsNullOrWhiteSpace(searchText) Then
            MessageBox.Show("Please enter a search term.")
            Return
        End If

        Using con As SqlConnection = DatabaseHelper.GetConnection()
            Dim query As String = "SELECT * FROM mst_PtType WHERE PtType LIKE @searchText"
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

                    dgvPtType.DataSource = table
                    dgvPtType.Columns("Sr.No").DisplayIndex = 0
                    dgvPtType.Columns("PtTypeId").Visible = False
                    dgvPtType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                Else
                    MessageBox.Show("No records found.")
                    dgvPtType.DataSource = Nothing
                End If

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnPtTypeWiseDisc_Click(sender As Object, e As EventArgs) Handles btnPtTypeWiseDisc.Click
        FrmPtTypewiseDisc.Show()
    End Sub
End Class
