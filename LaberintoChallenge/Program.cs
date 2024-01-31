using Challenge.Entities;
using Challenge.Strategies;

static class Program
{
    static void Main()
    {
        // Explicación de la solución:

        //Se propone una solución extendible en un contexto imaginario en el cual, al utilizar el patrón Strategy, se podría seleccionar
        //de manera dinámica qué tipo de grafo deseo evaluar y así aplicar el algoritmo de búsqueda más conveniente.

        //Por ejemplo, para la solución del camino más corto de un grafo ponderado con diferentes pesos en las aristas podríamos aplicar el
        //algoritmo de Dijkstra.

        //La matriz del problema propuesto EN EL CONTEXTO DADO puede ser representada como un grafo dirigido (solo podemos movernos en
        //una dirección)y ponderado (cada movimiento tiene peso 1) o directamente como un grafo no ponderado. Podríamos aplicar Dijkstra
        //pero hay una solución mas práctica que es aplicar un algoritmo de búsqueda en anchura. Esta solución resulta apropiada ya que 
        //el tamaño de la matriz propuesta es reducido.

        //Se genera por practicidad una matriz aleatoria con las condiciones dadas (laberinto)
        //y también se incluye el desarrollo de algunos test unitarios con fines demostrativos

        //-------------------------------------------------------------------------------------------------------------------------------

        bool anotherLaberinth = true;

        do
        {
            var randomMatrix = new RandomMatrix();
            var matrixStrategy = new MatrixStrategy(randomMatrix);
            var matrixContext = new DataStructureContext(matrixStrategy);

            Console.WriteLine("LABERINTO ALEATORIO:\n");
            randomMatrix.PrintMatrix();

            Console.WriteLine("\nPresione enter para resolver el laberinto (El camino se marcará con O)");
            Console.ReadLine();

            var shortPath = matrixContext.CalculateShortestPath();
            printPath(shortPath, randomMatrix.GetMatrix());
            randomMatrix.PrintMatrix();

            Console.WriteLine("\n------------------------------------------------------------------------\n");
            Console.WriteLine("\nPresione '1' para generar otro laberinto o cualquier otra tecla para salir:\n");

            string userInput = Console.ReadLine();

            anotherLaberinth = userInput == "1";

        } while (anotherLaberinth);



        void printPath(List<Position> caminoCorto, char[,] matrizAleatoria)
        {
            if (caminoCorto.Count > 0)
            {
                Console.WriteLine("\nCAMINO MAS CORTO:\n");
                foreach (Position posicion in caminoCorto)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    matrizAleatoria[posicion.Row, posicion.Column] = 'O';
                }
            }
            else
            {
                Console.WriteLine("\nNO HAY CAMINO HACIA LA X.");
            }
        }
    }
}






