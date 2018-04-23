Imports Microsoft.VisualBasic
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
		Private Shared fPixelShader As New PixelShader() With { _
			.UriSource = New Uri("pack://application:,,,/CustomizationDemo;component/GrayscaleEffect.ps")}
		Public Shared ReadOnly InputProperty As DependencyProperty = _
			ShaderEffect.RegisterPixelShaderSamplerProperty("Input", GetType(GrayscaleEffect), 0)
		Public Shared ReadOnly DesaturationFactorProperty As DependencyProperty = _
			DependencyProperty.Register("DesaturationFactor", _
										GetType(Double), _
										GetType(GrayscaleEffect), _
										New UIPropertyMetadata(0.0, _
															   PixelShaderConstantCallback(0), _
															   AddressOf CoerceDesaturationFactor))
		Private Shared Function CoerceDesaturationFactor(ByVal d As DependencyObject, _
				ByVal value As Object) As Object
			Dim effect As GrayscaleEffect = CType(d, GrayscaleEffect)
			Dim newFactor As Double = CDbl(value)
			If newFactor < 0.0 OrElse newFactor > 1.0 Then
				Return effect.DesaturationFactor
			End If
			Return newFactor
		End Function

		Public Sub New()
			PixelShader = fPixelShader
			UpdateShaderValue(InputProperty)
			UpdateShaderValue(DesaturationFactorProperty)
		End Sub
		Public Property Input() As Brush
			Get
				Return CType(GetValue(InputProperty), Brush)
			End Get
			Set(ByVal value As Brush)
				SetValue(InputProperty, value)
			End Set
		End Property
		Public Property DesaturationFactor() As Double
			Get
				Return CDbl(GetValue(DesaturationFactorProperty))
			End Get
			Set(ByVal value As Double)
				SetValue(DesaturationFactorProperty, value)
			End Set
		End Property
	End Class
End Namespace