Imports CorelDRAW
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports Pinyin4net

Public Class Form1
    Public core As New CorelDRAW.Application
    Private Sub TextBox1_CursorChanged(sender As Object, e As EventArgs) Handles TextBox1.CursorChanged

    End Sub

    Private Sub TextBox1_FontChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim tempArray() As String
        tempArray = TextBox1.Lines
        Label9.Text = "当前有" & tempArray.Length & "行条幅内容"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        OpenFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        OpenFileDialog1.ShowDialog()



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        SaveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        SaveFileDialog1.ShowDialog()

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim befortext As String = TextBox1.Text + System.Windows.Forms.Clipboard.GetText()

        TextBox1.Text = befortext

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fontitem As FontFamily
        For Each fontitem In FontFamily.Families
            If fontitem.Name <> "" Then
                If Asc(fontitem.Name) < 0 Then
                    ComboBox3.Items.Add(fontitem.Name)
                End If
            End If
        Next

        ComboBox1.SelectedIndex = 6
        ComboBox2.SelectedIndex = 0
        ComboBox4.SelectedIndex = 0
        '寻找方正大黑字体，如果存在就获取，不存在就获取微软雅黑为默认字体o 
        RadioButton3.Checked = True
        mymou.DefFontContent()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        If IO.File.Exists(OpenFileDialog1.FileName) Then
            TextBox1.Text = IO.File.ReadAllText(OpenFileDialog1.FileName, Encoding.Default)
        Else
            MsgBox（"文件不存在"）

        End If
        Label9.Text = "成功导入:" & OpenFileDialog1.SafeFileName
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        If TextBox1.Text <> "" Then
            IO.File.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text)
            Dim stri As String
            stri = SaveFileDialog1.FileName.Remove(0, SaveFileDialog1.FileName.LastIndexOf("\") + 1)
            Label9.Text = "保存成功:" & stri
            MsgBox("保存成功")
        Else
            MsgBox("当前没有一条内容，保存失败咯！")
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        FontColorChange() '如果改变了下拉框就改变fontcolor参数
        Creat_Tiao()



    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        'core.ActiveShape.Text.Frames.First.Range.Characters.All.Font = "方正大黑简体"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Sqlittext()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        fontInter = ComboBox3.Items(ComboBox3.SelectedIndex)
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

        For Each fonty In FontFamily.Families
            If fonty.Name <> "" Then
                If Asc(fonty.Name) < 0 Then
                    Dim newName As String
                    newName = StringExtension.ToPinYinAbbr(fonty.Name)
                    If newName.IndexOf(TextBox4.Text.ToUpper) <> -1 Then
                        ComboBox3.Text = fonty.Name
                    End If
                End If

            End If
        Next

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        For Each fonty In FontFamily.Families
            If fonty.Name <> "" Then



                If Asc(fonty.Name) < 0 Then
                    Dim newName As String
                    newName = StringExtension.ToPinYinAbbr(fonty.Name)
                    For Each abc In newName
                        If TextBox4.Text = abc Then
                            MsgBox(fonty.Name)
                        End If
                    Next
                End If

            End If
        Next

    End Sub
End Class
