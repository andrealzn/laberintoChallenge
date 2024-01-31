using Challenge.Entities;

namespace Challenge.Strategies
{
    public class MatrixStrategy : IDataStructureStrategy
    {
        private Matrix matrix;

        private static readonly int[] adjacentRows = { -1, 0, 1, 0 };
        private static readonly int[] adjacentColumns = { 0, 1, 0, -1 };

        public MatrixStrategy(Matrix initialMatrix)
        {
            matrix = initialMatrix ?? throw new ArgumentNullException();
        }

        public List<Position> CalculateShortestPath()
        {
            char[,] labyrinth = matrix.GetMatrix();

            if (labyrinth.Length == 0)
                throw new ArgumentException("The labyrinth cannot be empty.");


            if (labyrinth[0, 0] == 'B')
                return new List<Position>();

            int rows = labyrinth.GetLength(0);
            int columns = labyrinth.GetLength(1);

            Queue<Position> queue = new Queue<Position>();
            bool[,] visited = new bool[rows, columns];
            Dictionary<Position, Position> parent = new Dictionary<Position, Position>();


            Position start = new Position(0, 0);
            queue.Enqueue(start);
            visited[0, 0] = true;

            while (queue.Count > 0)
            {
                Position current = queue.Dequeue();

                if (labyrinth[current.Row, current.Column] == 'X')
                {
                    // Construir el camino desde X hasta el inicio
                    return BuildPath(parent, start, current);
                }

                for (int i = 0; i < 4; i++)
                {
                    int newRow = current.Row + adjacentRows[i];
                    int newColumn = current.Column + adjacentColumns[i];

                    if (IsValid(newRow, newColumn, rows, columns, labyrinth) && !visited[newRow, newColumn])
                    {
                        Position neighbor = new Position(newRow, newColumn);
                        queue.Enqueue(neighbor);
                        visited[newRow, newColumn] = true;
                        parent[neighbor] = current;
                    }
                }
            }

            // No se encontró camino a X
            return new List<Position>();
        }

        private static bool IsValid(int row, int column, int rows, int columns, char[,] labyrinth)
        {
            return row >= 0 && row < rows && column >= 0 && column < columns && labyrinth[row, column] != 'B';
        }

        private static List<Position> BuildPath(Dictionary<Position, Position> parent, Position start, Position end)
        {
            List<Position> path = new List<Position>();
            Position current = end;

            while (!current.Equals(start))
            {
                path.Add(current);

                if (parent.ContainsKey(current))
                {
                    current = parent[current];
                }
                else
                {
                    break;
                }
            }

            path.Add(start);
            path.Reverse(); // Invertir el camino para que sea desde inicio hasta X
            return path;
        }

    }
}
