using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNAUtils.Particles
{
    /// <summary>
    /// A <c>Particle</c> <c>Emitter</c> that randomly chooses a next
    /// <c>Particle</c> to emit.
    /// </summary>
    public class RandomizedEmitter
        : Emitter, IEmitter
    {
        private Random RNG;

        public RandomizedEmitter(Game game, Vector2 location)
            : base(game, location)
        {
            this.RNG = new Random();
        }

        public Particle EmitParticle(List<Particle> particleTypes)
        {
            Particle foundParticle = particleTypes[RNG.Next(particleTypes.Count)];
            Particle emittedParticle = new Particle(foundParticle.Game,
                                                    foundParticle.SpriteBatch,
                                                    foundParticle.Location,
                                                    foundParticle.Orientation,
                                                    foundParticle.Velocity,
                                                    foundParticle.Acceleration,
                                                    foundParticle.StartVelocity,
                                                    foundParticle.StartAcceleration,
                                                    foundParticle.Texture);
            return emittedParticle;
        }
    }
}
