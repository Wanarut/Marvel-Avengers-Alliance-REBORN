using Marvel_Avengers_Alliance_REBORN.Buttons;
using Marvel_Avengers_Alliance_REBORN.Components;
using Marvel_Avengers_Alliance_REBORN.DATA;
using Marvel_Avengers_Alliance_REBORN.DATA.Heroes;
using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace Marvel_Avengers_Alliance_REBORN.States
{
    class SelectState : State
    {
        #region Game Fields
        private List<Character> heroes;
        private List<Character> MonHeros;
        private List<SelectCard> cards;
        private List<SelectIcon> IconBackground;
        private List<SelectIcon> IconHero;
        private List<SelectIcon> HeroSelect;
        private List<SelectIcon> HerosStatus;
        private List<SelectIcon> Button;


        private Background Select_background;
        private Background Stetusbar;

        int numSelect = 0;

        int[] Xposition = new int[7];
        int[] Yposition = new int[7];

        #endregion

        /*public SelectState()
        {
            MonHeros = new List<Character>();
            MonHeros.Add(new Ant_Man(_content));
            MonHeros.Add(new Deadpool(_content));
            MonHeros.Add(new Captain_America(_content));

            //graphics = new GraphicsDeviceManager(this);

            _content.RootDirectory = "_content";
            IsMouseVisible = true;

            TargetElapsedTime = TimeSpan.FromSeconds(1 / 15.0); // Frame rate is 15 fps.
        }*/

        public SelectState(MAAGame game, GraphicsDevice graphicsDevice, ContentManager content, List<Character> enemies) : base(game, graphicsDevice, content)
        {
            MonHeros = enemies;

            heroes = new List<Character>();
            Select_background = new Background();
            Stetusbar = new Background();
            cards = new List<SelectCard>();
            IconBackground = new List<SelectIcon>();
            IconHero = new List<SelectIcon>();
            HeroSelect = new List<SelectIcon>();
            HerosStatus = new List<SelectIcon>();
            Button = new List<SelectIcon>();
            #region Song
            song = _content.Load<Song>("Songs/" + Songs.SelectSong);    //Set Song
            MediaPlayer.Play(song);
            #endregion

            #region Interface
            Select_background.LoadContent(_content, "Select_Background/" + BG.SG_001);  //Set BackGround
            Stetusbar.LoadContent(_content, "Select_Background/" + BG.SG_002);
            Stetusbar.Position = new Vector2((Select_background.Get_Width() / 2 - (Stetusbar.Get_Width() / 2)), 405);
            Xposition[6] = (Select_background.Get_Width() / 2 - (Stetusbar.Get_Width() / 2));
            Yposition[6] = 405;

            #endregion

            #region Back,Start
            var btnBack = new SelectIcon(_content, IconHeros.Button_Back);
            btnBack.Position = new Vector2(10, 10);
            btnBack.Click += Back_was_Clicked;
            Button.Add(btnBack);

            var btnStart = new SelectIcon(_content, IconHeros.Button_Start);
            btnStart.Position = new Vector2(605, 326);
            btnStart.Click += Start_was_Clicked;
            Button.Add(btnStart);
            #endregion

            #region CreatCrad
            var btnCard = new SelectCard(_content, IconHeros.Deadpool_Card);
            btnCard.Position = new Vector2(((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)) - btnCard.Get_Width() - 10), 50);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new SelectCard(_content, IconHeros.AntMan_Card);
            btnCard.Position = new Vector2((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)), 50);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new SelectCard(_content, IconHeros.Hulk_Card);
            btnCard.Position = new Vector2(((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)) + btnCard.Get_Width() + 10), 50);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new SelectCard(_content, IconHeros.Captain_Card);
            btnCard.Position = new Vector2(((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)) - btnCard.Get_Width() - 10), 50 + btnCard.Get_Height() + 10);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new SelectCard(_content, IconHeros.X23_Card);
            btnCard.Position = new Vector2((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)), 50 + btnCard.Get_Height() + 10);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new SelectCard(_content, IconHeros.Cable_Card);
            btnCard.Position = new Vector2(((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)) + btnCard.Get_Width() + 10), 50 + btnCard.Get_Height() + 10);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;
            #endregion

            #region BackgroundIcon

            var btnIcon1 = new SelectIcon(_content, IconHeros.Background_Icon1);
            btnIcon1.Position = new Vector2(75, 405);
            Xposition[0] = 75; Yposition[0] = 405;
            IconBackground.Add(btnIcon1);
            btnIcon1.Click += Icon_was_Clicked;

            var btnIcon2 = new SelectIcon(_content, IconHeros.Background_Icon2);
            btnIcon2.Position = new Vector2(75 + (btnIcon2.Get_Width()) + 10, 405 + (btnIcon2.Get_Height()));
            Xposition[1] = 75 + (btnIcon2.Get_Width()) + 10; Yposition[1] = 405 + (btnIcon2.Get_Height());
            IconBackground.Add(btnIcon2);
            btnIcon2.Click += Icon_was_Clicked;

            var btnIcon3 = new SelectIcon(_content, IconHeros.Background_Icon3);
            btnIcon3.Position = new Vector2(75, 405 + (btnIcon3.Get_Height() * 2));
            Xposition[2] = 75; Yposition[2] = 405 + (btnIcon3.Get_Height() * 2);
            IconBackground.Add(btnIcon3);
            btnIcon3.Click += Icon_was_Clicked;

            var btnIcon4 = new SelectIcon(_content, IconHeros.Background_Icon);
            btnIcon4.Position = new Vector2((Select_background.Get_Width()) - 75 - (btnIcon4.Get_Width()), 405);
            Xposition[3] = (Select_background.Get_Width()) - 75 - (btnIcon4.Get_Width()); Yposition[3] = 405;
            IconBackground.Add(btnIcon4);

            var btnIcon5 = new SelectIcon(_content, IconHeros.Background_Icon);
            btnIcon5.Position = new Vector2((Select_background.Get_Width()) - 75 - 10 - (btnIcon5.Get_Width() * 2), 405 + (btnIcon5.Get_Height()));
            Xposition[4] = (Select_background.Get_Width()) - 75 - 10 - (btnIcon5.Get_Width() * 2); Yposition[4] = 405 + (btnIcon5.Get_Height());
            IconBackground.Add(btnIcon5);

            var btnIcon6 = new SelectIcon(_content, IconHeros.Background_Icon);
            btnIcon6.Position = new Vector2((Select_background.Get_Width()) - 75 - (btnIcon6.Get_Width()), 405 + (btnIcon6.Get_Height() * 2));
            Xposition[5] = (Select_background.Get_Width()) - 75 - (btnIcon6.Get_Width()); Yposition[5] = 405 + (btnIcon6.Get_Height() * 2);
            IconBackground.Add(btnIcon6);
            #endregion

            #region Stadard Heros
            var btnIconDeadpool = new SelectIcon(_content, IconHeros.Deadpool_Icon);
            btnIconDeadpool.Position = new Vector2(Xposition[0], Yposition[0]);
            HeroSelect.Add(btnIconDeadpool);
            btnIconDeadpool.Click += Icon_was_Clicked;
            btnIconDeadpool.Set_IsFocusIcon(true);
            heroes.Add(new Deadpool(_content));
            heroes[0]._hp_bar = new StatusBar(heroes[0].Get_Name(), heroes[0].Get_Max_Health(), Gadget.HEALTH, _content);
            heroes[0]._hp_bar.Position = new Vector2(10, 200);

            var btnIconAntMan = new SelectIcon(_content, IconHeros.AntMan_Icon);
            btnIconAntMan.Position = new Vector2(Xposition[1], Yposition[1]);
            HeroSelect.Add(btnIconAntMan);
            btnIconAntMan.Click += Icon_was_Clicked;
            heroes.Add(new Ant_Man(_content));
            heroes[1]._hp_bar = new StatusBar(heroes[1].Get_Name(), heroes[1].Get_Max_Health(), Gadget.HEALTH, _content);
            heroes[1]._hp_bar.Position = new Vector2(10, 220);

            var btnIconHulk = new SelectIcon(_content, IconHeros.Hulk_Icon);
            btnIconHulk.Position = new Vector2(Xposition[2], Yposition[2]);
            HeroSelect.Add(btnIconHulk);
            btnIconHulk.Click += Icon_was_Clicked;
            heroes.Add(new Hulk(_content));
            heroes[2]._hp_bar = new StatusBar(heroes[2].Get_Name(), heroes[2].Get_Max_Health(), Gadget.HEALTH, _content);
            heroes[2]._hp_bar.Position = new Vector2(10, 240);

            var btnIconAntMan1 = new SelectIcon(_content, IconHeros.AntMan_Icon_Mon);
            btnIconAntMan1.Position = new Vector2(Xposition[3], Yposition[3]);
            HeroSelect.Add(btnIconAntMan1);
            heroes.Add(new Ant_Man(_content));
            heroes[3]._hp_bar = new StatusBar(heroes[3].Get_Name(), heroes[3].Get_Max_Health(), Gadget.HEALTH, _content);
            heroes[3]._hp_bar.Position = new Vector2(10, 260);

            var btnIconAntMan2 = new SelectIcon(_content, IconHeros.AntMan_Icon_Mon);
            btnIconAntMan2.Position = new Vector2(Xposition[4], Yposition[4]);
            HeroSelect.Add(btnIconAntMan2);
            heroes.Add(new Ant_Man(_content));
            heroes[4]._hp_bar = new StatusBar(heroes[4].Get_Name(), heroes[4].Get_Max_Health(), Gadget.HEALTH, _content);
            heroes[4]._hp_bar.Position = new Vector2(10, 280);

            var btnIconAntMan3 = new SelectIcon(_content, IconHeros.AntMan_Icon_Mon);
            btnIconAntMan3.Position = new Vector2(Xposition[5], Yposition[5]);
            HeroSelect.Add(btnIconAntMan3);
            heroes.Add(new Ant_Man(_content));
            heroes[5]._hp_bar = new StatusBar(heroes[5].Get_Name(), heroes[5].Get_Max_Health(), Gadget.HEALTH, _content);
            heroes[5]._hp_bar.Position = new Vector2(10, 300);
            #endregion

            #region Mon In State

            heroes[3] = MonHeros[0];
            heroes[4] = MonHeros[1];
            heroes[5] = MonHeros[2];
            //Mon1
            if (heroes[3].Get_Name() == "Deadpool")
            {
                var btnIconDeadpoolmon = new SelectIcon(_content, IconHeros.Deadpool_Icon_Mon);
                btnIconDeadpoolmon.Position = new Vector2(Xposition[3], Yposition[3]);
                HeroSelect[3] = btnIconDeadpoolmon;
                btnIconDeadpoolmon.Click += Icon_was_Clicked;
                heroes[3]._hp_bar = new StatusBar(heroes[3].Get_Name(), heroes[3].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[3]._hp_bar.Position = new Vector2(10, 260);
            }
            else if (heroes[3].Get_Name() == "Ant-Man")
            {
                var btnIconAntManmon = new SelectIcon(_content, IconHeros.AntMan_Icon_Mon);
                btnIconAntManmon.Position = new Vector2(Xposition[3], Yposition[3]);
                HeroSelect[3] = btnIconAntManmon;
                btnIconAntManmon.Click += Icon_was_Clicked;
                heroes[3]._hp_bar = new StatusBar(heroes[3].Get_Name(), heroes[3].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[3]._hp_bar.Position = new Vector2(10, 260);
            }
            else if (heroes[3].Get_Name() == "Hulk")
            {
                var btnIconHulkmon = new SelectIcon(_content, IconHeros.Hulk_Icon_Mon);
                btnIconHulkmon.Position = new Vector2(Xposition[3], Yposition[3]);
                HeroSelect[3] = btnIconHulkmon;
                btnIconHulkmon.Click += Icon_was_Clicked;
                heroes[3]._hp_bar = new StatusBar(heroes[3].Get_Name(), heroes[3].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[3]._hp_bar.Position = new Vector2(10, 260);
            }
            else if (heroes[3].Get_Name() == "Captain America")
            {
                var btnIconCaptainmon = new SelectIcon(_content, IconHeros.Captain_Icon_Mon);
                btnIconCaptainmon.Position = new Vector2(Xposition[3], Yposition[3]);
                HeroSelect[3] = btnIconCaptainmon;
                btnIconCaptainmon.Click += Icon_was_Clicked;
                heroes[3]._hp_bar = new StatusBar(heroes[3].Get_Name(), heroes[3].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[3]._hp_bar.Position = new Vector2(10, 260);
            }
            else if (heroes[3].Get_Name() == "X-23")
            {
                var btnIconX23mon = new SelectIcon(_content, IconHeros.X23_Icon_Mon);
                btnIconX23mon.Position = new Vector2(Xposition[3], Yposition[3]);
                HeroSelect[3] = btnIconX23mon;
                btnIconX23mon.Click += Icon_was_Clicked;
                heroes[3]._hp_bar = new StatusBar(heroes[3].Get_Name(), heroes[3].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[3]._hp_bar.Position = new Vector2(10, 260);
            }
            else if (heroes[3].Get_Name() == "Cable")
            {
                var btnIconCablemon = new SelectIcon(_content, IconHeros.Cable_Icon_Mon);
                btnIconCablemon.Position = new Vector2(Xposition[3], Yposition[3]);
                HeroSelect[3] = btnIconCablemon;
                btnIconCablemon.Click += Icon_was_Clicked;
                heroes[3]._hp_bar = new StatusBar(heroes[3].Get_Name(), heroes[3].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[3]._hp_bar.Position = new Vector2(10, 260);
            }
            //Mon2
            if (heroes[4].Get_Name() == "Deadpool")
            {
                var btnIconDeadpoolmon = new SelectIcon(_content, IconHeros.Deadpool_Icon_Mon);
                btnIconDeadpoolmon.Position = new Vector2(Xposition[4], Yposition[4]);
                HeroSelect[4] = btnIconDeadpoolmon;
                btnIconDeadpoolmon.Click += Icon_was_Clicked;
                heroes[4]._hp_bar = new StatusBar(heroes[4].Get_Name(), heroes[4].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[4]._hp_bar.Position = new Vector2(10, 280);
            }
            else if (heroes[4].Get_Name() == "Ant-Man")
            {
                var btnIconAntManmon = new SelectIcon(_content, IconHeros.AntMan_Icon_Mon);
                btnIconAntManmon.Position = new Vector2(Xposition[4], Yposition[4]);
                HeroSelect[4] = btnIconAntManmon;
                btnIconAntManmon.Click += Icon_was_Clicked;
                heroes[4]._hp_bar = new StatusBar(heroes[4].Get_Name(), heroes[4].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[4]._hp_bar.Position = new Vector2(10, 280);
            }
            else if (heroes[4].Get_Name() == "Hulk")
            {
                var btnIconHulkmon = new SelectIcon(_content, IconHeros.Hulk_Icon_Mon);
                btnIconHulkmon.Position = new Vector2(Xposition[4], Yposition[4]);
                HeroSelect[4] = btnIconHulkmon;
                btnIconHulkmon.Click += Icon_was_Clicked;
                heroes[4]._hp_bar = new StatusBar(heroes[4].Get_Name(), heroes[4].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[4]._hp_bar.Position = new Vector2(10, 280);
            }
            else if (heroes[4].Get_Name() == "Captain America")
            {
                var btnIconCaptainmon = new SelectIcon(_content, IconHeros.Captain_Icon_Mon);
                btnIconCaptainmon.Position = new Vector2(Xposition[4], Yposition[4]);
                HeroSelect[4] = btnIconCaptainmon;
                btnIconCaptainmon.Click += Icon_was_Clicked;
                heroes[4]._hp_bar = new StatusBar(heroes[4].Get_Name(), heroes[4].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[4]._hp_bar.Position = new Vector2(10, 280);
            }
            else if (heroes[4].Get_Name() == "X-23")
            {
                var btnIconX23mon = new SelectIcon(_content, IconHeros.X23_Icon_Mon);
                btnIconX23mon.Position = new Vector2(Xposition[4], Yposition[4]);
                HeroSelect[4] = btnIconX23mon;
                btnIconX23mon.Click += Icon_was_Clicked;
                heroes[4]._hp_bar = new StatusBar(heroes[4].Get_Name(), heroes[4].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[4]._hp_bar.Position = new Vector2(10, 280);
            }
            else if (heroes[4].Get_Name() == "Cable")
            {
                var btnIconCablemon = new SelectIcon(_content, IconHeros.Cable_Icon_Mon);
                btnIconCablemon.Position = new Vector2(Xposition[4], Yposition[4]);
                HeroSelect[4] = btnIconCablemon;
                btnIconCablemon.Click += Icon_was_Clicked;
                heroes[4]._hp_bar = new StatusBar(heroes[4].Get_Name(), heroes[4].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[4]._hp_bar.Position = new Vector2(10, 300);
            }
            //Mon3
            if (heroes[5].Get_Name() == "Deadpool")
            {
                var btnIconDeadpoolmon = new SelectIcon(_content, IconHeros.Deadpool_Icon_Mon);
                btnIconDeadpoolmon.Position = new Vector2(Xposition[5], Yposition[5]);
                HeroSelect[5] = btnIconDeadpoolmon;
                btnIconDeadpoolmon.Click += Icon_was_Clicked;
                heroes[5]._hp_bar = new StatusBar(heroes[5].Get_Name(), heroes[5].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[5]._hp_bar.Position = new Vector2(10, 300);
            }
            else if (heroes[5].Get_Name() == "Ant-Man")
            {
                var btnIconAntManmon = new SelectIcon(_content, IconHeros.AntMan_Icon_Mon);
                btnIconAntManmon.Position = new Vector2(Xposition[5], Yposition[5]);
                HeroSelect[5] = btnIconAntManmon;
                btnIconAntManmon.Click += Icon_was_Clicked;
                heroes[5]._hp_bar = new StatusBar(heroes[5].Get_Name(), heroes[5].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[5]._hp_bar.Position = new Vector2(10, 300);
            }
            else if (heroes[5].Get_Name() == "Hulk")
            {
                var btnIconHulkmon = new SelectIcon(_content, IconHeros.Hulk_Icon_Mon);
                btnIconHulkmon.Position = new Vector2(Xposition[5], Yposition[5]);
                HeroSelect[5] = btnIconHulkmon;
                btnIconHulkmon.Click += Icon_was_Clicked;
                heroes[5]._hp_bar = new StatusBar(heroes[5].Get_Name(), heroes[5].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[5]._hp_bar.Position = new Vector2(10, 300);
            }
            else if (heroes[5].Get_Name() == "Captain America")
            {
                var btnIconCaptainmon = new SelectIcon(_content, IconHeros.Captain_Icon_Mon);
                btnIconCaptainmon.Position = new Vector2(Xposition[5], Yposition[5]);
                HeroSelect[5] = btnIconCaptainmon;
                btnIconCaptainmon.Click += Icon_was_Clicked;
                heroes[5]._hp_bar = new StatusBar(heroes[5].Get_Name(), heroes[5].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[5]._hp_bar.Position = new Vector2(10, 300);
            }
            else if (heroes[5].Get_Name() == "X-23")
            {
                var btnIconX23mon = new SelectIcon(_content, IconHeros.X23_Icon_Mon);
                btnIconX23mon.Position = new Vector2(Xposition[5], Yposition[5]);
                HeroSelect[5] = btnIconX23mon;
                btnIconX23mon.Click += Icon_was_Clicked;
                heroes[5]._hp_bar = new StatusBar(heroes[5].Get_Name(), heroes[5].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[5]._hp_bar.Position = new Vector2(10, 300);
            }
            else if (heroes[5].Get_Name() == "Cable")
            {
                var btnIconCablemon = new SelectIcon(_content, IconHeros.Cable_Icon_Mon);
                btnIconCablemon.Position = new Vector2(Xposition[5], Yposition[5]);
                HeroSelect[5] = btnIconCablemon;
                btnIconCablemon.Click += Icon_was_Clicked;
                heroes[5]._hp_bar = new StatusBar(heroes[5].Get_Name(), heroes[5].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[5]._hp_bar.Position = new Vector2(10, 300);
            }
            #endregion

            #region Stadard Status
            var DeadpoolStatus = new SelectIcon(_content, IconHeros.Deadpool_Status);
            DeadpoolStatus.Position = new Vector2(Xposition[6], Yposition[6]);
            HerosStatus.Add(DeadpoolStatus);
            #endregion
        }
        
        private void Back_was_Clicked(object sender, EventArgs e)
        {
            _game.Change_State(new LoadingState(_game, _graphicsDevice, _content, 
                new MapState(_game, _graphicsDevice, _content)));
        }

        private void Start_was_Clicked(object sender, EventArgs e)
        {
            //Heros1
            if(HeroSelect[0].Get_Name() == "Deadpool_Icon")
            {
                heroes[0] = new Deadpool(_content);
                heroes[0]._hp_bar = new StatusBar(heroes[0].Get_Name(), heroes[0].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[0]._hp_bar.Position = new Vector2(10, 200);
            }
            else if (HeroSelect[0].Get_Name() == "Ant-Man_Icon")
            {
                heroes[0] = new Ant_Man(_content);
                heroes[0]._hp_bar = new StatusBar(heroes[0].Get_Name(), heroes[0].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[0]._hp_bar.Position = new Vector2(10, 200);

            }
            else if (HeroSelect[0].Get_Name() == "Hulk_Icon")
            {
                heroes[0] = new Hulk(_content);
                heroes[0]._hp_bar = new StatusBar(heroes[0].Get_Name(), heroes[0].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[0]._hp_bar.Position = new Vector2(10, 200);

            }
            else if (HeroSelect[0].Get_Name() == "Captain_Icon")
            {
                heroes[0] = new Captain_America(_content);
                heroes[0]._hp_bar = new StatusBar(heroes[0].Get_Name(), heroes[0].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[0]._hp_bar.Position = new Vector2(10, 200);

            }
            else if (HeroSelect[0].Get_Name() == "X-23_Icon")
            {
                heroes[0] = new X_23(_content);
                heroes[0]._hp_bar = new StatusBar(heroes[0].Get_Name(), heroes[0].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[0]._hp_bar.Position = new Vector2(10,200 );

            }
            else if (HeroSelect[0].Get_Name() == "Cable_Icon")
            {
                heroes[0] = new Cable(_content);
                heroes[0]._hp_bar = new StatusBar(heroes[0].Get_Name(), heroes[0].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[0]._hp_bar.Position = new Vector2(10, 200);
            }
            // Heros2
            if (HeroSelect[1].Get_Name() == "Deadpool_Icon")
            {
                heroes[1] = new Deadpool(_content);
                heroes[1]._hp_bar = new StatusBar(heroes[1].Get_Name(), heroes[1].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[1]._hp_bar.Position = new Vector2(10, 220);
            }
            else if (HeroSelect[1].Get_Name() == "Ant-Man_Icon")
            {
                heroes[1] = new Ant_Man(_content);
                heroes[1]._hp_bar = new StatusBar(heroes[1].Get_Name(), heroes[1].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[1]._hp_bar.Position = new Vector2(10, 220);

            }
            else if (HeroSelect[1].Get_Name() == "Hulk_Icon")
            {
                heroes[1] = new Hulk(_content);
                heroes[1]._hp_bar = new StatusBar(heroes[1].Get_Name(), heroes[1].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[1]._hp_bar.Position = new Vector2(10, 220);

            }
            else if (HeroSelect[1].Get_Name() == "Captain_Icon")
            {
                heroes[1] = new Captain_America(_content);
                heroes[1]._hp_bar = new StatusBar(heroes[1].Get_Name(), heroes[1].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[1]._hp_bar.Position = new Vector2(10, 220);

            }
            else if (HeroSelect[1].Get_Name() == "X-23_Icon")
            {
                heroes[1] = new X_23(_content);
                heroes[1]._hp_bar = new StatusBar(heroes[1].Get_Name(), heroes[1].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[1]._hp_bar.Position = new Vector2(10, 220);

            }
            else if (HeroSelect[1].Get_Name() == "Cable_Icon")
            {
                heroes[1] = new Cable(_content);
                heroes[1]._hp_bar = new StatusBar(heroes[1].Get_Name(), heroes[1].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[1]._hp_bar.Position = new Vector2(10, 220);
            }
            //Heros3
            if (HeroSelect[2].Get_Name() == "Deadpool_Icon")
            {
                heroes[2] = new Deadpool(_content);
                heroes[2]._hp_bar = new StatusBar(heroes[2].Get_Name(), heroes[2].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[2]._hp_bar.Position = new Vector2(10, 240);
            }
            else if (HeroSelect[2].Get_Name() == "Ant-Man_Icon")
            {
                heroes[2] = new Ant_Man(_content);
                heroes[2]._hp_bar = new StatusBar(heroes[2].Get_Name(), heroes[2].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[2]._hp_bar.Position = new Vector2(10, 240);

            }
            else if (HeroSelect[2].Get_Name() == "Hulk_Icon")
            {
                heroes[2] = new Hulk(_content);
                heroes[2]._hp_bar = new StatusBar(heroes[2].Get_Name(), heroes[2].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[2]._hp_bar.Position = new Vector2(10, 240);

            }
            else if (HeroSelect[2].Get_Name() == "Captain_Icon")
            {
                heroes[2] = new Captain_America(_content);
                heroes[2]._hp_bar = new StatusBar(heroes[2].Get_Name(), heroes[2].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[2]._hp_bar.Position = new Vector2(10, 240);

            }
            else if (HeroSelect[2].Get_Name() == "X-23_Icon")
            {
                heroes[2] = new X_23(_content);
                heroes[2]._hp_bar = new StatusBar(heroes[2].Get_Name(), heroes[2].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[2]._hp_bar.Position = new Vector2(10, 240);

            }
            else if (HeroSelect[2].Get_Name() == "Cable_Icon")
            {
                heroes[2] = new Cable(_content);
                heroes[2]._hp_bar = new StatusBar(heroes[2].Get_Name(), heroes[2].Get_Max_Health(), Gadget.HEALTH, _content);
                heroes[2]._hp_bar.Position = new Vector2(10, 240);
            }

            _game.Change_State(new LoadingState(_game, _graphicsDevice, _content, 
                new BattleState(_game, _graphicsDevice, _content, heroes)));
            //Do something
        }

        private void Icon_was_Clicked(object sender, EventArgs e)
        {
            if (((SelectIcon)sender).Get_Name() == HeroSelect[0].Get_Name())
            {

                if (HeroSelect[0].Get_Name() == "Deadpool_Icon")
                {
                    var DeadpoolStatus = new SelectIcon(_content, IconHeros.Deadpool_Status);
                    DeadpoolStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = DeadpoolStatus;
                }
                else if (HeroSelect[0].Get_Name() == "Ant-Man_Icon")
                {
                    var AntManStatus = new SelectIcon(_content, IconHeros.Ant_Man_Status);
                    AntManStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = AntManStatus;
                }
                else if (HeroSelect[0].Get_Name() == "Hulk_Icon")
                {
                    var HulkStatus = new SelectIcon(_content, IconHeros.Hulk_Status);
                    HulkStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = HulkStatus;
                }
                else if (HeroSelect[0].Get_Name() == "Captain_Icon")
                {
                    var CaptainStatus = new SelectIcon(_content, IconHeros.Captain_Status);
                    CaptainStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CaptainStatus;
                }
                else if (HeroSelect[0].Get_Name() == "X-23_Icon")
                {
                    var X23Status = new SelectIcon(_content, IconHeros.X_23_Status);
                    X23Status.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = X23Status;
                }
                else if (HeroSelect[0].Get_Name() == "Cable_Icon")
                {
                    var CableStatus = new SelectIcon(_content, IconHeros.Cable_Status);
                    CableStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CableStatus;
                }
            }
            else if (((SelectIcon)sender).Get_Name() == HeroSelect[1].Get_Name())
            {
                if (HeroSelect[1].Get_Name() == "Deadpool_Icon")
                {
                    var DeadpoolStatus = new SelectIcon(_content, IconHeros.Deadpool_Status);
                    DeadpoolStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = DeadpoolStatus;
                }
                else if (HeroSelect[1].Get_Name() == "Ant-Man_Icon")
                {
                    var AntManStatus = new SelectIcon(_content, IconHeros.Ant_Man_Status);
                    AntManStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = AntManStatus;
                }
                else if (HeroSelect[1].Get_Name() == "Hulk_Icon")
                {
                    var HulkStatus = new SelectIcon(_content, IconHeros.Hulk_Status);
                    HulkStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = HulkStatus;
                }
                else if (HeroSelect[1].Get_Name() == "Captain_Icon")
                {
                    var CaptainStatus = new SelectIcon(_content, IconHeros.Captain_Status);
                    CaptainStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CaptainStatus;
                }
                else if (HeroSelect[1].Get_Name() == "X-23_Icon")
                {
                    var X23Status = new SelectIcon(_content, IconHeros.X_23_Status);
                    X23Status.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = X23Status;
                }
                else if (HeroSelect[1].Get_Name() == "Cable_Icon")
                {
                    var CableStatus = new SelectIcon(_content, IconHeros.Cable_Status);
                    CableStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CableStatus;
                }
            }
            else if (((SelectIcon)sender).Get_Name() == HeroSelect[2].Get_Name())
            {
                if (HeroSelect[2].Get_Name() == "Deadpool_Icon")
                {
                    var DeadpoolStatus = new SelectIcon(_content, IconHeros.Deadpool_Status);
                    DeadpoolStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = DeadpoolStatus;
                }
                else if (HeroSelect[2].Get_Name() == "Ant-Man_Icon")
                {
                    var AntManStatus = new SelectIcon(_content, IconHeros.Ant_Man_Status);
                    AntManStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = AntManStatus;
                }
                else if (HeroSelect[2].Get_Name() == "Hulk_Icon")
                {
                    var HulkStatus = new SelectIcon(_content, IconHeros.Hulk_Status);
                    HulkStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = HulkStatus;
                }
                else if (HeroSelect[2].Get_Name() == "Captain_Icon")
                {
                    var CaptainStatus = new SelectIcon(_content, IconHeros.Captain_Status);
                    CaptainStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CaptainStatus;
                }
                else if (HeroSelect[2].Get_Name() == "X-23_Icon")
                {
                    var X23Status = new SelectIcon(_content, IconHeros.X_23_Status);
                    X23Status.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = X23Status;
                }
                else if (HeroSelect[2].Get_Name() == "Cable_Icon")
                {
                    var CableStatus = new SelectIcon(_content, IconHeros.Cable_Status);
                    CableStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CableStatus;
                }
            }
            else if (((SelectIcon)sender).Get_Name() == HeroSelect[3].Get_Name())
            {
                if (HeroSelect[3].Get_Name() == "Mon-Deadpool")
                {
                    var DeadpoolStatus = new SelectIcon(_content, IconHeros.Deadpool_Status);
                    DeadpoolStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = DeadpoolStatus;
                }
                else if (HeroSelect[3].Get_Name() == "Mon-Ant-Man")
                {
                    var AntManStatus = new SelectIcon(_content, IconHeros.Ant_Man_Status);
                    AntManStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = AntManStatus;
                }
                else if (HeroSelect[3].Get_Name() == "Mon-Hulk")
                {
                    var HulkStatus = new SelectIcon(_content, IconHeros.Hulk_Status);
                    HulkStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = HulkStatus;
                }
                else if (HeroSelect[3].Get_Name() == "Mon-Captain")
                {
                    var CaptainStatus = new SelectIcon(_content, IconHeros.Captain_Status);
                    CaptainStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CaptainStatus;
                }
                else if (HeroSelect[3].Get_Name() == "Mon-X-23")
                {
                    var X23Status = new SelectIcon(_content, IconHeros.X_23_Status);
                    X23Status.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = X23Status;
                }
                else if (HeroSelect[3].Get_Name() == "Mon-Cable")
                {
                    var CableStatus = new SelectIcon(_content, IconHeros.Cable_Status);
                    CableStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CableStatus;
                }
            }
            else if (((SelectIcon)sender).Get_Name() == HeroSelect[4].Get_Name())
            {
                if (HeroSelect[4].Get_Name() == "Mon-Deadpool")
                {
                    var DeadpoolStatus = new SelectIcon(_content, IconHeros.Deadpool_Status);
                    DeadpoolStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = DeadpoolStatus;
                }
                else if (HeroSelect[4].Get_Name() == "Mon-Ant-Man")
                {
                    var AntManStatus = new SelectIcon(_content, IconHeros.Ant_Man_Status);
                    AntManStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = AntManStatus;
                }
                else if (HeroSelect[4].Get_Name() == "Mon-Hulk")
                {
                    var HulkStatus = new SelectIcon(_content, IconHeros.Hulk_Status);
                    HulkStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = HulkStatus;
                }
                else if (HeroSelect[4].Get_Name() == "Mon-Captain")
                {
                    var CaptainStatus = new SelectIcon(_content, IconHeros.Captain_Status);
                    CaptainStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CaptainStatus;
                }
                else if (HeroSelect[4].Get_Name() == "Mon-X-23")
                {
                    var X23Status = new SelectIcon(_content, IconHeros.X_23_Status);
                    X23Status.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = X23Status;
                }
                else if (HeroSelect[4].Get_Name() == "Mon-Cable")
                {
                    var CableStatus = new SelectIcon(_content, IconHeros.Cable_Status);
                    CableStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CableStatus;
                }
            }
            else if (((SelectIcon)sender).Get_Name() == HeroSelect[5].Get_Name())
            {
                if (HeroSelect[5].Get_Name() == "Mon-Deadpool")
                {
                    var DeadpoolStatus = new SelectIcon(_content, IconHeros.Deadpool_Status);
                    DeadpoolStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = DeadpoolStatus;
                }
                else if (HeroSelect[5].Get_Name() == "Mon-Ant-Man")
                {
                    var AntManStatus = new SelectIcon(_content, IconHeros.Ant_Man_Status);
                    AntManStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = AntManStatus;
                }
                else if (HeroSelect[5].Get_Name() == "Mon-Hulk")
                {
                    var HulkStatus = new SelectIcon(_content, IconHeros.Hulk_Status);
                    HulkStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = HulkStatus;
                }
                else if (HeroSelect[5].Get_Name() == "Mon-Captain")
                {
                    var CaptainStatus = new SelectIcon(_content, IconHeros.Captain_Status);
                    CaptainStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CaptainStatus;
                }
                else if (HeroSelect[5].Get_Name() == "Mon-X-23")
                {
                    var X23Status = new SelectIcon(_content, IconHeros.X_23_Status);
                    X23Status.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = X23Status;
                }
                else if (HeroSelect[5].Get_Name() == "Mon-Cable")
                {
                    var CableStatus = new SelectIcon(_content, IconHeros.Cable_Status);
                    CableStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CableStatus;
                }
            }
        }

        private void Card_was_Clicked(object sender, EventArgs e)
        {
            numSelect = numSelect % 3;

            if(numSelect == 0)
            {
                HeroSelect[1].Set_IsFocusIcon(true);
                HeroSelect[0].Set_IsFocusIcon(false);
                HeroSelect[2].Set_IsFocusIcon(false);
            }
            else if(numSelect == 1)
            {
                HeroSelect[2].Set_IsFocusIcon(true);
                HeroSelect[0].Set_IsFocusIcon(false);
                HeroSelect[1].Set_IsFocusIcon(false);

            }
            else if(numSelect == 2)
            {
                HeroSelect[0].Set_IsFocusIcon(true);
                HeroSelect[1].Set_IsFocusIcon(false);
                HeroSelect[2].Set_IsFocusIcon(false);
            }
            switch (((SelectCard)sender).Get_Name())
            {
                case IconHeros.Deadpool_Card:
                    {
                        if (numSelect == 0)
                        {
                            var btnIconDeadpool = new SelectIcon(_content, IconHeros.Deadpool_Icon);
                            btnIconDeadpool.Position = new Vector2(Xposition[0], Yposition[0]);
                            HeroSelect[numSelect] = btnIconDeadpool;
                            btnIconDeadpool.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect == 1)
                        {
                            var btnIconDeadpool = new SelectIcon(_content, IconHeros.Deadpool_Icon);
                            btnIconDeadpool.Position = new Vector2(Xposition[1], Yposition[1]);
                            HeroSelect[numSelect] = btnIconDeadpool;
                            btnIconDeadpool.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect == 2)
                        {
                            var btnIconDeadpool = new SelectIcon(_content, IconHeros.Deadpool_Icon);
                            btnIconDeadpool.Position = new Vector2(Xposition[2], Yposition[2]);
                            HeroSelect[numSelect] = btnIconDeadpool;
                            btnIconDeadpool.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        break;
                    }
                case IconHeros.AntMan_Card:
                    {
                        if (numSelect == 0)
                        {
                            var btnIconAntMan = new SelectIcon(_content, IconHeros.AntMan_Icon);
                            btnIconAntMan.Position = new Vector2(Xposition[0], Yposition[0]);
                            HeroSelect[numSelect] = btnIconAntMan;
                            btnIconAntMan.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect == 1)
                        {
                            var btnIconAntMan = new SelectIcon(_content, IconHeros.AntMan_Icon);
                            btnIconAntMan.Position = new Vector2(Xposition[1], Yposition[1]);
                            HeroSelect[numSelect] = btnIconAntMan;
                            btnIconAntMan.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect == 2)
                        {
                            var btnIconAntMan = new SelectIcon(_content, IconHeros.AntMan_Icon);
                            btnIconAntMan.Position = new Vector2(Xposition[2], Yposition[2]);
                            HeroSelect[numSelect] = btnIconAntMan;
                            btnIconAntMan.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        break;
                    }
                case IconHeros.Hulk_Card:
                    {
                        if (numSelect == 0)
                        {
                            var btnIconHulk = new SelectIcon(_content, IconHeros.Hulk_Icon);
                            btnIconHulk.Position = new Vector2(Xposition[0], Yposition[0]);
                            HeroSelect[numSelect] = btnIconHulk;
                            btnIconHulk.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect == 1)
                        {
                            var btnIconHulk = new SelectIcon(_content, IconHeros.Hulk_Icon);
                            btnIconHulk.Position = new Vector2(Xposition[1], Yposition[1]);
                            HeroSelect[numSelect] = btnIconHulk;
                            btnIconHulk.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect == 2)
                        {
                            var btnIconHulk = new SelectIcon(_content, IconHeros.Hulk_Icon);
                            btnIconHulk.Position = new Vector2(Xposition[2], Yposition[2]);
                            HeroSelect[numSelect] = btnIconHulk;
                            btnIconHulk.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        break;
                    }
                case IconHeros.Captain_Card:
                    {
                        if (numSelect == 0)
                        {
                            var btnIconCaptain = new SelectIcon(_content, IconHeros.Captain_Icon);
                            btnIconCaptain.Position = new Vector2(Xposition[0], Yposition[0]);
                            HeroSelect[numSelect] = btnIconCaptain;
                            btnIconCaptain.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect == 1)
                        {
                            var btnIconCaptain = new SelectIcon(_content, IconHeros.Captain_Icon);
                            btnIconCaptain.Position = new Vector2(Xposition[1], Yposition[1]);
                            HeroSelect[numSelect] = btnIconCaptain;
                            btnIconCaptain.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect == 2)
                        {
                            var btnIconCaptain = new SelectIcon(_content, IconHeros.Captain_Icon);
                            btnIconCaptain.Position = new Vector2(Xposition[2], Yposition[2]);
                            HeroSelect[numSelect] = btnIconCaptain;
                            btnIconCaptain.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        break;
                    }
                case IconHeros.X23_Card:
                    {
                        if (numSelect == 0)
                        {
                            var btnIconX23 = new SelectIcon(_content, IconHeros.X23_Icon);
                            btnIconX23.Position = new Vector2(Xposition[0], Yposition[0]);
                            HeroSelect[numSelect] = btnIconX23;
                            btnIconX23.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect == 1)
                        {
                            var btnIconX23 = new SelectIcon(_content, IconHeros.X23_Icon);
                            btnIconX23.Position = new Vector2(Xposition[1], Yposition[1]);
                            HeroSelect[numSelect] = btnIconX23;
                            btnIconX23.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect == 2)
                        {
                            var btnIconX23 = new SelectIcon(_content, IconHeros.X23_Icon);
                            btnIconX23.Position = new Vector2(Xposition[2], Yposition[2]);
                            HeroSelect[numSelect] = btnIconX23;
                            btnIconX23.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        break;
                    }
                case IconHeros.Cable_Card:
                    {
                        if (numSelect == 0)
                        {
                            var btnIconCable = new SelectIcon(_content, IconHeros.Cable_Icon);
                            btnIconCable.Position = new Vector2(Xposition[0], Yposition[0]);
                            HeroSelect[numSelect] = btnIconCable;
                            btnIconCable.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect == 1)
                        {
                            var btnIconCable = new SelectIcon(_content, IconHeros.Cable_Icon);
                            btnIconCable.Position = new Vector2(Xposition[1], Yposition[1]);
                            HeroSelect[numSelect] = btnIconCable;
                            btnIconCable.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect == 2)
                        {
                            var btnIconCable = new SelectIcon(_content, IconHeros.Cable_Icon);
                            btnIconCable.Position = new Vector2(Xposition[2], Yposition[2]);
                            HeroSelect[numSelect] = btnIconCable;
                            btnIconCable.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        break;
                    }
            }
        }

        public void Notify(Calculator engine)
        {

        }

        public override void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;


            foreach (var btnCard in cards)
                btnCard.Update(gameTime);

            foreach (var IconHeros in HeroSelect)
                IconHeros.Update(gameTime);

            foreach (var Button in Button)
                Button.Update(gameTime);
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            Select_background.Draw(spriteBatch);
            Stetusbar.Draw(spriteBatch);

            foreach (var btnCard in cards)
                btnCard.Draw(spriteBatch);

            foreach (var btnIcon in IconBackground)
                btnIcon.Draw(spriteBatch);

            foreach (var HeroSelected1 in HeroSelect)
                HeroSelected1.Draw(spriteBatch);

            foreach (var HeroStatused in HerosStatus)
                HeroStatused.Draw(spriteBatch);

            foreach (var Button in Button)
                Button.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }
    }
}