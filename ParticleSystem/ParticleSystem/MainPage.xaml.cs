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
        //Explosion _explosionSystem;    
        FallEffect _explosionSystem;
        Timer tmr;

        public MainPage()
        {
            Environment.GetInstance().Gravity = new Vector(0.0f, -0.1f, 0.0f);
            Environment.GetInstance().Wind = new Vector(0.2f, 0.0f, 0.0f);
            //_explosionSystem = new Explosion(new Vector(.5f, .5f, 0f));
            _explosionSystem = new FallEffect();
            InitializeComponent();

            tmr = new Timer((obj) =>
           {
               _explosionSystem.Update();
               theCanvas.InvalidateSurface();
           }, null, 1000, 17);
        }

        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            _explosionSystem.Draw(canvas, surface, info);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            for (int i = 0; i < 200; i++)
            {
                _explosionSystem.AddNewParticle();
            }
        }
    }
}
