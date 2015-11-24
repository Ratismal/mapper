using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace mapper
{
    class Palette
    {
        private int width;
        private int height;
        private Image[][] tiles;
        private Image map;

        public Palette(int x, int y, Image map)
        {
            this.width = x;
            this.height = y;
            this.map = map;
            init();

        }

        private void init()
        {
            tiles = new Image[width][];
            for (int i = 0; i < width; i++)
            {
                tiles[i] = new Image[height];
                for (int ii = 0; ii < height; ii++)
                {
                    //temp = new Coord(i, ii);
                    //tiles.Add(new int[2], new Bitmap(32, 32));
                    tiles[i][ii] = new Bitmap(32, 32);
                    var graphics = Graphics.FromImage(tiles[i][ii]);
                    graphics.DrawImage(map, new Rectangle(0, 0, 32, 32), new Rectangle(i * 32, ii * 32, 32, 32), GraphicsUnit.Pixel);
                    graphics.Dispose();
                }
            }
        }

        public Image getTile(int x, int y)
        {
            return tiles[x][y];
        }
    }
}
