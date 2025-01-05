using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;

class PositionOnBoard
{
    public int PositionX;
    public int PositionY;
    public PositionOnBoard(int positionX, int positionY) => (PositionX, PositionY) = (positionX, positionY);
}
enum Color
{
    White,
    Black
}

abstract class Piece
{
    public Piece(Color color, PositionOnBoard positionOnBoard) =>
    (PieceColor, PositionOnBoard) = (color, positionOnBoard);
    private int _moveCunter = 0;
    public required Color PieceColor { get; init; }
    public required PositionOnBoard PositionOnBoard { get; set; }
    public List<PositionOnBoard> AvaliableMoves { get; } = new List<PositionOnBoard>();
    public bool MakeMove(PositionOnBoard positionOnBoard)
    {
        if (!AvaliableMoves.Contains(positionOnBoard))
            return false;
        if (Board.Grid[positionOnBoard.PositionX, positionOnBoard.PositionY] != null)
            Board.Grid[positionOnBoard.PositionX, positionOnBoard.PositionY] = null;
        _moveCunter++;
        AvaliableMoves.Clear();
        PositionOnBoard = positionOnBoard;
        Board.LastMovedPiece = this;
        return true;
    }
    public abstract void UpdateAvaliableMoves();

}
