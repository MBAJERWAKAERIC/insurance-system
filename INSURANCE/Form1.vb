Imports MySql.Data.MySqlClient
Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select * from  insurance.login where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "';", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()
            Dim count As Integer = 0
            If (myReader.HasRows()) Then
                count = count + 1
            End If
            If (count = 1) Then
                MessageBox.Show("username and password correct and access granted")
                TextBox1.Text = ""
                TextBox2.Text = ""
                HOME.Show()
                Me.Visible = False
            ElseIf (count > 1) Then
                MessageBox.Show("Duplicate user and access denied")
            Else
                MessageBox.Show("username and password does not macth")
            End If
            mycon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        CREATE.Show()
    End Sub
End Class
