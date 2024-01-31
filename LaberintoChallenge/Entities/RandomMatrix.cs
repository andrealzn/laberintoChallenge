namespace Challenge.Entities
{
    public class RandomMatrix : Matrix
    {
        private const int MinObstacles = 8;
        private const int MaxObstacles = 20;
        public RandomMatrix() : base()
        {
            Random random = new Random();
            FillWithAsterisks();
            AssignObstacles(random);
            AssignGoal(random);
        }

        // Segun el problema dado el camino está conformado por *
        private void FillWithAsterisks()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    MatrixArray[i, j] = '*';
                }
            }
        }

        // Segun el problema dado los obstáculos son representados con una B
        private void AssignObstacles(Random random)
        {
            int obstacleCount = random.Next(MinObstacles, MaxObstacles);
            for (int i = 0; i < obstacleCount; i++)
            {
                int obstacleRow = random.Next(Rows);
                int obstacleColumn = random.Next(Columns);
                while (MatrixArray[obstacleRow, obstacleColumn] == '*' || MatrixArray[obstacleRow, obstacleColumn] == 'X')
                {
                    obstacleRow = random.Next(Rows);
                    obstacleColumn = random.Next(Columns);
                    if (obstacleRow != 0 && obstacleColumn != 0)
                    {
                        MatrixArray[obstacleRow, obstacleColumn] = 'B';
                    }
                }
            }
        }

        //Segun el problema dado los obstáculos son representados con una X
        private void AssignGoal(Random random)
        {
            int goalRow = random.Next(Rows);
            int goalColumn = random.Next(Columns);
            MatrixArray[goalRow, goalColumn] = 'X';
        }
    }
}
