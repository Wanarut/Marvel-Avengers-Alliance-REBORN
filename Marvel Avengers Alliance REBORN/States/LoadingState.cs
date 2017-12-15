using Marvel_Avengers_Alliance_REBORN.Components;
using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Marvel_Avengers_Alliance_REBORN.DATA;

namespace Marvel_Avengers_Alliance_REBORN.States
{
    class LoadingState : State
    {
        private Background loading_background;
        private Sprite loading_icon;
        private State _next_state;

        public LoadingState(MAAGame game, GraphicsDevice graphicsDevice, ContentManager content, State next_state) : base(game, graphicsDevice, content)
        {
            loading_background = new Background();
            loading_background.LoadContent(_content, "Map_Background/" + BG.LoadingMap);  //Set BackGround
            
            loading_icon = new Sprite(content, "Map_Background/LoadingIcon");
            loading_icon.Position = new Vector2(loading_background.Get_Width() / 2 - 100, loading_background.Get_Height() / 2 + 100);

            loading_icon.Set_IsFocus(true);

            _next_state = next_state;

            game.TargetElapsedTime = TimeSpan.FromSeconds(1 / 30.0); // Frame rate is 30 fps for smooth loading icon.
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            loading_background.Draw(spriteBatch);

            loading_icon.DrawFrame(spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            loading_icon.Play();

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds * 2;

            loading_icon.UpdateFrame(elapsed);

            if (loading_icon.Get_IsDead())
            {
                _game.Change_State(_next_state);
            }
        }
    }
}
