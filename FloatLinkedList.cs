using System.Collections;

namespace Lab7;

public class FloatLinkedList : IEnumerable<float>
{
    private Node? head;

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

    public bool IsEmpty => head == null;

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
