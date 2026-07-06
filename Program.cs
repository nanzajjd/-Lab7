namespace Lab7;

class Program
{
    static void Main()
    {
        FloatLinkedList list = new FloatLinkedList();

        int count = ReadCount("Введіть кількість елементів: ");

        for (int i = 0; i < count; i++)
        {
            float value = ReadFloat($"Введіть елемент {i + 1}: ");

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

        if (list.IsEmpty)
        {
            Console.WriteLine("Список порожній, подальші обчислення неможливі.");
            return;
        }

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

    /// <summary>Зчитує з консолі невід'ємну кількість елементів, повторюючи запит при некоректному вводі.</summary>
    private static int ReadCount(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int count) && count >= 0)
            {
                return count;
            }

            Console.WriteLine("Помилка: введіть ціле невід'ємне число.");
        }
    }

    /// <summary>Зчитує з консолі число типу float, повторюючи запит при некоректному вводі.</summary>
    private static float ReadFloat(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (float.TryParse(input, out float value))
            {
                return value;
            }

            Console.WriteLine("Помилка: введіть дійсне число.");
        }
    }
}
