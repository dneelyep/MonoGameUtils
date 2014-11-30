using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameUtils.UI
{
    /// <summary>
    /// Represents a rectangular button that can be clicked in a game.
    /// </summary>
    public class Button : DrawableGameComponent
    {
        public SpriteFont Font { get; set; }
        public Color TextColor { get; set; }
        public string Text { get; set; }
        public Rectangle Bounds { get; set; }
        public Color BackgroundColor { get; set; }

        private Texture2D ButtonTexture;

        private SpriteBatch spriteBatch;

        public Button(Game game, SpriteFont font, Color textColor, string text,
                      Rectangle bounds, Color backgroundColor, SpriteBatch spriteBatch) : base(game)
        {
            this.Font = font;
            this.TextColor = textColor;
            this.Text = text;
            this.Bounds = bounds;
            this.BackgroundColor = backgroundColor;
            this.spriteBatch = spriteBatch;
        }

        public override void Initialize()
        {
            this.ButtonTexture = new Texture2D(Game.GraphicsDevice, 1, 1);
            this.ButtonTexture.SetData<Color>(new Color[] { Color.White });

            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            // Draw the button background.
            spriteBatch.Draw(ButtonTexture, Bounds, BackgroundColor);

            // Draw the button text.
            spriteBatch.DrawString(Font, Text, new Vector2(Bounds.X + 5, Bounds.Y + 5), TextColor);

            base.Draw(gameTime);
        }
    }
}
