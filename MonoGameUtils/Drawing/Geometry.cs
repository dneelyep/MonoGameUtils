using Microsoft.Xna.Framework;
using System;

namespace MonoGameUtils.Drawing
{
    internal class Geometry
    {
        /// <summary>
        /// Gets the distance between two points, using the distance formula.
        /// </summary>
        /// <remarks>
        /// Distance formula is:
        /// c = sqrt((x-x0)^2 + (y-y0)^2)
        /// </remarks>
        internal static double Distance(Vector2 Destination, Vector2 Origin)
        {
            return Math.Sqrt( Math.Pow(Destination.X - Origin.X, 2) + Math.Pow(Destination.Y - Origin.Y, 2) );
        }
    }
}
