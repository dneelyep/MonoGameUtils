using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Microsoft.Xna.Framework;

namespace MonoGameUtils.Extensions
{
    public static class GameComponentCollectionExtensions
    {
        public static void AddRange(this GameComponentCollection gameComponents, IEnumerable<GameComponent> collection)
        {
            Contract.Requires(gameComponents != null);
            Contract.Requires(collection != null);

            foreach (GameComponent component in collection)
            {
                gameComponents.Add(component);
            }
        }
    }
}
