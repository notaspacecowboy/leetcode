using System.Diagnostics;

namespace LeetCode;


public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class PriorityQueue<T>
{
    private class QueueElement
    {
        public int Key { get; set; }
        public T Val { get; set; }

        public QueueElement(int key, T val)
        {
            Key = key;
            Val = val;
        }
    }

    private List<QueueElement> _queue;
    private const int DefaultCapacity = 10;

    public PriorityQueue()
    {
        _queue = new List<QueueElement>(DefaultCapacity);
        _queue.Add(new QueueElement(0, default));   //dummy head
    }

    public int Count => _queue.Count - 1;

    public int GetParent(int i)
    {
        if (i <= 1)
            return -1;

        return i / 2;
    }

    public int GetLeft(int i)
    {
        return i * 2;
    }

    public int GetRight(int i)
    {
        return i * 2 + 1;
    }

    public void Push(int key, T element)
    {
        _queue.Add(new(Int32.MaxValue, element));
        UpdateKey(_queue.Count - 1, key);
    }

    public T Peek()
    {
        return _queue[1].Val;
    }

    public T Pop()
    {
        T min = _queue[1].Val;

        Swap(1, _queue.Count - 1);
        _queue.RemoveAt(_queue.Count - 1);

        Heapify(1);

        return min;
    }

    private void UpdateKey(int i, int key)
    {
        if (_queue[i].Key < key)
        {
            //error
            return;
        }

        _queue[i].Key = key;

        int parent = GetParent(i);
        while (parent != -1 && _queue[parent].Key > _queue[i].Key)
        {
            Swap(i, parent);
            i = parent;
            parent = GetParent(i);
        }
    }

    private void Heapify(int i)
    {
        if (i >= _queue.Count)
            return;

        int left = GetLeft(i);
        int right = GetRight(i);
        int min = i;

        if (left < _queue.Count && _queue[left].Key < _queue[i].Key)
            min = left;
        if (right < _queue.Count && _queue[right].Key < _queue[min].Key)
            min = right;

        if (min != i)
        {
            Swap(i, min);
            Heapify(min);
        }
    }

    private void Swap(int i, int j)
    {
        (_queue[j], _queue[i]) = (_queue[i], _queue[j]);
    }
}