using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace ParticleSystem.Effects
{
    public class SpaceTravelEffect : BaseParticleSystem
    {
        private Random _random = new Random();
        public SpaceTravelEffect()
        {
            Regenerate = true;
            MaximumParticlesCount = 40;
            ParticlesMaxLife = 1000;
            Environment.GetInstance().Gravity = new Vector(0f, 0f, 0f);
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
            var velVector = _random.GetRandomVector(new Vector(0.01f, 0.01f, 0.1f), new Vector(0.5f, 0.5f, 0.9f));

            var posVector = new Vector(.5f, .5f, 0);

            var particle = new Particle(posVector, velVector, Color.Gold, ParticlesMaxLife, 13);

            return particle;
        }
    }
}
