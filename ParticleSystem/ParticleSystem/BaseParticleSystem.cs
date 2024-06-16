using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ParticleSystem
{
    public abstract class BaseParticleSystem
    {
        protected List<Particle> Particles = new List<Particle>();
        protected bool Regenerate;
        protected bool RandomizeParticleSize;
        protected Vector Center;
        protected Color DefaultParticleColor;
        protected int ParticlesMaxLife = 150;
        protected int MaximumParticlesCount = 150;

        protected abstract Particle GenerateParticle();
        public abstract void AddNewParticle();
        public abstract bool Update();

        //private Random _rand = new Random();

        public virtual void Draw(SKCanvas canvas, SKSurface surface, SKImageInfo image)
        {
            Particle curParticle;

            for (int i = 0; i < Particles.Count; i++)
            {
                curParticle = Particles[i];

                SKPaint paint = new SKPaint
                {
                    Style = SKPaintStyle.StrokeAndFill,
                    Color = curParticle.Color.ToSKColor(),
                    //StrokeWidth = _rand.Next(2, 20),
                };

                canvas.DrawCircle(image.Width * curParticle.Position.X, image.Height * curParticle.Position.Y, curParticle.Size, paint);
            }
        }
    }
}
