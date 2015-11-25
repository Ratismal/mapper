using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mapper
{
    [Serializable]
    class TileMap
    {
        private List<Tile> tiles = new List<Tile>();
        private List<Prop> props = new List<Prop>(); 

        private int height;
        private int width;
        private Image map;

        public TileMap(int height, int width)
        {
            this.height = height;
            this.width = width;
            map = new Bitmap(width * 32, height * 32);


        }

        public void AddTile(Tile tile)
        {
           // Console.WriteLine("Checking if " + tile.x + ">" + width + " && " + tile.y + ">" + height);
            // Check if the tile is empty
            if (tile.texX == 0 && tile.texY == 0)
            {
                var matches = tiles.Where(p => p.x == tile.x && p.y == tile.y);
                List<Tile> match = matches.ToList();
                
                foreach (Tile t in match)
                {
                    tiles.Remove(t);
                }
                return;
            }

            // Check if the tile fits in the map
            if (tile.x < width && tile.y < height)
            {

                // Remove all tiles with the same coordinates
                var matches = tiles.Where(p => p.x == tile.x && p.y == tile.y);
                List<Tile> match = matches.ToList();

                foreach (Tile t in match)
                {
                    tiles.Remove(t);
                }

                // All is good, add the new tile
                tiles.Add(tile);
                //Console.WriteLine(tiles.Count());
            }

            
        }

        public void AddProp(Prop prop)
        {
            //Console.WriteLine("Checking if " + prop.x + ">" + width + " && " + prop.y + ">" + height);

            // Remove empty prop
            if (prop.texX == 0 && prop.texY == 0)
            {
                var matches = props.Where(p => p.x == prop.x && p.y == prop.y);
                List<Prop> match = matches.ToList();

                foreach (Prop t in match)
                {
                    props.Remove(t);
                }
                return;
            }

            // Check if the Prop fits in the map
            if (prop.x < width && prop.y < height)
            {
                // Remove all propss with the same coordinates
                var matches = props.Where(p => p.x == prop.x && p.y == prop.y);
                List<Prop> match = matches.ToList();

                foreach (Prop t in match)
                {
                    props.Remove(t);
                }

                // All is good, add the new Prop
                props.Add(prop);
                //Console.WriteLine(tiles.Count());
            }


        }

        public Image GetMap()
        {
            // init map
            Graphics g = Graphics.FromImage(map);
            g.Clear(Color.Purple);
            g.Dispose();

            CreateMap();
            CreateProp();
            
            return map;
        }

        public void CreateMap()
        {
            Graphics g = Graphics.FromImage(map);
            if (tiles.Count > 0)
            {
                foreach (Tile tile in tiles)
                {
                    //Console.WriteLine("Drawing stuff");
                    g.DrawImage(tile.GetImage(), new Point(tile.x * 32, tile.y * 32));
                }
            }
            g.Dispose();
        }

        public void CreateProp()
        {
            Graphics g = Graphics.FromImage(map);
            foreach (Prop prop in props)
            {
                //Console.WriteLine("Drawing stuff");
                g.DrawImage(prop.GetImage(), new Point(prop.x * 32, prop.y * 32));
            }
            g.Dispose();
        }
    }
}
