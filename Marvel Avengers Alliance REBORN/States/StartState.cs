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
    class StartState : State
    {
        private Background Start_background;
        private MenuButton StartButton;
        private MenuButton ExitButton;

        public StartState(MAAGame game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Start_background = new Background();
            Start_background.LoadContent(_content, "Map_Background/" + BG.BackStart);

            song = _content.Load<Song>("Songs/" + Songs.StartState_Song);    //Set Song
            MediaPlayer.Play(song);

            StartButton = new MenuButton(_content, MapButton.StartButton);
            StartButton.Position = new Vector2((Start_background.Get_Width()/2) - StartButton.Get_Width() / 2, 320);
            StartButton.Click += Menu_was_Clicked;

            ExitButton = new MenuButton(_content, MapButton.ExitButton);
            ExitButton.Position = new Vector2((Start_background.Get_Width() / 2) - ExitButton.Get_Width() / 2, 520);
            ExitButton.Click += Menu_was_Clicked;
        }

        private void Menu_was_Clicked(object sender, EventArgs e)
        {
            switch (((MenuButton)sender).Get_Name())
            {
                case MapButton.StartButton:
                    {
                        _game.Change_State(new LoadingState(_game, _graphicsDevice, _content,
                            new LogInState(_game, _graphicsDevice, _content)));
                        break;
                    }
                case MapButton.ExitButton:
                    {
                        _game.Exit();
                        break;
                    }
            }
        }

        public override void Update(GameTime gameTime)
        {
            StartButton.Update(gameTime);
            ExitButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
 
            Start_background.Draw(spriteBatch);

            StartButton.Draw(spriteBatch);
            ExitButton.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
    }
}
