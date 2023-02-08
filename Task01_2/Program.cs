// Если набор данных - таблица

// 1, 2, 3
// 4, 6, 1
// 2, 1, 6

// на выходе ожидаем получить

// 1 встречается 3 раза
// 2 встречается 2 раз
// 3 встречается 1 раз
// 4 встречается 1 раз
// 6 встречается 2 раза

void FillArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Random random = new Random();

        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(10);
        }
    }
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[] ArrangeArray(int[,] array)
{
    int size = array.GetLength(0) * array.GetLength(1);
    int[] arrangeArray = new int[size];

    int index = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            arrangeArray[index] = array[i, j];
            index++;
        }
    }

    for (int i = 0; i < arrangeArray.Length; i++)
    {
        for (int j = i + 1; j < arrangeArray.Length; j++)
        {
            if (arrangeArray[i] > arrangeArray[j])
            {
                int temp = arrangeArray[i];
                arrangeArray[i] = arrangeArray[j];
                arrangeArray[j] = temp;
            }
        }
    }

    return arrangeArray;
}

void PrintArrangeArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();
}

int[,] SearchRepeats(int[] array)
{
    int[,] repeatsArray = new int[array.Length, 2];

    for (int i = 0; i < array.Length; i++)
    {
        repeatsArray[i, 0] = array[i];
        int count = 0;

        for (int j = 0; j < array.Length; j++)
        {
            if (array[j] == repeatsArray[i, 0])
            {
                count++;
            }
        }

        repeatsArray[i, 1] = count;
    }

    return repeatsArray;
}

void PrintRepeats(int[,] repeatsArray)
{
    Console.WriteLine($"{repeatsArray[0, 0]} встречается {repeatsArray[0, 1]} раз");

    for (int i = 1; i < repeatsArray.GetLength(0); i++)
    {
        if (repeatsArray[i, 0] != repeatsArray[i - 1, 0])
        {
            Console.WriteLine($"{repeatsArray[i, 0]} встречается {repeatsArray[i, 1]} раз");
        }
    }
}

Console.Write("Введите количество строк двумерного массива: ");
int rows = int.Parse(Console.ReadLine()!);
Console.Write("Введите количество столбцов двумерного массива: ");
int columns = int.Parse(Console.ReadLine()!);

// int[,] matrix = new int[,]{ { 1, 2, 3 }, { 4, 6, 1 }, { 2, 1, 6 } };
int[,] array = new int[rows, columns];
FillArray(array);
PrintArray(array);
int[] arrangeArray = ArrangeArray(array);
PrintArrangeArray(arrangeArray);

int[,] repeatsArray = SearchRepeats(arrangeArray);
PrintRepeats(repeatsArray);