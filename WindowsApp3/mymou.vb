Imports CorelDRAW
Imports System
Imports WindowsApp3
Module mymou

    Public fontInter As String
    Public fontcolor As Integer

    Public WithEvents formdo As ComboBox '调用下拉框的事件
    Sub DefFontContent()
        Dim unused = Form1.ComboBox3
        For Each fonts In Form1.ComboBox3.Items
            If fonts = "方正大黑简体" Or fonts = "微软雅黑" Then
                fontInter = fonts
            End If

        Next
        Form1.ComboBox3.SelectedText = fontInter
    End Sub
    Sub fontColorChange() Handles formdo.SelectedIndexChanged '如果更改就改变颜色
        If Form1.ComboBox4.SelectedIndex = 0 Then
            fontcolor = 0
        Else
            fontcolor = 100
        End If
    End Sub
    Sub seachFont() '字母找字


    End Sub

End Module
