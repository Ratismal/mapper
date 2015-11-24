using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mapper
{
    class TileMap
    {
        private List<Tile> tiles = new List<Tile>();

        private int height;
        private int width;
        private Image map;

        public TileMap(int height, int width)
        {
            this.height = height;
            this.width = width;
            map = new Bitmap(width * 32, height * 32);


        }

        public void addTile(Tile tile)
        {
            Console.WriteLine("Checking if " + tile.getX() + ">" + width + " && " + tile.getY() + ">" + height);
            // Check if the tile fits in the map
            if (tile.getX() < width && tile.getY() < height)
            {

                // Remove all tiles with the same coordinates
                var matches = tiles.Where(p => p.getX() == tile.getX() && p.getY() == tile.getY());
                List<Tile> match = matches.ToList<Tile>();
                foreach (Tile i in match)
                {
                    Console.WriteLine("Removing tiles");
                    tiles.Remove(i);
                }
            
                // All is good, add the new tile
                tiles.Add(tile);
            }

            
        }

        public Image getMap()
        {
            // init map
            
            Graphics g = Graphics.FromImage(map);

            g.Clear(Color.Black);
            if (tiles.Count > 0) {
               foreach (Tile tile in tiles)
               {
                    Console.WriteLine("Drawing stuff");
                    g.DrawImage(tile.getImage(), new Point(tile.getX() * 32, tile.getY() * 32));
               }
            }
            g.Dispose();
            return map;
        }
    }
}
