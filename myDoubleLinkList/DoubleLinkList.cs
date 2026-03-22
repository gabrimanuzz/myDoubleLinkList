using System;
using System.Collections;

namespace myDoubleLinkList
{
    public class DoubleLinkList<T> : IEnumerable<T>
    {
        private Node<T>? head;
        private Node<T>? tail;

        public int Count { get; private set; }

        public DoubleLinkList()
        {
            head = null;
            tail = null;
        }

        public void Add(T item) 
        {
            Node<T> node = new Node<T>(item);

            if (head == null) 
            {
                head = tail = node;
                Count++;
                return;
            }

            tail!.Next = node;
            node.Prev = tail;
            tail = node;

            Count++;
        }

        public T ElementAt(int index) 
        {
            Node<T> node = GetNodeByIndex(index);
            return node.Data;
        }

        public void RemoveAt(int index) 
        {
            Node<T> node = GetNodeByIndex(index);


            if (node.Prev != null)
                node.Prev.Next = node.Next;
            else
                head = node.Next;
                
            if (node.Next != null)
                node.Next.Prev = node.Prev;
            else
                tail = node.Prev;


            Count--;
        }

        public void SetAt(int index, T newItem)
        {
            Node<T> node = GetNodeByIndex(index);
            node.Data = newItem;
        }


        private Node<T> GetNodeByIndex(int index)
        {
            if (head == null || index >= Count || index < 0)
                throw new IndexOutOfRangeException("Indice non valido");

            Node<T> node;

            if (index <= Count / 2)
            {
                node = head;
                for (int i = 0; i < index; i++)
                    node = node!.Next;
            } else
            {
                node = tail;
                for (int i = Count - 1; i > index; i--)
                    node = node!.Prev;
            }

            return node!;
        }

        public int Find(T item)
        {
            Node<T>? current = head;
            int index = 0;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }



        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
