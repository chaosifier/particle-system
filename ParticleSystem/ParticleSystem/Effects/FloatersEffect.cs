using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace ParticleSystem.Effects
{
    public class FloatersEffect : BaseParticleSystem
    {
        private Random _random = new Random();
        public FloatersEffect()
        {
            Regenerate = true;
            MaximumParticlesCount = 200;
            ParticlesMaxLife = 500;
            Environment.GetInstance().Wind = Vector.Zero;//new Vector(0.0001f, 0f, 0f);
            Environment.GetInstance().Gravity = Vector.Zero; //new Vector(0f, -.0001f, 0f);
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

                    //updatingParticle.Update();
                    updatingParticle.Update(ParticlesMaxLife == -1);

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
            var velVector = Vector.Zero;//_random.GetRandomVector(new Vector(-0.01f, -0.01f, 0), new Vector(0.01f, 0.01f, 0));

            var randLife = -1;//_random.Next(200, ParticlesMaxLife);
            var posVector = _random.GetRandomVector(new Vector(0, 0, 0), new Vector(1, 1, 0)); //new Vector(.5f, .5f, 0);

            var particle = new Particle(posVector, velVector, _random.GetRandomColor(), randLife, _random.Next(3, 14));

            return particle;
        }
    }
}
