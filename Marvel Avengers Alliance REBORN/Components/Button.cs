using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Marvel_Avengers_Alliance_REBORN.Models
{
    abstract class Button : Component
    {
        #region Field
        protected MouseState currentMouse;
        protected MouseState previousMouse;
        protected bool isPointed;
        protected bool isFocus;
        protected int margin = 5;
        public event EventHandler Click;
        #endregion

        #region Poperties
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public Rectangle MarginRectangle
        {
            get
            {
                return new Rectangle((int)Position.X + margin, (int)Position.Y + margin, _texture.Width - (margin * 2), _texture.Height - (margin * 2));
            }
        }
        #endregion

        public override void LoadContent(ContentManager content, string asset)
        {
            _texture = content.Load<Texture2D>(asset);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var color = Color.DarkGray;

            if (isPointed||isFocus)
                color = Color.White;

            spriteBatch.Draw(_texture, Rectangle, color);
        }
        public void Set_IsFocusIcon(bool logic)
        {
            isFocus = logic;
        }

        public override void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            isPointed = false;

            if (mouseRectangle.Intersects(MarginRectangle))
            {
                isPointed = true;

                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
