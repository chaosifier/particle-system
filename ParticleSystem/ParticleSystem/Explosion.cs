using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ParticleSystem
{
    public class Explosion : BaseParticleSystem
    {
        public static readonly int TOTAL_PARTICLES_TO_GENERATE = 500;
        private Random _random = new Random();

        public Explosion() : this(Vector.Zero) { }

        public Explosion(Vector startingPosition)
        {
            Center = startingPosition;
            DefaultParticleColor = Color.Orange;

            for (int i = 0; i < TOTAL_PARTICLES_TO_GENERATE; i++)
            {
                AddNewParticle();
            }
        }

        public override void AddNewParticle()
        {
            base.Particles.Add(GenerateParticle());
        }

        public override bool Update()
        {
            int particlesCount = Particles.Count;
            Particle updatingParticle;

            for (int i = 0; i < particlesCount; i++)
            {
                updatingParticle = this[i];

                updatingParticle.Update();

                if (updatingParticle.Age > ParticlesMaxLife)
                {
                    Particles.RemoveAt(i);
                    particlesCount--;
                }
                else
                {
                    float agePercent = updatingParticle.Age / (float)ParticlesMaxLife;
                    float correspondingHex = agePercent * 255;
                    updatingParticle.Color = Color.FromArgb(updatingParticle.Color.A, (int)correspondingHex, updatingParticle.Color.G, updatingParticle.Color.B);
                }
            }

            return particlesCount > 0;
        }

        protected override Particle GenerateParticle()
        {
            float randX = ((float)_random.NextDouble() - 0.9f);
            float randY = ((float)_random.NextDouble() - 0.9f);
            float randZ = ((float)_random.NextDouble() - 0.9f);

            return new Particle(base.Center, new Vector(randX, randY, randZ), base.DefaultParticleColor, 0);
        }
    }
}
