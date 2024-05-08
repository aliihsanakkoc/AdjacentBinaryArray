/* Create a new two-dimensional binary array 
based on neighboring elements in 
any two-dimensional array */
internal class Program
{
    private static void Main(string[] args)
    {
        int[,] twoDimArr = new int[,]{{1,2,3,4},
                                      {5,6,7,8},
                                      {9,10,11,12}};
       int[,] binaryArray = AdjacentArray(twoDimArr);
       for (int i = 0; i < binaryArray.GetLength(0); i++)
       {
            for (int j = 0; j < binaryArray.GetLength(1); j++)
            {
                Console.Write(binaryArray[i,j]);
            }
            Console.WriteLine();
       }
    }
     static List<int> CreateListAdjacent(int[,] arr, 
        int i, int j, int rowCount, int columnCount)
    {
        List<int> ListAdjacent = new();
        if(i-1>=0)
            ListAdjacent.Add(arr[i-1,j]);
        if(i+1 < rowCount)
            ListAdjacent.Add(arr[i+1,j]);
        if(j-1>=0)
            ListAdjacent.Add(arr[i,j-1]);
        if(j+1 < columnCount)
            ListAdjacent.Add(arr[i,j+1]);
        return ListAdjacent;
    }
    static int[,] AdjacentArray(int[,] arr){
        int rowCount = arr.GetLength(0);
        int columnCount = arr.GetLength(1);
        int resultArrDim = rowCount*columnCount;
        List<int> AllNums = new();
        int[,] resultArray = new int[resultArrDim, resultArrDim];

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                AllNums.Add(arr[i,j]);
            }
        }

        int x = 0;
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                List<int> adjacentNums = CreateListAdjacent(arr, i, j, 
                                                rowCount, columnCount);
                for (int y = 0; y < resultArrDim; y++)
                {
                    if(adjacentNums.Contains(AllNums[y]))
                        resultArray[x,y] = 1;
                    else
                        resultArray[x,y] = 0;
                }
                x++;
            }
        }
        return resultArray;
    }
}

