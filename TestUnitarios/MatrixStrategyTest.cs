using Challenge.Entities;
using Challenge.Strategies;
using NUnit.Framework.Legacy;

namespace UnitTest
{
    [TestFixture]
    public class MatrixStrategyTests
    {
        [Test]
        public void CalcularCaminoCorto_ConMatrizAleatoria_DeberiaEncontrarCaminoCorrecto()
        {
            RandomMatrix matrix = new RandomMatrix();
            MatrixStrategy matrixStrategy = new MatrixStrategy(matrix);

            List<Position> path = matrixStrategy.CalculateShortestPath();

            ClassicAssert.NotNull(path);
            ClassicAssert.IsNotEmpty(path);
        }

        [Test]
        public void CalcularCaminoCorto_ConMatrizNula_RetornaExcepcion()
        {
            try
            {
                RandomMatrix matrix = null;
                MatrixStrategy matrixStrategy = new MatrixStrategy(matrix);

                matrixStrategy.CalculateShortestPath();
            }
            catch (Exception ex)
            {
                ClassicAssert.AreEqual(ex.Message, "Value cannot be null.");
            }
        }

        [Test]
        public void CalcularCaminoCorto_LaberintoVacio_RetornaExcepcion()
        {
            try
            {
                char[,] labyrinth = { };

                Matrix matrix = new Matrix(labyrinth);
                MatrixStrategy matrixStrategy = new MatrixStrategy(matrix);

                matrixStrategy.CalculateShortestPath();
            }
            catch (Exception ex)
            {
                ClassicAssert.AreEqual(ex.Message, "The labyrinth cannot be empty.");
            }
        }

        [Test]
        public void CalcularCaminoCorto_NoExisteObjetivo_RetornaListaVacia()
        {
            char[,] labyrinth = {
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
            };

            Matrix matrix = new Matrix(labyrinth);
            MatrixStrategy matrixStrategy = new MatrixStrategy(matrix);

            List<Position> path = matrixStrategy.CalculateShortestPath();

            ClassicAssert.AreEqual(path.Count, 0);
        }

        [Test]
        public void CalcularCaminoCorto_NoExisteCamino_RetornaListaVacia()
        {
            char[,] labyrinth = {
                { '*', 'B', '*', '*', '*', '*', '*', '*'},
                { 'B', 'B', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', 'X', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
            };

            Matrix matrix = new Matrix(labyrinth);
            MatrixStrategy matrixStrategy = new MatrixStrategy(matrix);

            List<Position> path = matrixStrategy.CalculateShortestPath();

            ClassicAssert.AreEqual(path.Count, 0);
        }


        [Test]
        public void CalcularCaminoCorto_ObstaculoEnPositionInicial_RetornaListaVacia()
        {
            char[,] labyrinth = {
                { 'B', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', 'B', '*'},
                { '*', 'B', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', 'X', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', 'B', '*', '*', '*', 'B', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
            };

            Matrix matrix = new Matrix(labyrinth);
            MatrixStrategy matrixStrategy = new MatrixStrategy(matrix);

            List<Position> path = matrixStrategy.CalculateShortestPath();

            ClassicAssert.AreEqual(path.Count, 0);
        }

        [Test]
        public void CalcularCaminoCorto_ObjetivoEnPositionInicial_RetornaPositionInicial()
        {
            char[,] labyrinth = {
                { 'X', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', 'B', '*'},
                { '*', 'B', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', 'X', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', 'B', '*', '*', '*', 'B', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*', '*', '*', '*'},
            };

            Matrix matrix = new Matrix(labyrinth);
            MatrixStrategy matrixStrategy = new MatrixStrategy(matrix);

            List<Position> path = matrixStrategy.CalculateShortestPath();

            ClassicAssert.AreEqual(path.Count, 1);
            ClassicAssert.AreEqual(path[0], new Position(0,0));
        }

        

    }
}