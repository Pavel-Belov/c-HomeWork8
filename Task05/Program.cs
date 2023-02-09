// Показать треугольник Паскаля *Сделать вывод в виде равнобедренного треугольника

void PascalTriangle (double[,] triangle, int size)
{
    for (int i = 0; i <= size; i++)
    {
        for (int j = 0; j <= size; j++)
        {
            if (j == 0 || j == i)
                triangle[i, j] = 1;
            else if (i > 0 && j > 0)
                triangle[i, j] = triangle[i - 1, j - 1] + triangle[i - 1, j];
            else
                triangle[i, j] = 0;
        }
    }
}

void PrintTriangle(double[,] pascalTriangle)
{
    for (int i = 0; i < pascalTriangle.GetLength(0); i++)
    {
        double[] triangleLine = new double[i + 1];
        for (int j = 0; j < triangleLine.Length; j++)
        {
            triangleLine[j] = pascalTriangle[i, j];
        }
        string line = String.Join(" ", triangleLine);
        int screenWidthPosition = (Console.WindowWidth - line.Length) / 2;
        int screenHeightPosition = 3 + i;
        Console.SetCursorPosition(screenWidthPosition, screenHeightPosition);
        Console.WriteLine(line);
    }
}

Console.Clear();
Console.Write("Введите размер треугольника Паскаля: ");
int triangleSize = int.Parse(Console.ReadLine());
Console.WriteLine();

double[,] pascalTriangle = new double[triangleSize + 1, triangleSize + 1];
PascalTriangle(pascalTriangle, triangleSize);
Console.WriteLine();
PrintTriangle(pascalTriangle);