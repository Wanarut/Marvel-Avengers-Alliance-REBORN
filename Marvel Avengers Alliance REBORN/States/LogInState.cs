using Marvel_Avengers_Alliance_REBORN.Buttons;
using Marvel_Avengers_Alliance_REBORN.Components;
using Marvel_Avengers_Alliance_REBORN.DATA;
using Marvel_Avengers_Alliance_REBORN.DATA.Heroes;
using Marvel_Avengers_Alliance_REBORN.Models;
using MarvMarvel_Avengers_Alliance_REBORN.Models;
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
        static public int numstage = 0;
        private List<Component> _menucomponent;
        private Background _background;
        private Textbox textbox;

        /*public LogInState()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            MediaPlayer.IsRepeating = true;
        }*/

        public LogInState(MAAGame game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _menucomponent = new List<Component>();
            _background = new Background();

            _background.LoadContent(_content, "Combat_Background/" + BG.BG_024);  //Set BackGround

            textbox = new Textbox(_content, "textbox1");
            song = _content.Load<Song>("Songs/" + Songs.Imagine_Dragons_Warriors);    //Set Song
            MediaPlayer.Play(song);

            var btn = new MenuButton(_content, Gadget.Agent_Recharge);
            btn.Position = new Vector2(674, 230);
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
                        if(textbox.Text.Length > 3)
                        {
                            MediaPlayer.Stop();
                            List<Character> enemies = new List<Character>();
                            enemies.Add(new Ant_Man(_content));
                            enemies.Add(new Captain_America(_content));
                            enemies.Add(new Cable(_content));
                            _game.Change_State(new LoadingState(_game, _graphicsDevice, _content,
                                new MapState(_game, _graphicsDevice, _content)));
                        }
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

        public override void Update(GameTime gameTime)
        {
            foreach (var btn in _menucomponent)
                btn.Update(gameTime);

            textbox.Update(gameTime);
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            _background.Draw(spriteBatch);
            textbox.Draw(gameTime, spriteBatch);

            foreach (var btn in _menucomponent)
                btn.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
    }
}
