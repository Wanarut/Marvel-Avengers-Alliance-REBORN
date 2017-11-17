using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.Models
{
    class Skill
    {
        #region Fields
        private string _skill_name;
        private int _time_cast;
        private int _stamina_cost;
        private int _num_targets;
        private int[] _damage = new int[2];
        private int[] _cooldown = new int[2];
        private int _num_hits;
        private int _hits_chance;
        private int _cri_chance;
        #endregion

        #region Construcktor Function
        public Skill(string name)
        {
            _skill_name = name;

        }
        #endregion

        #region Set Attack Poperties
        public void Set_Time(int time_cast)
        {
            this._time_cast = time_cast;
        }

        public void Set_Stamina_Cost(int stamina_cost)
        {
            this._stamina_cost = stamina_cost;
        }

        public void Set_NumberOfTargets(int num_targets)
        {
            this._num_targets = num_targets;
        }
        
        public void Set_Damage(int min_damage, int max_damage)
        {
            _damage[0] = min_damage;
            _damage[1] = max_damage;
        }

        public void Set_Cooldown(int cooldown, int max_cooldown)
        {
            _cooldown[0] = cooldown;
            _cooldown[1] = max_cooldown;
        }

        public void Set_NumberOfHits(int num_hits)
        {
            this._num_hits = num_hits;
        }

        public void Set_Hits_Chance(int hits_chance)
        {
            this._hits_chance = hits_chance;
        }

        public void Set_Cri_Chance(int cri_chance)
        {
            this._cri_chance = cri_chance;
        }
        #endregion

        #region Get Attack Poperties
        public int Get_Time()
        {
            return _time_cast;
        }

        public string Get_Name()
        {
            return _skill_name;
        }

        public int Get_StaminaCost()
        {
            return _stamina_cost;
        }

        public int Get_NumberOfTargets()
        {
            return _num_targets;
        }

        public int[] Get_Damage()
        {
            return _damage;
        }

        public int[] Get_Cooldown()
        {
            return _cooldown;
        }

        public int Get_NumberOfHits()
        {
            return _num_hits;
        }

        public int Get_HitChance()
        {
            return _hits_chance;
        }

        public int Get_CriticalChance()
        {
            return _cri_chance; ;
        }
        #endregion
    }
}
