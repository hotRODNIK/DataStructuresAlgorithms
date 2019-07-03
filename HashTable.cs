// Author: Nick Eekhof
// Description: This class implements a simple hash table using a (very bad) hashing algorithm
// In my defense, I haven't had the opportunity to take Mathematical Cryptography, or figure out how to make a strong 
// hashing algorithm. Been too busy working on Sri's assignments. 

using System;
public class HashTable
{
    // An array used to implement the hash table
    // O(N) space
    private string[] table;

    // Author: Nick Eekhof
    // Description: A simple constructor which intiailizes the array to some arbitrary value
    // Parameters: size - the size of the table
    // O(1)
    public HashTable(int size)
    {
        table = new string[size];
    }

    // Author: Nick Eekhof
    // Description: Adds a value to the table 
    // Parameters: value - the data to add
    // O(1)
    public void Add(string value)
    {
        // Compute the hash and the index where the data will go
        int hash = Hash(value);
        int index = hash % table.Length;

        // If the spot at the index is free, then we may add it
        if (table[index] == null)
            table[index] = value;
        else
        {
            // Else, probe to find the next closest available index, then set its value
            index = Probe(index);

            // Provided the index is valid, add some data, if not then print off an error
            if (index != -1)
                table[index] = value;
            else
                Console.WriteLine("Could not add data, probe was unsuccessful.");
        }
    }

    // Author: Nick Eekhof
    // Description: Probes the table quadratically to find the next empty index. Returns -1 if no empty slots were found.
    // To remedy this problem we could implement a grow function, or some means to calculate load factor and grow as needed
    // Parameters: index - the index to probe from
    // O(log N)
    private int Probe(int index)
    {
        // Start at the index and probe quadratically to find the next empty index
        for (int i = index, increment = 0; i < table.Length; i += (int)Math.Pow(increment, 2))
        {
            increment++;
            if (table[i] == null)
                return i;
        }

        // Else return the error code
        return -1;
    }

    // Author: Nick Eekhof
    // Description: Finds a value in the table. Since a hash must be unique, there is only a single 
    // spot where any value may go. Therefore, by hashing and computing an index of a value to search for,
    // we can check the value of the index. If there is something there, then it must be the value we are searching for.
    // For redundancy, we should double check the data against the search string and factor in probing.
    // Parameters: value - the data to find
    // Ω(1), O(log N) 
    public bool Find(string value)
    {
        // Compute the hash and the index where the data is
        int hash = Hash(value);
        int index = hash % table.Length;

        // If the value is in the table, and they are equal we are done
        if (table[index] != null && table[index].Equals(value))
            return true;
        else
        {
            // Probe all other possible locations
            for (int i = index, increment = 0; i < table.Length; i += (int)Math.Pow(increment, 2))
            {
                increment++;
                if (table[i] != null && table[i].Equals(value))
                    return true;
            }

            // Else return false
            return false;
        }
    }

    // Author: Nick Eekhof
    // Description: A simple (god-awful) hashing algorithm. In my defense, I haven't taken Mathematical Cryptography (yet)
    // 1. Count the number of characters in the string... we now have a shitty hash
    // O(1)
    private int Hash(string value)
    {
        // Return the hash
        return value.Length;
    }

    // Author: Nick Eekhof
    // Description: This prints off all of the values in the table to the screen
    // O(N)
    public void TableDump()
    {
        // Iterate over the entire table
        for (int i = 0; i < table.Length; ++i)
        {
            // If the current index contains something print it off
            if (table[i] != null)
                Console.WriteLine("Value: {0} - Index: {1}", table[i], i);
        }
    }
}