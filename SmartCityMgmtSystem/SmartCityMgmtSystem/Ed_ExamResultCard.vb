﻿Imports System.IO

Public Class Ed_ExamResultCard
    Public UserID As Integer
    Public UserName As String
    Public ExamName As String
    Public Rank As Integer
    Public Date_Time As Date
    Public ProfilePhoto As Byte()
    Private entranceExamHandler As New Ed_EntranceExam_Handler()
    Private Sub Ed_ExamResultCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Assuming labels 7 to 11 exist on the form

        Label7.Text = UserName ' Set label text to UserID value as string
        Label8.Text = UserID.ToString()
        Label9.Text = ExamName
        Label14.Text = Rank.ToString()  ' Set label text to Rank value as string
        Label11.Text = Date_Time.ToShortDateString()  ' Format date for user-friendly display
        If ProfilePhoto Is Nothing Then
            ' Handle no picture found
            Exit Sub
        End If
        Dim imageStream As New MemoryStream(ProfilePhoto)
        Dim userPicture As Image = Image.FromStream(imageStream)
        PictureBox1.BackgroundImage = userPicture
    End Sub
End Class