using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameUtils.Particles
{
    /// <summary>
    /// Represents a single, visible particle.
    /// </summary>
    public class Particle
        : DrawableGameComponent
    {
        /// <summary>
        /// The SpriteBatch used to Draw() this Particle.
        /// </summary>
        internal SpriteBatch SpriteBatch;

        /// <summary>
        /// The coordinates of this Particle in the game.
        /// </summary>
        public Vector2 Location;

        /// <summary>
        /// The angle of this Particle. Range is between 0 and 360.
        /// 0 degrees is facing directly right from the y-axis, and increases
        /// counter-clockwise towards 360 degrees around the origin.
        /// </summary>
        public float Orientation;

        /// <summary>
        /// This Particle's velocity in the X- and Y-directions.
        /// </summary>
        public Vector2 Velocity;

        /// <summary>
        /// This Particle's acceleration in the X- and Y-directions.
        /// </summary>
        public Vector2 Acceleration;

        /// <summary>
        /// How fast this Particle moves, with respect to its
        /// emitter, when the particle is emitted.
        /// </summary>
        public Vector2 StartVelocity;

        /// <summary>
        /// How fast this Particle accelerates, with respect
        /// to its emitter, when the particle is emitted.
        /// </summary>
        public Vector2 StartAcceleration;

        /// <summary>
        /// The Texture2D used to visually represent this Particle.
        /// </summary>
        public Texture2D Texture;

        // TODO This should take into account Orientation.
        /// <summary>
        /// The physical space on the screen that this Particle takes up.
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)this.Location.X,
                                     (int)this.Location.Y,
                                     this.Texture.Width,
                                     this.Texture.Height);
            }
        }

        public Particle(Game game,
                        SpriteBatch spriteBatch,
                        Vector2 location,
                        float orientation,
                        Vector2 velocity,
                        Vector2 acceleration,
                        Vector2 startVelocity,
                        Vector2 startAcceleration,
                        Texture2D texture) : base(game)
        {
            this.SpriteBatch = spriteBatch;
            this.Location = location;
            this.Orientation = orientation;
            this.Velocity = velocity;
            this.Acceleration = acceleration;
            this.StartVelocity = startVelocity;
            this.StartAcceleration = startAcceleration;
            this.Texture = texture;
        }

        // TODO This should probably inherit from an object that
        //      handles transforming acceleration into changes in
        //      velocity and position.
        public override void Update(GameTime gameTime)
        {
            this.Location += this.Velocity;
            this.Velocity += this.Acceleration;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.SpriteBatch.Draw(this.Texture,
                                  this.Location,
                                  new Rectangle(0, 0, this.Texture.Width, this.Texture.Height),
                                  Color.White,
                                  this.Orientation,
                                  Vector2.Zero,
                                  1.0f,
                                  SpriteEffects.None,
                                  1);
            base.Draw(gameTime);
        }
    }
}
