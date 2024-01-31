namespace Challenge.Entities
{
    public class Matrix
    {
        protected const int Columns = 8;
        protected const int Rows = 13;
        protected readonly char[,] MatrixArray;

        public Matrix()
        {
            MatrixArray = new char[Rows, Columns];
        }

        public Matrix(char[,] initialMatrix)
        {
            MatrixArray = initialMatrix;
        }

        public char[,] GetMatrix()
        {
            return MatrixArray;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (MatrixArray[i, j] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(MatrixArray[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(MatrixArray[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}