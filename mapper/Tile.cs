﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mapper
{
    [Serializable]
    class Tile
    {
        public int x { get; set; }
        public int y { get; set; }

        public int texX { get; }
        public int texY { get; }

        public Tile (int x, int y, int texX, int texY)
        {
            this.x = x;
            this.y = y;
            this.texX = texX;
            this.texY = texY;
        }

        public Tile (int texX, int texY)
        {
            this.texX = texX;
            this.texY = texY;
        }

        public Image GetImage()
        {
            return Reference.palette.GetTile(texX, texY);
        }

        
    }
}
