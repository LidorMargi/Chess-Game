using ChessGame.backend;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class pieceSelect : Form
    {
        public pieceSelect()
        {
            InitializeComponent();
            printSelect();
        }

        public pieceSelect(bool player)
        {
            InitializeComponent();
            this.player = player;
            printSelect();
        }

        List<string> piece = new List<string>();
        int index = 0;
        bool player = true;
        public Piece newPiece = null;


        private void printSelect()
        {
            if (player)
            {
                piece.Add("♕");
                piece.Add("♖");
                piece.Add("♗");
                piece.Add("♘");
            }
            else
            {
                piece.Add("♛");
                piece.Add("♜");
                piece.Add("♝");
                piece.Add("♞");
            }
            label1.Font = new Font(label1.Font.FontFamily, 60);
            label1.Text = piece[index];

        }

        private void Back_Click(object sender, EventArgs e)
        {
            index--;
            if (index < 0)
            {
                index = 3;
            }
            label1.Text = piece[index];
        }

        private void Next_Click(object sender, EventArgs e)
        {
            index++;
            if (index > piece.Count - 1)
            {
                index = 0;
            }
            label1.Text = piece[index];
        }

        public void Select_Click(object sender, EventArgs e)
        {
            switch (label1.Text)
            {
                case "♛":
                    newPiece = new Queen(false);
                    Close();
                    break;
                case "♜":
                    newPiece = new Rook(false);
                    Close();
                    break;
                case "♝":
                    newPiece = new Bishop(false);
                    Close();
                    break;
                case "♞":
                    newPiece = new Knight(false);
                    Close();
                    break;
                case "♕":
                    newPiece = new Queen(true);
                    Close();
                    break;
                case "♖":
                    newPiece = new Rook(true);
                    Close();
                    break;
                case "♗":
                    newPiece = new Bishop(true);
                    Close();
                    break;
                case "♘":
                    newPiece = new Knight(true);
                    Close();
                    break;
                default:
                    break;
            }


        }
    }
}
