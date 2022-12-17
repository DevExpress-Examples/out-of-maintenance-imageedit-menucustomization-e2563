Imports System.Windows
Imports System.Windows.Controls

Namespace CustomizationDemo

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub OnApplyEffectButtonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If Me.edit.ImageEffect Is Nothing Then Me.edit.ImageEffect = New GrayscaleEffect()
        End Sub

        Private Sub OnUndoEffectButtonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.edit.ImageEffect = Nothing
        End Sub
    End Class
End Namespace
