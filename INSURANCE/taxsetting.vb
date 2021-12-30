Imports MySql.Data.MySqlClient
Public Class taxsetting

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub policies_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles policies.SelectedIndexChanged

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Hide()
        HOME.Show()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.Hide()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("insert into  insurance.tax(member_id,financial_year,category,charges,bonus_rate) values('" & TextBox1.Text & "','" & ComboBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "') ", mycon)
            Dim myReader As MySqlDataReader
            mycon.Open()
            myReader = SelectCommand.ExecuteReader()
            MessageBox.Show("Data has been saved")

            TextBox1.Text = ""
            ComboBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            ComboBox1.Text = ""
           

            mycon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim constring As String = "datasource=localhost;port=3306;username=root;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("Select * from  insurance.tax ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView1.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("update  insurance.tax set financial_year='" & ComboBox1.Text & "',category='" & TextBox3.Text & "',charges='" & TextBox4.Text & "',bonus_rate='" & ComboBox1.Text & "' where member_id='" & TextBox1.Text & "' ", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()


            myReader = SelectCommand.ExecuteReader()
            MessageBox.Show("Data has been updated")


            mycon.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
End Class