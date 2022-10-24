using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

//Lidor Margi - 205976905

namespace ChessGame.backend
{

	[Serializable]
	public class Board
	{

		public int SIZE = 8; //size of board
		public Piece[,] mat; //base matrix that the game is going to run by
		public List<Point> avMoves;
		static int turn { get; set; } //number of turns

		#region Constructor
		public Board()
		{
			mat = new Piece[SIZE, SIZE];
			turn = 1;
			cleanBoard(mat);
			newBoard(mat);
		}
		#endregion

		#region Opening Board
		//create an empty board
		void cleanBoard(Piece[,] mat)
		{
			for (int i = 0; i < 8; i++)
				for (int j = 0; j < 8; j++)
					mat[i, j] = null;
		}

		//create a new matrix with pieces at starting position
		void newBoard(Piece[,] mat)
		{
			mat[0, 0] = new Rook(0, 0, false);
			mat[1, 0] = new Knight(1, 0, false);
			mat[2, 0] = new Bishop(2, 0, false);
			mat[3, 0] = new Queen(3, 0, false);
			mat[4, 0] = new King(4, 0, false);
			mat[5, 0] = new Bishop(5, 0, false);
			mat[6, 0] = new Knight(6, 0, false);
			mat[7, 0] = new Rook(7, 0, false);
			mat[0, 7] = new Rook(0, 7, true);
			mat[1, 7] = new Knight(1, 7, true);
			mat[2, 7] = new Bishop(2, 7, true);
			mat[3, 7] = new Queen(3, 7, true);
			mat[4, 7] = new King(4, 7, true);
			mat[5, 7] = new Bishop(5, 7, true);
			mat[6, 7] = new Knight(6, 7, true);
			mat[7, 7] = new Rook(7, 7, true);
			for (int i = 0; i < 8; i++)
			{
				mat[i, 6] = new Pawn(i, 6, true);
				mat[i, 1] = new Pawn(i, 1, false);
			}
		}

		public string getTurn()
		{
			if (Board.turn % 2 == 0)
				return "Black's Turn";
			else
				return "White's Turn";
		}

		#endregion

		#region Functions for chess rules
		public bool movePiece(Point from, Point to)
		{
			Piece mover = this.mat[from.X, from.Y];
			Piece temp = this.mat[to.X, to.Y];
			if (mover != null && (Board.turn % 2 == 1 && !mover.player) || (Board.turn % 2 == 0 && mover.player)) return false;
			//mover.isValidMove(this.mat, from, to, this.avMoves);
			//if (avMoves.Contains(to))
			//{

			//	mover.location = to;
			//	this.mat[to.X, to.Y] = mover;
			//	this.mat[from.X, from.Y] = null;
			//	if (checkChess(mover.player))
			//	{
			//		this.mat[to.X, to.Y] = temp;
			//		mover.location = from;
			//		this.mat[from.X, from.Y] = mover;
			//		MessageBox.Show("King is threatend", "Illegal Move");
			//		return false;
			//	}
			//	else
			//	{
			//		if (mover.isPieceChange(to))
			//		{
			//			Form1.ps = new pieceSelect(mover.player);
			//			Form1.ps.ShowDialog();
			//			Form1.ps.newPiece.location = to;
			//			this.mat[to.X, to.Y] = Form1.ps.newPiece;
			//		}
			//		//this.mat[to.X, to.Y].location = to;
			//		turn++;
			//		return true;
			//	}
			//}
			//this.avMoves.Clear();
			//return false;
			if (mover != null && mover.isValidMove(this.mat, from, to))
			{
				mover.location = to;
				this.mat[to.X, to.Y] = mover;
				this.mat[from.X, from.Y] = null;
				if (checkChess(mover.player))
				{
					this.mat[to.X, to.Y] = temp;
					mover.location = from;
					this.mat[from.X, from.Y] = mover;
					MessageBox.Show("King is threatend", "Illegal Move");
					return false;
				}
				else
				{
					if (mover.isPieceChange(to))
					{
						Form1.ps = new pieceSelect(mover.player);
						Form1.ps.ShowDialog();
						Form1.ps.newPiece.location = to;
						this.mat[to.X, to.Y] = Form1.ps.newPiece;
					}
					//this.mat[to.X, to.Y].location = to;
					turn++;
					return true;
				}
			}
			return false;
		}

		public bool newMovePiece(Point from, Point to)
		{



			return false;
		}

		
		Point findKing(bool p)
		{
			Point loc = new Point(0,0);
			for (int i = 0; i < 8; i++)
				for(int j = 0; j < 8; j++)
					if (this.mat[i, j] != null && mat[i, j].isKing() && this.mat[i, j].player == p)
					{
						loc = mat[i, j].location;
						return loc;
					}
			return loc;
		}

		bool checkChess(bool player)
		{
			Point loc = findKing(player);
			for (int i = 0; i < 8; i++) 
				for (int j = 0; j < 8; j++)
					if (this.mat[i,j] != null && this.mat[i,j].player != player)
					{
						//Point temp = new Point(i, j);
						if (this.mat[i, j].isValidMove(this.mat, new Point(i, j), loc))
							return true;
					}
			return false;
		}
		#endregion
	}
}
