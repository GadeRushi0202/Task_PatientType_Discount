Imports System.Data.SqlClient

Public Class Form2
    Dim connectionString As String = "Data Source=DESKTOP-NUDMVOB\SQLEXPRESS; Initial Catalog=VbDotNet; Integrated Security=True"

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPtTypeComboBox()
        LoadDataGridView()
    End Sub

    Private Sub LoadPtTypeComboBox()
        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM mst_PtType"
            Dim cmd As New SqlCommand(query, con)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()

            Try
                con.Open()
                adapter.Fill(table)

                ComboBoxPtType.DataSource = table
                ComboBoxPtType.DisplayMember = "PtType"
                ComboBoxPtType.ValueMember = "PtTypeId"
                ComboBoxPtType.SelectedIndex = -1
            Catch ex As Exception
                MessageBox.Show("An error occurred while loading data: " & ex.Message)
            End Try
        End Using
    End Sub

    Dim opIpType As Boolean

    Private Sub RadioButtonOPD_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonOPD.CheckedChanged
        opIpType = RadioButtonOPD.Checked
    End Sub

    Private Sub RadioButtonIPD_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonIPD.CheckedChanged
        opIpType = Not RadioButtonIPD.Checked
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ComboBoxPtType.SelectedIndex = -1 Then
            MessageBox.Show("Please select a PtType.")
            Return
        End If

        Dim selectedPtTypeId As Integer = CInt(ComboBoxPtType.SelectedValue)

        Dim discountValue As Integer
        If Not Integer.TryParse(txtDiscount.Text, discountValue) Then
            MessageBox.Show("Please enter a valid discount value.")
            Return
        End If
        Dim isActive As Boolean = CheckBoxActive.Checked
        Using con As New SqlConnection(connectionString)
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
                    LoadDataGridView()
                Else
                    MessageBox.Show("Data insertion failed.")
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub LoadDataGridView()
        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT d.Id, " &
                              "IIF(d.OpIpType = 1, 'OPD', 'IPD') AS OpIpType, " &
                              "p.PtType AS PatientType, " &
                              "p.PtTypeId, " &
                              "d.Discount, " &
                              "d.IsActive " &
                              "FROM mst_PtTypeWiseDiscount d " &
                              "JOIN mst_PtType p ON d.PtTypeId = p.PtTypeId " &
                              "WHERE d.IsActive = 1"
            Dim cmd As New SqlCommand(query, con)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()

            Try
                con.Open()
                adapter.Fill(table)
                table.Columns.Add("Sr.No", GetType(Integer))

                For i As Integer = 0 To table.Rows.Count - 1
                    table.Rows(i)("Sr.No") = i + 1
                Next
                DataGridView1.DataSource = table

                DataGridView1.Columns("Sr.No").DisplayIndex = 0

                DataGridView1.Columns("Id").Visible = False

                DataGridView1.Columns("PtTypeId").Visible = False

                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub


    Private selectedPtTypeId As Integer
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            Dim ptTypeId As Object = selectedRow.Cells("PtTypeId").Value
            If ptTypeId IsNot Nothing AndAlso IsNumeric(ptTypeId) Then
                ComboBoxPtType.SelectedValue = Convert.ToInt32(ptTypeId)
            Else
                MessageBox.Show("Invalid Patient Type ID.")
                Return
            End If

            selectedPtTypeId = CInt(selectedRow.Cells("Id").Value)

            Dim opIpTypeValue As Object = selectedRow.Cells("OpIpType").Value
            If opIpTypeValue IsNot Nothing Then
                If opIpTypeValue.ToString() = "OPD" Then
                    RadioButtonOPD.Checked = True
                    RadioButtonIPD.Checked = False
                ElseIf opIpTypeValue.ToString() = "IPD" Then
                    RadioButtonOPD.Checked = False
                    RadioButtonIPD.Checked = True
                End If
            End If
            Dim discountValue As Object = selectedRow.Cells("Discount").Value
            If discountValue IsNot Nothing Then
                txtDiscount.Text = Convert.ToString(discountValue)
            End If

            Dim isActiveValue As Object = selectedRow.Cells("IsActive").Value
            If isActiveValue IsNot Nothing Then
                CheckBoxActive.Checked = Convert.ToBoolean(isActiveValue)
                CheckBoxDeactive.Checked = Not CheckBoxActive.Checked
            End If
        End If
    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedPtTypeId = 0 Then
            MessageBox.Show("Please select a record to update.")
            Return
        End If

        Dim opIpType As Boolean = RadioButtonOPD.Checked

        Using con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("UPDATE mst_PtTypeWiseDiscount SET PtTypeId = @PtTypeId, OpIpType = @OpIpType, Discount = @Discount WHERE Id = @Id", con)

            Dim ptTypeId As Integer
            If ComboBoxPtType.SelectedValue IsNot Nothing Then
                ptTypeId = Convert.ToInt32(ComboBoxPtType.SelectedValue)
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
                    LoadDataGridView()
                Else
                    MessageBox.Show("Data update failed.")
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
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

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        ComboBoxPtType.SelectedIndex = -1
        txtDiscount.Clear()
        RadioButtonOPD.Checked = False
        RadioButtonIPD.Checked = False
        CheckBoxActive.Checked = False
        CheckBoxDeactive.Checked = False
        selectedPtTypeId = 0
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
