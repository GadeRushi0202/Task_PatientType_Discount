﻿Imports System.Data.SqlClient

Public Class FrmPatientType

    Dim connectionString As String = "Data Source=DESKTOP-NUDMVOB\SQLEXPRESS; Initial Catalog=VbDotNet; Integrated Security=True"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataGridView()

        ' Set Active checkbox checked by default
        CheckBoxActive.Checked = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtPtType.Text) Then
            MessageBox.Show("Please fill in Item Name.")
            Return
        End If

        Dim ptTypeName As String = txtPtType.Text.Trim()
        Dim isActive As Boolean = CheckBoxActive.Checked

        Using con As New SqlConnection(connectionString)
            Try
                con.Open()

                ' Check if the PtType exists and its IsActive status
                Dim checkQuery As String = "SELECT IsActive FROM mst_PtType WHERE PtType = @PtType"
                Using checkCmd As New SqlCommand(checkQuery, con)
                    checkCmd.Parameters.AddWithValue("@PtType", ptTypeName)

                    Dim existingStatus As Object = checkCmd.ExecuteScalar()

                    If existingStatus IsNot Nothing Then
                        If Not CBool(existingStatus) Then
                            ' PtType is deactive, show a message but allow adding a new record
                            MessageBox.Show("If the PtType name already exists but is currently deactivated, it can be added again.")
                        Else
                            ' PtType is active, block addition
                            MessageBox.Show("Pt Type is already added.")
                            Return
                        End If
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
                        LoadDataGridView()
                    Else
                        MessageBox.Show("Data insertion failed.")
                    End If
                End Using

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

                DataGridView1.DataSource = table
                DataGridView1.Columns("Sr.No").DisplayIndex = 0
                DataGridView1.Columns("PtTypeId").Visible = False ' Hide the PtTypeId column
                DataGridView1.Columns("Sr.No").ReadOnly = True ' Make Sr.No column read-only
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

        ' Set Active checkbox checked by default
        CheckBoxActive.Checked = True
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
            txtPtType.Text = selectedRow.Cells("PtType").Value.ToString()
            selectedPtTypeId = CInt(selectedRow.Cells("PtTypeId").Value)
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

    Private Sub btnSearchPtType_Click(sender As Object, e As EventArgs) Handles btnSearchPtType.Click
        Dim searchText As String = txtSearchPtType.Text.Trim()

        If String.IsNullOrWhiteSpace(searchText) Then
            MessageBox.Show("Please enter a search term.")
            Return
        End If

        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM mst_PtType WHERE PtType LIKE @searchText"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@searchText", "%" & searchText & "%")
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()

            Try
                con.Open()
                adapter.Fill(table)

                If table.Rows.Count > 0 Then
                    ' Add a serial number column
                    table.Columns.Add("Sr.No", GetType(Integer))
                    For i As Integer = 0 To table.Rows.Count - 1
                        table.Rows(i)("Sr.No") = i + 1
                    Next

                    DataGridView1.DataSource = table
                    DataGridView1.Columns("Sr.No").DisplayIndex = 0
                    DataGridView1.Columns("PtTypeId").Visible = False ' Hide the PtTypeId column
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                Else
                    MessageBox.Show("No records found.")
                    DataGridView1.DataSource = Nothing
                End If

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmPtTypewiseDisc.Show()
    End Sub
End Class