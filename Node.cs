namespace Lab7;

public class Node
{
    public float Value { get; set; }
    public Node? Next { get; set; }

    public Node(float value)
    {
        Value = value;
        Next = null;
    }
}