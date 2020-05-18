Imports System.Data
Imports System.Data.SqlClient
Public Class Form2
    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click

        Dim connString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilizador\Desktop\WindowsAppLoginDV\WindowsAppLoginDV\Users.mdf;Integrated Security=True;Connect Timeout=30"
        Dim ligacao As SqlConnection = New SqlConnection(connString)


        Try
            ligacao.Open()

            MsgBox("Foi estabelecida a conexâo com a bd")
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        Dim cmd As SqlCommand = New SqlCommand("SELECT * From Utilizadores Where username='" & txtlogin.Text & "' AND password ='" & txtsenha.Text & "'", ligacao)

        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim encontrou As Boolean = False
        Dim strnome As String = ""
        Dim strApelido As String = ""
        If dr.HasRows Then
            While dr.Read
                encontrou = True
                strnome = dr("nome").ToString
                strApelido = dr("apelido").ToString
            End While
        End If

        ligacao.Close()


        If encontrou = True Then
            Me.Close()
            Form1.Show()
            Form1.Label1.Text = "Bem vindo(a)" & strnome & " " & strApelido
        Else
            Dim msg As String = "Não encontrado." & vbNewLine & "Utilizadores ou senha incorretos."
            Dim titulo As String = "Aviso"
            Dim botoes = MessageBoxButtons.OK
            Dim icone = MessageBoxIcon.Exclamation
        End If

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtlogin.Select()
    End Sub
End Class