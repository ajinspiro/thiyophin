string[] lines = File.ReadAllLines("sample.txt");
int[] numbers = new int[100];

int i = 0;
foreach (var line in lines)
{
    int temp = int.Parse(line);
    int tempSquare = temp * temp;
    numbers[i++] = tempSquare;
}

for (i = 0; i < lines.Length; i++)
{
    System.Console.WriteLine(numbers[i]);
}