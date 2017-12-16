using Marvel_Avengers_Alliance_REBORN.Buttons;
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
        public List<Character> heroes;
        private List<MenuButton> menu_component;

        private Background combat_background;
        private Background empty_status_bar;
        private Background turn_bar;
        private Background skill_bar;
        public int cur_turn;
        protected Viewport viewport;
        #endregion
                
        public static bool IsLeft_Side(Character hero)
        {
            return (hero.Get_Sprite().Position.X < MAAGame.SCREEN_WIDTH / 6.0f);
        }

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

            song = _content.Load<Song>("Songs/" + Songs.BattleState_Song);    //Set Song
            MediaPlayer.Play(song);
            MediaPlayer.Volume -= 0.4f;

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

            //observer
            foreach (var hero in heroes)
                hero.Get_Sprite().battle_stage = this;
        }
        
        public void Change_Turn(int num_player = BattleState.ONE_PLAYER)
        {
            cur_turn = cur_turn % heroes.Count;

            /*if (IsLeft_Side(heroes[cur_turn])) {
                foreach (var btnskill in heroes[cur_turn].Get_Skills_Buttons())
                    btnskill.Decrease_CoolDown();
            }*/

            heroes[cur_turn].Set_Sprite_Focus(false);

            if (num_player == 1 && !BattleState.IsLeft_Side(heroes[cur_turn]))
            {
                //create bot

                if (!heroes[cur_turn].Get_Sprite_HasTarget() && !heroes[cur_turn].Get_Skills_Buttons()[0].Get_EnoughStamina() && !heroes[cur_turn].Get_Skills_Buttons()[1].Get_EnoughStamina() && 
                    !heroes[cur_turn].Get_Skills_Buttons()[2].Get_EnoughStamina() && !heroes[cur_turn].Get_Skills_Buttons()[3].Get_EnoughStamina())
                {
                    heroes[cur_turn].Recharge();
                    cur_turn++;
                    cur_turn = cur_turn % heroes.Count;
                    Change_Turn();
                }
                else
                {
                    Random rand = new Random();
                    SkillButton cur_skill;
                    int skill_index;
                    do
                    {
                        skill_index = rand.Next(0, 4);
                        cur_skill = heroes[cur_turn].Get_Skills_Buttons()[skill_index];
                    } while (!cur_skill.Get_EnoughStamina() || cur_skill.Get_Skill().Get_Cooldown()[0] > 0);
                    heroes[cur_turn].Set_Cur_Skill_Btn(cur_skill);
                    Console.Out.WriteLine("Skill " + (cur_skill.Get_Skill().Get_Name() + " of " + heroes[cur_turn].Get_Name() + " BOT was Selected"));

                    //Action Skill
                    List<Sprite> targets = new List<Sprite>();
                    int hero_index;
                    switch (heroes[cur_turn].Get_Cur_Skill_Btn().Get_Skill().Get_NumberOfTargets())
                    {
                        case 0: //Self = 0
                            {
                                targets.Add(heroes[cur_turn].Get_Sprite());

                                heroes[cur_turn].Set_Sprite_HasTarget(true);

                                heroes[cur_turn].Skill_Action(_content);

                                heroes[cur_turn].isPickSkill = false;

                                heroes[cur_turn].Get_Cur_Skill_Btn().Re_CoolDown();

                                break;
                            }
                        case 1: //One_Ally = 1
                            {
                                do
                                {
                                    hero_index = rand.Next(0, heroes.Count);

                                    targets = new List<Sprite>();
                                    targets.Add(heroes[hero_index].Get_Sprite());

                                } while ((IsLeft_Side(heroes[hero_index]) ^ IsLeft_Side(heroes[cur_turn])));

                                heroes[cur_turn].Set_Sprite_HasTarget(true);

                                heroes[cur_turn].Skill_Action(_content);

                                heroes[cur_turn].isPickSkill = false;

                                heroes[cur_turn].Get_Cur_Skill_Btn().Re_CoolDown();

                                break;
                            }
                        case 2: //One_Enemy = 2
                            {
                                do
                                {
                                    hero_index = rand.Next(0, heroes.Count);

                                    targets = new List<Sprite>();
                                    targets.Add(heroes[hero_index].Get_Sprite());

                                } while (!(IsLeft_Side(heroes[hero_index]) ^ IsLeft_Side(heroes[cur_turn])));

                                heroes[cur_turn].Set_Sprite_HasTarget(true);

                                heroes[cur_turn].Skill_Action(_content);

                                heroes[cur_turn].isPickSkill = false;

                                heroes[cur_turn].Get_Cur_Skill_Btn().Re_CoolDown();

                                break;
                            }
                        case 3: //All_Allies = 3
                            {
                                if (IsLeft_Side(heroes[cur_turn]))
                                    {
                                        foreach (var hero in heroes)
                                        {
                                            if (IsLeft_Side(hero))
                                            {
                                                targets.Add(hero.Get_Sprite());
                                            }
                                        }
                                    }
                                    else
                                    {
                                        foreach (var hero in heroes)
                                        {
                                            if (!IsLeft_Side(hero))
                                            {
                                                targets.Add(hero.Get_Sprite());
                                            }
                                        }
                                    }
                                    heroes[cur_turn].Set_Sprite_HasTarget(true);

                                    heroes[cur_turn].Skill_Action(_content);

                                    heroes[cur_turn].isPickSkill = false;

                                    heroes[cur_turn].Get_Cur_Skill_Btn().Re_CoolDown();
                                
                                break;
                            }
                        case 4: //All_Enemies = 4
                            {
                                if (IsLeft_Side(heroes[cur_turn]))
                                {
                                    foreach (var hero in heroes)
                                    {
                                        if (!IsLeft_Side(hero))
                                        {
                                            targets.Add(hero.Get_Sprite());
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (var hero in heroes)
                                    {
                                        if (IsLeft_Side(hero))
                                        {
                                            targets.Add(hero.Get_Sprite());
                                        }
                                    }
                                }
                                heroes[cur_turn].Set_Sprite_HasTarget(true);

                                heroes[cur_turn].Skill_Action(_content);

                                heroes[cur_turn].isPickSkill = false;

                                heroes[cur_turn].Get_Cur_Skill_Btn().Re_CoolDown();

                                break;
                            }
                    }
                    heroes[cur_turn].Set_Target(targets);
                    //cur_turn++;
                }
                foreach (var btnskill in heroes[cur_turn].Get_Skills_Buttons())
                    btnskill.Decrease_CoolDown();
            }
            else
            {
                //cur_turn++;
            }
            //cur_turn++;
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
                        //Change_Turn(BattleState.TWO_PLAYER);
                        heroes[cur_turn].Set_Sprite_Focus(false);
                        foreach (var btnskill in heroes[cur_turn].Get_Skills_Buttons())
                            btnskill.Decrease_CoolDown();

                        heroes[cur_turn].Recharge();
                        cur_turn++;
                        cur_turn = cur_turn % heroes.Count;
                        heroes[cur_turn].Set_Sprite_Focus(true);
                        Change_Turn();
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
            if (!BattleState.IsLeft_Side(heroes[cur_turn])) return;
            if (heroes[cur_turn].Get_Sprite_HasTarget()) return;
            heroes[cur_turn].Set_Cur_Skill_Btn(((SkillButton)sender).Get_me());
            if (heroes[cur_turn].Get_Cur_Skill_Btn() == null) return;
            Console.Out.WriteLine("Skill " + ((SkillButton)sender).Get_Skill().Get_Name()  + " of " + heroes[cur_turn].Get_Name() + " was Clicked");
            heroes[cur_turn].isPickSkill = true;
            heroes[cur_turn].Set_Sprite_Focus(false);
        }

        private void Char_was_Clicked(object sender, EventArgs e)
        {
            heroes[cur_turn].Set_Sprite_HasTarget(false);

            if (!BattleState.IsLeft_Side(heroes[cur_turn])) return;

            if (!heroes[cur_turn].isPickSkill) return;

            if (heroes[cur_turn].Get_Cur_Skill_Btn().Get_me() == null) return;

            List<Sprite> targets = new List<Sprite>();

            switch (heroes[cur_turn].Get_Cur_Skill_Btn().Get_Skill().Get_NumberOfTargets())
            {
                case 0: //Self = 0
                    {
                        if (((Sprite)sender).Get_Me() == heroes[cur_turn].Get_Sprite())
                        {
                            targets.Add(heroes[cur_turn].Get_Sprite());

                            heroes[cur_turn].Set_Sprite_HasTarget(true);

                            heroes[cur_turn].Skill_Action(_content);

                            heroes[cur_turn].isPickSkill = false;

                            heroes[cur_turn].Get_Cur_Skill_Btn().Re_CoolDown();
                        }
                        break;
                    }
                case 1: //One_Ally = 1
                    {
                        if(!(IsLeft_Side(((Sprite)sender).Get_Me().Get_Char()) ^ IsLeft_Side(heroes[cur_turn])))
                        {
                            targets.Add(((Sprite)sender).Get_Me());

                            heroes[cur_turn].Set_Sprite_HasTarget(true);

                            heroes[cur_turn].Skill_Action(_content);

                            heroes[cur_turn].isPickSkill = false;

                            heroes[cur_turn].Get_Cur_Skill_Btn().Re_CoolDown();
                        }
                        break;
                    }
                case 2: //One_Enemy = 2
                    {
                        if ((IsLeft_Side(((Sprite)sender).Get_Me().Get_Char()) ^ IsLeft_Side(heroes[cur_turn])))
                        {
                            targets.Add(((Sprite)sender).Get_Me());

                            heroes[cur_turn].Set_Sprite_HasTarget(true);

                            heroes[cur_turn].Skill_Action(_content);

                            heroes[cur_turn].isPickSkill = false;

                            heroes[cur_turn].Get_Cur_Skill_Btn().Re_CoolDown();
                        }
                        break;
                    }
                case 3: //All_Allies = 3
                    {
                        if (!(IsLeft_Side(((Sprite)sender).Get_Me().Get_Char()) ^ IsLeft_Side(heroes[cur_turn])))
                        {
                            if (IsLeft_Side(heroes[cur_turn]))
                            {
                                foreach (var hero in heroes)
                                {
                                    if (IsLeft_Side(hero))
                                    {
                                        targets.Add(hero.Get_Sprite());
                                    }
                                }
                            }
                            else
                            {
                                foreach (var hero in heroes)
                                {
                                    if (!IsLeft_Side(hero))
                                    {
                                        targets.Add(hero.Get_Sprite());
                                    }
                                }
                            }
                            heroes[cur_turn].Set_Sprite_HasTarget(true);

                            heroes[cur_turn].Skill_Action(_content);

                            heroes[cur_turn].isPickSkill = false;

                            heroes[cur_turn].Get_Cur_Skill_Btn().Re_CoolDown();
                        }
                        break;
                    }
                case 4: //All_Enemies = 4
                    {
                        if ((IsLeft_Side(((Sprite)sender).Get_Me().Get_Char()) ^ IsLeft_Side(heroes[cur_turn])))
                        {
                            if (IsLeft_Side(heroes[cur_turn]))
                            {
                                foreach (var hero in heroes)
                                {
                                    if (!IsLeft_Side(hero))
                                    {
                                        targets.Add(hero.Get_Sprite());
                                    }
                                }
                            }
                            else
                            {
                                foreach (var hero in heroes)
                                {
                                    if (IsLeft_Side(hero))
                                    {
                                        targets.Add(hero.Get_Sprite());
                                    }
                                }
                            }
                            heroes[cur_turn].Set_Sprite_HasTarget(true);

                            heroes[cur_turn].Skill_Action(_content);

                            heroes[cur_turn].isPickSkill = false;

                            heroes[cur_turn].Get_Cur_Skill_Btn().Re_CoolDown();
                        }
                        break;
                    }
            }
            heroes[cur_turn].Set_Target(targets);
            foreach (var btnskill in heroes[cur_turn].Get_Skills_Buttons())
                btnskill.Decrease_CoolDown();
            Change_Turn();
        }

        public void Notify(Calculator engine)
        {

        }

        private bool Game_Over()
        {
            //One Last Stand
            if(heroes.Count == 1) return true;

            if (heroes.Count == 2)
            {
                if (!(BattleState.IsLeft_Side(heroes[0]) ^ BattleState.IsLeft_Side(heroes[1]))) return true;
            }

            if (heroes.Count == 3)
            {
                if ((!BattleState.IsLeft_Side(heroes[0]) && !BattleState.IsLeft_Side(heroes[1]) && !BattleState.IsLeft_Side(heroes[2])) || 
                    (BattleState.IsLeft_Side(heroes[0]) && BattleState.IsLeft_Side(heroes[1]) && BattleState.IsLeft_Side(heroes[2]))) return true;
            }

            return false;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var avatar in heroes)
                avatar.Play();

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var avatar in heroes)
            {
                if (avatar.Get_Sprite().Get_IsDead())
                {
                    heroes[cur_turn].Set_Sprite_Focus(true);
                    /*if (IsLeft_Side(avatar))*/
                    cur_turn--;
                    if (cur_turn < 0) cur_turn = 0;
                    heroes.Remove(avatar);
                    break;
                }

                avatar.Update_Sprite_Frame(gameTime, elapsed);
                avatar._hp_bar.Update(gameTime);
                avatar._sp_bar.Update(gameTime);
            }

            if (Game_Over())
            {
                if (!IsLeft_Side(heroes[0])) LogInState.numstage--;
                _game.Change_State(new LoadingState(_game, _graphicsDevice, _content, 
                    new MapState(_game, _graphicsDevice, _content)));
            }
            else
            {
                int j = 1;
                for (int i = cur_turn + 1; i != cur_turn; i++)
                {
                    i = i % heroes.Count;
                    heroes[i]._small_icon.Position = new Vector2(295 + (j * 30), 6);
                    j++;
                    if (j == heroes.Count) break;
                }

                //heroes[cur_turn]._small_icon.Position = new Vector2(277, 0);

                cur_turn %= heroes.Count;

                if (cur_turn > 0)
                {
                    foreach (var btnskill in heroes[cur_turn - 1].Get_Skills_Buttons())
                        btnskill.Update(heroes[cur_turn - 1]);
                }

                foreach (var btnskill in heroes[cur_turn].Get_Skills_Buttons())
                    btnskill.Update(heroes[cur_turn]);


                /*foreach(var hero in heroes)
                {
                    foreach (var btnskill in hero.Get_Skills_Buttons())
                        btnskill.Update(hero);
                }*/

                foreach (var btn in menu_component)
                    btn.Update(gameTime);
            }

            //base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.BackToFront);

            combat_background.Draw(spriteBatch);

            empty_status_bar.Draw(spriteBatch, 0.1f);

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

            foreach (var btnskill in heroes[cur_turn].Get_Skills_Buttons())
                btnskill.Draw(spriteBatch);

            turn_bar.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
    }
}
