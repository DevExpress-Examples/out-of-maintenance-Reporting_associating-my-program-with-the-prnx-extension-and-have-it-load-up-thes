Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace WindowsApplication1
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Public Shared FileToOpen As String = Nothing
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			If args.Length > 0 Then
				FileToOpen = args(0)
			End If
			Application.Run(New Form1())
		End Sub
	End Class
End Namespace