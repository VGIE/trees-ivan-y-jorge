using Lists;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;

    public ListNode<T> Previous = null;

    

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;
    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list
        return m_numItems;
        
    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds

        ListNode<T> node = First;
       
        if (First == null || index < 0 || index >= m_numItems) 
        {
            return default(T);
        }

        for (int i = 0; i < m_numItems; i++)
        {
            if (i == index)
            {
                return node.Value;
            }
            node = node.Next;
        }

        return default(T);
        

        
    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list

        //Guardamos value en newNode
        ListNode<T> newNode = new ListNode<T>(value);

        //Si esta vacio
        if (First == null)
        {
            First = newNode;
            Last = newNode;
        }
        //si hay un First
        else
        {
            newNode.Previous = Last;
            Last.Next = newNode;
            Last = newNode;
        }
        m_numItems++;
        
            
    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds

        //Si esta vacio o index esta "out of bounds"
        if (index < 0 || index >= m_numItems)
        {
            return default(T);
        }

        ListNode<T> node = First;


        //Si se quiere eleminar el primer nodo
        if (index == 0)
        {
            T removedValue = node.Value;
            First = node.Next;

            if (First != null)
                First.Previous = null;
            else
                Last = null; // la lista quedó vacía

            m_numItems--;
            return removedValue;
        }
        
        // Movernos hasta el nodo a eliminar
        for (int i = 0; i < index; i++)
        {
            node = node.Next;
        }
        T valueToRemove = node.Value;

        // Caso 2: eliminar último
        if (node == Last)
        {
            Last = node.Previous;
            Last.Next = null;
        }
        else
        {
            // Caso 3: eliminar nodo del medio
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }

        m_numItems--;
        return valueToRemove;
    }

        /*for (int i = 0; i < m_numItems; i++)
        {

            if (i == index - 1)
            {
                removedVariable = node.Next.Value;
                node.Next = node.Next.Next;
                m_numItems--;
                return removedVariable;
            }
        }
            
        */

        /*

        int i = 0;
        while (node != null && i < index - 1)
        {
            node = node.Next;
            i++;
        }

        if (node == null || node.Next == null)
        {
            return default(T);
        }

        removedVariable = node.Next.Value;
        node.Next = node.Next.Next;
        if (node.Next == null) Last = node;
        m_numItems--;
        return removedVariable;
        */
    

    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        m_numItems = 0;
        First = null;
        Last = null;
        
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
        ListNode<T> node = First;
        while (node != null)
        {
            yield return node.Value;
            node = node.Next;
        }

    }
    
    public int getLastIndex()
    {
        return m_numItems - 1;
    }
}
