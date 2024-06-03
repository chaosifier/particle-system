using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace ParticleSystem.Effects
{
    public class SnowEffect : BaseParticleSystem
    {
        private Random _random = new Random();
        public SnowEffect()
        {
            Regenerate = true;
            MaximumParticlesCount = 300;
            ParticlesMaxLife = 700;
            Environment.GetInstance().Wind = Vector.Zero;
            Environment.GetInstance().Gravity = new Vector(0f, -.00001f, 0f);
        }

        public override void AddNewParticle()
        {
            Particles.Add(GenerateParticle());
        }

        public override bool Update()
        {
            lock (Particles)
            {
                int particlesCount = Particles.Count;
                Particle updatingParticle;

                for (int i = 0; i < particlesCount; i++)
                {
                    updatingParticle = Particles[i];

                    updatingParticle.Velocity.X += (float)_random.GetNextDouble(-.0001f, .0001f);
                    updatingParticle.Velocity.Y += (float)_random.GetNextDouble(-.0001f, .0001f);

                    updatingParticle.Update();

                    if (ParticlesMaxLife != -1 && updatingParticle.Age > ParticlesMaxLife)
                    {
                        Particles.RemoveAt(i);
                        particlesCount--;
                    }

                    if (Regenerate && particlesCount < MaximumParticlesCount)
                    {
                        AddNewParticle();
                        particlesCount++;
                    }
                }

                return particlesCount > 0;
            }
        }

        protected override Particle GenerateParticle()
        {
            var velVector = Vector.Zero;
            var randLife = _random.Next(200, ParticlesMaxLife);
            var posVector = _random.GetRandomVector(new Vector(0, -.5f, 0), new Vector(1, 0, 0));

            var particle = new Particle(posVector, velVector, Color.Snow, randLife, _random.Next(5, 10));

            return particle;
        }
    }
}
