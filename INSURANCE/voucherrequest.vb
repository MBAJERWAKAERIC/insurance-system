Imports MySql.Data.MySqlClient
Imports System.IO
Public Class voucherrequest
    Dim i As Integer
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
            Dim SelectCommand As MySqlCommand = New MySqlCommand("insert into  insurance.voucher(member_id,firstname,lastname,date,voucher_number,service_required,insurance_type,total_claim,contact) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & DateTimePicker1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "') ", mycon)
            Dim myReader As MySqlDataReader
            mycon.Open()
            myReader = SelectCommand.ExecuteReader()
            MessageBox.Show("Data has been saved")

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            DateTimePicker1.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""

            mycon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim constring As String = "datasource=localhost;port=3306;username=root;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("Select * from  insurance.voucher ", conDatabase)
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

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        DateTimePicker1.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("delete from insurance.voucher  where member_id='" & TextBox1.Text & "' ", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()
            MessageBox.Show("Data has been deleted")

            mycon.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim constring As String = "datasource=localhost;port=3306;username=root;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("Select * from  insurance.voucher where member_id='" + TextBox1.Text + "' ;", conDatabase)
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
            Dim SelectCommand As MySqlCommand = New MySqlCommand("update  insurance.voucher set firstname='" & TextBox2.Text & "',lastname='" & TextBox3.Text & "',date='" & DateTimePicker1.Text & "',voucher_number='" & TextBox4.Text & "',service_required='" & TextBox5.Text & "',insurance_type='" & TextBox6.Text & "',total_claim='" & TextBox7.Text & "',contact='" & TextBox8.Text & "' where member_id='" & TextBox1.Text & "' ", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()


            myReader = SelectCommand.ExecuteReader()
            MessageBox.Show("Data has been updated")


            mycon.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)



            i = DataGridView1.CurrentRow.Index
            Me.TextBox1.Text = DataGridView1.Item(0, i).Value
            Me.TextBox2.Text = DataGridView1.Item(1, i).Value
            Me.TextBox3.Text = DataGridView1.Item(2, i).Value
            Me.DateTimePicker1.Text = DataGridView1.Item(3, i).Value
            Me.TextBox4.Text = DataGridView1.Item(4, i).Value
            Me.TextBox5.Text = DataGridView1.Item(5, i).Value
            Me.TextBox6.Text = DataGridView1.Item(6, i).Value
            Me.TextBox7.Text = DataGridView1.Item(7, i).Value
            Me.TextBox8.Text = DataGridView1.Item(8, i).Value
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim picture As New OpenFileDialog
        Dim ms As New IO.MemoryStream
        picture.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif"

        If picture.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(picture.FileName)

            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class