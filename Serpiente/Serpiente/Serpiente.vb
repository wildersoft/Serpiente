'
' Created by SharpDevelop.
' User: Administrador
' Date: 24/03/2006
' Time: 04:13 p.m.
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System
Imports System.Drawing
Imports System.Windows.Forms
imports Microsoft.VisualBasic.Interaction
Imports Microsoft.VisualBasic.VBMath

Namespace serpiente
	
	Public Class MainForm
		Inherits System.Windows.Forms.Form
		Private components As System.ComponentModel.IContainer
        Private pictureBox1 As System.Windows.Forms.PictureBox

        Dim Culebrita(200, 2) As Integer
		Dim posX As Integer, posY As Integer
		Dim posX2 As Integer, posY2 As Integer
		Dim Direccion As Integer
		Dim Anillos As Integer
		Dim Cnt As Integer
		Dim meta As Integer
        Dim Ancho As Single
        Dim Alto As Single
		Dim ColorCulebra As system.Drawing.Color
		Dim ColorBordeCulebra As system.Drawing.Color
        Dim Forma As Integer
        Dim filas As Integer
        Dim columnas As Integer

Public Shared Sub Main
	Dim fMainForm As New MainForm
	fMainForm.ShowDialog()
End Sub

Public Sub New()	
	MyBase.New
	'
	' The Me.InitializeComponent call is required for Windows Forms designer support.
	'
	Me.InitializeComponent
	'
	' TODO : Add constructor code after InitializeComponents
	'
End Sub
		
		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
        Friend WithEvents Timer1 As System.Windows.Forms.Timer
        Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.pictureBox1 = New System.Windows.Forms.PictureBox()
            Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
            Me.TrackBar1 = New System.Windows.Forms.TrackBar()
            CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pictureBox1
            '
            Me.pictureBox1.BackColor = System.Drawing.Color.White
            Me.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pictureBox1.Location = New System.Drawing.Point(8, 8)
            Me.pictureBox1.Name = "pictureBox1"
            Me.pictureBox1.Size = New System.Drawing.Size(360, 504)
            Me.pictureBox1.TabIndex = 1
            Me.pictureBox1.TabStop = False
            '
            'Timer1
            '
            '
            'TrackBar1
            '
            Me.TrackBar1.Location = New System.Drawing.Point(8, 513)
            Me.TrackBar1.Maximum = 50
            Me.TrackBar1.Name = "TrackBar1"
            Me.TrackBar1.Size = New System.Drawing.Size(360, 45)
            Me.TrackBar1.TabIndex = 2
            Me.TrackBar1.Value = 50
            '
            'MainForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(376, 550)
            Me.Controls.Add(Me.TrackBar1)
            Me.Controls.Add(Me.pictureBox1)
            Me.KeyPreview = True
            Me.MaximizeBox = False
            Me.Name = "MainForm"
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.Text = "Serpiente"
            CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
