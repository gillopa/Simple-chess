using Microsoft.VisualBasic;

class Program
{
    public static void Main()
    {
        List<Piece> pieces = new List<Piece>();
        pieces.Add(new Rock(Color.White, new PositionOnBoard(0, 0)));
        pieces.Add(new Rock(Color.White, new PositionOnBoard(0, 7)));
        pieces.Add(new Rock(Color.Black, new PositionOnBoard(Board.LengthY - 1, 0)));
        pieces.Add(new Rock(Color.Black, new PositionOnBoard(Board.LengthY - 1, 7)));
        while (true)
        {
            string? inputString = Console.ReadLine();
            var input = TryConvertInput(inputString);
            Console.WriteLine($"{input.Item1.ToString()} {input.Item2?.PositionX.ToString() ?? "fatal"}"
            + $" {input.Item2?.PositionY.ToString() ?? "fatal"}" + $" {input.Item3?.PositionX.ToString() ?? "fatal"}"
            + $" {input.Item3?.PositionY.ToString() ?? "fatal"}");
        }
    }
    public static Dictionary<char, int> CharSquare = new Dictionary<char, int>
    {
        {'a',0},
        {'b',1},
        {'c',2},
        {'d',3},
        {'e',4},
        {'f',5},
        {'j',6},
        {'h',7}
    };
    public static (bool, PositionOnBoard?, PositionOnBoard?) TryConvertInput(string? input)
    {
        if (string.IsNullOrEmpty(input) || input.Length != 4)
            return (false, null, null);
        int firstIndex;
        int secondIndex;
        if (CharSquare.ContainsKey(input[0]) && CharSquare.ContainsKey(input[2]) &&
         int.TryParse(input[1].ToString(), out firstIndex) && int.TryParse(input[3].ToString(), out secondIndex) &&
          1 <= firstIndex && firstIndex <= 8 && 1 <= secondIndex && secondIndex <= 8)
            return (true, new PositionOnBoard(CharSquare.GetValueOrDefault(input[0]), firstIndex), new PositionOnBoard(CharSquare.GetValueOrDefault(input[2]), secondIndex));
        return (false, null, null);
    }
}