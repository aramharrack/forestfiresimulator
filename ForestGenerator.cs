using System;
using System.IO;

namespace forestfiresimulator
{
    class ForestGenerator
    {
        string[] lineArray = new string[21];
        string lineInFile;
        int gridRow;
        int gridColumn;

        public ForestGenerator()
        {
            gridRow = 0;
            gridColumn = 0;
        }

        public int GetRow()
        {
            return gridRow;
        }

        public int GetColumn()
        {
            return gridColumn;
        }

        public void GetFile(int[,] forest)
        {
            try
            {
                StreamReader readFileIn = new StreamReader("forest.txt");
                lineInFile = readFileIn.ReadLine();

                while (lineInFile != null)
                {
                    lineArray = lineInFile.Split(',');
                    MapForest(forest, lineArray, gridRow);
                    lineInFile = readFileIn.ReadLine(); //read next line from the file
                    ++gridRow;
                }
                readFileIn.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Error with file: " + e.Message);
            }
        }//close method

        private int[,] MapForest(int[,] forest, string[] lineArray, int row)
        {
            int tree;
            gridColumn = lineArray.Length;
            for (int i = 0; i < gridColumn; i++)
            {
                tree = int.Parse(lineArray[i]);
                forest[row, i] = tree;
            }
            return forest;
        }//close method
    }//close class
}//close namespace