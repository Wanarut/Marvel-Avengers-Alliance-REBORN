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
    }
}
