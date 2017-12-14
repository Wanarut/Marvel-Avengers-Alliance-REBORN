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
    class X_23 : Character
    {
        public X_23(ContentManager content)
        {
            #region Set Stat
            name = Hero.X_23;
            alternate_uniform = Suit.X_23_Horseman_of_War;
            _max_health = 6438;
            _max_stamina = 7153;
            _attack = 1574;
            _defense = 1288;
            _accuracy = 1574;
            _evasion = 1574;
            _class = _Class.Bruiser;
            
            _cur_health = _max_health;
            _cur_stamina = _max_stamina;
            #endregion

            #region Set 1st Attack
            _skills = new List<Skill>();
            _skills_buttons = new List<SkillButton>();
            Skill skill = new Skill("X-23-Snikt!");
            skill.Set_Time(2);
            skill.Set_Stamina_Cost(16);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(648, 778);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(2);
            skill.Set_Hits_Chance(92);
            skill.Set_Cri_Chance(43);

            _skills.Add(skill);
            #endregion

            #region Set 2nd Attack
            skill = new Skill("X-23-Blades_of_Rage");
            skill.Set_Time(2);
            skill.Set_Stamina_Cost(25);
            skill.Set_NumberOfTargets(TargetType.All_Enemies);
            skill.Set_Damage(512, 614);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(2);
            skill.Set_Hits_Chance(92);
            skill.Set_Cri_Chance(43);

            _skills.Add(skill);
            #endregion

            #region Set 3rd Attack
            skill = new Skill("X-23-Made_For_Walking");
            skill.Set_Time(2);
            skill.Set_Stamina_Cost(20);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(1065, 1280);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(5);
            skill.Set_Hits_Chance(92);
            skill.Set_Cri_Chance(92);

            _skills.Add(skill);
            #endregion

            #region Set 4th Attack
            skill = new Skill("X-23-Assassin's_Strike");
            skill.Set_Time(2);
            skill.Set_Stamina_Cost(10);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(232, 278);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(92);
            skill.Set_Cri_Chance(43);

            _skills.Add(skill);
            #endregion
        }

        #region Animation Editor
        public override void Check_Skill()
        {
            switch (_cur_skill_btn.Get_Skill().Get_Name())
            {
                case "X-23-Snikt!":
                    #region Skill Motion
                    {
                        //for melee skill
                        goal = Set_Melee_Goal(_sprite.Get_Targets()[0]);

                        _sprite.Transition(_sprite.Position, goal, 5, 9);
                        //When Hit
                        if (_sprite.Get_Cur_Frame() == 21)
                        {
                            foreach (var target in _sprite.Get_Targets())
                            {
                                target.Re_Main();
                            }
                        }

                        _sprite.Transition(goal, _sprite.Position, 21, 6);

                        //Set Hit
                        if (_sprite.Get_Cur_Frame() == 10) _sprite.Set_isHealth_Calculated(true);
                        else _sprite.Set_isHealth_Calculated(false);

                        //Use Stamina
                        if (_sprite.Get_Cur_Frame() == 1) _sprite.Set_isStamina_Calculated(true);
                        else _sprite.Set_isStamina_Calculated(false);
                        break;
                    }
                #endregion
                case "X-23-Blades_of_Rage":
                    #region Skill Motion
                    {
                        //for range skill
                        if (_sprite.Get_Cur_Frame() == 5)
                        {
                            if (_sprite.Get_Targets().Count > 1 && _sprite.Get_Targets()[1] != null) _sprite._cur_position = Set_Range_Goal(_sprite.Get_Targets()[1]);
                            else if (_sprite.Get_Targets().Count > 1 && _sprite.Get_Targets()[2] != null) _sprite._cur_position = Set_Range_Goal(_sprite.Get_Targets()[2]);
                            else _sprite._cur_position = Set_Range_Goal(_sprite.Get_Targets()[0]);
                        }

                        if (_sprite.Get_Cur_Frame() == 14)
                        {
                            if (_sprite.Get_Targets()[0] != null) _sprite._cur_position = Set_Range_Goal(_sprite.Get_Targets()[0]);
                            else if (_sprite.Get_Targets()[2] != null) _sprite._cur_position = Set_Range_Goal(_sprite.Get_Targets()[2]);
                            else _sprite._cur_position = Set_Range_Goal(_sprite.Get_Targets()[1]);
                        }

                        if (_sprite.Get_Cur_Frame() == 10)
                        {
                            if (_sprite.Get_Targets().Count > 2 && _sprite.Get_Targets()[2] != null) _sprite._cur_position = Set_Range_Goal(_sprite.Get_Targets()[2]);
                            else if (_sprite.Get_Targets().Count > 2 && _sprite.Get_Targets()[1] != null) _sprite._cur_position = Set_Range_Goal(_sprite.Get_Targets()[1]);
                            else _sprite._cur_position = Set_Range_Goal(_sprite.Get_Targets()[0]);
                        }
                        //When Hit
                        if (_sprite.Get_Cur_Frame() == 22)
                        {
                            foreach (var target in _sprite.Get_Targets())
                            {
                                target.Re_Main();
                            }
                        }

                        //if (_sprite.Get_Cur_Frame() == 36) _sprite._cur_position = _sprite.Position;

                        //Set Hit
                        if (_sprite.Get_Cur_Frame() == 10) _sprite.Set_isHealth_Calculated(true);
                        else _sprite.Set_isHealth_Calculated(false);

                        //Use Stamina
                        if (_sprite.Get_Cur_Frame() == 1) _sprite.Set_isStamina_Calculated(true);
                        else _sprite.Set_isStamina_Calculated(false);
                        break;
                    }
                #endregion
                case "X-23-Made_For_Walking":
                    #region Skill Motion
                    {
                        //for melee skill
                        goal = Set_Melee_Goal(_sprite.Get_Targets()[0]);

                        _sprite.Transition(_sprite.Position, goal, 3, 4);
                        //When Hit
                        if (_sprite.Get_Cur_Frame() == 18)
                        {
                            foreach (var target in _sprite.Get_Targets())
                            {
                                target.Re_Main();
                            }
                        }

                        _sprite.Transition(goal, _sprite.Position, 22, 5);

                        //Set Hit
                        if (_sprite.Get_Cur_Frame() == 7) _sprite.Set_isHealth_Calculated(true);
                        else _sprite.Set_isHealth_Calculated(false);

                        //Use Stamina
                        if (_sprite.Get_Cur_Frame() == 1) _sprite.Set_isStamina_Calculated(true);
                        else _sprite.Set_isStamina_Calculated(false);
                        break;
                    }
                #endregion
                case "X-23-Assassin's_Strike":
                    #region Skill Motion
                    {
                        //for melee skill
                        goal = Set_Melee_Goal(_sprite.Get_Targets()[0]);

                        _sprite.Transition(_sprite.Position, goal, 5, 7);
                        //When Hit
                        if (_sprite.Get_Cur_Frame() == 20)
                        {
                            foreach (var target in _sprite.Get_Targets())
                            {
                                target.Re_Main();
                            }
                        }

                        _sprite.Transition(goal, _sprite.Position, 19, 7);

                        //Set Hit
                        if (_sprite.Get_Cur_Frame() == 12) _sprite.Set_isHealth_Calculated(true);
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
            if (BattleState.IsLeft_Side(this))
            {
                _sprite.Set_Rectangle(new Rectangle((int)_sprite.Position.X + (int)(_sprite.Get_Sprite_Width() / 3.0f),
                                                    (int)_sprite.Position.Y - 180,
                                                    (int)(_sprite.Get_Sprite_Width() / 3.5f),
                                                    100));
            }
            else
            {
                _sprite.Set_Rectangle(new Rectangle((int)_sprite.Position.X + (int)(_sprite.Get_Sprite_Width() /3.0f) + (int)(_sprite.Get_Sprite_Width() / 20.0f),
                                                    (int)_sprite.Position.Y - 180,
                                                    (int)(_sprite.Get_Sprite_Width() / 3.5f),
                                                    100));
            }
        }

        protected override Vector2 Set_Melee_Goal(Sprite target)
        {
            if (BattleState.IsLeft_Side(this)) return new Vector2(target.Get_Rectangle().X - 200, target.Position.Y + 0.01f);
            else return new Vector2(target.Get_Rectangle().X + target.Get_Rectangle().Width - 80, target.Position.Y + 0.01f);
        }

        protected override Vector2 Set_Range_Goal(Sprite target)
        {
            if (BattleState.IsLeft_Side(this)) return new Vector2(target.Get_Rectangle().X - 200, target.Position.Y + 0.01f);
            else return new Vector2(target.Get_Rectangle().X + target.Get_Rectangle().Width - 50, target.Position.Y + 0.01f);
        }

    }
}
