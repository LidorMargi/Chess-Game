using System;
using System.Collections.Generic;
using System.Drawing;

//Lidor Margi - 205976905

namespace ChessGame.backend
{
    [Serializable]
    public class Queen : Piece
    {
        public Queen(bool player) : base(player)
        {
            if (this.player)
                icon = "♕";
            else
                icon = "♛";
        }

        public Queen(int x, int y, bool player) : base(x, y, player) 
        {
            if (this.player)
                icon = "♕";
            else
                icon = "♛";
        }

        public override bool isValidMove(Piece[,] mat, Point from, Point to)
        {
            if (base.isValidMove(mat, from, to))
            {
                for (int i = 1; i <= distance; i++)
                {
                    if (from.X + i == to.X && from.Y + i == to.Y) return true;
                    if (from.X - i == to.X && from.Y + i == to.Y) return true;
                    if (from.X + i == to.X && from.Y - i == to.Y) return true;
                    if (from.X - i == to.X && from.Y - i == to.Y) return true;
                    if (from.X + i == to.X && from.Y == to.Y) return true;
                    if (from.X - i == to.X && from.Y == to.Y) return true;
                    if (from.X == to.X && from.Y + i == to.Y) return true;
                    if (from.X == to.X && from.Y - i == to.Y) return true;
                }
            }
            return false;
        }

    }
}
