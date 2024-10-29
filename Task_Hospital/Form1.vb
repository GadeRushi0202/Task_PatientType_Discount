Imports System.Data.SqlClient

Public Class Form1

    Dim connectionString As String = "Data Source=DESKTOP-NUDMVOB\SQLEXPRESS; Initial Catalog=VbDotNet; Integrated Security=True"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataGridView()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtPtType.Text) Then
            MessageBox.Show("Please fill in Item Name.")
            Return
        End If

        Dim isActive As Boolean = CheckBoxActive.Checked

        Using con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("INSERT INTO mst_PtType (PtType, IsActive) VALUES (@PtType, @IsActive)", con)
            cmd.Parameters.AddWithValue("@PtType", txtPtType.Text)
            cmd.Parameters.AddWithValue("@IsActive", If(isActive, 1, 0))
            Try
                con.Open()
                Dim result As Integer = cmd.ExecuteNonQuery()

                If result >= 1 Then
                    MessageBox.Show("Data inserted successfully.")
                    LoadDataGridView()
                Else
                    MessageBox.Show("Data insertion failed.")
                End If

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            Finally
                con.Close()
            End Try
            ClearFields()
        End Using
    End Sub

    Private Sub LoadDataGridView()
        Using con As New SqlConnection(connectionString)
            ' Selecting all records (including both active and inactive)
            Dim query As String = "SELECT * FROM mst_PtType where isActive = 1"
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

                DataGridView1.DataSource = table
                DataGridView1.Columns("Sr.No").DisplayIndex = 0
                DataGridView1.Columns("PtTypeId").Visible = False ' Hide the PtTypeId column
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

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
        CheckBoxActive.Checked = False
        CheckBoxDeactive.Checked = False
    End Sub

    Private selectedPtTypeId As Integer

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedPtTypeId = 0 Then
            MessageBox.Show("Please select a record to update.")
            Return
        End If

        Dim isActive As Boolean = CheckBoxActive.Checked
        Using con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("UPDATE mst_PtType SET PtType = @PtType, IsActive = @IsActive WHERE PtTypeId = @PtTypeId", con)
            cmd.Parameters.AddWithValue("@PtType", txtPtType.Text)
            cmd.Parameters.AddWithValue("@IsActive", If(isActive, 1, 0))
            cmd.Parameters.AddWithValue("@PtTypeId", selectedPtTypeId)

            Try
                con.Open()
                Dim result As Integer = cmd.ExecuteNonQuery()

                If result > 0 Then
                    MessageBox.Show("Data updated successfully.")
                    LoadDataGridView()
                Else
                    MessageBox.Show("Data update failed.")
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            ' Display the PtType in txtPtType
            txtPtType.Text = selectedRow.Cells("PtType").Value.ToString()

            ' Update selectedPtTypeId for further operations
            selectedPtTypeId = CInt(selectedRow.Cells("PtTypeId").Value)

            ' Update checkboxes based on the active status
            Dim isActive As Boolean = CBool(selectedRow.Cells("IsActive").Value)
            CheckBoxActive.Checked = isActive
            CheckBoxDeactive.Checked = Not isActive
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub CheckBoxActive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxActive.CheckedChanged
        If CheckBoxActive.Checked Then
            CheckBoxDeactive.Checked = False
        End If
    End Sub

    Private Sub CheckBoxDeactive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDeactive.CheckedChanged
        If CheckBoxDeactive.Checked Then
            CheckBoxActive.Checked = False
        End If
    End Sub

End Class
