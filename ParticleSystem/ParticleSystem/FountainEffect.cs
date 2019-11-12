using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace ParticleSystem
{
    public class FountainEffect : BaseParticleSystem
    {
        private Random _random = new Random();
        public FountainEffect()
        {
            Regenerate = true;
            MinimumParticlesCount = 200;
            ParticlesMaxLife = 400;
            Environment.GetInstance().Gravity = new Vector(0f, -.0001f, 0f);
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
            var velVector = _random.GetRandomVector(new Vector(-0.001f, -0.01f, 0), new Vector(0.01f, 0.001f, 0));

            var randLife = _random.Next(100, ParticlesMaxLife);
            var posVector = new Vector(.5f, .5f, 0);

            var particle = new Particle(posVector, velVector, _random.GetRandomColor(), randLife, _random.Next(2, 10));

            return particle;
        }
    }
}
