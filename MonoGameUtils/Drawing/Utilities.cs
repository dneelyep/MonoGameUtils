using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameUtils.Drawing
{
    /// <summary>
    /// Various useful utility methods that don't obviously go elsewhere.
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Draw the provided model in the world, given the provided matrices.
        /// </summary>
        /// <param name="model">The model to draw.</param>
        /// <param name="world">The world matrix that the model should be drawn in.</param>
        /// <param name="view">The view matrix that the model should be drawn in.</param>
        /// <param name="projection">The projection matrix that the model should be drawn in.</param>
       public static void DrawModel(Model model, Matrix world, Matrix view, Matrix projection)
        {
           Contract.Requires(model != null);
           Contract.Requires(world != null);
           Contract.Requires(view != null);
           Contract.Requires(projection != null);

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }

                mesh.Draw();
            }
        }
    }
}