using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate bool Condition<T>(T n);
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();
            list.add("AA");
            list.add("AA");
            list.add("AA");



            list.RemoveALL(n =>n =="BB");
            for(int i = 0; i <list.Count; ++i)
            {
                Console.Write($"[{list[i]}]");
            }
            Console.WriteLine();
        }
        static bool Compare(int n)
        {
            if ( n >= 2 && n <= 4)
            {
                return true;
            }
            return false;
        }
    }

    class Node<T>
    {
         public T Value;
         public Node<T> next;
         public Node(T n)
     {
                Value = n;
                next = null;
         }


        }
    class LinkedList<T>
    {
        public T this[int i]
        {
            get => Get(i);
        }


            Node<T> Head = null;
            public int Count = 0;

            public void add(T n)
            {
                Count++;
                Node<T> node = new Node<T>(n);
                Node<T> tail = Head;

                while (tail != null)
                {
                    if (tail.next == null)
                    {
                        break;
                    }
                    tail = tail.next;
                }

                if (tail == null)
                {
                    Head = node;
                }
                else
                {
                    tail.next = node;
                }

            }

        public void Remove(T i)
        {
            if (Head == null) return;
            Count--;
            Node<T> node = Head;
            Node<T> Prenode = null;
            // int k = Count ;
            if ( Head.Value.Equals(i))
            {
                Head = Head.next;
                return;
            }
            while (node != null)
            {
                if (node.Value.Equals(i))
                {
                    Prenode.next = node.next;
                    break;
                }
                Prenode = node;
                node = node.next;
                //k--;
            }
           
        }

        public void RemoveAt(int i)
        {
            if (i >= Count) return;
            Count--;
            Node<T> node = Head;
            Node<T> Prenode = null;
            int k = i;
            if ( i == 0)
            {
                Head = Head.next;
                return;
            }
            while (node != null)
            {
                if (k == 0)
                {
                    Prenode.next = node.next;
                    break;
                }
                Prenode = node;
                node = node.next;
                i--;
            }
        }

            public T Get(int i)
            {
                if (i >= Count)
                    return default;
                Node<T> node = Head;
                
                while (node != null)
                {
                    if ( i == 0)
                    {
                        break;
                    }      
                    i--;
                    node = node.next;             
                }
                return node.Value;
            }
        public void RemoveALL(Condition<T> func)
        {
            if (Head == null) return;

            Node<T> node = Head;
            Node<T> Prenode = null;

            while (node != null)
            {
                if (func(node.Value))
                {
                    if(Prenode == null)
                    {
                        node = Head = Head.next;

                    }
                    else
                    {
                        node = Prenode.next = node.next;
                        
                    }
                    Count--;
                    continue;
                }
                Prenode = node;
                node = node.next;

            }
        }

    }


 }

