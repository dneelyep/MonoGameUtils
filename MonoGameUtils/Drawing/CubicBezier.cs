using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace MonoGameUtils.Drawing
{
    /// <summary>
    /// Class that represents a Bezier curve made up of 4 control points.
    /// </summary>
    public class CubicBezier
    {
        /// <summary>
        /// The control points that make up this CubicBezier.
        /// </summary>
        internal List<Vector2> Points { get; private set; }

        internal CubicBezier(Vector2 point1,
                             Vector2 point2,
                             Vector2 point3,
                             Vector2 point4)
        {
            Debug.Assert(point1 != null && point2 != null && point3 != null && point4 != null);

            this.Points = new List<Vector2>();
            this.Points.AddRange(new Vector2[] { point1, point2, point3, point4 });
        }

        /// <summary>
        /// Returns the point at the specified value of t. t
        /// should range from 0 to 1, inclusive.
        /// </summary>
        internal Vector2 GetPoint(float t)
        {
            Debug.Assert(t >= 0f && t <= 1f);

            Vector2 q1 = this.Points[0] + ((this.Points[1] - this.Points[0])*t);
            Vector2 q2 = this.Points[1] + ((this.Points[2] - this.Points[1])*t);
            Vector2 q3 = this.Points[2] + ((this.Points[3] - this.Points[2])*t);

            Vector2 r1 = q1 + ((q2 - q1)*t);
            Vector2 r2 = q2 + ((q3 - q2)*t);

            Vector2 returnPoint = new Vector2(q1.X + ((q2.X - q1.X) * t),
                                              q1.Y + ((q2.Y - q1.Y) * t));

            return r1 + ((r2 - r1)*t);
        }
    }
}

