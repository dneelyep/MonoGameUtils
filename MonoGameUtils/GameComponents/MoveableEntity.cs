using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace MonoGameUtils.GameComponents
{
    /// <summary>
    /// Represents an entity with Position, Velocity, and Acceleration.
    /// Position is updated on each Update() based on Velocity, and Velocity
    /// is updated on each Update() based on Acceleration.
    /// </summary> 
    public class MoveableEntity
        : GameComponent 
    {
        /// <summary>
        /// This MoveableEntity's position on the screen.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// How much this MoveableEntity changes <see cref="Position"/>
        /// per call to <see cref="Update"/>
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// How much this MoveableEntity changes <see cref="Velocity"/>
        /// per call to <see cref="Update"/>.
        /// </summary>
        public Vector2 Acceleration { get; set; }

        /// <summary>
        /// Position, Velocity, and Acceleration are initialized to Vector2.Zero.
        /// </summary>
        public MoveableEntity(Game game)
            : base(game)
        {
            this.Position = Vector2.Zero;
            this.Velocity = Vector2.Zero;
            this.Acceleration = Vector2.Zero;
        }

        public MoveableEntity(Game game, Vector2 position, Vector2 acceleration, Vector2 velocity)
            : base(game)
        {
            this.Position = position;
            this.Velocity = velocity;
            this.Acceleration = acceleration;

            // Verify that all properties are properly initialized.
            Debug.Assert(position != null);
            Debug.Assert(position != null);
            Debug.Assert(position != null);
        }

        public override void Update(GameTime gameTime)
        {
            this.Position += this.Velocity;
            this.Velocity += this.Acceleration;

            base.Update(gameTime);
        }
    }
}