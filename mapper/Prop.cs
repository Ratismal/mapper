using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapper
{
    [Serializable]
    class Prop
    {
        public int x { get; set; }
        public int y { get; set; }

        public int texX { get; }
        public int texY { get; }

        public Prop(int x, int y, int texX, int texY)
        {
            this.x = x;
            this.y = y;
            this.texX = texX;
            this.texY = texY;
        }

        public Prop(int texX, int texY)
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
