using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularQueueUsingLinkedList
{
    internal class Program
    {
        class Node
        {
            public int Data;
            public Node Next;
            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        class CircularQueue
        {
            private Node front;
            private Node rear;

            public CircularQueue()
            {
                front = rear = null;
            }

            public bool IsEmpty()
            {
                return front == null && rear == null;
            }

            public void Enqueue(int x)
            {
                Node newNode = new Node(x);
                if (IsEmpty())
                {
                    front = rear = newNode;
                    rear.Next = front;
                }
                else
                {
                    rear.Next = newNode;
                    rear = newNode;
                    rear.Next = front;
                }
                Console.WriteLine($"{x} enqueued successfully.");
            }

            public void Dequeue()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Queue is empty");
                    return;
                }
                if (front == rear)
                {
                    Console.WriteLine($"Dequeued element: {front.Data}");
                    front = rear = null;
                }
                else
                {
                    Console.WriteLine($"Dequeued element: {front.Data}");
                    front = front.Next;
                    rear.Next = front;
                }
            }

            public void Peek()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Queue is empty");
                    return;
                }
                Console.WriteLine($"Front element: {front.Data}");
            }

            public void Display()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Queue is empty");
                    return;
                }
                Console.Write("Queue elements: ");
                Node temp = front;
                do
                {
                    Console.Write(temp.Data + " ");
                    temp = temp.Next;
                } while (temp != front);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            CircularQueue q = new CircularQueue();

            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);
            q.Enqueue(40);
            q.Enqueue(50);

            q.Display();
            q.Peek();

            q.Dequeue();
            q.Dequeue();

            q.Display();

            q.Enqueue(60);
            q.Enqueue(70);

            q.Display();
            q.Peek();

            Console.ReadLine();
        }
    }
}
