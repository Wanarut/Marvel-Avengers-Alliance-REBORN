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
    class Captain_America : Character
    {
        public Captain_America(ContentManager content)
        {
            #region Set Stat
            name = Hero.Captain_America;
            alternate_uniform = Suit.Captain_America_Avengers_Age_of_Ultron;
            _max_health = 7153;
            _max_stamina = 7153;
            _attack = 1431;
            _defense = 1431;
            _accuracy = 1431;
            _evasion = 1431;
            _class = _Class.Tactician;
            
            _cur_health = _max_health;
            _cur_stamina = _max_stamina;
            #endregion

            #region Set 1st Attack
            _skills = new List<Skill>();
            _skills_buttons = new List<SkillButton>();
            Skill skill = new Skill("Captain_America-Shield_Bash");
            skill.Set_Time(2);
            skill.Set_Stamina_Cost(18);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(868, 1388);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(88);
            skill.Set_Cri_Chance(11);

            _skills.Add(skill);
            #endregion

            #region Set 2nd Attack
            skill = new Skill("Captain_America-Leading_Strike");
            skill.Set_Time(2);
            skill.Set_Stamina_Cost(10);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(1066, 1279);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(92);
            skill.Set_Cri_Chance(11);

            _skills.Add(skill);
            #endregion

            #region Set 3rd Attack
            skill = new Skill("Captain_America-Shield_Throw");
            skill.Set_Time(2);
            skill.Set_Stamina_Cost(25);
            skill.Set_NumberOfTargets(TargetType.All_Enemies);
            skill.Set_Damage(570, 855);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(94);
            skill.Set_Cri_Chance(12);

            _skills.Add(skill);
            #endregion

            #region Set 4th Attack
            skill = new Skill("Captain_America-Shield_Guard");
            skill.Set_Time(1);
            skill.Set_Stamina_Cost(15);
            skill.Set_NumberOfTargets(TargetType.Self);
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
