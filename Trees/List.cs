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
        if (First == null || index < 0 || index >= m_numItems)
        {
            return default(T);
        }

        ListNode<T> node = First;
        T removedVariable = default(T);
  

        //Si se quiere eleminar el primer nodo
        if (index == 0)
        {
            // Y es el unico
            if (First == Last)
            {
                removedVariable = node.Value;
                First = null;
                Last = null;
                m_numItems--;
                return removedVariable;
            }
            //No es el Unico
            removedVariable = node.Value;
            First = node.Next;
            m_numItems--;
            return removedVariable;
        }
        //Si se quiere eleminar el ultimo nodo
        if (index == m_numItems - 1)
        {
            /*
            for (int i = 0; i < m_numItems; i++)
            {
                if (node.Next.Next == null)
                {
                    removedVariable = node.Next.Value;
                    Last = node;
                    m_numItems--;
                    return removedVariable;
                }
                node = node.Next;
            }
            */

            removedVariable = Last.Value;
            Last = Last.Previous;
            m_numItems--;
            return removedVariable;
        }


        //Si eleminamos una que no es no la primera ni la ultima

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
        if(index != m_numItems - 1 && index != 0)
        {
            for(int i = 0; i<m_numItems;i++)
            {

                if (i == index - 1)
                {
                    removedVariable = node.Next.Value;
                    node.Next = node.Next.Next;
                    node.Next.Previous = node.Next.Previous.Previous;
                    m_numItems--;
                    return removedVariable;
                }
            }
        }


        return default(T);

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
    }

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
