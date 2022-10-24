using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.backend
{
    [Serializable]
    public class Knight : Piece
    {
        public Knight(bool player) : base(player)
        {
            if (this.player)
                icon = "♘";
            else
                icon = "♞";
        }
        public Knight(int x, int y, bool player) : base(x, y, player)
        {
            if (this.player)
                icon = "♘";
            else
                icon = "♞";
        }
        public override bool isValidMove(Piece[,] mat, Point from, Point to)
        {
            if (base.isValidMove(mat, from, to))
            {
                if (from.X + 1 == to.X && from.Y + 2 == to.Y) return true;
                if (from.X - 1 == to.X && from.Y + 2 == to.Y) return true;
                if (from.X + 1 == to.X && from.Y - 2 == to.Y) return true;
                if (from.X - 1 == to.X && from.Y - 2 == to.Y) return true;
                if (from.X + 2 == to.X && from.Y + 1 == to.Y) return true;
                if (from.X - 2 == to.X && from.Y + 1 == to.Y) return true;
                if (from.X + 2 == to.X && from.Y - 1 == to.Y) return true;
                if (from.X - 2 == to.X && from.Y - 1 == to.Y) return true;
            }
            return false;
        }

    }
}
