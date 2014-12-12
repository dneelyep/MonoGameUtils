using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MonoGameUtils.GameComponents
{
    /// <summary>
    /// A solid-color rectangle that can be drawn on-screen.
    /// </summary>
    internal class Panel : DrawableGameComponent
    {
        #region "Properties"
        public Rectangle Bounds { get; set; }
        #endregion

        private readonly Color BACKGROUND_COLOR;

        private Texture2D Texture { get; set; }

        private SpriteBatch mSpriteBatch;

        public Panel(Rectangle bounds, Color backgroundColor, SpriteBatch spriteBatch, Game game) : base(game)
        {
            Bounds = bounds;
            BACKGROUND_COLOR = backgroundColor;
            mSpriteBatch = spriteBatch;
        }

        public override void Initialize()
        {
            Texture = new Texture2D(Game.GraphicsDevice, 1, 1);
            Texture.SetData<Color>(new Color[] { BACKGROUND_COLOR } );

            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            mSpriteBatch.Draw(Texture, Bounds, BACKGROUND_COLOR);

            base.Draw(gameTime);
        }
    }
}
