using Marvel_Avengers_Alliance_REBORN.Buttons;
using Marvel_Avengers_Alliance_REBORN.Models;
using Marvel_Avengers_Alliance_REBORN.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.DATA.Heroes
{
    class Deadpool : Character
    {
        public Deadpool(ContentManager content)
        {
            #region Set Stat
            name = Hero.Deadpool;
            alternate_uniform = Suit.Deadpool_Classic;
            _max_health = 7868;
            _max_stamina = 6438;
            _attack = 1717;
            _defense = 1431;
            _accuracy = 1431;
            _evasion = 1288;
            _class = _Class.Blaster;
            
            _cur_health = _max_health;
            _cur_stamina = _max_stamina;
            #endregion

            #region Set 1st Attack
            _skills = new List<Skill>();
            _skills_buttons = new List<SkillButton>();
            Skill skill = new Skill("Deadpool-Sharp_Pointy_Things");
            skill.Set_Time(3);
            skill.Set_Stamina_Cost(13);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(1086, 1302);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(2);
            skill.Set_Hits_Chance(88);
            skill.Set_Cri_Chance(11);

            _skills.Add(skill);
            #endregion

            #region Set 2nd Attack
            skill = new Skill("Deadpool-Bang_Bang_Bang!");
            skill.Set_Time(6);
            skill.Set_Stamina_Cost(26);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(1150, 1600);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(25);
            skill.Set_Hits_Chance(88);
            skill.Set_Cri_Chance(53);

            _skills.Add(skill);
            #endregion

            #region Set 3rd Attack
            skill = new Skill("Deadpool-No_Holds_Barred");
            skill.Set_Time(3);
            skill.Set_Stamina_Cost(20);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(1779, 2313);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(3);
            skill.Set_Hits_Chance(88);
            skill.Set_Cri_Chance(11);

            _skills.Add(skill);
            #endregion

            #region Set 4th Attack
            skill = new Skill("Deadpool-Happy_to_See_You");
            skill.Set_Time(3);
            skill.Set_Stamina_Cost(44);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(2382, 3573);
            skill.Set_Cooldown(3, 3);
            skill.Set_NumberOfHits(3);
            skill.Set_Hits_Chance(88);
            skill.Set_Cri_Chance(11);

            _skills.Add(skill);
            #endregion
        }

        #region Animation Editor
        public override void Check_Skill()
        {
            switch (_cur_skill_btn.Get_Skill().Get_Name())
            {
                case "Deadpool-Sharp_Pointy_Things":
                    #region Skill Motion
                    {
                        //for melee skill
                        goal = Set_Melee_Goal(_sprite.Get_Targets()[0]);

                        _sprite.Transition(_sprite.Position, goal, 10, 5);
                        //When Hit
                        if (_sprite.Get_Cur_Frame() == 20)
                        {
                            foreach (var target in _sprite.Get_Targets())
                            {
                                target.Re_Main();
                            }
                        }

                        _sprite.Transition(goal, _sprite.Position, 29, 5);

                        //Set Hit
                        if (_sprite.Get_Cur_Frame() == 14) _sprite.Set_isHealth_Calculated(true);
                        else _sprite.Set_isHealth_Calculated(false);

                        //Use Stamina
                        if (_sprite.Get_Cur_Frame() == 1) _sprite.Set_isStamina_Calculated(true);
                        else _sprite.Set_isStamina_Calculated(false);
                        break;
                    }
                    #endregion
                case "Deadpool-Bang_Bang_Bang!":
                    #region Skill Motion
                    {
                        //for melee skill
                        goal = Set_Melee_Goal(_sprite.Get_Targets()[0]);

                        _sprite.Transition(_sprite.Position, goal, 7, 5);
                        //When Hit
                        if (_sprite.Get_Cur_Frame() == 76)
                        {
                            foreach (var target in _sprite.Get_Targets())
                            {
                                target.Re_Main();
                            }
                        }

                        _sprite.Transition(goal, _sprite.Position, 76, 5);

                        //Set Hit
                        if (_sprite.Get_Cur_Frame() == 12) _sprite.Set_isHealth_Calculated(true);
                        else _sprite.Set_isHealth_Calculated(false);

                        //Use Stamina
                        if (_sprite.Get_Cur_Frame() == 1) _sprite.Set_isStamina_Calculated(true);
                        else _sprite.Set_isStamina_Calculated(false);
                        break;
                    }
                    #endregion
                case "Deadpool-No_Holds_Barred":
                    #region Skill Motion
                    {
                        //for melee skill
                        goal = Set_Melee_Goal(_sprite.Get_Targets()[0]);

                        _sprite.Transition(_sprite.Position, goal, 8, 5);
                        //When Hit
                        if (_sprite.Get_Cur_Frame() == 35)
                        {
                            foreach (var target in _sprite.Get_Targets())
                            {
                                target.Re_Main();
                            }
                        }

                        _sprite.Transition(goal, _sprite.Position, 35, 5);

                        //Set Hit
                        if (_sprite.Get_Cur_Frame() == 16) _sprite.Set_isHealth_Calculated(true);
                        else _sprite.Set_isHealth_Calculated(false);

                        //Use Stamina
                        if (_sprite.Get_Cur_Frame() == 1) _sprite.Set_isStamina_Calculated(true);
                        else _sprite.Set_isStamina_Calculated(false);
                        break;
                    }
                    #endregion
                case "Deadpool-Happy_to_See_You":
                    #region Skill Motion
                    {
                        //for melee skill
                        goal = Set_Range_Goal(_sprite.Get_Targets()[0]);

                        _sprite.Transition(_sprite.Position, goal, 5, 5);
                        //When Hit
                        if (_sprite.Get_Cur_Frame() == 37)
                        {
                            foreach (var target in _sprite.Get_Targets())
                            {
                                target.Re_Main();
                            }
                        }

                        _sprite.Transition(goal, _sprite.Position, 39, 4);

                        //Set Hit
                        if (_sprite.Get_Cur_Frame() == 9) _sprite.Set_isHealth_Calculated(true);
                        else _sprite.Set_isHealth_Calculated(false);

                        //Use Stamina
                        if (_sprite.Get_Cur_Frame() == 1) _sprite.Set_isStamina_Calculated(true);
                        else _sprite.Set_isStamina_Calculated(false);
                        break;
                    }
                    #endregion
            }
        }
        #endregion

        public override void Set_Sprite_Position(Vector2 vector)
        {
            _sprite.Position = vector;
            if (vector.X < MAAGame.SCREEN_WIDTH / 6.0f)
            {
                _sprite.Set_Rectangle(new Rectangle((int)_sprite.Position.X + (int)(_sprite.Get_Sprite_Width() / 3.4f),
                                                    (int)_sprite.Position.Y - 180,
                                                    (int)(_sprite.Get_Sprite_Width() / 5.2f),
                                                    100));
            }
            else
            {
                _sprite.Set_Rectangle(new Rectangle((int)_sprite.Position.X + (int)(_sprite.Get_Sprite_Width() / 3.4f) + (int)(_sprite.Get_Sprite_Width() / 4.5f),
                                                    (int)_sprite.Position.Y - 180,
                                                    (int)(_sprite.Get_Sprite_Width() / 5.2f),
                                                    100));
            }
        }

        protected override Vector2 Set_Melee_Goal(Sprite target)
        {
            if (BattleState.IsLeft_Side(this)) return new Vector2(target.Get_Rectangle().X - 260, target.Position.Y + 0.01f);
            else return new Vector2(target.Get_Rectangle().X + target.Get_Rectangle().Width - 240, target.Position.Y + 0.01f);
        }

        protected override Vector2 Set_Range_Goal(Sprite target)
        {
            if (BattleState.IsLeft_Side(this)) return new Vector2(target.Get_Rectangle().X - 380, target.Position.Y + 0.01f);
            else return new Vector2(target.Get_Rectangle().X + target.Get_Rectangle().Width + 50, target.Position.Y + 0.01f);
        }
    }
}
