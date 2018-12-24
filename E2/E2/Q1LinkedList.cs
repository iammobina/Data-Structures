using System;
using System.Collections;
using System.Collections.Generic;

namespace E2
{       

    public class Q1LinkedList
    {
        public class Node
        {
            public Node(int key) { this.Key = key;  }
            public int Key;
            public Node Next = null;
            public Node Prev = null;
            public override string ToString() => ToString(4);

            public string ToString(int maxDepth)
            {
                return maxDepth == 1 || Next == null ?
                    $"{Key.ToString()}" + (Next != null ? "..." : string.Empty) :
                    $"{Key.ToString()} {Next.ToString(maxDepth - 1)}";
            }
        }

        private Node Head = null;
        private Node Tail = null;

        public void Insert(int key)
        {
            if (Head == null)
            {
                Head = Tail = new Node(key);
            }
            else
            {
                var newNode = new Node(key);
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
        }

        public override string ToString() => Head.ToString();

        public void Reverse()
        {
            // زحمت بکشید پیاده سازی کنید
            // اگر نیاز بود میتوانید متد اضافه کنید

            while(Tail.Next == null)
            {
                //3-5-9
                //9 
                //تمش اینجوریه حالا باز دقیق ترشو فک کن بعد پیاده
                Node temp = new Node(Tail.Key);//9
                //temp prev next =null
                temp.Next = Tail.Prev;//5
                temp.Next.Next.Key = Head.Key;//3
                Reverse();
                //                              //thanks god
                //temp.Next = Tail.Prev;//5
                //temp.Next.Next.Key = Head.Key;//3
            }
           
        }

        public void DeepReverse()
        {
            // زحمت بکشید پیاده سازی کنید
            // اگر نیاز بود میتوانید متد اضافه کنید
        }

        public IEnumerable<int> GetForwardEnumerator()
        {
            var it = this.Head;
            while (it != null)
            {
                yield return it.Key;
                it = it.Next;
            }
        }

        public IEnumerable<int> GetReverseEnumerator()
        {
            var it = this.Tail;
            while (it != null)
            {
                yield return it.Key;
                it = it.Prev;
            }
        }
    }
}