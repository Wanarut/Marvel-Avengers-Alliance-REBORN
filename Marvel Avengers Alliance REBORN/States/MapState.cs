using Marvel_Avengers_Alliance_REBORN.Buttons;
using Marvel_Avengers_Alliance_REBORN.Components;
using Marvel_Avengers_Alliance_REBORN.DATA;
using Marvel_Avengers_Alliance_REBORN.DATA.Heroes;
using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.States
{
    class MapState : MAAGame
    {
        #region Game Fields
        private Background map_background;
        private IconMap button_map0;
        private IconMap button_map1;
        private IconMap button_map2;
        private IconMap button_map3;
        private IconMap button_map4;
        private IconMap button_map5;
        /*private IconMap1 NextBar;
        private IconMap1 IconBar;*/
        protected Viewport viewport;
        private List<IconMap> Icon_map;
        private List<IconMap> enemieslist;
        private List<Character> enemies;
        #endregion

        public MapState(/*List<Character> avatar*/)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 15.0); // Frame rate is 15 fps.
        }

        public MapState(MAAGame game, GraphicsDeviceManager graphicsDevice, ContentManager content)
        {
            _game = game;
            graphics = graphicsDevice;
            Content = content;

            IsMouseVisible = true;
            MediaPlayer.IsRepeating = true;

            TargetElapsedTime = TimeSpan.FromSeconds(1 / 15.0); // Frame rate is 15 fps.
        }
        protected override void Initialize()
        {
            enemies = new List<Character>();
            Icon_map = new List<IconMap>();
            map_background = new Background();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            enemieslist = new List<IconMap>();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            viewport = graphics.GraphicsDevice.Viewport;
            map_background.LoadContent(Content, "Map_Background/" + BG.BG_0000);
            button_map0 = new IconMap(Content,MapButton.MB_000);
            button_map1 = new IconMap(Content,MapButton.MB_001);
            button_map2 = new IconMap(Content,MapButton.MB_002);
            button_map3 = new IconMap(Content,MapButton.MB_003);
            button_map4 = new IconMap(Content,MapButton.MB_004);
            button_map5 = new IconMap(Content,MapButton.MB_005);
           
            button_map0.Position = new Vector2(265,155 - button_map0.Get_Height());
            Icon_map.Add(button_map0);
            button_map0.Click += Menu_was_Clicked;

            button_map1.Position = new Vector2(145, 280 - button_map1.Get_Height());
            Icon_map.Add(button_map1);
            button_map1.Click += Menu_was_Clicked;

            button_map2.Position = new Vector2(230, 440 - button_map2.Get_Height());
            Icon_map.Add(button_map2);
            button_map2.Click += Menu_was_Clicked;

            button_map3.Position = new Vector2(400, 380 - button_map3.Get_Height());
            Icon_map.Add(button_map3);
            button_map3.Click += Menu_was_Clicked;

            button_map4.Position = new Vector2(550, 280 - button_map4.Get_Height());
            Icon_map.Add(button_map4);
            button_map4.Click += Menu_was_Clicked;

            button_map5.Position = new Vector2(640, 470 - button_map5.Get_Height());
            Icon_map.Add(button_map5);
            button_map5.Click += Menu_was_Clicked;



            //base.LoadContent();
        }
        private void Menu_was_Clicked(object sender, EventArgs e)
        {
            switch (((IconMap)sender).Get_Name())
            {
                case MapButton.MB_000:
                    {
                        enemieslist.Clear();
                        enemies.Clear();
                        var NextBar =new IconMap(Content,MapButton.IC_007);
                        NextBar.Position = new Vector2(650, 601 - NextBar.Get_Height());
                        NextBar.Click += Menu_was_Clicked;
                        enemieslist.Add(NextBar);
                        var IconBar = new IconMap(Content, MapButton.IC_000);
                        IconBar.Position = new Vector2(205, 600 - IconBar.Get_Height());
                        enemieslist.Add(IconBar);
                        var Ant = new IconMap(Content, MapButton.IC_001);
                        Ant.Position = new Vector2((map_background.Get_Width() / 2) - (Ant.Get_Width() / 2), 600-Ant.Get_Height());
                        enemieslist.Add(Ant);
                        var Ant1 = new IconMap(Content, MapButton.IC_001);
                        Ant1.Position = new Vector2((map_background.Get_Width() / 2) - ((Ant1.Get_Width() / 2)*(7/2)+10), 600 - Ant1.Get_Height());
                        enemieslist.Add(Ant1);
                        var Ant2 = new IconMap(Content, MapButton.IC_001);
                        Ant2.Position = new Vector2((map_background.Get_Width() / 2) + ((Ant2.Get_Width() / 2)+10), 600 - Ant2.Get_Height());
                        enemieslist.Add(Ant2);
                        enemies.Add(new Ant_Man(Content));
                        enemies.Add(new Ant_Man(Content));
                        enemies.Add(new Ant_Man(Content));
                        break;
                    }
                case MapButton.MB_001:
                    {
                        enemieslist.Clear();
                        enemies.Clear();
                        var NextBar = new IconMap(Content, MapButton.IC_007);
                        NextBar.Position = new Vector2(650, 601 - NextBar.Get_Height());
                        NextBar.Click += Menu_was_Clicked;
                        enemieslist.Add(NextBar);
                        var IconBar = new IconMap(Content, MapButton.IC_000);
                        IconBar.Position = new Vector2(205, 600 - IconBar.Get_Height());
                        enemieslist.Add(IconBar);
                        var Ant = new IconMap(Content, MapButton.IC_002);
                        Ant.Position = new Vector2((map_background.Get_Width() / 2) - (Ant.Get_Width() / 2), 600 - Ant.Get_Height());
                        enemieslist.Add(Ant);
                        var Ant1 = new IconMap(Content, MapButton.IC_002);
                        Ant1.Position = new Vector2((map_background.Get_Width() / 2) - ((Ant1.Get_Width() / 2) * (7 / 2) + 10), 600 - Ant1.Get_Height());
                        enemieslist.Add(Ant1);
                        var Ant2 = new IconMap(Content, MapButton.IC_002);
                        Ant2.Position = new Vector2((map_background.Get_Width() / 2) + ((Ant2.Get_Width() / 2) + 10), 600 - Ant2.Get_Height());
                        enemieslist.Add(Ant2);
                        enemies.Add(new Captain_America(Content));
                        enemies.Add(new Captain_America(Content));
                        enemies.Add(new Captain_America(Content));


                        break;
                    }
                case MapButton.MB_002:
                    {
                        enemieslist.Clear();
                        enemies.Clear();
                        var NextBar = new IconMap(Content, MapButton.IC_007);
                        NextBar.Position = new Vector2(650, 601 - NextBar.Get_Height());
                        NextBar.Click += Menu_was_Clicked;
                        enemieslist.Add(NextBar);
                        var IconBar = new IconMap(Content, MapButton.IC_000);
                        IconBar.Position = new Vector2(205, 600 - IconBar.Get_Height());
                        enemieslist.Add(IconBar);
                        var Ant = new IconMap(Content, MapButton.IC_003);
                        Ant.Position = new Vector2((map_background.Get_Width() / 2) - (Ant.Get_Width() / 2), 600 - Ant.Get_Height());
                        enemieslist.Add(Ant);
                        var Ant1 = new IconMap(Content, MapButton.IC_003);
                        Ant1.Position = new Vector2((map_background.Get_Width() / 2) - ((Ant1.Get_Width() / 2) * (7 / 2) + 10), 600 - Ant1.Get_Height());
                        enemieslist.Add(Ant1);
                        var Ant2 = new IconMap(Content, MapButton.IC_003);
                        Ant2.Position = new Vector2((map_background.Get_Width() / 2) + ((Ant2.Get_Width() / 2) + 10), 600 - Ant2.Get_Height());
                        enemieslist.Add(Ant2);
                        enemies.Add(new Deadpool(Content));
                        enemies.Add(new Deadpool(Content));
                        enemies.Add(new Deadpool(Content));

                        break;
                    }
                case MapButton.MB_003:
                    {
                        enemieslist.Clear();
                        enemies.Clear();
                        var NextBar = new IconMap(Content, MapButton.IC_007);
                        NextBar.Position = new Vector2(650, 601 - NextBar.Get_Height());
                        NextBar.Click += Menu_was_Clicked;
                        enemieslist.Add(NextBar);
                        var IconBar = new IconMap(Content, MapButton.IC_000);
                        IconBar.Position = new Vector2(205, 600 - IconBar.Get_Height());
                        enemieslist.Add(IconBar);
                        var Ant = new IconMap(Content, MapButton.IC_005);
                        Ant.Position = new Vector2((map_background.Get_Width() / 2) - (Ant.Get_Width() / 2), 600 - Ant.Get_Height());
                        enemieslist.Add(Ant);
                        var Ant1 = new IconMap(Content, MapButton.IC_005);
                        Ant1.Position = new Vector2((map_background.Get_Width() / 2) - ((Ant1.Get_Width() / 2) * (7 / 2) + 10), 600 - Ant1.Get_Height());
                        enemieslist.Add(Ant1);
                        var Ant2 = new IconMap(Content, MapButton.IC_005);
                        Ant2.Position = new Vector2((map_background.Get_Width() / 2) + ((Ant2.Get_Width() / 2) + 10), 600 - Ant2.Get_Height());
                        enemieslist.Add(Ant2);
                        enemies.Add(new Hulk(Content));
                        enemies.Add(new Hulk(Content));
                        enemies.Add(new Hulk(Content));

                        break;
                    }
                case MapButton.MB_004:
                    {
                        enemieslist.Clear();
                        enemies.Clear();
                        var NextBar = new IconMap(Content, MapButton.IC_007);
                        NextBar.Position = new Vector2(650, 601 - NextBar.Get_Height());
                        NextBar.Click += Menu_was_Clicked;
                        enemieslist.Add(NextBar);
                        var IconBar = new IconMap(Content, MapButton.IC_000);
                        IconBar.Position = new Vector2(205, 600 - IconBar.Get_Height());
                        enemieslist.Add(IconBar);
                        var Ant = new IconMap(Content, MapButton.IC_004);
                        Ant.Position = new Vector2((map_background.Get_Width() / 2) - (Ant.Get_Width() / 2), 600 - Ant.Get_Height());
                        enemieslist.Add(Ant);
                        var Ant1 = new IconMap(Content, MapButton.IC_004);
                        Ant1.Position = new Vector2((map_background.Get_Width() / 2) - ((Ant1.Get_Width() / 2) * (7 / 2) + 10), 600 - Ant1.Get_Height());
                        enemieslist.Add(Ant1);
                        var Ant2 = new IconMap(Content, MapButton.IC_004);
                        Ant2.Position = new Vector2((map_background.Get_Width() / 2) + ((Ant2.Get_Width() / 2) + 10), 600 - Ant2.Get_Height());
                        enemieslist.Add(Ant2);
                        enemies.Add(new Cable(Content));
                        enemies.Add(new Cable(Content));
                        enemies.Add(new Cable(Content));
                        break;
                    }
                case MapButton.MB_005:
                    {
                        enemieslist.Clear();
                        enemies.Clear();
                        var NextBar = new IconMap(Content, MapButton.IC_007);
                        NextBar.Position = new Vector2(650, 601 - NextBar.Get_Height());
                        NextBar.Click += Menu_was_Clicked;
                        enemieslist.Add(NextBar);
                        var IconBar = new IconMap(Content, MapButton.IC_000);
                        IconBar.Position = new Vector2(205, 600 - IconBar.Get_Height());
                        enemieslist.Add(IconBar);
                        var Ant = new IconMap(Content, MapButton.IC_006);
                        Ant.Position = new Vector2((map_background.Get_Width() / 2) - (Ant.Get_Width() / 2), 600 - Ant.Get_Height());
                        enemieslist.Add(Ant);
                        var Ant1 = new IconMap(Content, MapButton.IC_006);
                        Ant1.Position = new Vector2((map_background.Get_Width() / 2) - ((Ant1.Get_Width() / 2) * (7 / 2) + 10), 600 - Ant1.Get_Height());
                        enemieslist.Add(Ant1);
                        var Ant2 = new IconMap(Content, MapButton.IC_006);
                        Ant2.Position = new Vector2((map_background.Get_Width() / 2) + ((Ant2.Get_Width() / 2) + 10), 600 - Ant2.Get_Height());
                        enemieslist.Add(Ant2);
                        enemies.Add(new X_23(Content));
                        enemies.Add(new X_23(Content));
                        enemies.Add(new X_23(Content));

                        break;
                    }
                case MapButton.IC_007:
                    {
                        _game.Change_State(new SelectState(this, graphics, Content, enemies));
                        break;
                    }
            }
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {

            foreach (var btn in Icon_map)
            {
                btn.Update(gameTime);
            }
            foreach (var btn in enemieslist)
            {
                btn.Update(gameTime);
            }

            //base.Update(gameTime);

        }

        public void Notify(Calculator engine)
        {

        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            map_background.Draw(spriteBatch);

            foreach (var btn in Icon_map)
            {
                btn.Draw(spriteBatch);
            }
            foreach (var btn in enemieslist)
            {
                btn.Draw(spriteBatch);
            }



            spriteBatch.End();

            //base.Draw(gameTime);
        }
    }
}
