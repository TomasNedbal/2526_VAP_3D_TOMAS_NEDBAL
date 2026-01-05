if (1 < 2)
    Console.WriteLine();

void print(params string[] messages)
{
    foreach (string message in messages)
    {
        Console.WriteLine(message);
    }
    return Console.ReadLine();
}

(int, int) getMinMax(params int[] numbers)
{
    if (numbers.Length == 0) return (0, 0);
    int min = numbers[0];
    int max = numbers[0];
    for (int i = 1; i < numbers.Length; i++)
    {
        if (numbers[i] < min) min = numbers[i];
        if (numbers[i] > max) max = numbers[i];
    }
    return (min, max);
}

string name = input("Zadej název souboru");
(int min, int max) = getMinMax(1, 2, 3, 4, 5, 6, 7);
print(name, min.ToString(), max.ToString());