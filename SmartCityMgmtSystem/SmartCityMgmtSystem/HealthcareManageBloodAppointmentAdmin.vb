﻿Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports MySql.Data.MySqlClient
Public Class HealthcareManageBloodAppointmentAdmin
    Private primaryKeyEdit As String

    Private Sub ShowEditOption(ByVal txt1 As String, ByVal txt2 As String, ByVal txt3 As String, ByVal txt4 As String, ByVal txt5 As String, ByVal txt6 As String)
        Label3.Text = "Update Blood Donation Appointment"
        Button1.Text = "Update"
        TextBox6.Text = txt1
        TextBox3.Text = txt2
        TextBox2.Text = txt3
        DateTimePicker1.Text = txt4
        TextBox5.Text = txt5
        TextBox1.Text = txt6

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Check if the clicked cell is in the "EditBut" column and not a header cell
        If e.ColumnIndex = DataGridView1.Columns("EditBut").Index AndAlso e.RowIndex >= 0 Then
            ' Change this to DB logic later
            'MessageBox.Show("Edit button clicked for row " & e.RowIndex.ToString(), "Edit Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            primaryKeyEdit = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            ShowEditOption(DataGridView1.Rows(e.RowIndex).Cells(0).Value, DataGridView1.Rows(e.RowIndex).Cells(1).Value, DataGridView1.Rows(e.RowIndex).Cells(2).Value, DataGridView1.Rows(e.RowIndex).Cells(3).Value, DataGridView1.Rows(e.RowIndex).Cells(4).Value, DataGridView1.Rows(e.RowIndex).Cells(5).Value)

            ' Check if the clicked cell is in the "DeleteBut" column and not a header cell
        ElseIf e.ColumnIndex = DataGridView1.Columns("DeleteBut").Index AndAlso e.RowIndex >= 0 Then
            ' Perform the action for the "DeleteButton" column
            'MessageBox.Show("Delete button clicked for row " & e.RowIndex.ToString(), "Delete Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this entry?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then

                ' Call a method to delete the row from the database using the primary key
                Dim success As Boolean = Globals.ExecuteDeleteQuery("DELETE FROM blood_donation where Blood_donation_id = " & DataGridView1.Rows(e.RowIndex).Cells(0).Value)

                If success Then
                    ' If deletion is successful, then refresh the datagridview
                    LoadandBindDataGridView()
                End If

            End If
        End If
    End Sub

    Private Sub LoadandBindDataGridView()
        'Get connection from globals
        Dim Con = Globals.GetDBConnection()
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand

        Try
            Con.Open()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        cmd = New MySqlCommand("SELECT * FROM blood_donation", Con)
        reader = cmd.ExecuteReader
        ' Create a DataTable to store the data
        Dim dataTable As New DataTable()

        'Fill the DataTable with data from the SQL table
        dataTable.Load(reader)
        reader.Close()
        Con.Close()

        'IMP: Specify the Column Mappings from DataGridView to SQL Table
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Columns(0).DataPropertyName = "Blood_Donation_id"
        DataGridView1.Columns(1).DataPropertyName = "hospital_ID"
        DataGridView1.Columns(2).DataPropertyName = "patient_ID"
        DataGridView1.Columns(3).DataPropertyName = "time"
        DataGridView1.Columns(4).DataPropertyName = "status"
        DataGridView1.Columns(5).DataPropertyName = "Blood_grp"

        ' Bind the data to DataGridView
        DataGridView1.DataSource = dataTable
    End Sub

    Private Sub TransportationInnerScreen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Dummy Data, Change it to LoadandBindDataGridView() 
        'For i As Integer = 1 To 8
        '    ' Add an empty row to the DataGridView
        '    Dim row As New DataGridViewRow()
        '    DataGridView1.Rows.Add(row)

        '    ' Set values for the first three columns in the current row
        '    DataGridView1.Rows(i - 1).Cells("Column1").Value = "DummyVal"
        '    DataGridView1.Rows(i - 1).Cells("Column2").Value = "DummyVal"
        '    DataGridView1.Rows(i - 1).Cells("Column3").Value = "DummyVal"
        'Next
        LoadandBindDataGridView()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label3.Text = "Add Appointment Details"
        Button1.Text = "Add"
        TextBox6.Clear()
        TextBox3.Clear()
        TextBox2.Clear()

        TextBox5.Clear()
        TextBox1.Clear()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox6.Text) Then
            MessageBox.Show("Please enter some input in the textbox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Label3.Text = "Add Appointment Details"
            Button1.Text = "Add"
            TextBox6.Clear()
            TextBox3.Clear()
            TextBox2.Clear()

            TextBox5.Clear()
            TextBox1.Clear()
            Return
        End If
        If String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("Please enter some input in the textbox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Label3.Text = "Add Appointment Details"
            Button1.Text = "Add"
            TextBox6.Clear()
            TextBox3.Clear()
            TextBox2.Clear()

            TextBox5.Clear()
            TextBox1.Clear()
            Return
        End If
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Please enter some input in the textbox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Label3.Text = "Add Appointment Details"
            Button1.Text = "Add"
            TextBox6.Clear()
            TextBox3.Clear()
            TextBox2.Clear()

            TextBox5.Clear()
            TextBox1.Clear()
            Return
        End If

        If String.IsNullOrWhiteSpace(TextBox5.Text) Then
            MessageBox.Show("Please enter some input in the textbox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Label3.Text = "Add Appointment Details"
            Button1.Text = "Add"
            TextBox6.Clear()
            TextBox3.Clear()
            TextBox2.Clear()

            TextBox5.Clear()
            TextBox1.Clear()
            Return
        End If
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Please enter some input in the textbox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Label3.Text = "Add Appointment Details"
            Button1.Text = "Add"
            TextBox6.Clear()
            TextBox3.Clear()
            TextBox2.Clear()

            TextBox5.Clear()
            TextBox1.Clear()
            Return
        End If
        If Button1.Text = "Update" Then
            Dim cmd As String
            cmd = "UPDATE blood_donation SET Blood_Donation_id = " & Convert.ToInt32(TextBox6.Text) & " , hospital_ID = " & Convert.ToInt32(TextBox3.Text) & " , patient_ID =" & Convert.ToInt32(TextBox2.Text) & " , time = '" & DateTimePicker1.Value.Date.ToString("yyyyMMdd") & "' , status = '" & TextBox5.Text & "' , Blood_grp = '" & TextBox1.Text & "' WHERE Blood_Donation_id =" & primaryKeyEdit
            Dim success As Boolean = Globals.ExecuteUpdateQuery(cmd)
            If success Then
                LoadandBindDataGridView()
            End If
            Label3.Text = "Add Fastag Plan"
            Button1.Text = "Add"
            TextBox6.Clear()
            TextBox3.Clear()
            TextBox2.Clear()

            TextBox5.Clear()
            TextBox1.Clear()
        Else
            Dim cmd As String
            cmd = "INSERT into blood_donation(Blood_Donation_id,hospital_ID,patient_ID,time,status,Blood_grp) VALUES (" & Convert.ToInt32(TextBox6.Text) & "," & Convert.ToInt32(TextBox3.Text) & "," & Convert.ToInt32(TextBox2.Text) & ",'" & DateTimePicker1.Value.Date.ToString("yyyyMMdd") & "','" & TextBox5.Text & "','" & TextBox1.Text & "')"
            Dim success As Boolean = Globals.ExecuteInsertQuery(cmd)
            If success Then
                LoadandBindDataGridView()
            End If
            TextBox6.Clear()
            TextBox3.Clear()
            TextBox2.Clear()

            TextBox5.Clear()
            TextBox1.Clear()
        End If
    End Sub

End Class