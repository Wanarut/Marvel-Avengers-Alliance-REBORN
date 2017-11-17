using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.Buttons
{
    class IconMap : Button
    {

        private string IconMap_name;

        public IconMap(ContentManager content, string Icon1_name)
        {
            IconMap_name = Icon1_name;
            LoadContent(content, "MapButton/" + IconMap_name);
        }

        public string Get_Name()
        {
            return IconMap_name;
        }

    }
}
