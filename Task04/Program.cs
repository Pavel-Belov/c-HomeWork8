// Сформировать трехмерный массив не повторяющимися двузначными числами
// показать его построчно на экран вывода индексы соответствующего элемента

void FillArray(int[,,] array)
{
    int number = 10;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = number;
                number++;
            }
        }
    }
    // Перемешиваем матрицу
    int sizeI = array.GetLength(0);
    int sizeJ = array.GetLength(1);
    int sizeK = array.GetLength(2);
    Random random = new Random();
    for (int i = 0; i < sizeI * sizeJ * sizeK; i++)
    {
        int element1i = random.Next(sizeI);
        int element1j = random.Next(sizeJ);
        int element1k = random.Next(sizeK);
        int element2i = random.Next(sizeI);
        int element2j = random.Next(sizeJ);
        int element2k = random.Next(sizeK);
        int temp = array[element1i, element1j, element1k];
        array[element1i, element1j, element1k] = array[element2i, element2j, element2k];
        array[element2i, element2j, element2k] = temp;
    }
}

void PrintArray(int[,,] array)
{
    for (int z = 0; z < array.GetLength(0); z++)
    {
        for (int y = 0; y < array.GetLength(1); y++)
        {
            for (int x = 0; x < array.GetLength(2); x++)
            {
                Console.Write($"[{z},{y},{x}]:{array[z, y, x]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

Console.Write("Введите мерность матрицы: ");
int z = int.Parse(Console.ReadLine()!);
Console.Write("Введите количество строк матрицы: ");
int y = int.Parse(Console.ReadLine()!);
Console.Write("Введите количество столбцов матрицы: ");
int x = int.Parse(Console.ReadLine()!);

int sizeArray = x * y * z;
if (sizeArray < 100)
{
    int[,,] array = new int[z, y, x];
    FillArray(array);
    PrintArray(array);
}
else
{
    Console.WriteLine("ОШИБКА!");
    Console.WriteLine("В данной матрице значения элементов выходят за границу двухзначных чисел.");
    Console.WriteLine("Попробуйте ввести другие размеры матрицы");
}