class King : Piece
{
    private bool _underCheck { get; set; } = false;
    public King(Color color, PositionOnBoard positionOnBoard) : base(color, positionOnBoard) { }
    public bool UnderCheck => _underCheck;
    public override void UpdateAvaliableMoves()
    {
        List<PositionOnBoard> positionsOnBoards = new List<PositionOnBoard>();
        List<PositionOnBoard> enemyPossibleMoves = new List<PositionOnBoard>();
        positionsOnBoards.Add(new PositionOnBoard(PositionOnBoard.PositionX + 1, PositionOnBoard.PositionY + 1));
        positionsOnBoards.Add(new PositionOnBoard(PositionOnBoard.PositionX + 1, PositionOnBoard.PositionY - 1));
        positionsOnBoards.Add(new PositionOnBoard(PositionOnBoard.PositionX + 1, PositionOnBoard.PositionY));
        positionsOnBoards.Add(new PositionOnBoard(PositionOnBoard.PositionX, PositionOnBoard.PositionY + 1));
        positionsOnBoards.Add(new PositionOnBoard(PositionOnBoard.PositionX, PositionOnBoard.PositionY - 1));
        positionsOnBoards.Add(new PositionOnBoard(PositionOnBoard.PositionX - 1, PositionOnBoard.PositionY + 1));
        positionsOnBoards.Add(new PositionOnBoard(PositionOnBoard.PositionX - 1, PositionOnBoard.PositionY - 1));
        positionsOnBoards.Add(new PositionOnBoard(PositionOnBoard.PositionX - 1, PositionOnBoard.PositionY));
        for (int i = 0; i < Board.LengthX; i++)
        {
            for (int j = 0; j < Board.LengthY; j++)
            {
                if (Board.Grid[i, j] != null && Board.Grid[i, j].PieceColor != PieceColor)
                {
                    enemyPossibleMoves.AddRange(Board.Grid[i, j].AvaliableMoves);
                }
            }
        }
        if (enemyPossibleMoves.Contains(PositionOnBoard))
            _underCheck = true;
        else
            _underCheck = false;
        foreach (var item in positionsOnBoards)
        {
            if (item.PositionX >= 0 && item.PositionX <= Board.LengthX &&
             item.PositionY >= 0 && item.PositionY <= Board.LengthY && !enemyPossibleMoves.Contains(item))
                AvaliableMoves.Add(item);
        }
    }
}