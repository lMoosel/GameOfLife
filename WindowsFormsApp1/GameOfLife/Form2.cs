using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        int[][] countArray;
        int width, height;
        public Form2(int w, int h)
        {
            InitializeComponent();
            width = w;
            height = h;
            countArray = new int[width][];
            for (int i = 0; i < width; i++)
            {
                countArray[i] = new int[height];
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void addCount(int x, int y)
        {
            countArray[x][y] += 1;
        }

        public void updateLabel()
        {
            string gridString = "";


            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    
                        gridString = gridString + " " + countArray[x][y];
                    

                }
                gridString = gridString + "\n";
            }
            label1.Text = gridString;
        }
    }
}
