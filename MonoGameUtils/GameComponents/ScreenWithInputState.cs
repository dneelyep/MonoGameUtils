using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameUtils.GameComponents
{
    /// <summary>
    /// A screen that tracks the Keyboard and Mouse state between
    /// Update() calls.
    /// </summary>
    public class ScreenWithInputState
        : DrawableGameComponent
    {
        protected MouseState previousMouseState;
        protected MouseState currentMouseState;
        protected KeyboardState previousKeyboardState;
        protected KeyboardState currentKeyboardState;

        /// <summary>
        /// Gets whether or not the left mouse button was pressed in the
        /// previous Update() and is now released.
        /// </summary>
        protected bool LeftMouseButtonReleased
        {
            get
            {
                return (previousMouseState.LeftButton == ButtonState.Pressed &&
                        currentMouseState.LeftButton == ButtonState.Released);
            }
        }

        /// <summary>
        /// Gets whether or not the right mouse button was pressed in the
        /// previous Update() and is now released.
        /// </summary>
        protected bool RightMouseButtonReleased
        {
            get
            {
                return (previousMouseState.RightButton == ButtonState.Pressed &&
                        currentMouseState.RightButton == ButtonState.Released);
            }
        }

        /// <summary>
        /// Gets whether or not the middle mouse button was pressed in the
        /// previous Update() and is now released.
        /// </summary>
        protected bool MiddleMouseButtonReleased
        {
            get
            {
                return (previousMouseState.MiddleButton == ButtonState.Pressed &&
                        currentMouseState.MiddleButton == ButtonState.Released);
            }
        }

        public ScreenWithInputState(Game game)
            : base(game)
        {
        }

        public override void Update(GameTime gameTime)
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            base.Update(gameTime);
        }
    }
}
