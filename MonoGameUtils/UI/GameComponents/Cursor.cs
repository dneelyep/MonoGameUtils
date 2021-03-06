﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameUtils.UI.GameComponents
{
    /// <summary>
    /// A simple cursor that will follow the user's mouse movements.
    /// </summary>
    public class Cursor : DrawableGameComponent
    {
        private Texture2D Texture { get; set; }
        private Game game { get; set; }

        // TODO Cursor width/height should be user-specifyable.
        // TODO The user should have more options than just displaying a rectangle for the cursor.
        private const int CURSOR_WIDTH = 10;
        private const int CURSOR_HEIGHT = 10;

        /// <summary>
        /// The color of the Cursor.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// The SpriteBatch to be used to draw this Cursor.
        /// </summary>
        private SpriteBatch spriteBatch { get; set; }

        public event EventHandler<CursorClickEventArgs> Click;

        private bool _isMousePressed = false;

        private MouseState CurrentMouseState;

        public Rectangle Bounds => new Rectangle(CurrentMouseState.Position.X,
                                                 CurrentMouseState.Position.Y,
                                                 CURSOR_WIDTH,
                                                 CURSOR_HEIGHT);

        public Cursor(Game game, SpriteBatch spriteBatch, Color color) : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.Color = color;
        }

        public override void Initialize()
        {
            this.Texture = new Texture2D(game.GraphicsDevice, 1, 1);
            this.Texture.SetData<Color>(new Color[] { Color.White });

            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(Texture, Bounds, Color);

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            CurrentMouseState = Mouse.GetState();

            if (CurrentMouseState.LeftButton == ButtonState.Pressed && !_isMousePressed)
            {
                _isMousePressed = true;
                if (Click != null)
                {
                    Click.Invoke(this, new CursorClickEventArgs(Bounds));
                }
            }

            if (CurrentMouseState.LeftButton == ButtonState.Released)
            {
                _isMousePressed = false;
            }

            base.Update(gameTime);
        }
    }

    public class CursorClickEventArgs : EventArgs
    {
        public Rectangle CursorBounds { get; }

        public CursorClickEventArgs(Rectangle cursorBounds)
        {
            CursorBounds = cursorBounds;
        }
    }
}