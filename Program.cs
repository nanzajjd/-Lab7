namespace Lab7;

class Program
{
    static void Main()
    {
        FloatLinkedList list = new FloatLinkedList();

        Console.Write("Введіть кількість елементів: ");
        int count = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введіть елемент {i + 1}: ");
            float value = float.Parse(Console.ReadLine()!);

            if (i < 2)
            {
                list.Add(value);
            }
            else
            {
                list.InsertAfterSecond(value);
            }
        }

    

        Console.WriteLine();

        float average = list.GetAverage();
        Console.WriteLine($"Середнє арифметичне елементів списку: {average}");

        float? firstNegative = list.FindFirstNegative();

        if (firstNegative != null)
        {
            Console.WriteLine($"Перше знайдене від'ємне значення: {firstNegative}");
        }
        else
        {
            Console.WriteLine("У списку від'ємні значення відсутні.");
        }

        Console.WriteLine($"Сума значень, які перевищують середнє: {list.SumGreaterThanAverage()}");

        Console.WriteLine("Список, сформований лише з позитивних елементів:");
        FloatLinkedList positiveList = list.GetPositiveElements();
        positiveList.Print();

        Console.WriteLine("Список після вилучення всіх від'ємних значень:");
        list.RemoveNegativeElements();
        list.Print();

        Console.WriteLine();
        Console.WriteLine("Перебір списку через foreach:");
        foreach (float value in list)
        {
            Console.Write(value + " ");
        }

        Console.WriteLine();
    }
}