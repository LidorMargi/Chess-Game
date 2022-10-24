using System;
using System.Collections.Generic;
using System.Drawing;

//Lidor Margi - 205976905

namespace ChessGame.backend
{
    [Serializable]
    public class Pawn : Piece
    {

        public Pawn(int x, int y, bool player) : base(x, y, player) 
        {
            if (this.player)
                icon = "♙";
            else
                icon = "♟";
        }
        public override bool isValidMove(Piece[,] mat, Point from, Point to)
        {
            if (base.isValidMove(mat, from, to))
            {
                if (this.player && from.Y == 6)
                    if (from.Y > to.Y && from.Y - to.Y <= 2 && from.X == to.X && mat[to.X, to.Y] == null) return true;
                if (!this.player && from.Y == 1)
                    if (from.Y < to.Y && to.Y - from.Y <= 2 && from.X == to.X && mat[to.X, to.Y] == null) return true;
                if (this.player)
                    if (from.Y > to.Y && from.Y - to.Y == 1 && from.X == to.X && mat[to.X, to.Y] == null) return true;
                if (!this.player)
                    if (from.Y < to.Y && to.Y - from.Y == 1 && from.X == to.X && mat[to.X, to.Y] == null) return true;
                return isEating(mat, from, to);
            }
            return false;
        }

        public bool isEating(Piece[,] mat, Point from, Point to)
        {
            if (mat[to.X, to.Y] != null && mat[from.X, from.Y].player != mat[to.X, to.Y].player)
            {
                if (((from.Y + 1 == to.Y && mat[to.X, to.Y].player) || (!mat[to.X, to.Y].player && from.Y - 1 == to.Y)) && (from.X + 1 == to.X || from.X - 1 == to.X))
                    return true;
            }
            return false;
        }

        public override bool isPieceChange(Point loc)
        {
            if ((this.player && loc.Y == 0) || (!this.player && loc.Y == 7))
                return true;
            return false;
        }
    }
}
