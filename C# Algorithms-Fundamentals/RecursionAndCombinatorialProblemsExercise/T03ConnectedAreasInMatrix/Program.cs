namespace T03ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = ReadMatrix(rows, cols);
            var visited = new bool[rows, cols];

            var totalAreas = new List<Area>();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == '*')
                    {
                        continue;
                    }

                    if (visited[r, c])
                    {
                        continue;
                    }

                    var areaSize = GetAreaSize(matrix, r, c, visited);
                    var area = new Area { Size = areaSize, Row = r, Col = c };
                    totalAreas.Add(area);
                }
            }

            PrintResult(totalAreas
                        .OrderByDescending(x => x.Size)
                        .ThenBy(x => x.Row)
                        .ThenBy(x => x.Col)
                        .ToList());
        }

        private static void PrintResult(List<Area> totalAreas)
        {
            Console.WriteLine($"Total areas found: {totalAreas.Count}");
            for (int i = 0; i < totalAreas.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({totalAreas[i].Row}, {totalAreas[i].Col}), size: {totalAreas[i].Size}");
            }
        }

        private static int GetAreaSize(char[,] matrix, int row, int col, bool[,] visited)
        {
            if (IsOutside(matrix, row, col))
            {
                return 0;
            }

            if (matrix[row, col] == '*')
            {
                return 0;
            }

            if (visited[row, col])
            {
                return 0;
            }

            visited[row, col] = true;

            // row - 1, col -> up
            // row + 1, col -> down
            // row, col - 1 -> left
            // row, col + 1 -> right

            var areaSize = GetAreaSize(matrix, row - 1, col, visited) +
                           GetAreaSize(matrix, row + 1, col, visited) +
                           GetAreaSize(matrix, row, col - 1, visited) +
                           GetAreaSize(matrix, row, col + 1, visited);

            return areaSize + 1;
        }

        private static bool IsOutside(char[,] matrix, int row, int col)
        {
            return row < 0 ||
                   row >= matrix.GetLength(0) ||
                   col < 0 ||
                   col >= matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var colElements = Console.ReadLine();

                for (int c = 0; c < colElements.Length; c++)
                {
                    matrix[r, c] = colElements[c];
                }
            }

            return matrix;
        }
    }

    public class Area
    {
        public int Size { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}




//namespace T03ConnectedAreasInMatrix
//{
//    using System;
//    using System.Linq;
//    using System.Collections.Generic;

//    public class Area
//    {
//        public int Row { get; set; }

//        public int Col { get; set; }

//        public int Size { get; set; }
//    }

//    public class Program
//    {
//        private const char VisitedSymbol = 'v';
//        private static char[,] matrix;
//        private static int size = 0;

//        static void Main(string[] args)
//        {
//            int rows = int.Parse(Console.ReadLine());
//            int cols = int.Parse(Console.ReadLine());

//            matrix = new char[rows, cols];
//            FillTheMatrix(rows, cols);

//            var areas = new List<Area>();

//            for (int i = 0; i < rows; i++)
//            {
//                for (int j = 0; j < cols; j++)
//                {
//                    size = 0;
//                    ExploreArea(i, j);

//                    if (size != 0)
//                    {
//                        areas.Add(new Area { Row = i, Col = j, Size = size });
//                    }
//                }
//            }

//            var sorted = areas
//                .OrderByDescending(a => a.Size)
//                .ThenBy(a => a.Row)
//                .ThenBy(a => a.Col)
//                .ToList();

//            Console.WriteLine($"Total areas found: {areas.Count}");
//            for (int i = 0; i < sorted.Count; i++)
//            {
//                var area = sorted[i];
//                Console.WriteLine($"Area #{i + 1} at ({area.Row}, {area.Col}), size: {area.Size}");
//            }
//        }

//        private static void ExploreArea(int row, int col)
//        {
//            if (IsOutside(row, col) || IsWall(row, col) || IsVisited(row, col))
//            {
//                return;
//            }

//            size += 1;
//            matrix[row, col] = VisitedSymbol;

//            ExploreArea(row - 1, col);
//            ExploreArea(row + 1, col);
//            ExploreArea(row, col - 1);
//            ExploreArea(row, col + 1);
//        }

//        private static bool IsOutside(int row, int col)
//            => row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1);

//        private static bool IsWall(int row, int col)
//            => matrix[row, col] == '*';

//        private static bool IsVisited(int row, int col)
//            => matrix[row, col] == VisitedSymbol;

//        private static void FillTheMatrix(int rows, int cols)
//        {
//            for (int i = 0; i < rows; i++)
//            {
//                var colElements = Console.ReadLine();

//                for (int j = 0; j < cols; j++)
//                {
//                    matrix[i, j] = colElements[i];
//                }
//            }
//        }
//    }
//}