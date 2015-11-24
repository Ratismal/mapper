using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace mapper
{
    
    public partial class Form1 : Form
    {
        Dictionary<Coord, Image> tiles = new Dictionary<Coord, Image>();
        Image currentTile;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Palette|*.png";
            openFileDialog1.Title = "Select a Palette File";

            Image map;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.
                map = Bitmap.FromStream(openFileDialog1.OpenFile());

                int height = map.Height;
                int width = map.Width;

                int xTileCount = width / 32;
                int yTileCount = height / 32;

                Console.WriteLine(xTileCount + " " + yTileCount);

                tiles.Clear();
                Coord temp;

                for (int i = 0; i < xTileCount; i++)
                {
                    for (int ii = 0; ii < yTileCount; ii++)
                    {
                        temp = new Coord(i, ii);
                        tiles.Add(temp, new Bitmap(32, 32));
                        var graphics = Graphics.FromImage(tiles[temp]);
                        graphics.DrawImage(map, new Rectangle(0, 0, 32, 32), new Rectangle(i * 32, ii * 32, 32, 32), GraphicsUnit.Pixel);
                        graphics.Dispose();
                    }
                }

                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.Image = map;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coord = me.Location;
            Coord p = new Coord(coord.X / 32, coord.Y / 32);
            Console.WriteLine("Was clicked at " + p.getX() + " " + p.getY());

            try {
                currentTile = tiles[new Coord(coord.X / 32, coord.Y / 32)];
            }
            catch (Exception ee)
            {
                
            }

            pictureBox2.Image = currentTile;

        }
    }
}
