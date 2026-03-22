
namespace myDoubleLinkList
{
    internal class Node<T>
    {
        public T Data;
        public Node<T> Prev;
        public Node<T> Next;

        public Node(T data) 
        {
            Data = data;
            Prev = null;
            Next = null;
        }
    }
}
