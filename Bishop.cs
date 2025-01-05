class Bishop : Piece
{
    public Bishop(Color color, PositionOnBoard positionOnBoard) : base(color, positionOnBoard) { }

    public override void UpdateAvaliableMoves()
    {
        for (int i = PositionOnBoard.PositionX + 1; i <= Board.LengthX; i++)
        {
            for (int g = PositionOnBoard.PositionY + 1; i <= Board.LengthY; g++)
            {
                AvaliableMoves.Add(new PositionOnBoard(i, g));
                if (Board.Grid[i, g] != null)
                    break;
            }
        }
        for (int i = PositionOnBoard.PositionX - 1; i >= 0; i--)
        {
            for (int g = PositionOnBoard.PositionY - 1; i >= 0; g--)
            {
                AvaliableMoves.Add(new PositionOnBoard(i, g));
                if (Board.Grid[i, g] != null)
                    break;
            }
        }
        for (int i = PositionOnBoard.PositionX + 1; i <= Board.LengthX; i++)
        {
            for (int g = PositionOnBoard.PositionY - 1; i >= 0; g--)
            {
                AvaliableMoves.Add(new PositionOnBoard(i, g));
                if (Board.Grid[i, g] != null)
                    break;
            }
        }
        for (int i = PositionOnBoard.PositionX - 1; i >= 0; i--)
        {
            for (int g = PositionOnBoard.PositionY + 1; i <= Board.LengthY; g++)
            {
                AvaliableMoves.Add(new PositionOnBoard(i, g));
                if (Board.Grid[i, g] != null)
                    break;
            }
        }
    }
}