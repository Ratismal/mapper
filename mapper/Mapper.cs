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

        public bool tileMode = true;
        
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
                if (tileMap != null)
                {
                    pictureBox3.Image = tileMap.GetMap();
                }
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
            pictureBox2.Image = currentTile.GetImage();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            New newForm = new New();
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                tileMap = new TileMap(newForm.height, newForm.width);
                pictureBox3.Image = tileMap.GetMap();
            }
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Map|*.map";
            saveFileDialog1.Title = "Save a map";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(fs, tileMap);
                fs.Close();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Map|*.map";
            openFileDialog1.Title = "Select a Map File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fs =
                    (System.IO.FileStream)openFileDialog1.OpenFile();
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                tileMap = (TileMap)bformatter.Deserialize(fs);
                fs.Close();
                pictureBox3.Image = tileMap.GetMap();

            }
        }

        bool _mousePressed;
        private void PictureBox3MouseDown(object sender, MouseEventArgs e)
        {
            _mousePressed = true;
            AddSomething(e);
        }

        private void PictureBox3MouseMove(object sender, MouseEventArgs e)
        {
            if (_mousePressed)
            {
                AddSomething(e);

            }
        }

        private void PictureBox3MouseUp(object sender, MouseEventArgs e)
        {
            _mousePressed = false;
        }

        private void AddSomething(MouseEventArgs e)
        {
            var me = (MouseEventArgs)e;
            var coord = me.Location;
            if (tileMode)
            {
                var tempTile = new Tile(currentTile.texX, currentTile.texY);
                tempTile.x = coord.X/32;
                tempTile.y = coord.Y/32;
                tileMap.AddTile(tempTile);
            }
            else
            {
                var tempProp = new Prop(currentTile.texX, currentTile.texY);
                tempProp.x = coord.X / 32;
                tempProp.y = coord.Y / 32;
                tileMap.AddProp(tempProp);
            }
            pictureBox3.Image = tileMap.GetMap();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (!tileMode)
            {
                tileMode = true;
                toolStripButton5.BackColor = SystemColors.ControlDark;
                toolStripButton6.BackColor = SystemColors.Control;
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (tileMode)
            {
                tileMode = false;
                toolStripButton5.BackColor = SystemColors.Control;
                toolStripButton6.BackColor = SystemColors.ControlDark;
            }
        }
    }

    
}
