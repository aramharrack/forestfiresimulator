using System;
using System.Threading;

namespace forestfiresimulator
{
    class ForestFireSimulation
    {
        Random rand = new Random();
        private int burnCount;

        public ForestFireSimulation()
        {
            burnCount = 0;
        }

        public int GetBurnCount()
        {
            return burnCount;
        }

        public void SetBurnCount(int count)
        {
            burnCount = count;
        }

        private void PrintForest(int[,] forest, int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(forest[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }//close method

        public int[,] StartBurn(int[,] forest, int row, int column)
        {
            forest[10, 10] = 2;
            PrintPauseClear(forest, row, column);
            return forest;
        }

        private int[,] BurnTrees(int[,] forest, int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    double burnChance = rand.NextDouble();
                    switch (forest[i, j])
                    {
                        case 0:
                            break;
                        case 1:
                            {
                                bool neighborState = IsNeighborBurning(forest, i, j);
                                if (neighborState && burnChance > 0.5) //if a neighbor is burning 50% to burn current cell
                                    forest[i, j] = 2; //burn
                                break;
                            }
                        case 2:
                            forest[i, j] = 0; //change to empty if cell is burning
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine("\tBurning Forest.\n");
            PrintPauseClear(forest, row, column);
            bool burning = CheckCellState(forest, row, column, 2);
            if (burning)
                BurnTrees(forest, row, column);
            return forest;
        }//close method

        //reburn a tree
        private int[,] ReburnTrees(int[,] forest, int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (forest[i, j] == 1)//check for tree
                    {
                        forest[i, j] = 2;//set to burn
                        break;
                    }
                }
            }
            Console.WriteLine("\tReburning Trees.\n");
            PrintPauseClear(forest, row, column);
            BurnTrees(forest, row, column);
            bool tree = CheckCellState(forest, row, column, 1);
            if (tree)
                ReburnTrees(forest, row, column);
            return forest;
        }//close method

        private bool IsNeighborBurning(int[,] forest, int i, int j)
        {
            int minRow = Math.Max(i - 1, forest.GetLowerBound(0));
            int maxRow = Math.Min(i + 1, forest.GetUpperBound(0));
            int minCol = Math.Max(j - 1, forest.GetLowerBound(1));
            int maxCol = Math.Min(j + 1, forest.GetUpperBound(1));
            // Check each cell within a 1 cell radius for the specified value.
            for (int x = minRow; x <= maxRow; x++)
            {
                for (int y = minCol; y <= maxCol; y++)
                {
                    if (forest[x, y] == 2)
                        return true;
                }
            }
            return false;
        }//close method

        private bool CheckCellState(int[,] forest, int row, int column, int cellState)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (forest[i, j] == cellState)//check for state
                        return true;
                }
            }
            return false;
        }//close method

        private void CellStateCounter(int[,] forest, int row, int column)
        {
            int tree = 0, burning = 0, empty = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    switch (forest[i, j])
                    {
                        case 0:
                            empty++;    //count empty trees 
                            break;
                        case 1:
                            tree++;     //count unburnt trees
                            break;
                        case 2:
                            burning++;  //count burning trees
                            break;
                    }
                }
            }
            Console.WriteLine("Forest Status: \nUnburnt Trees: {0} \nBurning Trees: {1} \nBurnt Trees: {2}", tree, burning, empty);
        }//close method

        private void PrintPauseClear(int[,] forest, int row, int column)
        {
            DisplayGrid(forest, row, column);
            SetBurnCount(GetBurnCount() + 1);
            Console.Write("Iteration: {0}", GetBurnCount());
            Thread.Sleep(2000);
            Console.Clear();
        }

        public void DisplayGrid(int[,] forest, int row, int column)
        {
            PrintForest(forest, row, column);
            CellStateCounter(forest, row, column);
            Console.WriteLine();
        }//close method

        //burn forest
        public void ApplyBurn(int[,] forest, int row, int column, int option)
        {
            switch (option)
            {
                case 0:
                    BurnTrees(forest, row, column);
                    break;
                case 1:
                    ReburnTrees(forest, row, column);
                    break;
                case 2:
                    StartBurn(forest, row, column);
                    BurnTrees(forest, row, column);
                    ReburnTrees(forest, row, column);
                    break;
            }
        }//close method

        //reset the forest
        public int[,] ResetForest(int[,] forest, int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    forest[i, j] = 1;
                }
            }
            SetBurnCount(0);
            return forest;
        }//close method

    }//close class
}//close namespace