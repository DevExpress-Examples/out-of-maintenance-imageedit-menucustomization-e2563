using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Effects;
using System.Windows;
using System.Windows.Media;

namespace CustomizationDemo {
    public class GrayscaleEffect : ShaderEffect {
        static PixelShader pixelShader = new PixelShader() { 
            UriSource = new Uri(@"pack://application:,,,/CustomizationDemo;component/GrayscaleEffect.ps")
        };
        public static readonly DependencyProperty InputProperty = 
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(GrayscaleEffect), 0);
        public static readonly DependencyProperty DesaturationFactorProperty = 
            DependencyProperty.Register("DesaturationFactor", 
                                        typeof(double), 
                                        typeof(GrayscaleEffect),
                                        new UIPropertyMetadata(0.0, 
                                                               PixelShaderConstantCallback(0),
                                                               CoerceDesaturationFactor));
        static object CoerceDesaturationFactor(DependencyObject d, object value) {
            GrayscaleEffect effect = (GrayscaleEffect)d;
            double newFactor = (double)value;
            if(newFactor < 0.0 || newFactor > 1.0) 
                return effect.DesaturationFactor;
            return newFactor;
        }
        
        public GrayscaleEffect() {
            PixelShader = pixelShader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(DesaturationFactorProperty);
        }
        public Brush Input {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }
        public double DesaturationFactor {
            get { return (double)GetValue(DesaturationFactorProperty); }
            set { SetValue(DesaturationFactorProperty, value); }
        }
    }
}