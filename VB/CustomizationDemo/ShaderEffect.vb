Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Media.Effects
Imports System.Windows
Imports System.Windows.Media

Namespace CustomizationDemo
	Public Class GrayscaleEffect
		Inherits ShaderEffect

'INSTANT VB NOTE: The field pixelShader was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private Shared pixelShader_Conflict As New PixelShader() With {.UriSource = New Uri("pack://application:,,,/CustomizationDemo;component/GrayscaleEffect.ps")}
		Public Shared ReadOnly InputProperty As DependencyProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", GetType(GrayscaleEffect), 0)
		Public Shared ReadOnly DesaturationFactorProperty As DependencyProperty = DependencyProperty.Register("DesaturationFactor", GetType(Double), GetType(GrayscaleEffect), New UIPropertyMetadata(0.0, PixelShaderConstantCallback(0), AddressOf CoerceDesaturationFactor))
		Private Shared Function CoerceDesaturationFactor(ByVal d As DependencyObject, ByVal value As Object) As Object
			Dim effect As GrayscaleEffect = CType(d, GrayscaleEffect)
			Dim newFactor As Double = DirectCast(value, Double)
			If newFactor < 0.0 OrElse newFactor > 1.0 Then
				Return effect.DesaturationFactor
			End If
			Return newFactor
		End Function

		Public Sub New()
			PixelShader = pixelShader_Conflict
			UpdateShaderValue(InputProperty)
			UpdateShaderValue(DesaturationFactorProperty)
		End Sub
		Public Property Input() As Brush
			Get
				Return DirectCast(GetValue(InputProperty), Brush)
			End Get
			Set(ByVal value As Brush)
				SetValue(InputProperty, value)
			End Set
		End Property
		Public Property DesaturationFactor() As Double
			Get
				Return DirectCast(GetValue(DesaturationFactorProperty), Double)
			End Get
			Set(ByVal value As Double)
				SetValue(DesaturationFactorProperty, value)
			End Set
		End Property
	End Class
End Namespace