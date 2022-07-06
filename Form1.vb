'*** Practice of integer numbers ***
Imports System.Runtime.InteropServices

Public Class Form1
    Private leftBorderBtn As Panel
    Private currentBtn As Button
    Dim currentExercise As Integer = 0
    'Drag Form
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal WParam As Integer, ByVal IParam As Integer)
    End Sub
    Private Sub PanelTitleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelTitleBar.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    'RESIZE OF FORM - CHANGE SIZE'
    Dim cGrip As Integer = 10
    Protected Overrides Sub WndProc(ByRef m As Message)
        If (m.Msg = 132) Then
            Dim pos As Point = New Point((m.LParam.ToInt32 And 65535), (m.LParam.ToInt32 + 16))
            pos = Me.PointToClient(pos)
            If ((pos.X _
                    >= (Me.ClientSize.Width - cGrip)) _
                    AndAlso (pos.Y _
                    >= (Me.ClientSize.Height - cGrip))) Then
                m.Result = CType(17, IntPtr)
                Return
            End If
        End If
        MyBase.WndProc(m)
    End Sub
    '----------------DRAW RECTANGLE / EXCLUDE CORNER PANEL'
    Dim sizeGripRectangle As Rectangle
    Dim tolerance As Integer = 15
    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        Dim region = New Region(New Rectangle(0, 0, Me.ClientRectangle.Width, Me.ClientRectangle.Height))
        sizeGripRectangle = New Rectangle((Me.ClientRectangle.Width - tolerance), (Me.ClientRectangle.Height - tolerance), tolerance, tolerance)
        region.Exclude(sizeGripRectangle)
        Me.PanelFormContainer.Region = region
        Me.Invalidate()
    End Sub
    '----------------COLOR Y GRIP DE RECTANGULO INFERIOR'
    'Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
    '    Dim blueBrush As SolidBrush = New SolidBrush(Color.FromArgb(34, 33, 74))
    '    e.Graphics.FillRectangle(blueBrush, sizeGripRectangle)
    '    MyBase.OnPaint(e)
    '    ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle)
    'End Sub

    'Constructor
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        leftBorderBtn = New Panel()
        leftBorderBtn.Size = New Size(7, 38)
        PanelMenu.Controls.Add(leftBorderBtn)
        LabelInput2.Visible = False
        Input2.Visible = False
    End Sub

    'Methods
    Private Sub ActivateButton(senderBtn As Object, customColor As Color)
        If senderBtn IsNot Nothing Then
            LabelInput1.Text = "N"
            DisableButton()
            PanelStudent.Visible = False
            StudentBtn.BackColor = Color.FromArgb(26, 25, 62)
            StudentBtn.ForeColor = Color.Gainsboro
            'Button
            currentBtn = CType(senderBtn, Button)
            currentBtn.BackColor = Color.FromArgb(37, 36, 81)
            currentBtn.ForeColor = customColor
            currentBtn.TextAlign = ContentAlignment.MiddleCenter
            'Left border
            leftBorderBtn.BackColor = customColor
            leftBorderBtn.Location = New Point(0, currentBtn.Location.Y)
            leftBorderBtn.Visible = True
            leftBorderBtn.BringToFront()
        End If
    End Sub

    Private Sub DisableButton()
        If currentBtn IsNot Nothing Then
            currentBtn.BackColor = Color.FromArgb(31, 30, 68)
            currentBtn.ForeColor = Color.Gainsboro
            currentBtn.TextAlign = ContentAlignment.MiddleCenter
        End If
        LabelInput2.Visible = False
        Input2.Visible = False
    End Sub

    Private Sub BtnExercise1_Click(sender As Object, e As EventArgs) Handles BtnExercise1.Click
        ActivateButton(sender, RGBColors.color1)
        HeaderTitle.Text = "1. Acumular términos de acuerdo a la formula con dígitos impares:"
        currentExercise = 1
        Result.Text = String.Empty
    End Sub

    Private Sub BtnExercise2_Click(sender As Object, e As EventArgs) Handles BtnExercise2.Click
        ActivateButton(sender, RGBColors.color2)
        HeaderTitle.Text = "2. Eliminar los dígitos múltiplos de 'd1'"
        currentExercise = 2
        Result.Text = String.Empty
        LabelInput2.Visible = True
        Input2.Visible = True
    End Sub

    Private Sub BtnExercise3_Click(sender As Object, e As EventArgs) Handles BtnExercise3.Click
        ActivateButton(sender, RGBColors.color3)
        HeaderTitle.Text = "3. Seleccionar dígitos primos en otro número entero"
        currentExercise = 3
        Result.Text = String.Empty
    End Sub

    Private Sub BtnExercise4_Click(sender As Object, e As EventArgs) Handles BtnExercise4.Click
        ActivateButton(sender, RGBColors.color4)
        HeaderTitle.Text = "4. Seleccionar dígitos repetidos en otro número entero"
        currentExercise = 4
        Result.Text = String.Empty
    End Sub

    Private Sub BtnExercise5_Click(sender As Object, e As EventArgs) Handles BtnExercise5.Click
        ActivateButton(sender, RGBColors.color5)
        HeaderTitle.Text = "5. Verificar si los dígitos están en orden descendente"
        currentExercise = 5
        Result.Text = String.Empty
    End Sub

    Private Sub BtnExercise6_Click(sender As Object, e As EventArgs) Handles BtnExercise6.Click
        ActivateButton(sender, RGBColors.color6)
        HeaderTitle.Text = "6. Insertar un digito en el orden que corresponde"
        currentExercise = 6
        Result.Text = String.Empty
        LabelInput2.Text = "dig"
        LabelInput2.Visible = True
        Input2.Visible = True
    End Sub

    Private Sub BtnExercise7_Click(sender As Object, e As EventArgs) Handles BtnExercise7.Click
        ActivateButton(sender, RGBColors.color1)
        HeaderTitle.Text = "7. Encontrar la intersección de dígitos de 2 números enteros, el resultado es otro número entero"
        currentExercise = 7
        Result.Text = String.Empty
        Input2.Visible = True
        LabelInput1.Text = "N1"
        LabelInput2.Visible = True
        LabelInput2.Text = "N2"
    End Sub

    Private Sub BtnExercise8_Click(sender As Object, e As EventArgs) Handles BtnExercise8.Click
        ActivateButton(sender, RGBColors.color2)
        HeaderTitle.Text = "8. Encontrar el número de dígitos diferentes"
        currentExercise = 8
        Result.Text = String.Empty
    End Sub

    Private Sub BtnExercise9_Click(sender As Object, e As EventArgs) Handles BtnExercise9.Click
        ActivateButton(sender, RGBColors.color3)
        HeaderTitle.Text = "9. Ordenar los dígitos de un NE"
        currentExercise = 9
        Result.Text = String.Empty

    End Sub

    Private Sub BtnExercise10_Click(sender As Object, e As EventArgs) Handles BtnExercise10.Click
        ActivateButton(sender, RGBColors.color4)
        HeaderTitle.Text = "10. Verificar si la jugada de dados es POKAR (4 dígitos iguales)"
        currentExercise = 10
        Result.Text = String.Empty
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles StudentBtn.Click
        DisableButton()
        PanelStudent.Visible = True
        StudentBtn.BackColor = Color.FromArgb(34, 33, 74)
        StudentBtn.ForeColor = Color.FromArgb(130, 83, 215)
        leftBorderBtn.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Public Function ErroMessage(many As Integer) As String
        Return If(many = 1, $"¡{LabelInput1.Text} es un campo requerido!", $"¡{LabelInput1.Text} y {LabelInput2.Text} son campos requeridos!")
    End Function
    'Methods for the exercises
    Public Function EvenAndOdd(number As Integer) As Boolean
        Return number Mod 2 = 0
    End Function

    Public Function ReverseNumber(number As Integer) As Integer
        Dim result As Integer : Dim digit As Byte
        While number > 0
            digit = number Mod 10
            result = result * 10 + digit
            number \= 10
        End While
        Return result
    End Function

    Public Function isMultiple(digit As Integer, multiple As Integer) As Boolean
        Return digit Mod multiple = 0
    End Function

    Public Function isPrime(number As Integer) As Boolean
        Dim result As Boolean = number > 1
        For index As Integer = 2 To number - 1
            If number Mod index = 0 Then
                result = False
            End If
        Next
        Return result
    End Function

    Public Function isEqual(number As Integer, digit As Byte) As Boolean
        Dim result As Boolean = False
        Dim dig As Byte
        While number > 0
            dig = number Mod 10
            number \= 10
            If digit = dig Then
                result = True
            End If
        End While
        Return result
    End Function

    Public Function removeDigit(number As Integer, digit As Byte) As Integer
        Dim dig As Byte
        Dim result As Integer = 0
        Dim pass As Boolean = True
        While number > 0
            dig = number Mod 10
            number \= 10
            If (digit <> dig) And pass Then
                result = result * 10 + dig
            ElseIf digit = dig Then
                pass = False
            Else
                result = result * 10 + dig
            End If
        End While
        Return ReverseNumber(result)
    End Function

    Public Function getMajorDigit(number As Integer) As Byte
        Dim majorDigit, dig As Byte
        majorDigit = number Mod 10
        number \= 10
        While number > 0
            dig = number Mod 10
            number \= 10
            If dig > majorDigit Then
                majorDigit = dig
            End If
        End While
        Return majorDigit
    End Function

    '<-- 1. Accumuate terms according to the formula with odd digits -->
    Public Function AccumulateOddDigits(number As Integer) As String
        Dim result As String = "" : Dim digit As Byte
        Dim count As Integer = 2
        Dim intermittent, first As Boolean
        intermittent = True : first = True
        While number > 0
            digit = number Mod 10
            number \= 10
            If Not EvenAndOdd(digit) Then
                If first Then
                    result = $"({digit} / {count}!) ^ (1/{count})"
                Else
                    If intermittent Then
                        result = $"{result}  -  ({digit} / {count}!) ^ (1/{count})"
                    Else
                        result = $"{result}  +  ({digit} / {count}!) ^ (1/{count})"
                    End If
                    intermittent = Not intermittent
                End If
                first = False
                count += 1
            End If
        End While
        Return "F = " + result
    End Function

    '<-- 2. Remove multiple digits of any digit -->
    Public Function EliminateMultiples(number As Integer, d1 As Integer) As Integer
        Dim result As Integer = 0 : Dim digit As Byte
        While number > 0
            digit = number Mod 10
            number \= 10
            If Not isMultiple(digit, d1) Then
                result = result * 10 + digit
            End If
        End While
        Return ReverseNumber(result)
    End Function

    '<-- 3. Select prime digits in other integer number -->
    Public Function SelectPrimeDigits(number As Integer) As Integer
        Dim result As Integer : Dim digit As Byte
        While number > 0
            digit = number Mod 10
            If isPrime(digit) Then
                result = result * 10 + digit
            End If
            number \= 10
        End While
        Return result
    End Function

    '<-- 4. Select prime digits in other integer number -->
    Public Function SelectRepeatDigits(number As Integer) As Integer
        Dim digit As Byte : Dim result As Integer = 0
        While number > 0
            digit = number Mod 10
            number \= 10
            If isEqual(number, digit) Or isEqual(result, digit) Then
                result = result * 10 + digit
            End If
        End While
        Return result
    End Function

     '<-- 5. Verify if digits are in descending order -->
    Public Function IsDescendingOrder(number As Integer) As Boolean
        Dim digit, firstDigit As Byte
        Dim result As Boolean = False
        firstDigit = number Mod 10
        number \= 10
        While number > 0
            digit = number Mod 10
            number \= 10
            If firstDigit <= digit Then
                firstDigit = digit
                result = True
            Else
                result = False
            End If
        End While
        Return result
    End Function

    '<-- 6. Insert digit in correspond order -->
    Public Function SortedNumbers(number As Integer, addDigit As Byte, reverse As Boolean) As Integer
        Dim numArray(Str(number).Length) As Integer
        Dim digit As Integer
        Dim count, index As Integer : count = 1
        Dim sortedNumber As Integer = 0
        numArray(0) = addDigit
        While number > 0
            digit = number Mod 10
            number \= 10
            numArray(count) = digit
            count += 1
        End While
        If reverse Then
            Array.Sort(numArray)
            Array.Reverse(numArray)
            Array.Resize(numArray, numArray.Length - 1)
        Else
            Array.Sort(numArray)
        End If
        For index = 0 To numArray.GetUpperBound(0)
            sortedNumber = sortedNumber * 10 + numArray(index)
        Next
        Return sortedNumber
    End Function

    Public Function InsertDigitInOrder(number As Integer, digit As Byte) As Long
        Dim cloneNum As Integer
        Dim isReverse As Boolean = False
        cloneNum = number
        Dim currentDigit, firstDigit As Byte
        firstDigit = number Mod 10
        number \= 10
        While number > 0
            currentDigit = number Mod 10
            number \= 10
            If firstDigit < currentDigit Then
                isReverse = True
            End If
        End While
        Return SortedNumbers(cloneNum, digit, isReverse)
    End Function

    '<-- 7. Find intersection of two integer numbers -->
    Public Function FindIntersection(number1 As Integer, number2 As Integer) As Integer
        Dim digit As Byte
        Dim result As Integer
        While number1 > 0
            digit = number1 Mod 10
            number1 \= 10
            If isEqual(number2, digit) Then
                result = result * 10 + digit
            End If
        End While
        Return ReverseNumber(result)
    End Function

    '<-- 8. Find and count number of different digits -->
    Public Function CountDigitsOfNumber(number As Integer) As Integer
        Dim digit As Byte
        Dim storeNumber As Integer
        storeNumber = 0
        While number > 0
            digit = number Mod 10
            number \= 10
            If Not isEqual(storeNumber, digit) Then
                storeNumber = storeNumber * 10 + digit
            End If
        End While
        Return storeNumber.ToString().Length
    End Function

    '<-- 9. Order the digits of a integer number -->
    Public Function OrderDigits(number As Integer) As Integer
        Dim sortResult As Integer
        Dim numArray(number.ToString().Length) As Integer
        Dim digit As Byte
        Dim count, index As Integer : count = 0
        While number > 0
            digit = number Mod 10
            number \= 10
            numArray(count) = digit
            count += 1
        End While
        Array.Sort(numArray)
        For index = 0 To numArray.GetUpperBound(0)
            sortResult = sortResult * 10 + numArray(index)
        Next
        Return sortResult
    End Function

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Result.ForeColor = Color.FromArgb(255, 255, 255)
            Select Case currentExercise
                Case 1
                    If Input1.Text.Length > 0 Then
                        Result.Text = AccumulateOddDigits(Input1.Text)
                    Else
                        Result.ForeColor = RGBColors.color1
                        Result.Text = ErroMessage(1)
                    End If
                Case 2
                    If (Input1.Text.Length > 0) Or (Input2.Text.Length > 0) Then
                        Result.Text = EliminateMultiples(Input1.Text, Input2.Text)
                    Else
                        Result.ForeColor = RGBColors.color2
                        Result.Text = ErroMessage(2)
                    End If
                Case 3
                    If Input1.Text.Length > 0 Then
                        Result.Text = SelectPrimeDigits(Input1.Text)
                    Else
                        Result.ForeColor = RGBColors.color3
                        Result.Text = ErroMessage(1)
                    End If
                Case 4
                    If Input1.Text.Length > 0 Then
                        Result.Text = SelectRepeatDigits(Input1.Text)
                    Else
                        Result.ForeColor = RGBColors.color4
                        Result.Text = ErroMessage(1)
                    End If
                Case 5
                    If Input1.Text.Length > 0 Then
                        Result.Text = IsDescendingOrder(Input1.Text)
                    Else
                        Result.ForeColor = RGBColors.color5
                        Result.Text = ErroMessage(1)
                    End If
                Case 6
                    If (Input1.Text.Length <> 0) And (Input2.Text.Length = 1) Then
                        Result.Text = InsertDigitInOrder(Input1.Text, Input2.Text)
                    ElseIf Input2.Text.Length > 1 Then
                        Result.ForeColor = RGBColors.color6
                        Result.Text = "'Dig' es de tipo byte, asegurese de enviar solo digitos."
                    Else
                        Result.ForeColor = RGBColors.color6
                        Result.Text = ErroMessage(2)
                    End If
                Case 7
                    If (Input1.Text.Length > 0) And (Input2.Text.Length > 0) Then
                        Result.Text = FindIntersection(Input1.Text, Input2.Text)
                    Else
                        Result.ForeColor = RGBColors.color1
                        Result.Text = ErroMessage(2)
                    End If
                Case 8
                    If Input1.Text.Length > 0 Then
                        Result.Text = CountDigitsOfNumber(Input1.Text)
                    Else
                        Result.ForeColor = RGBColors.color2
                        Result.Text = ErroMessage(1)
                    End If
                Case 9
                    If Input1.Text.Length > 0 Then
                        Result.Text = OrderDigits(Input1.Text)
                    Else
                        Result.ForeColor = RGBColors.color3
                        Result.Text = ErroMessage(1)
                    End If
                Case 10
                Case Else
                    Result.ForeColor = Color.FromArgb(130, 83, 215)
                    Result.Text = "No se ha seleccionado ningún ejercicio."
            End Select
        Catch ex As Exception
            Dim extra As String = ""
            If ex.Message = "Arithmetic operation resulted in an overflow." Then
                extra = "Asegurese de insertar datos dentro del limite esperado (Long = 4294967296)"
            End If

            Result.ForeColor = Color.FromArgb(237, 61, 61)
            Result.Text = "Por favor, ingrese un número valido (de tipo Entero). " + extra
        End Try
    End Sub
End Class
