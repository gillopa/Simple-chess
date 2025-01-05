using System.Diagnostics.CodeAnalysis;

class Pown : Piece
{
    private int _direction;
    public int Direction => _direction;
    [SetsRequiredMembers]
    public Pown(Color color, PositionOnBoard positionOnBoard) : base(color, positionOnBoard)
    {
        if (color == Color.White)
            _direction = 1;
        else
            _direction = -1;
    }

    public override void UpdateAvaliableMoves()
    {
        PositionOnBoard frontMove = PositionOnBoard;
        frontMove.PositionY += _direction;
        if (Board.Grid[frontMove.PositionX, frontMove.PositionY] == null)
            AvaliableMoves.Add(frontMove);

        PositionOnBoard rightAttack = frontMove;
        rightAttack.PositionX++;
        if (Board.Grid[rightAttack.PositionX, rightAttack.PositionY] != null)
            AvaliableMoves.Add(rightAttack);

        PositionOnBoard leftAttack = frontMove;
        leftAttack.PositionX--;
        if (Board.Grid[leftAttack.PositionX, leftAttack.PositionY] != null)
            AvaliableMoves.Add(leftAttack);

        PositionOnBoard takeOnFirstMoveRight = PositionOnBoard;
        takeOnFirstMoveRight.PositionX++;
        if (Board.Grid[takeOnFirstMoveRight.PositionX, takeOnFirstMoveRight.PositionY] is Piece
        && Board.Grid[takeOnFirstMoveRight.PositionX, takeOnFirstMoveRight.PositionY] == Board.LastMovedPiece)
        {
            takeOnFirstMoveRight.PositionY += _direction;
            AvaliableMoves.Add(takeOnFirstMoveRight);
        }

        PositionOnBoard takeOnFirstMoveLeft = PositionOnBoard;
        takeOnFirstMoveLeft.PositionX++;
        if (Board.Grid[takeOnFirstMoveLeft.PositionX, takeOnFirstMoveLeft.PositionY] is Piece
        && Board.Grid[takeOnFirstMoveLeft.PositionX, takeOnFirstMoveLeft.PositionY] == Board.LastMovedPiece)
        {
            takeOnFirstMoveLeft.PositionY += _direction;
            AvaliableMoves.Add(takeOnFirstMoveLeft);
        }
    }
}
