Imports CorelDRAW
Imports System
Imports WindowsApp3
Module mymou

    Public fontInter As String
    Public fontcolor As Integer
    Private core As New CorelDRAW.Application
    Public WithEvents Formdo As ComboBox '调用下拉框的事件
    Sub DefFontContent()
        Dim unused = Form1.ComboBox3
        For Each fonts In Form1.ComboBox3.Items
            If fonts = "方正大黑简体" Or fonts = "微软雅黑" Then
                fontInter = fonts
            End If

        Next
        Form1.ComboBox3.SelectedText = fontInter
    End Sub
    Sub FontColorChange() Handles Formdo.SelectedIndexChanged '如果更改就改变颜色
        If Form1.ComboBox4.SelectedIndex = 0 Then
            fontcolor = 0
        Else
            fontcolor = 100
        End If
    End Sub
    Sub ZhinengModel()

        Dim checkeds As RadioButton
        checkeds = Form1.GroupBox3.Controls.OfType(Of RadioButton)().FirstOrDefault(Function(r) r.Checked = True)
        core.ActiveDocument.Unit = VGCore.cdrUnit.cdrCentimeter
        core.ActiveDocument.ReferencePoint = VGCore.cdrReferencePoint.cdrBottomLeft
        If checkeds.Tag = 2 Then

            If Form1.TextBox1.Text <> "" Then
                Dim creat_zn_shape As Shape
                Dim creat_zn_text As Shape
                Dim i As Long, pos_zn_y As Long = 0
                Dim new_shapcing As Long = 0
                For i = 0 To Form1.TextBox1.Lines.Length - 1
                    Dim current_long As Double, current_height As Double
                    creat_zn_shape = core.ActiveLayer.CreateRectangle2(0, pos_zn_y, Form1.ComboBox1.Text, Form1.ComboBox2.Text)
                    creat_zn_text = core.ActiveLayer.CreateArtisticText(0, pos_zn_y, Form1.TextBox1.Lines(i), VGCore.cdrTextLanguage.cdrSimplifiedChinese,, fontInter, 1230)
                    core.FrameWork.Automation.InvokeItem("747d4f35-b3a1-4d4f-a69c-06c4b4f9ff6b")
                    If creat_zn_shape.CanHaveFill = True Then
                        creat_zn_shape.Fill.UniformColor.CMYKAssign(0, 100, 100, 0)
                        creat_zn_text.Fill.UniformColor.CMYKAssign(0, 0, 0, 0)
                    End If
                    current_long = creat_zn_shape.SizeWidth * 0.08 / 2
                    current_height = (creat_zn_shape.SizeHeight - creat_zn_text.SizeHeight) / 2
                    creat_zn_text.SetPosition(current_long, current_height + pos_zn_y)
                    Dim changesTextwidth As Double = creat_zn_text.SizeWidth
                    Do
                        creat_zn_text.Text.Story.CharSpacing += 10
                    Loop While creat_zn_text.SizeWidth < (creat_zn_shape.SizeWidth - current_long * 2) * 0.6
                    creat_zn_text.SetSize(creat_zn_shape.SizeWidth - current_long * 2, 42.5)
                    pos_zn_y += 75

                Next


            End If



        ElseIf checkeds.Tag = 1 Then

            '开始循环，循环textbox里面的行数
            If Form1.TextBox1.Text <> "" Then
                Dim shapPosY As Integer = 0
                Dim creat_shape As Shape
                Dim creat_text As Shape
                Dim i As Long
                Dim loadingshow As Long
                Form1.Hide()
                loading.Show()
                For i = 0 To Form1.TextBox1.Lines.Count - 1
                    '定义创建位置变量
                    loadingshow += 1
                    If Form1.TextBox1.Lines(i) <> "" Then
                        creat_shape = core.ActiveLayer.CreateRectangle2(0, shapPosY, Form1.ComboBox1.Text, Form1.ComboBox2.Text)
                        creat_text = core.ActiveLayer.CreateArtisticText(0, shapPosY, Form1.TextBox1.Lines(i), VGCore.cdrTextLanguage.cdrSimplifiedChinese, , fontInter, 1250)
                        '设置文字大小
                        core.FrameWork.Automation.InvokeItem("747d4f35-b3a1-4d4f-a69c-06c4b4f9ff6b")
                        creat_text.SetSize(0, 42.5)
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
                If loadingshow = Form1.TextBox1.Lines.Count Then
                    loading.Dispose()
                    Form1.Show()
                End If
            End If
        End If


    End Sub

    Sub Creat_tiaofu()
        Dim creat_s As Shape
        Dim creat_t As Shape
        Dim movex As Integer = 0
        core.ActiveDocument.Unit = VGCore.cdrUnit.cdrCentimeter
        For i As Integer = 0 To Form1.TextBox1.Lines.Length - 1
            If Form1.TextBox1.Lines(i) <> "" Then
                creat_s = core.ActiveLayer.CreateRectangle2(movex, 0, Form1.ComboBox2.Text, Form1.ComboBox1.Text)
                creat_t = core.ActiveLayer.CreateArtisticText(movex, Form1.ComboBox1.Text, Form1.TextBox1.Lines(i), VGCore.cdrTextLanguage.cdrSimplifiedChinese,, fontInter， 1250)
                core.FrameWork.Automation.InvokeItem("747d4f35-b3a1-4d4f-a69c-06c4b4f9ff6b")
                If creat_s.CanHaveFill Then
                    creat_s.Fill.UniformColor.CMYKAssign(0, 100, 100, 0)
                    creat_t.Fill.UniformColor.CMYKAssign(0, 0, 0, 0)
                End If
                creat_t.SetSize(, 42.5)
                creat_t.SizeWidth = creat_s.SizeHeight - (creat_s.SizeHeight * 0.08)

                core.FrameWork.Automation.InvokeItem("e243b0da-2586-43f0-a3d9-4251ff9f7213")

                creat_t.SetPositionEx(VGCore.cdrReferencePoint.cdrTopLeft, (creat_s.SizeWidth - 42.5) / 2 + movex, creat_s.TopY - (creat_s.SizeHeight * 0.08 / 2))
                movex += 75
            Else
                MsgBox("出现空行,我跳过这行了哦")
            End If

        Next


    End Sub

    Sub Creat_Tiao()
        Dim checked = Form1.GroupBox1.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True)
        If checked.Tag = 1 Then
            ZhinengModel()
        Else
            Creat_tiaofu()
        End If


    End Sub




End Module
