Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Media.Effects

Namespace CustomizationDemo
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub OnApplyEffectButtonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If edit.ImageEffect Is Nothing Then
				edit.ImageEffect = New GrayscaleEffect()
			End If
		End Sub

		Private Sub OnUndoEffectButtonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			edit.ImageEffect = Nothing
		End Sub
	End Class
End Namespace
