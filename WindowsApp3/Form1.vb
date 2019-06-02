Imports CorelDRAW
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

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
        fontColorChange() '如果改变了下拉框就改变fontcolor参数
        core.ActiveDocument.Unit = VGCore.cdrUnit.cdrCentimeter
        core.ActiveDocument.ReferencePoint = VGCore.cdrReferencePoint.cdrBottomLeft
        '开始循环，循环textbox里面的行数
        If TextBox1.Text <> "" Then
            Dim shapPosY As Integer = 0
            Dim creat_shape As Shape
            Dim creat_text As Shape
            Dim i As Long
            Dim loadingshow As Long
            Me.Hide()
            loading.Show()
            For i = 0 To TextBox1.Lines.Count - 1
                '定义创建位置变量
                loadingshow += 1
                If TextBox1.Lines(i) <> "" Then
                    creat_shape = core.ActiveLayer.CreateRectangle2(0, shapPosY, ComboBox1.Text, ComboBox2.Text)
                    creat_text = core.ActiveLayer.CreateArtisticText(0, shapPosY, TextBox1.Lines(i), VGCore.cdrTextLanguage.cdrSimplifiedChinese, , fontInter, 1250)
                    '设置文字大小
                    creat_text.SetSize(0, 43)
                    '设置文字字体
                    '让文字居中算式
                    '如果可以填充就执行
                    If creat_shape.CanHaveFill = True Then
                        creat_shape.Fill().UniformColor.CMYKAssign(0, 100, 100, 0)
                        creat_text.Fill().UniformColor.CMYKAssign(0, 0, fontcolor, 0)
                    End If

                    'If creat_text.SizeHeight <= 43 Then
                    'MsgBox((creat_shape.SizeHeight - creat_text.SizeHeight) / 2)

                    creat_text.SetPosition((creat_shape.SizeWidth * 0.08) / 2, ((creat_shape.SizeHeight - creat_text.SizeHeight) / 2) + shapPosY)
                    creat_text.SizeWidth = creat_shape.SizeWidth - (creat_shape.SizeWidth * 0.08)

                    'End If
                    '设置创建位置增加
                    shapPosY += 75
                Else
                    MsgBox("有一条没有文字，我自动给你跳过了哦")
                End If


            Next
            '创建矩形  创建文本
            If loadingshow = TextBox1.Lines.Count Then
                loading.Dispose()
                Me.Show()
            End If
        End If



    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        'core.ActiveShape.Text.Frames.First.Range.Characters.All.Font = "方正大黑简体"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        fontInter = ComboBox3.Items(ComboBox3.SelectedIndex)
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub
    Public Function HzTopy(ByVal mystr As String) As String
        Dim i As Integer
        Dim J As Integer
        Dim Pstr As String
        Try
            Dim k As Integer = Len(mystr)
            For J = 1 To k
                i = Asc(Mid(mystr, J, 1))

                Dim Py As String
                Select Case i
                    Case -20319 To -20284 : Py = "A"
                    Case -20283 To -19776 : Py = "B"
                    Case -19775 To -19219 : Py = "C"
                    Case -19218 To -18711 : Py = "D"
                    Case -18710 To -18527 : Py = "E"
                    Case -18526 To -18240 : Py = "F"
                    Case -18239 To -17923 : Py = "G"
                    Case -17922 To -17418 : Py = "H"
                    Case -17417 To -16475 : Py = "J"
                    Case -16474 To -16213 : Py = "K"
                    Case -16212 To -15641 : Py = "L"
                    Case -15640 To -15166 : Py = "M"
                    Case -15165 To -14923 : Py = "N"
                    Case -14922 To -14915 : Py = "O"
                    Case -14914 To -14631 : Py = "P"
                    Case -14630 To -14150 : Py = "Q"
                    Case -14149 To -14091 : Py = "R"
                    Case -14090 To -13319 : Py = "S"
                    Case -13318 To -12839 : Py = "T"
                    Case -12838 To -12557 : Py = "W"
                    Case -12556 To -11848 : Py = "X"
                    Case -11847 To -11056 : Py = "Y"
                    Case -11055 To -10247 : Py = "Z"
                    Case Else : Py = CStr(Chr(i))
                End Select
                Pstr = Pstr & Py
            Next
            HzTopy = Pstr
        Catch ex As Exception
            MsgBox("转成失败！")
            Return String.Empty
        End Try
    End Function

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

        For Each fonty In FontFamily.Families
            If fonty.Name <> "" Then

                If Asc(fonty.Name) < 0 Then
                    If TextBox4.Text.ToUpper = HzTopy(fonty.Name) Then

                        ComboBox3.Text = fonty.Name

                    End If


                End If

            End If
        Next
    End Sub
End Class
