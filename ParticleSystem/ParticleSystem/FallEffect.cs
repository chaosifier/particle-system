using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace ParticleSystem
{
    public class FallEffect : BaseParticleSystem
    {
        private Random _random = new Random();
        public FallEffect()
        {
            ParticlesMaxLife = 100;
            Environment.GetInstance().Wind = Vector.Zero;//new Vector(0.0001f, 0f, 0f);
            Environment.GetInstance().Gravity = Vector.Zero; //new Vector(0f, -.0001f, 0f);
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
                updatingParticle = this[i];

                updatingParticle.Update();

                if (updatingParticle.Age > ParticlesMaxLife)
                {
                    Particles.RemoveAt(i);
                    particlesCount--;
                }
            }

            return particlesCount > 0;
        }

        protected override Particle GenerateParticle()
        {
            var velVector = _random.GetRandomVector(new Vector(-0.01f, -0.01f, 0), new Vector(0.01f, 0.01f, 0));

            var randLife = _random.Next(10, ParticlesMaxLife);

            return new Particle(new Vector(.5f, .5f, 0), velVector, _random.GetRandomColor(), randLife);
        }
    }
}
