using System;
using System.Drawing;

//Lidor Margi - 205976905

namespace ChessGame.backend
{
    [Serializable]
    public class King : Queen
    {
        public King(int x, int y, bool player) : base(x, y, player) 
        {
            this.distance = 1;
            if (this.player)
                icon = "♔";
            else
                icon = "♚";
        }

        //public override bool isValidMove(Piece[,] mat, Point from, Point to)
        //{
        //    if (base.isValidMove(mat, from, to))
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
