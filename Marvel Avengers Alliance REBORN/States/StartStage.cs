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
        private IconMap StartButton;

        public StartState(MAAGame game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Start_background = new Background();
            Start_background.LoadContent(_content, "Map_Background/" + BG.BackStart);

            StartButton = new IconMap(_content, MapButton.StartButton);
            StartButton.Position = new Vector2((Start_background.Get_Width()/2)-StartButton.Get_Width()/2, 270);
            StartButton.Click += Menu_was_Clicked;
        }

        private void Menu_was_Clicked(object sender, EventArgs e)
        {
            _game.Change_State(new LoadingState(_game, _graphicsDevice, _content, 
                new LogInState(_game, _graphicsDevice, _content)));

        }

        public override void Update(GameTime gameTime)
        {
            StartButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
 
            Start_background.Draw(spriteBatch);
            StartButton.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
    }
}
