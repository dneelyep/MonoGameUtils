using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameUtils.Drawing
{
    /// <summary>
    /// Represents a collection of connected <see cref="CubicBezier"/> curves.
    /// </summary>
    public class CubicBezierPath
    {
        /// <summary>
        /// The list of Bezier curves that belong to this path.
        /// </summary>
        public List<CubicBezier> Curves { get; set; }

        /// <summary>
        /// Creates a default, empty <see cref="CubicBezierPath"/>.
        /// </summary>
        public CubicBezierPath()
        {
            this.Curves = new List<CubicBezier>();
        }

        /// <summary>
        /// Create a new bezier path, using the provided curve collection
        /// to make up the path.
        /// </summary>
        /// <param name="curves">The curves that this path should be made of.</param>
        public CubicBezierPath(List<CubicBezier> curves)
        {
            Debug.Assert(curves != null);

            this.Curves = curves;
        }
    }
}
