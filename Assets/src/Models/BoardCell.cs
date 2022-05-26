namespace src.Models
{
    public struct BoardCell
    {
        public BoardCell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Row:{Row} Column:{Column}";
        }
    }
}