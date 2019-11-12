using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace ParticleSystem
{
    public class RainEffect : BaseParticleSystem
    {
        private Random _random = new Random();
        public RainEffect()
        {
            Regenerate = true;
            MinimumParticlesCount = 600;
            ParticlesMaxLife = 600;
            Environment.GetInstance().Wind = new Vector(0.000001f, 0f, 0f);
            Environment.GetInstance().Gravity = new Vector(0f, -.0002f, 0f);
        }

        public override void AddNewParticle()
        {
            Particles.Add(GenerateParticle());
        }

        public override bool Update()
        {
            int particlesCount = Particles.Count;
            Particle updatingParticle;

            for (int i = 0; i < particlesCount; i++)
            {
                updatingParticle = Particles[i];

                updatingParticle.Update();

                if (ParticlesMaxLife != -1 && updatingParticle.Age > ParticlesMaxLife)
                {
                    Particles.RemoveAt(i);
                    particlesCount--;
                }

                if (Regenerate && particlesCount < MinimumParticlesCount)
                {
                    AddNewParticle();
                    particlesCount++;
                }
            }

            return particlesCount > 0;
        }

        protected override Particle GenerateParticle()
        {
            var velVector = Vector.Zero;
            var randLife = _random.Next(200, ParticlesMaxLife);
            var posVector = _random.GetRandomVector(new Vector(0, -.5f, 0), new Vector(1, 0, 0));

            var particle = new Particle(posVector, velVector, Color.LightBlue, randLife, _random.Next(3, 6));

            return particle;
        }
    }
}
