using Marvel_Avengers_Alliance_REBORN.Buttons;
using Marvel_Avengers_Alliance_REBORN.Components;
using Marvel_Avengers_Alliance_REBORN.DATA;
using Marvel_Avengers_Alliance_REBORN.DATA.Heroes;
using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.States
{
    class LogInState : State
    {
        private List<Component> _menucomponent;
        private Background _background;

        public LogInState(MAAGame game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _menucomponent = new List<Component>();
            _background = new Background();
            _background.LoadContent(game.Content, "Combat_Background/" + BG.BG_024);  //Set BackGround

            var btn = new MenuButton(content, Gadget.Agent_Recharge);
            btn.Position = new Vector2(0, 0);
            _menucomponent.Add(btn);
            btn.Click += Menu_was_Clicked;
        }

        private void Menu_was_Clicked(object sender, EventArgs e)
        {
            Console.Out.WriteLine(((MenuButton)sender).Get_Name());
            switch (((MenuButton)sender).Get_Name())
            {
                case Gadget.Agent_Recharge:
                    {
                        
                        break;
                    }
                case Gadget.Arc_Reactor_Charge:
                    {
                        break;
                    }
                case Gadget.Curative_Measure:
                    {
                        break;
                    }
                case Gadget.Agent_Inventory:
                    {
                        break;
                    }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();

            _background.Draw(spriteBatch);

            foreach (var btn in _menucomponent)
                btn.Draw(spriteBatch);

            //spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {

            foreach (var btn in _menucomponent)
                btn.Update(gameTime);
        }
    }
}
