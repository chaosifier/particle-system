using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace ParticleSystem.Effects
{
    public class FountainEffect : BaseParticleSystem
    {
        private Random _random = new Random();
        public FountainEffect()
        {
            Regenerate = true;
            MaximumParticlesCount = 300;
            ParticlesMaxLife = 400;
            Environment.GetInstance().Gravity = new Vector(0f, -.0001f, 0f);
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
            var velVector = _random.GetRandomVector(new Vector(-0.005f, -0.005f, 0), new Vector(0.005f, -0.01f, 0));

            var randLife = _random.Next(50, ParticlesMaxLife);
            var posVector = new Vector(.5f, .8f, 0);

            var particle = new Particle(posVector, velVector, _random.GetRandomColor(), randLife, _random.Next(2, 13));

            return particle;
        }
    }
}
