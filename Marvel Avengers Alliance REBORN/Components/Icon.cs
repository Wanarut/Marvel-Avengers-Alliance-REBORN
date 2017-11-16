using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace Marvel_Avengers_Alliance_REBORN.Components
{
    class Icon : Component
    {
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(0, 0, _texture.Width, _texture.Height);
            }
        }

        public Icon(ContentManager content, string hero_name, string uniform_name)
        {
            LoadContent(content, "Character/" + hero_name + "/" + uniform_name + "/" + hero_name + "_Icon");
        }

        public override void LoadContent(ContentManager content, string asset)
        {
            _texture = content.Load<Texture2D>(asset);
        }

        public void Draw(SpriteBatch spriteBatch,float scale, SpriteEffects effect = SpriteEffects.None)
        {
            var color = Color.White;
            //spriteBatch.Draw(_texture, Rectangle, color);
            spriteBatch.Draw(_texture,Position,Rectangle,color,0,Vector2.Zero, scale, effect, 0);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
