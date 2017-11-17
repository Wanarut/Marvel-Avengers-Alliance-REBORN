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
            throw new NotImplementedException();
        }

        protected override Vector2 Set_Range_Goal(Sprite target)
        {
            throw new NotImplementedException();
        }
    }
}
