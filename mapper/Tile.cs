using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mapper
{
    class Tile
    {
        private int x;
        private int y;

        private int texX;
        private int texY;

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

        public Image getImage()
        {
            return Reference.palette.getTile(texX, texY);
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }
    }
}
