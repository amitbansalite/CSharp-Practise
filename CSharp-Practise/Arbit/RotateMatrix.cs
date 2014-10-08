using System;

namespace ConsoleApplication1.Arbit
{
    // 1. rotation is clockwise or anti clockwise
    // 2. is it in place rotation? need to return the same matrix or a different one?
    // 3. if in place, then matrix has to be square
    
    
    public class RotateMatrix
    {
        public void Rotate_Square_Matrix_Clockwise(ref int[,] matrix)
        {
            int n = matrix.GetLength(0);

            for (int layer = 0; layer < n/2; layer++)
            {
                int first = layer;
                int last = n - layer - 1;

                int counter = last;

                for (int elem = first; elem < last; elem++)
                {
                    int temp = matrix[first, elem];

                    // left goes to top
                    matrix[first, elem] = matrix[counter, first];

                    // bottom goes to left
                    matrix[counter,first] = matrix[last, counter];

                    // right goes to bottom
                    matrix[last, counter] = matrix[elem, last];

                    // top goes to right
                    matrix[elem, last] = temp;

                    counter--;
                }
            }
        }

        public int[,] Rotate_Jagged_Matrix_Clockwise(int[,] input_matrix)
        {
            int xDimension = input_matrix.GetLength(0);
            int yDimension = input_matrix.GetLength(1);

            var result_matrix = new int[yDimension,xDimension];

            int xCount = xDimension - 1;
            for (int i = 0; i < xDimension; i++)
            {
                for (int j = 0; j < yDimension; j++)
                {
                    result_matrix[j,xCount] = input_matrix[i, j];
                }
                xCount--;
            }
            return result_matrix;
        }
        
        //public static void Main()
        //{
        //    int n = 4;
        //    var matrix = new int[n,n];
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            matrix[i, j] = i*n + j;
        //        }
        //    }

        //    var obj = new RotateMatrix();

        //    obj.PrintSquareMatrix(matrix);
        //    obj.Rotate_Square_Matrix_Clockwise(ref matrix);
        //    Console.WriteLine("\n\n Matrix after rotation.");
        //    obj.PrintSquareMatrix(matrix);

        //    int x = 3;
        //    int y = 5;
        //    var jagged_matrix = new int[x,y];

        //    for (int i = 0; i < x; i++)
        //    {
        //        for (int j = 0; j < y; j++)
        //        {
        //            jagged_matrix[i,j] = i * x*x + j;
        //        }
        //    }

        //    Console.WriteLine("\n\n Jagged Matrix.");
        //    obj.PrintJaggedMatrix(jagged_matrix);
        //    jagged_matrix = obj.Rotate_Jagged_Matrix_Clockwise(jagged_matrix);
        //    Console.WriteLine("\n\n Matrix after rotation.");
        //    obj.PrintJaggedMatrix(jagged_matrix);
            
        //    Console.ReadLine();
        //}

        private void PrintSquareMatrix(int[,] matrix)
        {
            int length = matrix.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < length; j++)
                {
                    Console.Write(" {0} ", matrix[i, j]);
                }
            }
        }

        private void PrintJaggedMatrix(int[,] matrix)
        {
            int xDimension = matrix.GetLength(0);
            int yDimension = matrix.GetLength(1);

            for (int i = 0; i < xDimension; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < yDimension; j++)
                {
                    Console.Write(" {0} ", matrix[i, j]);
                }
            }
        }
    }
}
