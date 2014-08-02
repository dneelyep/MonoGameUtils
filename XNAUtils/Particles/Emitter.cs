using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameUtils.Particles
{
    /// <summary>
    /// Class that represents a point from which Particles can be emitted.
    /// </summary>
    public class Emitter
        : GameComponent
    {
        /// <summary>
        /// The coordinates of this Emitter in the game.
        /// </summary>
        public Vector2 Location;
        // TODO Implement all of these:
//        a particle emission frequency,
//        a list of particle types to emit,
//        a particle emission style (sequentially emit all particles in list? Randomly? Some other pattern?).
//        An Emitter is a GameComponent, but not necessarily Draw()able. It can be updated on Update().
        public Emitter(Game game, Vector2 location) : base(game)
        {
            this.Location = location;
        }

        public override void Update(GameTime gameTime)
        {
            // TODO Here, implement the logic to implement particles.
            base.Update(gameTime);
        }
    }
}
