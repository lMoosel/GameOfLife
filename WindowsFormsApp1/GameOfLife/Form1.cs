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
    public partial class Form1 : Form
    {
        int width, height;
        Cell[][] cellArray;
        int cellsAlive = 0;
        //Form2 form2 = new Form2(40, 93);

        public Form1()
        {
            InitializeComponent();
            InitalizeArrays();
            tmrUpdate.Start();
            tmrReset.Start();
        }

        public void InitalizeArrays()
        {
            Random gen = new Random();
            width = Int32.Parse(txtWidth.Text);
            height = Int32.Parse(txtHeight.Text);
            //form2.Visible = true;
          

            cellArray = new Cell[width][];
            for (int i = 0; i < width; i++)
            {
                cellArray[i] = new Cell[height];
            }
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {

                    cellArray[x][y] = new Cell(gen.Next(0, 10));
                }
            }
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {

        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            cellsAlive = 0;
            string gridString = "";
            

             for (int x = 0; x < width; x++)
             {
                 for (int y = 0; y < height; y++)
                 {
                     if (cellArray[x][y].getisAlive())
                     {
                        gridString = gridString + " - ";
                     }
                     else
                     {
                        gridString = gridString + "   ";
                     }

                 }
                gridString = gridString + "\n";
             }

             for (int i = 0; i <width-1; i++)
            {
                for (int j = 0; j<height-1; j++)
                cellsAlive += Convert.ToInt32(cellArray[i][j].getisAlive());
            }
            label3.Text = gridString;
            lblSum.Text = cellsAlive.ToString();
            //form2.updateLabel();
            checkActives();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitalizeArrays();
        }

        public void checkActives()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (cellArray[x][y].getisAlive())
                    {
                        try
                        {
                            cellArray[x - 1][y - 1].activeNeighbors += 1;

                        }
                        catch { }
                        try
                        {
                            cellArray[x][y - 1].activeNeighbors += 1;
                        }
                        catch { }
                        try
                        {
                            cellArray[x + 1][y - 1].activeNeighbors += 1;
                        }
                        catch { }
                        try
                        {
                            cellArray[x - 1][y].activeNeighbors += 1;
                        }
                        catch { }
                        try
                        {
                            cellArray[x + 1][y].activeNeighbors += 1;
                        }
                        catch { }
                        try
                        {
                            cellArray[x - 1][y + 1].activeNeighbors += 1;
                        }
                        catch { }
                        try
                        {
                            cellArray[x][y + 1].activeNeighbors += 1;
                        }
                        catch { }
                        try
                        {
                            cellArray[x + 1][y + 1].activeNeighbors += 1;
                        }
                        catch { }
                        //form2.addCount(x, y);
                    }

                }
            }
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cellArray[x][y].setState();
                }
            }
        }

        
        private void tmrReset_Tick(object sender, EventArgs e)
        {

            if (cellsAlive <= 200)
                shakeItUp();
                
        }

        public void shakeItUp()
        {
            Random gen = new Random();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (gen.Next(0, 15) == 1)
                    {
                        cellArray[x][y].setisAlive(true);
                    }
                }
            }
        }
        public class Cell
        {
            bool isAlive;
            public int activeNeighbors;
            public Cell(int num)
            {
                if (num == 1)
                {
                    isAlive = true;
                }
                
            }

            public void setState()
            {
                if (activeNeighbors == 3)
                {
                    isAlive = true;
                }
                else if (activeNeighbors != 2)
                {
                    isAlive = false;
                }
                activeNeighbors = 0;
            }
            public bool getisAlive()
            {
                return isAlive;
            }
            public void setisAlive(bool state)
            {
                isAlive = state;
            }


        }
    }
}