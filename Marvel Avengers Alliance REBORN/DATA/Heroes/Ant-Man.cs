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
    class Ant_Man : Character
    {
        public Ant_Man(ContentManager content)
        {
            #region Set Stat
            name = Hero.Ant_Man;
            alternate_uniform = Suit.Ant_Man_Modern;
            _max_health = 6438;
            _max_stamina = 7868;
            _attack = 1431;
            _defense = 1288;
            _accuracy = 1431;
            _evasion = 1574;
            _class = _Class.Infiltrator;
            
            _cur_health = _max_health;
            _cur_stamina = _max_stamina;
            #endregion

            #region Set 1st Attack
            _skills = new List<Skill>();
            _skills_buttons = new List<SkillButton>();
            Skill skill = new Skill("Ant-Man-Break_In");
            skill.Set_Time(3);
            skill.Set_Stamina_Cost(18);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(1072, 1286);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(2);
            skill.Set_Hits_Chance(88);
            skill.Set_Cri_Chance(11);

            _skills.Add(skill);
            #endregion

            #region Set 2nd Attack
            skill = new Skill("Ant-Man-Greatest_Allies");
            skill.Set_Time(5);
            skill.Set_Stamina_Cost(5);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(241, 288);
            skill.Set_Cooldown(1, 1);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(100);
            skill.Set_Cri_Chance(60);

            _skills.Add(skill);
            #endregion

            #region Set 3rd Attack
            skill = new Skill("Ant-Man-Pint-Size_Surprise");
            skill.Set_Time(3);
            skill.Set_Stamina_Cost(23);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(1146, 1375);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(88);
            skill.Set_Cri_Chance(11);

            _skills.Add(skill);
            #endregion

            #region Set 4th Attack
            skill = new Skill("Ant-Man-Super-Pint-Size_Surprise");
            skill.Set_Time(4);
            skill.Set_Stamina_Cost(5);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(510, 612);
            skill.Set_Cooldown(1, 1);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(100);
            skill.Set_Cri_Chance(60);

            _skills.Add(skill);
            #endregion
        }

        #region Animation Editor
        public override void Check_Skill()
        {
            switch (_cur_skill_btn.Get_Skill().Get_Name())
            {
                case "Ant-Man-Break_In":
                    #region Skill Motion
                    {
                        //for melee skill
                        goal = Set_Melee_Goal(_sprite.Get_Targets()[0]);

                        _sprite.Transition(_sprite.Position, goal, 11, 5);
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
                        if (_sprite.Get_Cur_Frame() == 15) _sprite.Set_isHealth_Calculated(true);
                        else _sprite.Set_isHealth_Calculated(false);

                        //Use Stamina
                        if (_sprite.Get_Cur_Frame() == 1) _sprite.Set_isStamina_Calculated(true);
                        else _sprite.Set_isStamina_Calculated(false);
                        break;
                    }
                    #endregion
                case "Ant-Man-Greatest_Allies":
                    #region Skill Motion
                    {
                        //When Hit
                        if (_sprite.Get_Cur_Frame() == 35)
                        {
                            foreach (var target in _sprite.Get_Targets())
                            {
                                target.Re_Main();
                            }
                        }

                        //Set Hit
                        if (_sprite.Get_Cur_Frame() == 25) _sprite.Set_isHealth_Calculated(true);
                        else _sprite.Set_isHealth_Calculated(false);

                        //Use Stamina
                        if (_sprite.Get_Cur_Frame() == 1) _sprite.Set_isStamina_Calculated(true);
                        else _sprite.Set_isStamina_Calculated(false);
                        break;
                    }
                    #endregion
                case "Ant-Man-Pint-Size_Surprise":
                    #region Skill Motion
                    {
                        //for melee skill
                        goal = Set_Melee_Goal(_sprite.Get_Targets()[0]);

                        _sprite.Transition(_sprite.Position, goal, 11, 5);
                        //When Hit
                        if (_sprite.Get_Cur_Frame() == 36)
                        {
                            foreach (var target in _sprite.Get_Targets())
                            {
                                target.Re_Main();
                            }
                        }

                        _sprite.Transition(goal, _sprite.Position, 35, 5);

                        //Set Hit
                        if (_sprite.Get_Cur_Frame() == 26) _sprite.Set_isHealth_Calculated(true);
                        else _sprite.Set_isHealth_Calculated(false);

                        //Use Stamina
                        if (_sprite.Get_Cur_Frame() == 1) _sprite.Set_isStamina_Calculated(true);
                        else _sprite.Set_isStamina_Calculated(false);
                        break;
                    }
                    #endregion
                case "Ant-Man-Super-Pint-Size_Surprise":
                    #region Skill Motion
                    {
                        #region Skill Motion
                        {
                            //for melee skill
                            if (_sprite.Get_Cur_Frame() == 10)
                            {
                                if (BattleState.IsLeft_Side(this)) goal = new Vector2(_sprite.Position.X - 300, _sprite.Position.Y - 300);
                                else goal = new Vector2(_sprite.Position.X + 300, _sprite.Position.Y - 300);
                            }

                            _sprite.Transition(_sprite.Position, goal, 10, 10);

                            if (_sprite.Get_Cur_Frame() == 23) _sprite._cur_position = Set_Melee_Goal(_sprite.Get_Targets()[0]);

                            //When Hit
                            if (_sprite.Get_Cur_Frame() == 36)
                            {
                                foreach (var target in _sprite.Get_Targets())
                                {
                                    target.Re_Main();
                                }
                            }

                            if (_sprite.Get_Cur_Frame() == 47)
                            {
                                goal = new Vector2(_sprite.Position.X, _sprite.Position.Y - 500);
                                _sprite._cur_position = goal;
                            }

                            _sprite.Transition(goal, _sprite.Position, 47, 8);

                            //Set Hit
                            if (_sprite.Get_Cur_Frame() == 30) _sprite.Set_isHealth_Calculated(true);
                            else _sprite.Set_isHealth_Calculated(false);

                            //Use Stamina
                            if (_sprite.Get_Cur_Frame() == 1) _sprite.Set_isStamina_Calculated(true);
                            else _sprite.Set_isStamina_Calculated(false);
                            break;
                        }
                        #endregion
                        break;
                    }
                    #endregion
            }
        }
        #endregion

        public override void Set_Sprite_Position(Vector2 vector)
        {
            _sprite.Position = vector;
            if (BattleState.IsLeft_Side(this))
            {
                _sprite.Set_Rectangle(new Rectangle((int)_sprite.Position.X + (int)(_sprite.Get_Sprite_Width() / 2.5f),
                                                    (int)_sprite.Position.Y - 180,
                                                    (int)(_sprite.Get_Sprite_Width() / 1.8f), 
                                                    100));
            }
            else
            {
                _sprite.Set_Rectangle(new Rectangle((int)_sprite.Position.X - (int)(_sprite.Get_Sprite_Width() / 2.5f) + (int)(_sprite.Get_Sprite_Width() / 2.3f),
                                                    (int)_sprite.Position.Y - 180,
                                                    (int)(_sprite.Get_Sprite_Width() / 1.8f), 
                                                    100));
            }
        }

        protected override Vector2 Set_Melee_Goal(Sprite target)
        {
            if (BattleState.IsLeft_Side(this)) return new Vector2(target.Get_Rectangle().X - 200, target.Position.Y + 0.01f);
            else return new Vector2(target.Get_Rectangle().X + target.Get_Rectangle().Width - 120, target.Position.Y + 0.01f);
        }

        protected override Vector2 Set_Range_Goal(Sprite target)
        {
            if (BattleState.IsLeft_Side(this)) return new Vector2(target.Get_Rectangle().X - 370, target.Position.Y + 0.01f);
            else return new Vector2(target.Get_Rectangle().X + target.Get_Rectangle().Width + 50, target.Position.Y + 0.01f);
        }
    }
}
