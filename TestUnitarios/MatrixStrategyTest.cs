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

            List<Position> camino = matrixStrategy.CalculateShortestPath();

            ClassicAssert.NotNull(camino);
            ClassicAssert.IsNotEmpty(camino);
        }

        [Test]
        public void CalcularCaminoCorto_ConMatrizNula_RetornaExcepcion()
        {
            try
            {
                RandomMatrix matriz = null;
                MatrixStrategy matrixStrategy = new MatrixStrategy(matriz);

                List<Position> camino = matrixStrategy.CalculateShortestPath();
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
                char[,] laberinto = { };

                Matrix matriz = new Matrix(laberinto);
                MatrixStrategy matrixStrategy = new MatrixStrategy(matriz);

                List<Position> camino = matrixStrategy.CalculateShortestPath();
            }
            catch (Exception ex)
            {
                ClassicAssert.AreEqual(ex.Message, "The labyrinth cannot be empty.");
            }
        }

        [Test]
        public void CalcularCaminoCorto_NoExisteObjetivo_RetornaListaVacia()
        {
            char[,] laberinto = {
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

            Matrix matriz = new Matrix(laberinto);
            MatrixStrategy matrixStrategy = new MatrixStrategy(matriz);

            List<Position> camino = matrixStrategy.CalculateShortestPath();

            ClassicAssert.AreEqual(camino.Count, 0);
        }

        [Test]
        public void CalcularCaminoCorto_NoExisteCamino_RetornaListaVacia()
        {
            char[,] laberinto = {
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

            Matrix matriz = new Matrix(laberinto);
            MatrixStrategy matrixStrategy = new MatrixStrategy(matriz);

            List<Position> camino = matrixStrategy.CalculateShortestPath();

            ClassicAssert.AreEqual(camino.Count, 0);
        }


        [Test]
        public void CalcularCaminoCorto_ObstaculoEnPositionInicial_RetornaListaVacia()
        {
            char[,] laberinto = {
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

            Matrix matriz = new Matrix(laberinto);
            MatrixStrategy matrixStrategy = new MatrixStrategy(matriz);

            List<Position> camino = matrixStrategy.CalculateShortestPath();

            ClassicAssert.AreEqual(camino.Count, 0);
        }

        [Test]
        public void CalcularCaminoCorto_ObjetivoEnPositionInicial_RetornaPositionInicial()
        {
            char[,] laberinto = {
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

            Matrix matriz = new Matrix(laberinto);
            MatrixStrategy matrixStrategy = new MatrixStrategy(matriz);

            List<Position> camino = matrixStrategy.CalculateShortestPath();

            ClassicAssert.AreEqual(camino.Count, 1);
            ClassicAssert.AreEqual(camino.First(), new Position(0,0));
        }

        

    }
}