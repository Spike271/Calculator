Public Class Form1
    Dim myList As New List(Of String)()
    Dim temp, str, ans As String

    Private Sub Print()
        If ans IsNot Nothing Then
            expression.Text = ""
            TextBox1.Text = ""
            ans = Nothing
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Print()
        TextBox1.Text = TextBox1.Text & Button1.Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Print()
        TextBox1.Text = TextBox1.Text & Button2.Text
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Print()
        TextBox1.Text = TextBox1.Text & Button3.Text
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Print()
        TextBox1.Text = TextBox1.Text & Button4.Text
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Print()
        TextBox1.Text = TextBox1.Text & Button5.Text
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Print()
        TextBox1.Text = TextBox1.Text & Button6.Text
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Print()
        TextBox1.Text = TextBox1.Text & Button7.Text
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Print()
        TextBox1.Text = TextBox1.Text & Button8.Text
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Print()
        TextBox1.Text = TextBox1.Text & Button9.Text
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Print()
        TextBox1.Text = TextBox1.Text & Button10.Text
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Point.Click
        Print()
        TextBox1.Text = TextBox1.Text & Point.Text
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles PlusBtn.Click
        If myList.Count > 0 Or TextBox1.Text.Length > 0 Then
            str = ""
            expression.Text = expression.Text & " " & PlusBtn.Text & " "
            myList.Add(TextBox1.Text)
            If temp IsNot Nothing Then
                myList.Add(temp)
                temp = Nothing
            End If
            temp = PlusBtn.Text
            TextBox1.Clear()
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles MinusBtn.Click
        If myList.Count > 0 Or TextBox1.Text.Length > 0 Then

            str = ""
            expression.Text = expression.Text & " " & MinusBtn.Text & " "
            myList.Add(TextBox1.Text)
            If temp IsNot Nothing Then
                myList.Add(temp)
                temp = Nothing
            End If
            temp = MinusBtn.Text
            TextBox1.Clear()

        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles MulBtn.Click
        If myList.Count > 0 Or TextBox1.Text.Length > 0 Then

            str = ""
            expression.Text = expression.Text & " " & MulBtn.Text & " "
            myList.Add(TextBox1.Text)
            If temp IsNot Nothing Then
                myList.Add(temp)
                temp = Nothing
            End If
            temp = MulBtn.Text
            TextBox1.Clear()
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles DivBtn.Click
        If myList.Count > 0 Or TextBox1.Text.Length > 0 Then

            str = ""
            expression.Text = expression.Text & " " & DivBtn.Text & " "
            myList.Add(TextBox1.Text)
            If temp IsNot Nothing Then
                myList.Add(temp)
                temp = Nothing
            End If
            temp = DivBtn.Text
            TextBox1.Clear()

        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles EqualBtn.Click
        str = ""
        expression.Text = expression.Text & " " & EqualBtn.Text
        myList.Add(TextBox1.Text)
        If temp IsNot Nothing Then
            myList.Add(temp)
            temp = Nothing
        End If

        TextBox1.Text = EvalRPN(myList.ToArray()).ToString() & " "
        ans = " "
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Back.Click
        Print()
        If TextBox1.Text.Count > 0 Then
            TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.Length - 1)
            If expression.Text.Length > 1 Then
                expression.Text = expression.Text.Substring(0, expression.Text.Length - 2)
            Else
                expression.Text = ""
            End If
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Clear.Click
        expression.Text = expression.Text.Replace(TextBox1.Text, "")
        Print()
        TextBox1.Clear()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Clear_All.Click
        TextBox1.Clear()
        expression.Text = ""
        If myList.Count < 0 Then
            myList.Clear()
        End If
    End Sub

    Public Function EvalRPN(tokens As String()) As Double
        Dim operators As New HashSet(Of String) From {"+", "-", "*", "/"}
        Dim stack As New Stack(Of String)()

        For Each token As String In tokens
            If operators.Contains(token) Then
                Dim var2 As Double = Double.Parse(stack.Pop())
                Dim var1 As Double = Double.Parse(stack.Pop())
                Dim ans As Double

                Select Case token
                    Case "+"
                        ans = var1 + var2
                    Case "-"
                        ans = var1 - var2
                    Case "*"
                        ans = var1 * var2
                    Case "/"
                        ans = var1 / var2
                    Case Else
                        Throw New ArgumentException("Invalid operator: " & token)
                End Select
                stack.Push(ans.ToString())
            Else
                stack.Push(token)
            End If
        Next

        Return Double.Parse(stack.Pop())
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        str = sender.Text
        If TextBox1.Text.Length = 1 Then
            expression.Text = expression.Text & str
        ElseIf TextBox1.Text.Length > 1 Then
            expression.Text = expression.Text & str.ElementAt(str.Length - 1)
        End If
    End Sub
End Class