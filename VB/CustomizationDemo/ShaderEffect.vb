Imports System
Imports System.Windows.Media.Effects
Imports System.Windows
Imports System.Windows.Media

Namespace CustomizationDemo

    Public Class GrayscaleEffect
        Inherits ShaderEffect

        Private Shared pixelShader As PixelShader = New PixelShader() With {.UriSource = New Uri("pack://application:,,,/CustomizationDemo;component/GrayscaleEffect.ps")}

        Public Shared ReadOnly InputProperty As DependencyProperty = RegisterPixelShaderSamplerProperty("Input", GetType(GrayscaleEffect), 0)

        Public Shared ReadOnly DesaturationFactorProperty As DependencyProperty = DependencyProperty.Register("DesaturationFactor", GetType(Double), GetType(GrayscaleEffect), New UIPropertyMetadata(0.0, PixelShaderConstantCallback(0), AddressOf CoerceDesaturationFactor))

        Private Shared Function CoerceDesaturationFactor(ByVal d As DependencyObject, ByVal value As Object) As Object
            Dim effect As GrayscaleEffect = CType(d, GrayscaleEffect)
            Dim newFactor As Double = CDbl(value)
            If newFactor < 0.0 OrElse newFactor > 1.0 Then Return effect.DesaturationFactor
            Return newFactor
        End Function

        Public Sub New()
            PixelShader = pixelShader
            UpdateShaderValue(InputProperty)
            UpdateShaderValue(DesaturationFactorProperty)
        End Sub

        Public Property Input As Brush
            Get
                Return CType(GetValue(InputProperty), Brush)
            End Get

            Set(ByVal value As Brush)
                SetValue(InputProperty, value)
            End Set
        End Property

        Public Property DesaturationFactor As Double
            Get
                Return CDbl(GetValue(DesaturationFactorProperty))
            End Get

            Set(ByVal value As Double)
                SetValue(DesaturationFactorProperty, value)
            End Set
        End Property
    End Class
End Namespace
