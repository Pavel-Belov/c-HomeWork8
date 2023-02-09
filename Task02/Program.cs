// Найти произведение двух матриц

void FillArray(int[,] array)
{
    Random random = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
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

int[,] MultiplyArray(int[,] array1, int[,] array2)
{
    int[,] multiplyArray = new int[array1.GetLength(0), array1.GetLength(1)];

    for (int i = 0; i < array1.GetLength(0); i++)
    {
        for (int j = 0; j < array1.GetLength(1); j++)
        {
            multiplyArray[i, j] = array1[i, j] * array2[i, j];
        }
    }

    return multiplyArray;
}

Console.Write("Введите количество строк массива: ");
int rows = int.Parse(Console.ReadLine()!);
Console.Write("Введите количество столбцов массива: ");
int columns = int.Parse(Console.ReadLine()!);

int[,] array1 = new int[rows, columns];
Console.WriteLine("Матрица 1: ");
FillArray(array1);
PrintArray(array1);
Console.WriteLine();

int[,] array2 = new int[rows, columns];
Console.WriteLine("Матрица 2: ");
FillArray(array2);
PrintArray(array2);
Console.WriteLine();

Console.WriteLine("Произведение двух матриц: ");
int[,] multiplyArray = MultiplyArray(array1, array2);
PrintArray(multiplyArray);