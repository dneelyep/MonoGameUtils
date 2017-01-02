using System.Diagnostics.Contracts;
using Microsoft.Xna.Framework;

namespace MonoGameUtils.Extensions
{
    public static class RectangleExtensions
    {
        /// <summary>
        /// This <see cref="Rectangle"/>'s location, represented as a Vector2D rather than a Point.
        /// </summary>
        public static Vector2 LocationV2(this Rectangle rect)
        {
            Contract.Requires(rect != null);

            return rect.Location.ToVector2();
        }
    }
}
