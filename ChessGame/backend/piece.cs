using System;
using System.Collections.Generic;
using System.Drawing;

//Lidor Margi - 205976905

namespace ChessGame.backend
{
    [Serializable]
    public class Piece
    {
        public bool player { get; set; }//Player's color (black or white)
        //protected bool canCastle; // For rooks and kings
        public Point location; //the location of the piece on the grid
        public int distance; //distance that the piece can move
        public string icon; // UTF-16 unicode icon
       // public List<Point> avMoves;

        #region Constructors

        public Piece(bool player)
        {
            this.player = player;
            this.distance = 7;
        }

        public Piece(int x, int y, bool player)
        {
            this.player = player;
            //this.canCastle = false;
            this.distance = 7;
            this.location = new Point(x, y);
        }
        #endregion

        #region Functions
        public virtual bool isValidMove(Piece[,] mat, Point from, Point to)
        {
            if (to.X < 0 || to.X > 7 || to.Y < 0 || to.Y > 7) return false;
            if (mat[to.X, to.Y] != null && this.player == mat[to.X, to.Y].player) return false;
            //if ((Board.turn % 2 == 1 && !player) || (Board.turn % 2 == 0 && player)) return false;
            return true;
        }

        public bool isKing()
        {
            if (this.icon == "♔" || this.icon == "♚")
                return true;
            return false;
        }

        public virtual bool isPieceChange(Point loc)
        {
            return false;
        }
        #endregion

    }
}
