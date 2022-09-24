using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class LRUCache
    {
        Node head = new Node(0, 0), tail = new Node(0, 0);
        Dictionary<int, Node> keyValues = new Dictionary<int, Node>();
        int capacity;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            head.next = tail;
            tail.prev = head;
        }

        public int get(int key)
        {
            if (keyValues.ContainsKey(key))
            {
                Node node = keyValues[key];
                Remove(node);
                Insert(node);
                return node.value;
            }

            return -1;
        }

        public void put(int key,int value)
        {
            if (keyValues.ContainsKey(key))
            {
                Remove(keyValues[key]);
            }
            if(keyValues.Count == capacity)
            {
                Remove(tail.prev);
            }

            Insert(new Node(key, value));
        }

        private void Remove(Node node)
        {
            keyValues.Remove(node.key);
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        private void Insert(Node node)
        {
            keyValues.Add(node.key, node);
            Node headNext = head.next;
            head.next = node;
            node.prev = head;
            node.next = headNext;
            headNext.prev = node;
        }



        public class Node
        {
            public int key, value;
            public Node prev, next;

            public Node(int key, int value)
            {
                this.key = key;
                this.value = value;
            }
        }

    }
}
