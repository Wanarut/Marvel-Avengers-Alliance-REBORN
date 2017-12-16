using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.Buttons
{
    class IconMap : Button
    {

        private string IconMap_name;
        private bool isBoss;
        public event EventHandler Click;

        public IconMap(ContentManager content, string Icon1_name)
        {
            IconMap_name = Icon1_name;
            LoadContent(content, "MapButton/" + IconMap_name);
        }

        public string Get_Name()
        {
            return IconMap_name;
        }

        public void Set_IsFocusIcon(bool logic)
        {
            isFocus = logic;
        }

        public void Set_isBoss(bool logic)
        {
            isBoss = logic;
        }

        public bool Get_isBoss()
        {
            return isBoss;
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            var color = Color.White;

            if (Position.Y <= 500) color = Color.DarkSlateGray;

            if (isFocus)
                color = Color.White;

            if (isBoss)
                color = Color.Crimson;

            spriteBatch.Draw(_texture, Rectangle, color);
        }
    }
}
