// Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.

// Пример: Есть набор данных

// { 1, 9, 9, 0, 2, 8, 0, 9 }

// частотный массив может быть представлен так:

// 0 встречается 2 раза
// 1 встречается 1 раз
// 2 встречается 1 раз
// 8 встречается 1 раз
// 9 встречается 3 раза

void FillArray(int[] array)
{
    Random random = new Random();

    for (int i = 0; i < array.Length; i++)
    {
        array[i] = random.Next(10);
    }
}

void PrintArray(int[] array)
{
    Console.Write("{ ");

    for (int i = 0; i < array.Length; i++)
    {
        if (i == array.Length - 1)
            Console.Write($"{array[i]}");
        else
            Console.Write($"{array[i]}, ");
    }

    Console.WriteLine(" }");
}

void ArrangeArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[i] > array[j])
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
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

Console.Write("Введите размер массива: ");
int size = int.Parse(Console.ReadLine()!);

// int[] array = new int[] { 1, 9, 9, 0, 2, 8, 0, 9 };
int[] array = new int[size];
FillArray(array);
PrintArray(array);
ArrangeArray(array);
PrintArray(array);

int[,] repeatsArray = SearchRepeats(array);
PrintRepeats(repeatsArray);