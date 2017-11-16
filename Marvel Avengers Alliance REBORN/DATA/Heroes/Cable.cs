using Marvel_Avengers_Alliance_REBORN.Buttons;
using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.DATA.Heroes
{
    class Cable : Character
    {
        public Cable(ContentManager content)
        {
            #region Set Stat
            name = Hero.Cable;
            alternate_uniform = Suit.Cable_Classic;
            _max_health = 7153;
            _max_stamina = 5722;
            _attack = 1574;
            _defense = 1574;
            _accuracy = 1431;
            _evasion = 1144;
            _class = _Class.Blaster;
            
            _cur_health = _max_health;
            _cur_stamina = _max_stamina;
            #endregion

            #region Set 1st Attack
            _skills = new List<Skill>();
            _skills_buttons = new List<SkillButton>();
            Skill skill = new Skill("Cable-Plasma_Rifle");
            skill.Set_Time(2);
            skill.Set_Stamina_Cost(31);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(1364, 1636);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(88);
            skill.Set_Cri_Chance(11);

            _skills.Add(skill);
            #endregion

            #region Set 2nd Attack
            skill = new Skill("Cable-Bodyslide");
            skill.Set_Time(3);
            skill.Set_Stamina_Cost(25);
            skill.Set_NumberOfTargets(TargetType.All_Enemies);
            skill.Set_Damage(644, 772);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(4);
            skill.Set_Hits_Chance(74);
            skill.Set_Cri_Chance(9);

            _skills.Add(skill);
            #endregion

            #region Set 3rd Attack
            skill = new Skill("Cable-Askani_Arts");
            skill.Set_Time(2);
            skill.Set_Stamina_Cost(19);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(875, 1050);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(2);
            skill.Set_Hits_Chance(93);
            skill.Set_Cri_Chance(19);

            _skills.Add(skill);
            #endregion

            #region Set 4th Attack
            skill = new Skill("Cable-Temporal_Shift");
            skill.Set_Time(1);
            skill.Set_Stamina_Cost(25);
            skill.Set_NumberOfTargets(TargetType.One_Ally);
            skill.Set_Damage(0, 0);
            skill.Set_Cooldown(2, 2);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(100);
            skill.Set_Cri_Chance(0);

            _skills.Add(skill);
            #endregion
        }

        #region Animation Editor
        public override void Check_Skill()
        {
            switch (_cur_skill.Get_Name())
            {
                case "Cable-Plasma_Rifle":
                    #region Skill Motion
                    {
                        
                        break;
                    }
                    #endregion
                case "Cable-Bodyslide":
                    #region Skill Motion
                    {
                        
                        break;
                    }
                    #endregion
                case "Cable-Askani_Arts":
                    #region Skill Motion
                    {
                        break;
                    }
                    #endregion
                case "Cable-Temporal_Shift":
                    #region Skill Motion
                    {
                        
                        break;
                    }
                    #endregion
            }
        }
        #endregion

        public override void Set_Sprite_Position(Vector2 vector)
        {
            _sprite.Position = vector;
            if (_sprite.Position.X < MAAGame.SCREEN_WIDTH / 4.0f)
            {
                _sprite.Set_Rectangle(new Rectangle((int)_sprite.Position.X + (int)(_sprite.Get_Sprite_Width() / 6.5f),
                                                    (int)_sprite.Position.Y - (int)(_sprite.Get_Sprite_Height() / 1.6f),
                                                    (int)(_sprite.Get_Sprite_Width() / 3.0f),
                                                    (int)(_sprite.Get_Sprite_Height() / 3) - 15));
            }
            else
            {
                _sprite.Set_Rectangle(new Rectangle((int)_sprite.Position.X + (int)(_sprite.Get_Sprite_Width() / 6.5f) + (int)(_sprite.Get_Sprite_Width() / 2.7f),
                                                    (int)_sprite.Position.Y - (int)(_sprite.Get_Sprite_Height() / 1.6f),
                                                    (int)(_sprite.Get_Sprite_Width() / 3.0f),
                                                    (int)(_sprite.Get_Sprite_Height() / 3) - 15));
            }
        }
    }
}