#End Region

        Sub Avanzar()
            Select Case Direccion
                Case 37
                    posX = posX - 1
                Case 38
                    posY = posY - 1
                Case 39
                    posX = posX + 1
                Case 40
                    posY = posY + 1
            End Select
            If posX >= (columnas) Then
                posX = 0
            End If
            If posX < 0 Then
                posX = (columnas)
            End If
            If posY >= (filas) Then
                posY = 0
            End If
            If posY < 0 Then
                posY = (filas)
            End If
            Dibujar(System.Drawing.Color.White, System.Drawing.Color.White)
            Culebrita(Cnt, 0) = posX
            Culebrita(Cnt, 1) = posY
            If Cnt >= Anillos Then
                Cnt = 1
            Else
                Cnt = Cnt + 1
            End If
            Dibujar(ColorCulebra, ColorBordeCulebra)
            Dim x As Integer
            Dim Ocasiones As Integer
            For x = 1 To Anillos
                If posX = Culebrita(x, 0) And posY = Culebrita(x, 1) Then
                    Ocasiones = Ocasiones + 1
                    If Ocasiones > 1 Then
                        Dibujar(System.Drawing.Color.Yellow, System.Drawing.Color.Black)
                        timer1.Enabled = False
                        Beep()
                        Me.Text = "Perdiste"
                        MsgBox("Perdiste ", MsgBoxStyle.Critical, "Game Over")
                        End
                    End If
                End If
            Next
        End Sub

        Sub Dibujar(ByVal Color As System.Drawing.Color, ByVal Borde As System.Drawing.Color)
            Dim x As Integer
            Dim gr As Single
            For x = 1 To Anillos
                gr = gr + (x / Anillos)
                DrawForma(Culebrita(x, 0), Culebrita(x, 1), pictureBox1, Color, Borde, Forma)
            Next
        End Sub

        Sub DrawForma(ByVal x As Single, ByVal Y As Single, ByVal obj As Object, ByVal Color As System.Drawing.Color, ByVal Borde As System.Drawing.Color, ByVal Estilo As Integer)
            Dim pic As Graphics
            Dim lapiz As New System.Drawing.Pen(System.Drawing.Color.Black)
            Dim brocha As New System.Drawing.SolidBrush(System.Drawing.Color.Black)
            pic = Me.pictureBox1.CreateGraphics()
            Select Case Estilo
                Case 1
                    brocha.Color = Color
                    pic.FillRectangle(brocha, CSng((x + 0.1) * Ancho), CSng((Y + 0.1) * Alto), CSng(0.8 * Ancho), CSng(0.8 * Alto))
                    lapiz.Color = Color
                    pic.DrawRectangle(lapiz, CSng((x + 0.1) * Ancho), CSng((Y + 0.1) * Alto), CSng(0.8 * Ancho), CSng(0.8 * Alto))
            End Select
        End Sub

        Sub Enemigo()
            DrawForma(posX2, posY2, pictureBox1, System.Drawing.Color.Blue, System.Drawing.Color.White, Forma)
        End Sub

        Sub posicionEnemigo()
            Randomize()
            posX2 = (Rnd() * columnas)
            posY2 = (Rnd() * filas)
            Do While Comparar(posX2, posY2)
                Randomize()
                posX2 = (Rnd() * columnas)
                posY2 = (Rnd() * filas)
            Loop
        End Sub

        Sub Malla()
            Dim pic As Graphics
            Dim lapiz As New System.Drawing.Pen(System.Drawing.Color.Black)
            Dim x As Integer, y As Integer
            pic = Me.pictureBox1.CreateGraphics()
            For x = 1 To columnas
                pic.DrawLine(lapiz, x * Ancho, 0, x * Ancho, Me.pictureBox1.Height)
            Next
            For y = 1 To filas
                pic.DrawLine(lapiz, 0, y * Alto, Me.pictureBox1.Width, y * Alto)
            Next
            pic.Dispose()
            lapiz.Dispose()
        End Sub

        Function Comparar(ByVal px As Integer, ByVal py As Integer) As Boolean
            Dim x As Integer
            For x = 1 To Anillos
                If Culebrita(x, 0) = px And Culebrita(x, 1) = py Then
                    Comparar = True
                    Exit For
                End If
            Next
        End Function

        Private Sub MainFormKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
            Select Case e.KeyCode
                Case 37
                    If Direccion = 38 Or Direccion = 40 Then
                        Direccion = e.KeyCode
                    End If
                Case 38
                    If Direccion = 37 Or Direccion = 39 Then
                        Direccion = e.KeyCode
                    End If
                Case 39
                    If Direccion = 38 Or Direccion = 40 Then
                        Direccion = e.KeyCode
                    End If
                Case 40
                    If Direccion = 37 Or Direccion = 39 Then
                        Direccion = e.KeyCode
                    End If
                Case 27
                    timer1.Enabled = False
                    Me.trackBar1.Enabled = True
                Case 13
                    timer1.Enabled = True
                    Me.trackBar1.Enabled = False
                    Malla()
                    Enemigo()
            End Select
        End Sub

        Private Sub MainFormLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            filas = 30
            columnas = 15
            Ancho = (Me.pictureBox1.Width) / columnas
            Alto = (Me.pictureBox1.Height) / filas
            posX = (Rnd() * columnas)
            posY = (Rnd() * filas)
            Forma = 1
            Anillos = 1
            posicionEnemigo()
            Enemigo()
            Direccion = 37 + CInt(Rnd() * 4)
            timer1.Interval = 50
            timer1.Enabled = True
            trackBar1.Enabled = False
            ColorCulebra = System.Drawing.Color.Blue
            ColorBordeCulebra = System.Drawing.Color.Yellow
            Cnt = 1
            Malla()
            meta = 45
        End Sub


        Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
            Malla()
            Enemigo()
            Avanzar()
            If posX = posX2 And posY = posY2 Then
                Anillos = Anillos + 1
                If Anillos > meta Then
                    MsgBox("tu Ganaste",MsgBoxStyle.Exclamation)
                    End
                End If
                Culebrita(Anillos, 0) = Culebrita(Anillos - 1, 0)
                Culebrita(Anillos, 1) = Culebrita(Anillos - 1, 1)
                posicionEnemigo()
                Enemigo()
            End If
        End Sub

        Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
            Timer1.Interval = (201 - (TrackBar1.Value * 4))
            pictureBox1.Focus()
        End Sub
    End Class
End Namespace
