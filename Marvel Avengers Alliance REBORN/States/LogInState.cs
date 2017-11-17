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
    class LogInState : MAAGame
    {
        private List<Component> _menucomponent;
        private Background _background;
        private Textbox textbox;

        public LogInState()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            MediaPlayer.IsRepeating = true;
        }

        public LogInState(MAAGame game, GraphicsDeviceManager graphicsDevice, ContentManager content)
        {
            _game = game;
            graphics = graphicsDevice;
            Content = content;

            //graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";
            IsMouseVisible = true;
            MediaPlayer.IsRepeating = true;

            TargetElapsedTime = TimeSpan.FromSeconds(1 / 15.0); // Frame rate is 15 fps.
        }

        protected override void Initialize()
        {
            Set_Windows_size(SCREEN_WIDTH, SCREEN_HEIGHT);

            _menucomponent = new List<Component>();
            _background = new Background();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _background.LoadContent(Content, "Combat_Background/" + BG.BG_024);  //Set BackGround

            textbox = new Textbox(Content, "textbox1");
            song = Content.Load<Song>("Songs/" + Songs.Imagine_Dragons_Warriors);    //Set Song
            MediaPlayer.Volume -= 0.2f;
            MediaPlayer.Play(song);

            var btn = new MenuButton(Content, Gadget.Agent_Recharge);
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
                        MediaPlayer.Stop();
                        List<Character> enemies = new List<Character>();
                        enemies.Add(new Ant_Man(Content));
                        enemies.Add(new Captain_America(Content));
                        enemies.Add(new Cable(Content));
                        _game.Change_State(new MapState(this, graphics, Content));
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

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected void PostUpdate(GameTime gameTime)
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (var btn in _menucomponent)
                btn.Update(gameTime);

            textbox.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            _background.Draw(spriteBatch);
            textbox.Draw(gameTime, spriteBatch);

            foreach (var btn in _menucomponent)
                btn.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
