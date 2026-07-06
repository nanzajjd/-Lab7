using System.Collections;

namespace Lab7;

/// <summary>
/// Односпрямований список елементів типу float.
/// Новий елемент (починаючи з третього) додається одразу після другого елемента списку.
/// </summary>
public class FloatLinkedList : IEnumerable<float>
{
    private Node? head;

    /// <summary>Кількість елементів у списку.</summary>
    public int Count
    {
        get
        {
            int count = 0;
            Node? current = head;

            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }
    }

    /// <summary>Чи порожній список.</summary>
    public bool IsEmpty => head == null;

    /// <summary>Додає елемент у кінець списку.</summary>
    public void Add(float value)
    {
        Node newNode = new Node(value);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node current = head;

        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = newNode;
    }

    /// <summary>
    /// Додає елемент одразу після другого елемента списку.
    /// Якщо список порожній — новий елемент стає першим.
    /// Якщо в списку лише один елемент — новий елемент стає другим.
    /// </summary>
    public void InsertAfterSecond(float value)
    {
        Node newNode = new Node(value);

        if (head == null)
        {
            head = newNode;
            return;
        }

        if (head.Next == null)
        {
            head.Next = newNode;
            return;
        }

        newNode.Next = head.Next.Next;
        head.Next.Next = newNode;
    }

    /// <summary>Виводить елементи списку в один рядок.</summary>
    public void Print()
    {
        if (head == null)
        {
            Console.WriteLine("(список порожній)");
            return;
        }

        Node? current = head;

        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }

        Console.WriteLine();
    }

    /// <summary>Повертає перший від'ємний елемент списку, або null, якщо такого немає.</summary>
    public float? FindFirstNegative()
    {
        Node? current = head;

        while (current != null)
        {
            if (current.Value < 0)
            {
                return current.Value;
            }

            current = current.Next;
        }

        return null;
    }

    /// <summary>Повертає середнє арифметичне елементів списку.</summary>
    /// <exception cref="InvalidOperationException">Якщо список порожній.</exception>
    public float GetAverage()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Неможливо обчислити середнє: список порожній.");
        }

        float sum = 0;
        int count = 0;

        Node? current = head;

        while (current != null)
        {
            sum += current.Value;
            count++;
            current = current.Next;
        }

        return sum / count;
    }

    /// <summary>Повертає суму елементів, більших за середнє значення списку.</summary>
    public float SumGreaterThanAverage()
    {
        if (head == null)
        {
            return 0;
        }

        float average = GetAverage();
        float sum = 0;

        Node? current = head;

        while (current != null)
        {
            if (current.Value > average)
            {
                sum += current.Value;
            }

            current = current.Next;
        }

        return sum;
    }

    /// <summary>Створює та повертає новий список, що складається лише з додатних елементів поточного.</summary>
    public FloatLinkedList GetPositiveElements()
    {
        FloatLinkedList newList = new FloatLinkedList();

        Node? current = head;

        while (current != null)
        {
            if (current.Value > 0)
            {
                newList.Add(current.Value);
            }

            current = current.Next;
        }

        return newList;
    }

    /// <summary>Видаляє з поточного списку всі від'ємні елементи.</summary>
    public void RemoveNegativeElements()
    {
        while (head != null && head.Value < 0)
        {
            head = head.Next;
        }

        Node? current = head;

        while (current != null && current.Next != null)
        {
            if (current.Next.Value < 0)
            {
                current.Next = current.Next.Next;
            }
            else
            {
                current = current.Next;
            }
        }
    }

    /// <summary>Доступ до елемента списку за індексом (0-базований).</summary>
    /// <exception cref="IndexOutOfRangeException">Якщо індекс від'ємний або виходить за межі списку.</exception>
    public float this[int index]
    {
        get
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Неправильний індекс.");
            }

            Node? current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current.Value;
                }

                current = current.Next;
                currentIndex++;
            }

            throw new IndexOutOfRangeException("Елемент не знайдено.");
        }
    }

    public IEnumerator<float> GetEnumerator()
    {
        Node? current = head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
