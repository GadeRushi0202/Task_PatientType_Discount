Imports System.Data.SqlClient

Public Class FrmPtTypewiseDisc
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPtTypeComboBox()
        LoadDataGridView()
        ' Set Active checkbox checked by default
        CheckBoxActive.Checked = True
    End Sub

    Private Sub LoadPtTypeComboBox()
        Using con As SqlConnection = DatabaseHelper.GetConnection()
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validation checks
        If ComboBoxPtType.SelectedIndex = -1 Then
            MessageBox.Show("Please select a PtType.")
            Return
        End If

        Dim discountValue As Integer
        If Not Integer.TryParse(txtDiscount.Text, discountValue) Then
            MessageBox.Show("Please enter a valid discount value.")
            Return
        End If

        If Not RadioButtonOPD.Checked AndAlso Not RadioButtonIPD.Checked Then
            MessageBox.Show("Please select either OPD or IPD.")
            Return
        End If

        ' Data insertion
        Dim selectedPtTypeId As Integer = CInt(ComboBoxPtType.SelectedValue)
        Dim isActive As Boolean = CheckBoxActive.Checked
        Dim opIpType As Boolean = RadioButtonOPD.Checked

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
End Class
