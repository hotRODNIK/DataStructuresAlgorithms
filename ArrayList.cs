// Author: Nick Eekhof
// Description: This class implements an arraylist specifically for a mobile object

using System;
public class ArrayList
{
    // An array of mobile objects
    private MobileObject[] list;

    // Creates a list with two spaces allocated in memory
    public ArrayList()
    {
        list = new MobileObject[2];
    }

    // Grows the list as needed
    private void Grow()
    {
        // Create a new array twice the size of the old one
        MobileObject[] newList = new MobileObject[list.Length + 1];

        // Copy all of the values into the new list, and reassign the old list
        for (int i = 0; i < list.Length; ++i)
            newList[i] = list[i];
        list = newList;
    }

    // Adds a piece of data to the end of the list
    public void Append(MobileObject data)
    {
        if (list != null)
        {
            // Boolean flag for use in the loops
            bool added = false;

            // If the last position of the list is empty, add some data
            for (int i = list.Length - 1; i >= 0 && !added; --i)
            {
                if (list[i] == null)
                {
                    list[i] = data;
                    added = true;
                }
            }

            // If nothing was added, we need to grow the list
            if (added == false)
            {
                // Grow the list and reset the flag
                added = false;
                Grow();

                // Find the first empty position and add the data
                for (int i = list.Length - 1; i >= 0 && !added; --i)
                {
                    if (list[i] == null)
                    {
                        list[i] = data;
                        added = true;
                    }
                }
            }
        }
        else
        {
            // Create a new list, then add something to it
            list = new MobileObject[2];
            list[0] = data;
        }
    }

    // Sorts the list in ascending order using bubble sort
    public void InPlaceSort()
    {
        if (list != null)
        {
            // Required Variables
            int sentinel = 0, count = 0;
            MobileObject min, max;

            // Check to see which is the maximum value we can sort to (skip null values)
            for (int i = 0; i < list.Length; ++i)
            {
                if (list[i] != null)
                    ++count;
            }

            // While there are still unsorted values, sort
            while (sentinel != count - 1)
            {
                sentinel = 0;
                for (int i = 0; i < count - 1; ++i)
                {
                    // Assign a minimum and a maximum
                    min = list[i];
                    max = list[i + 1];
                    ++sentinel;

                    if (min > max)
                    {
                        // Swap if needed (has been overridden to sort by id value)
                        list[i + 1] = min;
                        list[i] = max;
                        sentinel = 0;
                    }
                }
            }
        }
        else
            Console.WriteLine("Nothing to see here... can't sort a list which has been deleted.");
    }

    // Deletes the last item in the list
    public void DeleteLast()
    {
        // If the entire list has been deleted, then we can't delete it
        if (list == null)
            Console.WriteLine("Nothing to see here... the list has been deleted.");
        else if (list[list.Length - 1] != null) // If the list is full and has no null values, handle this special case
            list[list.Length - 1] = null;
        else // Else traverse the list to find the value to delete
        {
            // Find the first empty position, then delete the value prior to it
            for (int i = list.Length - 1; i >= 0; --i)
            {
                if (list[i] != null)
                {
                    list[i] = null;
                    break;
                }
            }
        }
    }

    // Deletes the entire list
    public void DeleteAll()
    {
        if (list != null)
        {
            // Delete the whole list
            list = null;
        }
        else
            Console.WriteLine("Nothing to see here... the list has already been deleted.");
    }

    // Prints the list starting at the top
    public void PrintAllForward()
    {
        try
        {
            // Print each item containing a value starting at the top
            for (int i = 0; i < list.Length; ++i)
            {
                if (list[i] != null)
                    Console.WriteLine(list[i].ToString());
            }
        }
        catch (NullReferenceException e)
        {
            // If there's a null reference exception which occurs, print off an error
            Console.WriteLine("Can not print a list with null values. " + e.Message);
        }
    }

    // Prints the list starting at the bottom
    public void PrintAllBackward()
    {
        try
        {
            // Print each item containing a value starting at the bottom
            for (int i = list.Length - 1; i >= 0; --i)
            {
                if (list[i] != null)
                    Console.WriteLine(list[i].ToString());
            }
        }
        catch (NullReferenceException e)
        {
            // If there's a null reference exception which occurs, print off an error
            Console.WriteLine("Can not print a list with null values. " + e.Message);
        }
    }
}
