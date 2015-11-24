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
    
    public partial class Mapper : Form
    {
        //Dictionary<int[], Image> tiles = new Dictionary<int[], Image>();
        Tile currentTile;
        TileMap tileMap;
        
        public Mapper()
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

                Reference.palette = new Palette(xTileCount, yTileCount, map);
                //tiles = new Image[xTileCount][];

                //tileMap = new Palette(xTileCount, yTileCount, map);

                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.Image = map;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coord = me.Location;
            //Coord p = new Coord(coord.X / 32, coord.Y / 32);
            //Console.WriteLine("Was clicked at " + p.getX() + " " + p.getY());

            try {
                //currentTile = 
                //currentTile = new Tile()
                currentTile = new Tile(coord.X / 32, coord.Y / 32);
            }
            catch (Exception ee)
            {
                
            }
            pictureBox2.Image = currentTile.getImage();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            New newForm = new New();
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                tileMap = new TileMap(newForm.height, newForm.width);
                pictureBox3.Image = tileMap.getMap();
            }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Doing stuff");
            MouseEventArgs me = (MouseEventArgs)e;
            Point coord = me.Location;
            Tile tempTile = currentTile;
            tempTile.setX(coord.X / 32);
            tempTile.setY(coord.Y / 32);
            tileMap.addTile(tempTile);
            pictureBox3.Image = tileMap.getMap();
        }
    }
}
