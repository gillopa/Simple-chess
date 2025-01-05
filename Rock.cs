using System.Diagnostics.CodeAnalysis;

class Rock : Piece
{
    [SetsRequiredMembers]
    public Rock(Color color, PositionOnBoard positionOnBoard) : base(color, positionOnBoard) { }

    public override void UpdateAvaliableMoves()
    {
        for (int i = PositionOnBoard.PositionX + 1; i <= Board.LengthX; i++)
        {
            AvaliableMoves.Add(new PositionOnBoard(i, PositionOnBoard.PositionY));
            if (Board.Grid[i, PositionOnBoard.PositionY] != null)
                break;
        }
        for (int i = PositionOnBoard.PositionX + 1; i >= 0; i--)
        {
            AvaliableMoves.Add(new PositionOnBoard(i, PositionOnBoard.PositionY));
            if (Board.Grid[i, PositionOnBoard.PositionY] != null)
                break;
        }
        for (int i = PositionOnBoard.PositionX + 1; i <= Board.LengthY; i++)
        {
            AvaliableMoves.Add(new PositionOnBoard(PositionOnBoard.PositionX, i));
            if (Board.Grid[PositionOnBoard.PositionX, i] != null)
                break;
        }
        for (int i = PositionOnBoard.PositionX + 1; i >= 0; i--)
        {
            AvaliableMoves.Add(new PositionOnBoard(PositionOnBoard.PositionX, i));
            if (Board.Grid[PositionOnBoard.PositionX, i] != null)
                break;
        }
    }
}