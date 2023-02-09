// В двумерном массиве целых чисел. Удалить строку и столбец,
// на пересечении которых расположен наименьший элемент.

void FillArray(int[,] array)
{
    // Делаем так, что при заполнении матрицы минимальный элемент будет только один
    Random random = new Random();
    int minRange = 10;
    int maxRange = 99;
    int min = maxRange;
    int indexMinI = 0;
    int indexMinJ = 0;
    // Создаём слуйчайные значения для элементов матрицы и находим минимальный элемент
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(minRange, maxRange + 1);
            if (array[i, j] < min)
            {
                min = array[i, j];
                indexMinI = i;
                indexMinJ = j;
            }
        }
    }
    // Пока минимальный элемент повторяется, выбираем другое случайное число
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] == min)
            {
                if (i != indexMinI || j != indexMinJ)
                {
                    while (array[i, j] == min)
                        array[i, j] = random.Next(minRange, maxRange + 1);
                }
            }
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

// Находим минимальный элемент в матрице
int[] SearchMinElement(int[,] array)
{
    int[] minElement = new int[3];
    minElement[0] = array[0, 0];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < minElement[0])
            {
                minElement[0] = array[i, j];
                minElement[1] = i;
                minElement[2] = j;
            }
        }
    }
    return minElement;
}

// Удаляем строки и столбцы на пересечении минимальных элементов
int[,] DeleteCrossElements(int[,] array, int[] minElement)
{
    int[,] newArray = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
    int indexI = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        if (i != minElement[1])
        {
            int indexJ = 0;
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (j != minElement[2])
                {
                    newArray[indexI, indexJ] = array[i, j];
                    indexJ++;
                }
            }
            indexI++;
        }
    }
    return newArray;
}

Console.Write("Введите количество строк матрицы: ");
int rows = int.Parse(Console.ReadLine()!);
Console.Write("Введите количество столбцов матрицы: ");
int columns = int.Parse(Console.ReadLine()!);
// Console.Write("Задайте максимально возможное значение элементов матрицы: ");
// int range = int.Parse(Console.ReadLine()!);
int range = 99;

int[,] array = new int[rows, columns];
FillArray(array);
PrintArray(array);

int[] minElement = SearchMinElement(array);
Console.Write($"Минимальный элемент в матрице равен {minElement[0]} и находится в ");
Console.WriteLine($"{minElement[1]} строке, {minElement[2]} столбце");

Console.WriteLine("Получаем матрицу:");
int[,] resultArray = DeleteCrossElements(array, minElement);
PrintArray(resultArray);