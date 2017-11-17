using Marvel_Avengers_Alliance_REBORN.Components;
using Marvel_Avengers_Alliance_REBORN.States;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.Models
{
    class Calculator
    {
        Random rand;
        protected ArrayList StateObserver;
        protected ArrayList BarObserver;

        public Calculator()
        {
            rand = new Random();
            StateObserver = new ArrayList();
            BarObserver = new ArrayList();
        }

        public void NotifyAll()
        {
            foreach (BattleState state in StateObserver)
            {
                state.Notify(this);
            }
            foreach (StatusBar component in BarObserver)
            {
                component.Notify(this);
            }
        }

        public void AttachStateObserver(BattleState game)
        {
            StateObserver.Add(game);
        }

        public void AttachBarObserver(StatusBar bar)
        {
            BarObserver.Add(bar);
        }

        public void HeathCalculate(Sprite subject, List<Sprite> objects)
        {
            foreach(var target in objects)
            {
                int total_damage = rand.Next(subject.Get_Char().Get_Cur_Skill_Btn().Get_Skill().Get_Damage()[0], subject.Get_Char().Get_Cur_Skill_Btn().Get_Skill().Get_Damage()[1]) + subject.Get_Char().Get_Attack() - target.Get_Char().Get_Defense();

                if (total_damage < 0) total_damage = 0;

                target.Get_Char().Set_Health(target.Get_Char().Get_Health() - total_damage);

                //target.Set_WasAttacked(true);

                if (target.Get_Char().Get_Health() <= 0) target.Set_IsDead(true);
            }
            NotifyAll();
        }

        public void StaminaCalculate(Sprite actor)
        {
            int stamina_cost = (actor.Get_Char().Get_Cur_Skill_Btn().Get_Skill().Get_StaminaCost() * actor.Get_Char().Get_Max_Stamina()) / 100;

            actor.Get_Char().Set_Stamina(actor.Get_Char().Get_Stamina() - stamina_cost);

            actor.Get_Char().Set_Stamina(actor.Get_Char().Get_Stamina());

            NotifyAll();
        }
    }
}