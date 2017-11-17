using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.Buttons
{
    class SelectIcon : Button
    {
        #region Field
        private string Icon_name;

        #endregion

        public SelectIcon(ContentManager content, string uniform_name)
        {
            Icon_name = uniform_name;
            LoadContent(content, "Icon/" + uniform_name);
        }

        public string Get_Name()
        {
            return Icon_name;
        }

    }
}

