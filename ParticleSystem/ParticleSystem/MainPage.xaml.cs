using ParticleSystem.Effects;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParticleSystem
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private BaseParticleSystem _particleSystem;
        private Timer _timer;
        private List<string> _effectTypes = new List<string>() { "Explosion", "Floaters", "Fall", "Fountain", "Rain", "Snow", "Space Travel" };
        private int _refreshDuration = 20;
        private int _particlesCount = 200;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            thePicker.ItemsSource = _effectTypes;
            thePicker.SelectedIndex = 0;

            base.OnAppearing();
        }

        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            _particleSystem?.Draw(canvas, surface, info);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (_particleSystem == null) return;

            if (_timer == null)
            {
                _timer = new Timer((obj) =>
                {
                    _particleSystem.Update();
                    theCanvas.InvalidateSurface();
                }, null, 0, _refreshDuration);
            }

            for (int i = 0; i < _particlesCount; i++)
            {
                _particleSystem.AddNewParticle();
            }
        }

        private void fpsEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            int newFps = 60;

            int.TryParse(e.NewTextValue, out newFps);
            _refreshDuration = newFps;

            _timer?.Change(0, _refreshDuration);
        }

        private void particlesEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            int newParticlesCount = 60;

            int.TryParse(e.NewTextValue, out newParticlesCount);
            _particlesCount = newParticlesCount;
        }

        private void thePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (thePicker.SelectedItem)
            {
                case "Explosion":
                    _particleSystem = new ExplosionEffect();
                    BackgroundColor = Color.White;
                    break;
                case "Floaters":
                    _particleSystem = new FloatersEffect();
                    BackgroundColor = Color.White;
                    break;
                case "Fall":
                    _particleSystem = new FallEffect();
                    BackgroundColor = Color.White;
                    break;
                case "Fountain":
                    _particleSystem = new FountainEffect();
                    BackgroundColor = Color.White;
                    break;
                case "Rain":
                    _particleSystem = new RainEffect();
                    BackgroundColor = Color.White;
                    break;
                case "Snow":
                    _particleSystem = new SnowEffect();
                    BackgroundColor = Color.SkyBlue;
                    break;
                case "Space Travel":
                    _particleSystem = new SpaceTravelEffect();
                    BackgroundColor = Color.Black;
                    break;
            }
            theCanvas.InvalidateSurface();
            _timer?.Dispose();
            _timer = null;
        }
    }
}
