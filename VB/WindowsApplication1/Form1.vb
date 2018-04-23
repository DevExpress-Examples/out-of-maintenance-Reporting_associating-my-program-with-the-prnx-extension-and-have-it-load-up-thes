Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.Win32
Imports System.Reflection
Imports System.IO

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim r As New XtraReport1()
			r.CreateDocument()
			xtraUserControl11.printControl1.PrintingSystem = r.PrintingSystem
		End Sub

		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click

			Dim rk1 As RegistryKey
			If Registry.ClassesRoot.OpenSubKey(".prnx") Is Nothing Then
				rk1 = Registry.ClassesRoot.CreateSubKey(".prnx")
			Else
				rk1 = Registry.ClassesRoot.OpenSubKey(".prnx",True)
			End If
			rk1.SetValue("", "prnxfile")
			Dim rk2 As RegistryKey
			If Registry.ClassesRoot.OpenSubKey("prnxfile") Is Nothing Then
				rk2 = Registry.ClassesRoot.CreateSubKey("prnxfile")
			Else
				rk2 = Registry.ClassesRoot.OpenSubKey("prnxfile", True)
			End If
			rk2.SetValue("", "DevExpress Printing System Document")
			Dim rk3 As RegistryKey
			If rk2.OpenSubKey("DefaultIcon") Is Nothing Then
				rk3 = rk2.CreateSubKey("DefaultIcon")
			Else
				rk3 = rk2.OpenSubKey("DefaultIcon", True)
			End If
			rk3.SetValue("", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) & "\App.ico")
			Dim rk4 As RegistryKey
			If rk2.OpenSubKey("shell") Is Nothing Then
				rk4 = rk2.CreateSubKey("shell")
			Else
				rk4 = rk2.OpenSubKey("shell")
			End If

			Dim rk5 As RegistryKey
			If rk4.OpenSubKey("open") Is Nothing Then
				rk5 = rk4.CreateSubKey("open")
			Else
				rk5 = rk4.OpenSubKey("open")
			End If
			Dim rk6 As RegistryKey
			If rk5.OpenSubKey("command") Is Nothing Then
				rk6 = rk5.CreateSubKey("command")
			Else
				rk6 = rk5.OpenSubKey("command", True)
			End If
			rk6.SetValue("", """" & System.Reflection.Assembly.GetExecutingAssembly().Location & """ ""%1""")

		End Sub

		Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
			xtraUserControl11.printControl1.PrintingSystem.ClearContent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			If WindowsApplication1.Program.FileToOpen IsNot Nothing Then
				xtraUserControl11.printControl1.PrintingSystem = New DevExpress.XtraPrinting.PrintingSystem()
				xtraUserControl11.printControl1.PrintingSystem.LoadDocument(WindowsApplication1.Program.FileToOpen)
			End If

		End Sub
	End Class
End Namespace