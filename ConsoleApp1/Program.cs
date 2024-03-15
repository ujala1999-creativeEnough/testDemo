using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

class KeyValuePair<TKey, TValue>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }
    public KeyValuePair(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
    LinkedList<KeyValuePair<int, char>>[] arrayOfLinkedLists = new LinkedList<KeyValuePair<int, char>>[10];

    public void Add(int v1, char v2)
    {
        int hashing = HashValue(v1,v2);
    }

    public char Get(int key)
    {
        int pos = key % 10;
        if (arrayOfLinkedLists[pos].Count() == 0)
        {
            Console.WriteLine("Value doesn't exist");
            return ' ';
        }
        var currentNode = arrayOfLinkedLists[pos].First;
        while (currentNode != null)
        {
            if (currentNode.Value.Key == key)
                return currentNode.Value.Value;
            currentNode = currentNode.Next;
        }
        Console.WriteLine("Value doesn't exist");
        return ' ';
    }

    public bool Delete(int key)
    {
        int pos = key % 10;
        if (arrayOfLinkedLists[pos].Count()==0)
            return false;
        for(int i = 0;i < arrayOfLinkedLists[pos].Count();i++)
        {
            var currentNode = arrayOfLinkedLists[pos].First;
            if (currentNode.Value.Key == key)
                return true;
            while (currentNode != null)
                currentNode = currentNode.Next;
        }
        return false;
    }
    public void printHashTable()
    {
        for (int i = 0; i < arrayOfLinkedLists.Length; i++)
        {
            Console.WriteLine($"Linked List {i}:");
            foreach (var pair in arrayOfLinkedLists[i])
            {
                Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
            }
            Console.WriteLine();
        }
    }
    public int HashValue(int v1, char v2)
    {
        int position = v1 % 10;
        arrayOfLinkedLists[position].AddLast(new KeyValuePair<int, char>(v1,v2));
        return position;
    }
    public void initializeHashTable()
    {
        for (int i = 0; i < 10; i++)
        {
            arrayOfLinkedLists[i] = new LinkedList<KeyValuePair<int, char>>();
        }
        arrayOfLinkedLists[0].AddLast(new KeyValuePair<int, char>(1, 'U'));
    }
}
class Program
{
    static void Main(string[] args)
    {
        KeyValuePair<int, char> dictionary = new KeyValuePair<int, char>(1,'U');
        dictionary.initializeHashTable();
        dictionary.Add(2, 'A');
        dictionary.Add(12, 'C');
        dictionary.printHashTable();
        Console.WriteLine("Value for key 'Two': " + dictionary.Get(2));
        Console.WriteLine(dictionary.Delete(2));
    }
}
