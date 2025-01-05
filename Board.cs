static class Board
{
    public static Color RightForMove = Color.White;
    private static readonly int lengthX = 8;
    private static readonly int lengthY = 8;
    public static Piece?[,] Grid { get; set; } = new Piece[LengthX, LengthY];
    public static int LengthX => lengthX - 1;
    public static int LengthY => lengthY - 1;
    public static Piece? LastMovedPiece;
    public static void UpdateBoard()
    {
        Piece?[,] oldGrid = Grid;
        Piece?[,] newGrid = new Piece[LengthX, LengthY];
        for (int i = 0; i <= LengthX; i++)
            for (int g = 0; g <= LengthY; g++)
            {
                Piece? piece = oldGrid[i, g];
                if (piece != null)
                {
                    newGrid[piece.PositionOnBoard.PositionX, piece.PositionOnBoard.PositionY] = piece;
                }
            }
        Grid = newGrid;
    }
}
