using Marvel_Avengers_Alliance_REBORN.DATA;
using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.Components
{
    class StatusBar : Component
    {
        #region Field
        private const int MAX_WIDTH = 80;
        private const int MAX_HEIGHT = 8;
        
        private string _hero_name;
        private int _bar_width;
        private int _cur_value;
        private int _max_value;
        private string _type;

        private SpriteFont Calibri;
        private SpriteFont Conso;
        #endregion

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int) Position.X, (int) Position.Y, _bar_width, MAX_HEIGHT);
            }
        }

        public StatusBar(string hero_name, int max_value, string type,ContentManager content)
        {
            _hero_name = hero_name;
            _max_value = max_value;
            _type = type;

            _cur_value = max_value;
            _bar_width = MAX_WIDTH;

            LoadContent(content, "Component/" + _type);
        }

        public void Set_Value(int cur_value)
        {
            _cur_value = cur_value;
        }

        public void Notify(Calculator component)
        {

        }

        public override void LoadContent(ContentManager content, string asset)
        {
            _texture = content.Load<Texture2D>(asset);
            Calibri = content.Load<SpriteFont>("Fonts/Calibri");
            Conso = content.Load<SpriteFont>("Fonts/Conso");
        }

        public override void Update(GameTime gameTime)
        {
            _bar_width = (_cur_value * MAX_WIDTH) / _max_value;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var color = Color.White;
            
            spriteBatch.Draw(_texture, new Rectangle(Convert.ToInt32(Position.X) + 43, Convert.ToInt32(Position.Y), _bar_width, MAX_HEIGHT), Color.White);
            spriteBatch.DrawString(Calibri, _type + "                                          " + (_cur_value).ToString(), Position, Color.White);
            if(_type is Gadget.HEALTH) spriteBatch.DrawString(Conso, _hero_name + "", new Vector2(Position.X + 160, Position.Y + 2), Color.White);
        }
    }
}
