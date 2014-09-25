using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace MonoGameUtils.Drawing
{
    /// <summary>
    /// Helper methods for drawing useful objects, etc.
    /// </summary>
    public class Drawing
    {
        // TODO What I need to do here:
        // * (Ideaaly) Add a GetCircleWithoutChunkcs() method which returns a circle texture missing a list of angles from starting angles.
        public static Texture2D GetCircleTexture(int Radius, Color Color, GraphicsDevice graphicsDevice)
        {
            Debug.Assert(Radius >= 0, "Radius should never be negative.");

            int width = Radius * 2;
            int height = Radius * 2;

            Color[] circleTextureTexels = new Color[width * height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (Geometry.Distance(new Vector2(x, y), new Vector2(width / 2, height / 2)) <= Radius)
                    {
                        circleTextureTexels[x + (y * height)] = Color;
                    }
                    else
                    {
                        circleTextureTexels[x + (y * height)] = Color.Transparent;
                    }
                }
            }

            Texture2D circleTexture = new Texture2D(graphicsDevice, width, height);
            circleTexture.SetData<Color>(circleTextureTexels);

            return circleTexture;
        }

        public static Texture2D GetCircleTextureMissingChunk(int Radius, Color Color, float startAngle,
                                                             float missingChunkDegrees, GraphicsDevice graphicsDevice)
        {
            Debug.Assert(Radius >= 0, "Radius should never be negative.");
            Debug.Assert(missingChunkDegrees >= 0, "Can't be missing negative degrees of chunk.");

            // TODO I should probably modify these to just return the array
            //      of texels. Otherwise, memory leaks are very likely.
            // TODO This method has abysmal performance when used for semi-large circles.
            // * One easy win: Calculate the set of points inside the circle *once*, and then loop through
            //   that list of points below, and check if a point inside that set is a missing chunk or not.
            //   That will get rid of a crap ton of unneeded calculations.
            // TODO Simpler than doing all this nastiness:
            // * Do things in polar coordinates.
            //   So I'd say:
            //   for each texel in the texture:
            //       if (the texel is inside the circle [determined by polar to rectangular coords conversion]
            //           and theta is

            // TODO Should probably refactor this to use GetCircleTexture, and overwrite it. Maybe.
            int width = Radius * 2;
            int height = Radius * 2;
            Vector2 Center = new Vector2(width / 2, height / 2);

            Color[] circleTextureTexels = new Color[width * height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // TODO An Origin point might be useful for calculations of xory / 2.
                    // Add a minor x-offset to avoid division by 0.
                    double angleWRTCenter = Math.Atan2(y - Center.Y, x - Center.X + 0.001f) * (180/Math.PI);

                    //if (x <= Center.X && y >= Center.Y) angleWRTCenter += 90;
                    //if (x <= Center.X && y <= Center.Y) angleWRTCenter += 180;
                    //if (x >= Center.X && y <= Center.Y) angleWRTCenter += 360;
                    if (y <= Center.Y || angleWRTCenter > 340)
                        angleWRTCenter += 360;

                    // Check if the point is inside the circle's radius AND
                    // not inside the chunk of the circle that is being excluded.
                    if (Geometry.Distance(new Vector2(x, y), Center) <= Radius)
                    {
                        circleTextureTexels[y + (x * width)] =
                                (startAngle + missingChunkDegrees > 360 && (angleWRTCenter % 360) >= ((startAngle + missingChunkDegrees) % 360)) ||
                                ((angleWRTCenter % 360) >= startAngle &&
                                 (angleWRTCenter % 360) <= (startAngle + missingChunkDegrees)) ? Color.Transparent : Color;
                    }
                    else
                    {
                        circleTextureTexels[y + (x * width)] = Color.Transparent;
                    }
                }
            }

            Texture2D circleTexture = new Texture2D(graphicsDevice, width, height);
            circleTexture.SetData<Color>(circleTextureTexels);

            return circleTexture;
        }


        internal static Color[,] TextureTo2DArray(Texture2D texture)
        { 
            Color[] colors1D = new Color[texture.Width * texture.Height];
            texture.GetData(colors1D);

            Color[,] colors2D = new Color[texture.Width, texture.Height];
            for (int x = 0; x < texture.Width; x++)
            {
                for (int y = 0; y < texture.Height; y++)
                {
                    colors2D[x, y] = colors1D[x + y * texture.Width];
                }
            }

            return colors2D;
        }
    }
}
