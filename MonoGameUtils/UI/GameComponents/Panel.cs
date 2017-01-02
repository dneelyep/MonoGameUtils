using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameUtils.UI.GameComponents
{
    public class Panel : DrawableGameComponent
    {
        private readonly SpriteBatch _spriteBatch;
        private Color _backgroundColor;

        private Rectangle _bounds;
        private Texture2D _texture;

        public Rectangle Bounds
        {
            get { return _bounds; }
            set
            {
                _bounds = value;
                RecalculateTexture();
            }
        }

        public Texture2D Texture
        {
            get { return _texture; }
            set
            {
                _texture = value;
                Texture.SetData(BackgroundColorArray);
            }
        }

        private Color[] BackgroundColorArray { get; set; }

        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                RecalculateTexture();
            }
        }

        public Panel(Game game, Color backgroundColor, Rectangle bounds, SpriteBatch spriteBatch)
            : base(game)
        {
            _backgroundColor = backgroundColor;
            _spriteBatch = spriteBatch;

            Bounds = bounds;
            Texture = new Texture2D(GraphicsDevice, Bounds.Width, Bounds.Height);
        }

        private void RecalculateTexture()
        {
            BackgroundColorArray = CalculateBackgroundColorArray();
            Texture?.SetData(BackgroundColorArray);
        }

        private Color[] CalculateBackgroundColorArray()
        {
            var backgroundColors = new Color[Bounds.Width * Bounds.Height];
            for (var index = 0; index < backgroundColors.Length; index++)
            {
                backgroundColors[index] = BackgroundColor;
            }
            return backgroundColors;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(Texture, Bounds, Color.White);

            base.Draw(gameTime);
        }
    }
}