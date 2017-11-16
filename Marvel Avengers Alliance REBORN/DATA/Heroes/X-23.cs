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
            switch (_cur_skill.Get_Name())
            {
                case "Captain_America-Shield_Bash":
                    #region Skill Motion
                    {
                        
                        break;
                    }
                    #endregion
                case "Captain_America-Leading_Strike":
                    #region Skill Motion
                    {
                        
                        break;
                    }
                    #endregion
                case "Captain_America-Shield_Throw":
                    #region Skill Motion
                    {
                        break;
                    }
                    #endregion
                case "Captain_America-Shield_Guard":
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
    }
}
