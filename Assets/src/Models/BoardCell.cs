namespace src.Models
{
    public readonly struct BoardCell
    {
        public BoardCell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }

        public override string ToString()
        {
            return $"Row:{Row} Column:{Column}";
        }
    }
}