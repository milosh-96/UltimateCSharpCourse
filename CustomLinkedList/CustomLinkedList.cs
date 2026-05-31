using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinkedListImplementation;
public class CustomLinkedList<T> : ILinkedList<T?>
{
    Node<T>? head;
    private Node<T>? last;
    private int count = 0;

    public int Count => count;

    public bool IsReadOnly => false;

    public void AddToEnd(T? item)
    {
        throw new NotImplementedException();
    }

    public void AddToFront(T? item)
    {
        head = new Node<T>(item) { Next = head };
        count++;
    }

    public void Add(T? item)
    {
        AddToFront(item);
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T? item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T?[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T?> GetEnumerator()
    {
        foreach(var node in GetNodes())
        {
            yield return node.Value;
        }
    }

    public bool Remove(T? item)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerable<Node<T>> GetNodes()
    {
        if(head is null) { yield break; }
        var currentHead = head;
        while(currentHead is not null)
        {
            yield return currentHead;
            currentHead = currentHead.Next;
        }
    }
}
