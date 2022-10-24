using ChessGame.backend;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

//Lidor Margi - 205976905

namespace ChessGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            printGrid();
        }

        static Board myBoard = new Board();
        bool on = false;
        public static pieceSelect ps;
        Point from;
        Point to;
        public Button[,] btnGrid = new Button[myBoard.SIZE, myBoard.SIZE];

        #region Print functions

        private void printGrid()
        {
            int buttonSize = panel1.Width / myBoard.SIZE;
            panel1.Height = panel1.Width;

            for (int i = 0; i < myBoard.SIZE; i++)
            {
                for (int j = 0; j < myBoard.SIZE; j++)
                {
                    btnGrid[i, j] = new Button();
                    btnGrid[i, j].Font = new Font(btnGrid[i, j].Font.FontFamily, 25);
                    btnGrid[i, j].Height = buttonSize;
                    btnGrid[i, j].Width = buttonSize;

                    btnGrid[i, j].Click += Grid_ButtonClick;

                    panel1.Controls.Add(btnGrid[i, j]);

                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);
                    btnGrid[i, j].Tag = new Point(i, j);
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            btnGrid[i, j].BackColor = Color.OldLace;/*FromArgb(253, 245, 230);*/
                        else
                            btnGrid[i, j].BackColor = Color.OliveDrab; /*FromArgb(107, 142, 45);*/
                    }
                    else
                    {
                        if (j % 2 == 0)
                            btnGrid[i, j].BackColor = Color.OliveDrab; /*FromArgb(107, 142, 45);*/
                        else
                            btnGrid[i, j].BackColor = Color.OldLace; /*FromArgb(253, 245, 230);*/
                    }
                }
            }
            printPieces();
            label1.Text = myBoard.getTurn();
        }

        void printPieces()
        {
            for (int i = 0; i < myBoard.SIZE; i++)
            {
                for (int j = 0; j < myBoard.SIZE; j++)
                {
                    if (myBoard.mat[i, j] != null)
                        btnGrid[i, j].Text = myBoard.mat[i, j].icon;
                    else
                        btnGrid[i, j].Text = "";
                }
            }
        }
        #endregion

        #region Button Grid Clicks(chess board)
        private void Grid_ButtonClick(object sender, EventArgs e)
        {
            Button clickbtn = sender as Button;
            Point loc = (Point)clickbtn.Tag;
            if (myBoard.mat[from.X, from.Y] == null || (on && myBoard.mat[loc.X, loc.Y] != null && myBoard.mat[from.X,from.Y].player== myBoard.mat[loc.X, loc.Y].player))
            {
                from = loc;
                on = true;
            }
            else if (on)
            {
                to = loc;
                myBoard.movePiece(from, to);
                printPieces();
                label1.Text = myBoard.getTurn();
                on = false;
            }
            else
            {
                from = loc;
                on = true;
            }
        }

        #endregion
        
        #region Other Buttons Clicks
        private void button1_Click(object sender, EventArgs e)
        {
            myBoard = new Board();
            printPieces();
            label1.Text = myBoard.getTurn();

        }


        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.InitialDirectory = Directory.GetCurrentDirectory();
            sfd1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            sfd1.FilterIndex = 1;
            sfd1.RestoreDirectory = true;
            if (sfd1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(sfd1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, myBoard);
                }
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd1 = new OpenFileDialog();
            ofd1.InitialDirectory = Directory.GetCurrentDirectory();
            ofd1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            ofd1.FilterIndex = 1;
            ofd1.RestoreDirectory = true;
            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.Open(ofd1.FileName, FileMode.Open);
                var binaryFormatter = new BinaryFormatter();
                myBoard = (Board)binaryFormatter.Deserialize(stream);
                printPieces();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save before exit?", "Save Or Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                button3_Click(sender, e);
            else
                Close();
        }
        #endregion

    }
}
