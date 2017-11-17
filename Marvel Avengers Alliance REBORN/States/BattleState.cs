﻿using Marvel_Avengers_Alliance_REBORN.Buttons;
using Marvel_Avengers_Alliance_REBORN.Components;
using Marvel_Avengers_Alliance_REBORN.DATA;
using Marvel_Avengers_Alliance_REBORN.DATA.Heroes;
using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.States
{
    class BattleState : State
    {
        public const int ONE_PLAYER = 1;
        public const int TWO_PLAYER = 2;

        #region Game Fields
        private List<Character> heroes;
        private List<MenuButton> menu_component;

        private Background combat_background;
        private Background empty_status_bar;
        private Background turn_bar;
        private Background skill_bar;
        private int cur_turn;
        protected Viewport viewport;
        #endregion

        //public BattleState()
        //{
        //    heroes = new List<Character>();

        //    //graphics = new GraphicsDeviceManager(this);
        //    Content.RootDirectory = "Content";
        //    IsMouseVisible = true;
        //    MediaPlayer.IsRepeating = true;

        //    TargetElapsedTime = TimeSpan.FromSeconds(1 / 15.0); // Frame rate is 15 fps.
            
        //    /*heroes.Add(new Ant_Man(Content));
        //    heroes.Add(new Ant_Man(Content));
        //    heroes.Add(new Deadpool(Content));
        //    heroes.Add(new Deadpool(Content));
        //    heroes.Add(new Cable(Content));
        //    heroes.Add(new Cable(Content));*/

        //    //heroes.Add(new Ant_Man(Content));
        //    //heroes.Add(new Ant_Man(Content));
        //    //heroes.Add(new Captain_America(Content));
        //    //heroes.Add(new Captain_America(Content));
        //    heroes.Add(new Cable(Content));
        //    heroes.Add(new Ant_Man(Content));
        //    heroes.Add(new Cable(Content));
        //    heroes.Add(new Ant_Man(Content));
        //    heroes.Add(new Cable(Content));
        //    heroes.Add(new Cable(Content));

        //    /*heroes.Add(new Ant_Man(Content));
        //    heroes.Add(new Captain_America(Content));
        //    heroes.Add(new Cable(Content));
        //    heroes.Add(new Deadpool(Content));
        //    heroes.Add(new Hulk(Content));
        //    heroes.Add(new X_23(Content));*/
        //}

        public BattleState(MAAGame game, GraphicsDevice graphicsDevice, ContentManager content, List<Character> avatar) : base(game, graphicsDevice, content)
        {
            heroes = new List<Character>(6);
            for (int i = 0; i < 6; i++) heroes.Add(null);
            
            heroes[0] = avatar[0];
            heroes[2] = avatar[1];
            heroes[4] = avatar[2];

            heroes[1] = avatar[3];
            heroes[3] = avatar[4];
            heroes[5] = avatar[5];

            game.TargetElapsedTime = TimeSpan.FromSeconds(1 / 15.0); // Frame rate is 15 fps.

            combat_background = new Background();
            empty_status_bar = new Background();
            turn_bar = new Background();
            skill_bar = new Background();
            menu_component = new List<MenuButton>();

            cur_turn = 0;

            song = _content.Load<Song>("Songs/" + Songs.Thor_Ragnarok_Soundtrack_Song);    //Set Song
            MediaPlayer.Play(song);

            combat_background.LoadContent(_content, "Combat_Background/" + BG.BG_011);  //Set BackGround

            empty_status_bar.LoadContent(_content, "Component/" + Gadget.Empty_Status_Bar);
            empty_status_bar.Position = new Vector2(0, 630 - empty_status_bar.Get_Height());
            turn_bar.LoadContent(_content, "Component/" + Gadget.Turn_Bar);
            turn_bar.Position = new Vector2((MAAGame.SCREEN_WIDTH / 2) - (turn_bar.Get_Width() / 2), 0);

            #region Load Menu
            var btn = new MenuButton(_content, Gadget.Agent_Recharge);
            btn.Position = new Vector2(((combat_background.Get_Width() - btn.Get_Width()) / 2) + ((4 - 0) * (btn.Get_Width() + 8)) - (btn.Get_Width() / 2), 496);
            menu_component.Add(btn);
            btn.Click += Menu_was_Clicked;
            btn = new MenuButton(_content, Gadget.Agent_Inventory);
            btn.Position = new Vector2(((combat_background.Get_Width() - btn.Get_Width()) / 2) + ((4 - 1) * (btn.Get_Width() + 8)) - (btn.Get_Width() / 2), 496);
            menu_component.Add(btn);
            btn.Click += Menu_was_Clicked;
            btn = new MenuButton(_content, Gadget.Curative_Measure);
            btn.Position = new Vector2(((combat_background.Get_Width() - btn.Get_Width()) / 2) + ((4 - 2) * (btn.Get_Width() + 8)) - (btn.Get_Width() / 2), 496);
            menu_component.Add(btn);
            btn.Click += Menu_was_Clicked;
            btn = new MenuButton(_content, Gadget.Arc_Reactor_Charge);
            btn.Position = new Vector2(((combat_background.Get_Width() - btn.Get_Width()) / 2) + ((4 - 3) * (btn.Get_Width() + 8)) - (btn.Get_Width() / 2), 496);
            menu_component.Add(btn);
            btn.Click += Menu_was_Clicked;
            #endregion

            for (int i = 0; i < heroes.Count; i++)
            {
                for (int j = 0; j < heroes[i].Get_Skills().Count; j++)
                {
                    var btnskill = new SkillButton(_content, heroes[i].Get_Name(), heroes[i].Get_Uniform(), heroes[i].Get_Skills()[j]);
                    btnskill.Position = new Vector2(((combat_background.Get_Width() - btnskill.Get_Width()) / 2) + ((j - 4) * (btnskill.Get_Width() + 8)) + (btnskill.Get_Width() / 2), 496);
                    btnskill.Click += BtnAttack_was_Clicked;
                    heroes[i].Add_Skill_Button(btnskill);
                }
                heroes[i]._hp_bar = new StatusBar(heroes[i].Get_Name(), heroes[i].Get_Max_Health(), Gadget.HEALTH, _content);
                if (i % 2 == 0) heroes[i]._hp_bar.Position = new Vector2(7, MAAGame.SCREEN_HEIGHT - 72 + (i * 12));
                else heroes[i]._hp_bar.Position = new Vector2(389, MAAGame.SCREEN_HEIGHT - 72 + ((i - 1) * 12));
                heroes[i]._sp_bar = new StatusBar(heroes[i].Get_Name(), heroes[i].Get_Max_Stamina(), Gadget.STAMINA, _content);
                if (i % 2 == 0) heroes[i]._sp_bar.Position = new Vector2(7, MAAGame.SCREEN_HEIGHT - 62 + (i * 12));
                else heroes[i]._sp_bar.Position = new Vector2(389, MAAGame.SCREEN_HEIGHT - 62 + ((i - 1) * 12));

                heroes[i]._small_icon = new Icon(_content, heroes[i].Get_Name(), heroes[i].Get_Uniform());
                if (i == 0) heroes[i]._small_icon.Position = new Vector2(277, 0);
                else heroes[i]._small_icon.Position = new Vector2(295 + (i * 30), 6);

                heroes[i].Load_Sprite(_content, heroes[i].Get_Name(), heroes[i].Get_Uniform());
                if (i % 2 == 0) heroes[i].Set_Sprite_Position(new Vector2(0, (i * 50) + 330));
                else heroes[i].Set_Sprite_Position(new Vector2(MAAGame.SCREEN_WIDTH - heroes[i].Get_Sprite_Width(), ((i - 1) * 50) + 330));
                heroes[i].Get_Sprite().Click += Char_was_Clicked;
            }

            heroes[cur_turn].Set_Sprite_Focus(true);
        }

        private void Change_Turn(int num_player = BattleState.ONE_PLAYER)
        {
            heroes[cur_turn].Set_Sprite_Focus(false);
            if(num_player == 1)
            {
                cur_turn += 2;
            }
            else
            {
                cur_turn++;
            }
            cur_turn = cur_turn % heroes.Count;
            heroes[cur_turn].Set_Sprite_Focus(true);

            heroes[cur_turn]._small_icon.Position = new Vector2(277, 0);
        }

        private void Menu_was_Clicked(object sender, EventArgs e)
        {
            switch (((MenuButton)sender).Get_Name())
            {
                case Gadget.Agent_Recharge:
                    {
                        Change_Turn(BattleState.TWO_PLAYER);
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

        private void BtnAttack_was_Clicked(object sender, EventArgs e)
        {
            if (heroes[cur_turn].Get_Sprite_HasTarget()) return;
            heroes[cur_turn].Set_Cur_Skill(((SkillButton)sender).Get_Skill());
            if (heroes[cur_turn].Get_Cur_Skill() == null) return;
            Console.Out.WriteLine("Skill " + ((SkillButton)sender).Get_Skill().Get_Name()  + " of " + heroes[cur_turn].Get_Name() + " was Clicked");
            heroes[cur_turn].isPickSkill = true;
            heroes[cur_turn].Set_Sprite_Focus(false);
        }

        private void Char_was_Clicked(object sender, EventArgs e)
        {
            heroes[cur_turn].Set_Sprite_HasTarget(false);

            if (!heroes[cur_turn].isPickSkill) return;

            List<Sprite> targets = new List<Sprite>();

            if (heroes[cur_turn].Get_Cur_Skill().Get_NumberOfTargets() == TargetType.One_Enemy)
            {
                targets.Add(((Sprite)sender).Get_Me());
                Console.Out.WriteLine(targets[0].Get_Char().Get_Name() + " was Selected");
            }
            else
            {
                for(int i = 0; i < heroes.Count; i++)
                {
                    if (i % 2 == 1) targets.Add(heroes[i].Get_Sprite());
                }
            }
            heroes[cur_turn].Set_Target(targets);

            heroes[cur_turn].Set_Sprite_HasTarget(true);

            heroes[cur_turn].Skill_Action(_content);

            heroes[cur_turn].isPickSkill = false;

            Change_Turn();
        }

        public void Notify(Calculator engine)
        {

        }

        private bool Game_Over()
        {
            //One Last Stand
            if(heroes.Count == 1) return true;

            if (heroes.Count <= 3)
            {
                if (!(heroes[0].Get_Sprite().Position.X < (MAAGame.SCREEN_WIDTH / 8) ^ heroes[1].Get_Sprite().Position.X < (MAAGame.SCREEN_WIDTH / 8))) return true;
            }

            if (heroes.Count == 3)
            {

            }

            return false;
        }

        public override void Update(GameTime gameTime)
        {
            if(Game_Over()) _game.Change_State(new MapState(_game, _graphicsDevice, _content));

            foreach (var avatar in heroes)
                avatar.Play();

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var avatar in heroes)
            {
                if (avatar.Get_Sprite().Get_IsDead())
                {
                    heroes.Remove(avatar);
                    break;
                }

                avatar.Update_Sprite_Frame(gameTime, elapsed);
                avatar._hp_bar.Update(gameTime);
                avatar._sp_bar.Update(gameTime);
            }

            int j = 1;
            for(int i = cur_turn + 1; i != cur_turn; i++)
            {
                i = i % heroes.Count;
                heroes[i]._small_icon.Position = new Vector2(295 + (j * 30), 6);
                j++;
                if (j == heroes.Count) break;
            }

            //heroes[cur_turn]._small_icon.Position = new Vector2(277, 0);

            foreach (var btnskill in heroes[cur_turn].Get_Skills_Button())
                btnskill.Update(heroes[cur_turn]);

            foreach (var btn in menu_component)
                btn.Update(gameTime);

            //base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.BackToFront);

            combat_background.Draw(spriteBatch);

            empty_status_bar.Draw(spriteBatch);

            foreach (var btn in menu_component)
                btn.Draw(spriteBatch);

            for (int i = 0; i < heroes.Count; i++)
            {
                heroes[i].Draw_Sprite(gameTime, spriteBatch);
                heroes[i]._hp_bar.Draw(spriteBatch);
                heroes[i]._sp_bar.Draw(spriteBatch);
                SpriteEffects effect = SpriteEffects.None;
                if (heroes[i].Get_Sprite().Position.X > MAAGame.SCREEN_WIDTH / 4.0f) effect = SpriteEffects.FlipHorizontally;
                if (i == cur_turn) heroes[i]._small_icon.Draw(spriteBatch, 1, effect);
                else heroes[i]._small_icon.Draw(spriteBatch, 0.66f, effect);
            }

            foreach (var btnskill in heroes[cur_turn].Get_Skills_Button())
                btnskill.Draw(spriteBatch);

            turn_bar.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
    }
}
