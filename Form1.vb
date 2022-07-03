'*** Practice of integer numbers ***
Imports System.Runtime.InteropServices

Public Class Form1
    Private leftBorderBtn As Panel
    Private currentBtn As Button
    Private borderSize As Integer = 0
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
    End Sub

    'Methods
    Private Sub ActivateButton(senderBtn As Object, customColor As Color)
        If senderBtn IsNot Nothing Then
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
    End Sub


    Private Sub BtnExercise1_Click(sender As Object, e As EventArgs) Handles BtnExercise1.Click
        ActivateButton(sender, RGBColors.color1)
        HeaderTitle.Text = "1. Acumular términos de acuerdo a la formula con dígitos impares:"
    End Sub

    Private Sub BtnExercise2_Click(sender As Object, e As EventArgs) Handles BtnExercise2.Click
        ActivateButton(sender, RGBColors.color2)
        HeaderTitle.Text = "2. Eliminar los dígitos múltiplos de d1"
    End Sub

    Private Sub BtnExercise3_Click(sender As Object, e As EventArgs) Handles BtnExercise3.Click
        ActivateButton(sender, RGBColors.color3)
        HeaderTitle.Text = "3. Seleccionar dígitos primos en otro número entero"
    End Sub

    Private Sub BtnExercise4_Click(sender As Object, e As EventArgs) Handles BtnExercise4.Click
        ActivateButton(sender, RGBColors.color4)
        HeaderTitle.Text = "4. Seleccionar dígitos repetidos en otro número entero"
    End Sub

    Private Sub BtnExercise5_Click(sender As Object, e As EventArgs) Handles BtnExercise5.Click
        ActivateButton(sender, RGBColors.color5)
        HeaderTitle.Text = "5. Verificar si los dígitos están en orden descendente"
    End Sub

    Private Sub BtnExercise6_Click(sender As Object, e As EventArgs) Handles BtnExercise6.Click
        ActivateButton(sender, RGBColors.color6)
        HeaderTitle.Text = "6. Insertar un digito en el orden que corresponde"
    End Sub

    Private Sub BtnExercise7_Click(sender As Object, e As EventArgs) Handles BtnExercise7.Click
        ActivateButton(sender, RGBColors.color2)
        HeaderTitle.Text = "7. Encontrar la intersección de dígitos de 2 números enteros, el resultado es otro número entero"
    End Sub

    Private Sub BtnExercise8_Click(sender As Object, e As EventArgs) Handles BtnExercise8.Click
        ActivateButton(sender, RGBColors.color1)
        HeaderTitle.Text = "8. Encontrar el número de dígitos diferentes"
    End Sub

    Private Sub BtnExercise9_Click(sender As Object, e As EventArgs) Handles BtnExercise9.Click
        ActivateButton(sender, RGBColors.color3)
        HeaderTitle.Text = "9. Ordenar los dígitos de un NE"
    End Sub

    Private Sub BtnExercise10_Click(sender As Object, e As EventArgs) Handles BtnExercise10.Click
        ActivateButton(sender, RGBColors.color4)
        HeaderTitle.Text = "10. Verificar si la jugada de dados es POKAR (4 dígitos iguales)"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles StudentBtn.Click
        DisableButton()
        PanelStudent.Visible = True
        StudentBtn.BackColor = Color.FromArgb(34, 33, 74)
        StudentBtn.ForeColor = Color.FromArgb(130, 83, 215)
        leftBorderBtn.Visible = False
    End Sub
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

    Public Function EvenAndOdd(number As Integer) As Boolean
        Return number Mod 2 = 0
    End Function

    '<-- 1. Accumuate terms according to the formula with odd digits -->
    'Public Function AccumulateOddDigits(number As Integer) As String
    '    Dim result As String = ""
    '    Dim digit As Byte
    '    While number > 0
    '        digit = number Mod 10
    '        number \= 10

    '    End While
    'End Function
End Class
