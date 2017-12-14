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
    class Hulk : Character
    {
        public Hulk(ContentManager content)
        {
            #region Set Stat
            name = Hero.Hulk;
            alternate_uniform = Suit.Hulk_Savage;
            _max_health = 8584;
            _max_stamina = 6438;
            _attack = 1574;
            _defense = 1574;
            _accuracy = 1144;
            _evasion = 1144;
            _class = _Class.Bruiser;
            
            _cur_health = _max_health;
            _cur_stamina = _max_stamina;
            #endregion

            #region Set 1st Attack
            _skills = new List<Skill>();
            _skills_buttons = new List<SkillButton>();
            Skill skill = new Skill("Hulk-Incredible_Rage_Punch");
            skill.Set_Time(2);
            skill.Set_Stamina_Cost(11);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(963, 1156);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(74);
            skill.Set_Cri_Chance(17);

            _skills.Add(skill);
            #endregion

            #region Set 2nd Attack
            skill = new Skill("Hulk-Monster-Size_Thunder_Clap");
            skill.Set_Time(2);
            skill.Set_Stamina_Cost(17);
            skill.Set_NumberOfTargets(TargetType.All_Enemies);
            skill.Set_Damage(483, 628);
            skill.Set_Cooldown(1, 1);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(89);
            skill.Set_Cri_Chance(0);

            _skills.Add(skill);
            #endregion

            #region Set 3rd Attack
            skill = new Skill("Hulk-Indestructible_Titanic_Hurl");
            skill.Set_Time(3);
            skill.Set_Stamina_Cost(33);
            skill.Set_NumberOfTargets(TargetType.All_Enemies);
            skill.Set_Damage(244, 367);
            skill.Set_Cooldown(1, 1);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(57);
            skill.Set_Cri_Chance(2);

            _skills.Add(skill);
            #endregion

            #region Set 4th Attack
            skill = new Skill("Hulk-Giant-Size_Hulk_Smash");
            skill.Set_Time(2);
            skill.Set_Stamina_Cost(22);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(1439, 2012);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(74);
            skill.Set_Cri_Chance(4);

            _skills.Add(skill);
            #endregion
        }

        #region Animation Editor
        public override void Check_Skill()
        {
            switch (_cur_skill_btn.Get_Skill().Get_Name())
            {
                case "Hulk-Incredible_Rage_Punch":
                    #region Skill Motion
                    {
                        //for melee skill
                        goal = Set_Melee_Goal(_sprite.Get_Targets()[0]);

                        _sprite.Transition(_sprite.Position, goal, 9, 3);
                        //When Hit
                        if (_sprite.Get_Cur_Frame() == 22)
                        {
                            foreach (var target in _sprite.Get_Targets())
                            {
                                target.Re_Main();
                            }
                        }

                        _sprite.Transition(goal, _sprite.Position, 23, 4);

                        //Set Hit
                        if (_sprite.Get_Cur_Frame() == 12) _sprite.Set_isHealth_Calculated(true);
                        else _sprite.Set_isHealth_Calculated(false);

                        //Use Stamina
                        if (_sprite.Get_Cur_Frame() == 1) _sprite.Set_isStamina_Calculated(true);
                        else _sprite.Set_isStamina_Calculated(false);
                        break;
                    }
                #endregion
                case "Hulk-Monster-Size_Thunder_Clap":
                    #region Skill Motion
                    {

                        //for melee skill
                        if(BattleState.IsLeft_Side(this)) goal = new Vector2(250, 420);
                        else goal = new Vector2(0, 420);

                        _sprite.Transition(_sprite.Position, goal, 4, 2);
                        //When Hit
                        if (_sprite.Get_Cur_Frame() == 23)
                        {
                            foreach (var target in _sprite.Get_Targets())
                            {
                                target.Re_Main();
                            }
                        }

                        _sprite.Transition(goal, _sprite.Position, 24, 4);

                        //Set Hit
                        if (_sprite.Get_Cur_Frame() == 17) _sprite.Set_isHealth_Calculated(true);
                        else _sprite.Set_isHealth_Calculated(false);

                        //Use Stamina
                        if (_sprite.Get_Cur_Frame() == 1) _sprite.Set_isStamina_Calculated(true);
                        else _sprite.Set_isStamina_Calculated(false);
                        break;
                    }
                #endregion
                case "Hulk-Indestructible_Titanic_Hurl":
                    #region Skill Motion
                    {

                        //for melee skill
                        if (BattleState.IsLeft_Side(this)) goal = new Vector2(250, 420);
                        else goal = new Vector2(0, 420);

                        _sprite.Transition(_sprite.Position, goal, 1, 1);
                        //When Hit
                        if (_sprite.Get_Cur_Frame() == 40)
                        {
                            foreach (var target in _sprite.Get_Targets())
                            {
                                target.Re_Main();
                            }
                        }

                        _sprite.Transition(goal, _sprite.Position, 41, 2);

                        //Set Hit
                        if (_sprite.Get_Cur_Frame() == 31) _sprite.Set_isHealth_Calculated(true);
                        else _sprite.Set_isHealth_Calculated(false);

                        //Use Stamina
                        if (_sprite.Get_Cur_Frame() == 1) _sprite.Set_isStamina_Calculated(true);
                        else _sprite.Set_isStamina_Calculated(false);
                        break;
                    }
                #endregion
                case "Hulk-Giant-Size_Hulk_Smash":
                    #region Skill Motion
                    {
                        //for melee skill
                        goal = Set_Melee_Goal(_sprite.Get_Targets()[0]);

                        _sprite.Transition(_sprite.Position, goal, 9, 5);
                        //When Hit
                        if (_sprite.Get_Cur_Frame() == 30)
                        {
                            foreach (var target in _sprite.Get_Targets())
                            {
                                target.Re_Main();
                            }
                        }

                        _sprite.Transition(goal, _sprite.Position, 27, 3);

                        //Set Hit
                        if (_sprite.Get_Cur_Frame() == 21) _sprite.Set_isHealth_Calculated(true);
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
                _sprite.Set_Rectangle(new Rectangle((int)_sprite.Position.X + (int)(_sprite.Get_Sprite_Width() / 4.0f),
                                                    (int)_sprite.Position.Y - 180,
                                                    (int)(_sprite.Get_Sprite_Width() / 3.0f),
                                                    100));
            }
            else
            {
                _sprite.Set_Rectangle(new Rectangle((int)_sprite.Position.X + (int)(_sprite.Get_Sprite_Width() / 4.0f) + (int)(_sprite.Get_Sprite_Width() / 6.3f),
                                                    (int)_sprite.Position.Y - 180,
                                                    (int)(_sprite.Get_Sprite_Width() / 3.0f),
                                                    100));
            }
        }

        protected override Vector2 Set_Melee_Goal(Sprite target)
        {
            if (BattleState.IsLeft_Side(this)) return new Vector2(target.Get_Rectangle().X -80, target.Position.Y + 0.01f);
            else return new Vector2(target.Get_Rectangle().X + target.Get_Rectangle().Width -400, target.Position.Y + 0.01f);
        }

        protected override Vector2 Set_Range_Goal(Sprite target)
        {
            if (BattleState.IsLeft_Side(this)) return new Vector2(target.Get_Rectangle().X -300, target.Position.Y + 0.01f);
            else return new Vector2(target.Get_Rectangle().X + target.Get_Rectangle().Width -200, target.Position.Y + 0.01f);
        }

    }
}
