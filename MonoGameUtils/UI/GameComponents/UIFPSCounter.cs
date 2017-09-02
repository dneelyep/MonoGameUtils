using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameUtils.Diagnostics;

namespace MonoGameUtils.UI.GameComponents
{
    public class UIFPSCounter : DrawableGameComponent
    {
        private FPSCounter _fpsCounter = new FPSCounter();
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private Vector2 _topLeftPoint;
        private Vector2 _avgFPSLocation;
        private readonly Color _fontColor = Color.Black;

        public UIFPSCounter(Game game,
                            SpriteFont font,
                            Vector2 topLeftPoint,
                            SpriteBatch spriteBatch) : base(game)
        {
            _spriteBatch = spriteBatch;
            _font = font;
            _topLeftPoint = topLeftPoint;
            _avgFPSLocation = Vector2.Add(_topLeftPoint, new Vector2(0, 20));
        }

        public override void Update(GameTime gameTime)
        {
            _fpsCounter.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.DrawString(_font, "Current FPS: " + _fpsCounter.CurrentFPS, _topLeftPoint, _fontColor);
            _spriteBatch.DrawString(_font, "Avg FPS: " + _fpsCounter.AverageFPS, _avgFPSLocation, _fontColor);

            base.Draw(gameTime);
        }
    }
}
