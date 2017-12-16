using Marvel_Avengers_Alliance_REBORN.Buttons;
using Marvel_Avengers_Alliance_REBORN.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.Models
{
    abstract class Character
    {
        #region Field
        protected string name;
        protected string alternate_uniform;
        protected int _max_health;
        protected int _cur_health;
        protected int _max_stamina;
        protected int _cur_stamina;
        protected int _attack;
        protected int _defense;
        protected int _accuracy;
        protected int _evasion;
        protected _Class _class;

        protected List<SkillButton> _skills_buttons;
        protected Vector2 goal = Vector2.Zero;
        protected List<Skill> _skills;
        protected Sprite _sprite;
        protected SkillButton _cur_skill_btn;
        
        public bool isPickSkill = false;
        public StatusBar _hp_bar;
        public StatusBar _sp_bar;
        public Icon _small_icon;

        //public Vector2 Position { get; set; }
        #endregion

        public abstract void Set_Sprite_Position(Vector2 vector);

        protected abstract Vector2 Set_Melee_Goal(Sprite target);

        protected abstract Vector2 Set_Range_Goal(Sprite target);

        #region Get Function
        public Sprite Get_Sprite()
        {
            return _sprite;
        }

        public int Get_Sprite_Height()
        {
            return _sprite.Get_Sprite_Height();
        }

        public int Get_Sprite_Width()
        {
            return _sprite.Get_Sprite_Width();
        }

        public string Get_Name()
        {
            return name;
        }

        public string Get_Uniform()
        {
            return alternate_uniform;
        }

        public int Get_Max_Stamina()
        {
            return _max_stamina;
        }

        public int Get_Health()
        {
            return _cur_health;
        }

        public int Get_Max_Health()
        {
            return _max_health;
        }

        public int Get_Stamina()
        {
            return _cur_stamina;
        }

        public int Get_Attack()
        {
            return _attack;
        }

        public int Get_Defense()
        {
            return _defense;
        }

        public int Get_Accuracy()
        {
            return _accuracy;
        }

        public int Get_Evasion()
        {
            return _evasion;
        }

        public _Class Get_Class()
        {
            return _class;
        }
        
        public List<Skill> Get_Skills()
        {
            return _skills;
        }

        public List<SkillButton> Get_Skills_Buttons()
        {
            return _skills_buttons;
        }

        public SkillButton Get_Cur_Skill_Btn()
        {
            return _cur_skill_btn;
        }

        public bool Get_Sprite_HasTarget()
        {
            return _sprite.Get_HasTarget();
        }
        #endregion

        #region Set Function
        public void Add_Skill_Button(SkillButton btnskill)
        {
            _skills_buttons.Add(btnskill);
        }

        public void Set_Sprite_HasTarget(bool logic)
        {
            _sprite.Set_HasTarget(logic);
        }

        public void Set_Cur_Skill_Btn(SkillButton cur_skill)
        {
            _cur_skill_btn = cur_skill;
        }

        public void Set_Sprite_Focus(bool logic)
        {
            _sprite.Set_IsFocus(logic);
        }

        public void Set_Health(int cur_health)
        {
            _cur_health = cur_health;
            if(_hp_bar != null) _hp_bar.Set_Value(_cur_health);
        }

        public void Set_Stamina(int cur_stamina)
        {
            _cur_stamina = cur_stamina;
            if(_sp_bar != null) _sp_bar.Set_Value(_cur_stamina);
        }

        public void Set_Attack(int attack)
        {
            _attack = attack;
        }

        public void Set_Defense(int defense)
        {
            _defense = defense;
        }

        public void Set_Accuracy(int accuracy)
        {
            _accuracy = accuracy;
        }

        public void Set_Evasion(int evasion)
        {
            _evasion = evasion;
        }

        public void Set_Class(_Class _class)
        {
            this._class = _class;
        }

        public void Set_Target(List<Sprite> targets)
        {
            _sprite.Set_Targets(targets);
        }
        #endregion

        #region Order Function
        public void Skill_Action(ContentManager content)
        {
            _sprite.ChangeTexture(content.Load<Texture2D>("Character/" + name + "/" + alternate_uniform + "/" + "Sprite_" + _cur_skill_btn.Get_Skill().Get_Name()), 15, _cur_skill_btn.Get_Skill().Get_Time());
            //Check_Skill();
        }

        public abstract void Check_Skill();

        public void Load_Sprite(ContentManager content, string hero_name, string uniform_name)
        {
            _sprite = new Sprite(content, hero_name, uniform_name);
            _sprite.Set_MyChar(this);
        }

        public void Draw_Sprite(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _sprite.DrawFrame(spriteBatch);
        }

        public void Update_Sprite_Frame(GameTime gameTime, float elapsed)
        {
            _sprite.UpdateFrame(elapsed);
        }
        #endregion

        #region FrameControl Function
        public bool IsPaused
        {
            get { return _sprite.IsPaused; }
        }

        public void Reset()
        {
            _sprite.Reset();
        }

        public void Stop()
        {
            _sprite.Stop();
        }

        public void Play()
        {
            _sprite.Play();
        }

        public void Pause()
        {
            _sprite.Pause();
        }

        public void Recharge()
        {
            _cur_stamina = _cur_stamina + (int)(_max_stamina * 0.15f);
            if (_cur_stamina > _max_stamina) _cur_stamina = _max_stamina;
            _sprite.Get_Char().Set_Stamina(_cur_stamina);
        }
        #endregion
    }
}
