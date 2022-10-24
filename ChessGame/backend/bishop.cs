using System;
using System.Collections.Generic;
using System.Drawing;
//Lidor Margi - 205976905

namespace ChessGame.backend
{
    [Serializable]
    public class Bishop : Piece
    {
        public Bishop(bool player) : base(player)
        {
            if (this.player)
                icon = "♗";
            else
                icon = "♝";
        }
        public Bishop(int x, int y, bool player) : base(x, y, player)
        {
            if (this.player)
                icon = "♗";
            else
                icon = "♝";
        }

        //public List<Point> availableMoves(Piece[,] mat, Point from ,Point to)
        //{
        //    int i = 0;
        //    Point temp;
        //    temp = from;
        //    while(mat[temp.X,temp.Y] == null || temp==from)
        //    {
        //        avMoves.Add(temp);
        //        temp.X += 1;
        //        temp.Y += 1;
        //    }
        //    temp = from;
        //    while (mat[temp.X, temp.Y] == null || temp == from)
        //    {
        //        avMoves.Add(temp);
        //        temp.X += 1;
        //        temp.Y -= 1;
        //    }
        //    temp = from;
        //    while (mat[temp.X, temp.Y] == null || temp == from)
        //    {
        //        avMoves.Add(temp);
        //        temp.X -= 1;
        //        temp.Y -= 1;
        //    }
        //    temp = from;
        //    while (mat[temp.X, temp.Y] == null || temp == from)
        //    {
        //        avMoves.Add(temp);
        //        temp.X -= 1;
        //        temp.Y += 1;
        //    }
        //    return mat[from.X, from.Y].avMoves;
        //}

        public override bool isValidMove(Piece[,] mat, Point from, Point to)
        {
            if (base.isValidMove(mat, from, to))
            {
                for (int i = 1; i <= distance; i++)
                {
                    if (from.X + i == to.X && from.Y + i == to.Y)
                    {
                        //if (mat[from.X + i, from.Y + i] != null) continue;
                        //avMoves.Add(new Point(from.X + i, from.Y + i));
                        return true;
                    }
                    if (from.X - i == to.X && from.Y + i == to.Y)
                    {
                        //if (mat[from.X - i, from.Y + i] != null) continue;
                        //avMoves.Add(new Point(from.X + i, from.Y + i));
                        return true;
                    }
                    if (from.X + i == to.X && from.Y - i == to.Y)
                    {
                        //if (mat[from.X + i, from.Y + i] != null) continue;
                        //avMoves.Add(new Point(from.X + i, from.Y - i));
                        return true;
                    }
                    if (from.X - i == to.X && from.Y - i == to.Y)
                     
                        //if (mat[from.X - i, from.Y - i] != null) continue;
                        //avMoves.Add(new Point(from.X + i, from.Y + i));
                        return true;
                    }
                }
            return false;
            }
        }
        
    }

