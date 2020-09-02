using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class RotateImage : Runner
    {

        void RotateMyImage(int[,] matrix)
        {

        }

        void RowToColumn(int[,] matrix, int r, int c)
        {
            //int[] row = matrix.r;
        }

        void ColumnToRow(int[,] matrix, int r, int c)
        {

        }

        public override void Run(string[] args)
        {
            int[,] arr = new int[3, 3]
            {
                { 1 ,2 , 3 },
                { 4 ,5 , 6 },
                { 7 ,8 , 9 }
            };

            RotateMyImage(arr);
        }
    }
}
