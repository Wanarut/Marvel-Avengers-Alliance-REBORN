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
    class SkillButton : Button
    {
        private Skill _skill;
        private bool isEnoughStamina;
        private SpriteFont Georg;
        public event EventHandler Click;

        public SkillButton(ContentManager content, string hero_name, string uniform_name, Skill skill)
        {
            _skill = skill;
            LoadContent(content,"Character/" + hero_name + "/" + uniform_name + "/" + skill.Get_Name());
            Georg = content.Load<SpriteFont>("Fonts/Georg");
            isEnoughStamina = true;
        }

        public Skill Get_Skill()
        {
            //if (_skill.Get_Cooldown()[0] > 0 || !isEnoughStamina) return null;
            return _skill;
        }

        public bool Get_EnoughStamina()
        {
            return isEnoughStamina;
        }

        public void Decrease_CoolDown()
        {
            _skill.Get_Cooldown()[0]--;
            if (_skill.Get_Cooldown()[0] < 1) _skill.Get_Cooldown()[0] = 0;
        }

        public void Re_CoolDown()
        {
            _skill.Get_Cooldown()[0] = _skill.Get_Cooldown()[1];
        }

        public SkillButton Get_me()
        {
            if (_skill.Get_Cooldown()[0] > 0 || !isEnoughStamina) return null;
            return this;
        }

        public void Update(Character hero)
        {
            if (hero.Get_Stamina() >= (_skill.Get_StaminaCost() * hero.Get_Max_Stamina() / 100))
            {
                isEnoughStamina = true;
            }
            else
            {
                isEnoughStamina = false;
                //return;
            }

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
            var color = Color.DarkGray;

            if (isPointed)
                color = Color.White;
            
            if (_skill.Get_Cooldown()[0] > 0)
                color = Color.RoyalBlue;

            if (!isEnoughStamina)
                color = Color.Salmon;

            spriteBatch.Draw(_texture, Rectangle,new Rectangle(0,0,_texture.Width,_texture.Height),color,0,Vector2.Zero,SpriteEffects.None,0.05f);
            
            if (!isEnoughStamina)
            {
                spriteBatch.DrawString(Georg, "     NO\r\nSTAMINA", new Vector2(Position.X + 4, Position.Y + 14), Color.White,0,Vector2.Zero,1,SpriteEffects.None,0);
            }else

            if (_skill.Get_Cooldown()[0] > 0 && isEnoughStamina)
            {
                spriteBatch.DrawString(Georg, "       " + _skill.Get_Cooldown()[0] + "\r\n ROUND", new Vector2(Position.X + 5, Position.Y + 12), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            }
        }
    }
}
