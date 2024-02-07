//homework task 3
class program
{
    static random random = new random();

    static void main()
    {
        int boardsize = 8;
        int[] queens = placequeens(boardsize);

        printchessboard(queens);
    }

    static int[] placequeens(int boardsize)
    {
        int[] queens = new int[boardsize];

        for (int i = 0; i < boardsize; i++)
        {
            queens[i] = random.next(boardsize);
        }

        while (!isvalid(queens))
        {
            for (int i = 0; i < boardsize; i++)
            {
                queens[i] = random.next(boardsize);
            }
        }

        return queens;
    }

    static bool isvalid(int[] queens)
    {
        for (int i = 0; i < queens.length; i++)
        {
            for (int j = i + 1; j < queens.length; j++)
            {
                if (queens[i] == queens[j] || math.abs(queens[i] - queens[j]) == math.abs(i - j))
                {
                    return false;
                }
            }
        }

        return true;
    }

    static void printchessboard(int[] queens)
    {
        int boardsize = queens.length;

        for (int i = 0; i < boardsize; i++)
        {
            for (int j = 0; j < boardsize; j++)
            {
                console.write(queens[i] == j ? "1 " : "0 ");
            }
            console.writeline();
        }
    }
}

//hpmework task 4
class program
{
    static random random = new random();

    static void main()
    {
        int boardsize = 8;
        int[,] chessboard = new int[boardsize, boardsize];

        int knightrow = 2;
        int knightcol = 3;

        chessboard[knightrow, knightcol] = 1;

        var newposition = performknightmove(chessboard, knightrow, knightcol);
        knightrow = newposition.item1;
        knightcol = newposition.item2;

        printchessboard(chessboard);
    }

    static tuple<int, int> performknightmove(int[,] chessboard, int row, int col)
    {
        int[] moverow = { -2, -1, 1, 2, 2, 1, -1, -2 };
        int[] movecol = { 1, 2, 2, 1, -1, -2, -2, -1 };

        var validmoves = getvalidmoves(chessboard, row, col, moverow, movecol);

        if (validmoves.count > 0)
        {
            var randommove = validmoves[random.next(validmoves.count)];
            var newrow = row + moverow[randommove];
            var newcol = col + movecol[randommove];

            chessboard[newrow, newcol] = 1;

            return new tuple<int, int>(newrow, newcol);
        }

        return new tuple<int, int>(row, col);
    }

    static list<int> getvalidmoves(int[,] chessboard, int row, int col, int[] moverow, int[] movecol)
    {
        var validmoves = new list<int>();

        for (int i = 0; i < 8; i++)
        {
            var newrow = row + moverow[i];
            var newcol = col + movecol[i];

            if (isvalidmove(chessboard, newrow, newcol))
            {
                validmoves.add(i);
            }
        }

        return validmoves;
    }

    static bool isvalidmove(int[,] chessboard, int row, int col)
    {
        return row >= 0 && row < chessboard.getlength(0) &&
               col >= 0 && col < chessboard.getlength(1) &&
               chessboard[row, col] == 0;
    }

    static void printchessboard(int[,] chessboard)
    {
        for (int i = 0; i < chessboard.getlength(0); i++)
        {
            for (int j = 0; j < chessboard.getlength(1); j++)
            {
                console.write(chessboard[i, j] + " ");
            }
            console.writeline();
        }
    }
}



//homework task 5
 class saddlepoint
{
    static bool findsaddlepoint(int[,] mat, int n)
    {

        for (int i = 0; i < n; i++)
        {

            int min_row = mat[i, 0], col_ind = 0;
            for (int j = 1; j < n; j++)
            {
                if (min_row > mat[i, j])
                {
                    min_row = mat[i, j];
                    col_ind = j;
                }
            }

            int k;
            for (k = 0; k < n; k++)

                if (min_row < mat[k, col_ind])
                    break;

            if (k == n)
            {
                console.writeline("value of saddle point is: " + min_row);
                return true;
            }
        }

        return false;
    }

    public static void main()
    {
        int[,] mat = {{1, 2, 3},
                        {4, 5, 6},
                        {7, 8, 9}};

        int n = 3;
        if (findsaddlepoint(mat, n) == false)
            console.writeline("no saddle point ");
    }
}


----------------------------------------------------------------------------------------------------------------------------------


//homework task 6
 class randomfill
{
    static void main()
    {
        console.write("enter the number of rows (n): ");
        int n = int.parse(console.readline());

        console.write("enter the number of columns (m): ");
        int m = int.parse(console.readline());

        if (n <= 0 || m <= 0)
        {
            console.writeline("invalid matrix size. please enter positive values for n and m.");
            return;
        }

        int[,] matrix = new int[n, m];
        list<int> availablenumbers = generateavailablenumbers(n * m);

        randomlyfillmatrix(matrix, availablenumbers);

        console.writeline("randomly filled matrix:");
        printmatrix(matrix);
    }

    static list<int> generateavailablenumbers(int count)
    {
        list<int> numbers = new list<int>();
        for (int i = 1; i <= count; i++)
        {
            numbers.add(i);
        }
        return numbers;
    }

    static void randomlyfillmatrix(int[,] matrix, list<int> availablenumbers)
    {
        random random = new random();

        for (int i = 0; i < matrix.getlength(0); i++)
        {
            for (int j = 0; j < matrix.getlength(1); j++)
            {
                if (availablenumbers.count == 0)
                {
                    console.writeline("not enough unique numbers available.");
                    return;
                }

                int randomindex = random.next(availablenumbers.count);
                matrix[i, j] = availablenumbers[randomindex];
                availablenumbers.removeat(randomindex);
            }
        }
    }

    static void printmatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.getlength(0); i++)
        {
            for (int j = 0; j < matrix.getlength(1); j++)
            {
                console.write(matrix[i, j] + "\t");
            }
            console.writeline();
        }
    }
}