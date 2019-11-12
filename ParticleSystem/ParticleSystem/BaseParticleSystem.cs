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
        protected Vector Center;
        protected Color DefaultParticleColor;

        protected abstract Particle GenerateParticle();
        public abstract void AddNewParticle();
        public abstract bool Update();

        public int ParticlesMaxLife { get; set; } = 150;

        public virtual void Draw(SKCanvas canvas, SKSurface surface, SKImageInfo image)
        {
            Particle curParticle;

            canvas.Clear();

            for (int i = 0; i < Particles.Count; i++)
            {
                curParticle = Particles[i];

                SKPaint paint = new SKPaint
                {
                    Style = SKPaintStyle.StrokeAndFill,
                    Color = curParticle.Color.ToSKColor(),
                    StrokeWidth = 5
                };

                canvas.DrawCircle(image.Width * curParticle.Position.X, image.Height * curParticle.Position.Y, 2, paint);
            }
        }

        public Particle this[int index]
        {
            get
            {
                return Particles[index];
            }
        }
    }
}
