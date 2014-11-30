using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameUtils.Extensions
{
    public static class GraphicsDeviceExtensions
    {
        /// <summary>
        /// A <see cref="Vector2"/> representing the center of the
        /// provided <see cref="GraphicsDevice"/>'s <see cref="Viewport"/>.
        /// </summary>
        public static Vector2 ScreenCenter(this GraphicsDevice graphics)
        {
            return new Vector2(graphics.Viewport.Bounds.X/2,
                               graphics.Viewport.Bounds.Y/2);
        }
    }
}
