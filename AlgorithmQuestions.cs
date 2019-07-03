// Author: Nick Eekhof
// Description: This class implements various algorithms to solve the problems presented in Assignment 2

using System;
public static class MainClass
{
    public static void Main()
    {
        // Required variables
        int x = 9;
        int[] theArray = new int[10];

        // Populate the array with values
        for (int i = 0; i < theArray.Length; ++i)
            theArray[i] = i + 1; 

        // Output the results of each function
        Console.WriteLine("{0} can be represented as a sum in the array: {1}", x, QuestionFour(theArray, x));
        QuestionFive(theArray, x);
        Console.WriteLine("{0} is the maximum local value in the array", QuestionThree());
        Console.ReadKey();
    }

    // Author: Nick Eekhof
    // Description: Returns true if two values in an array sum to a provided value
    // Parameters: arr => the array to check, x => the provided value
    // Answer to the subsequent question posed: We could exploit the properties of a sorted list.
    // If x represents the sum to check for, we would not need to check values >= x, as they would
    // not be able to be used in a sum which equalled x (we could use a negative value, but this could never be the case in a sorted list).
    public static bool QuestionFour(int [] arr, int x)
    {
        // Required variables => sum and a boolean flag
        bool sumFound = false;
        int sum;

        // Iterate through the array one term at a time
        // Due to the commutativity of addition, it is redundant to check elements before the current index
        for (int i = 0; i < arr.Length - 1 && !sumFound; ++i)
        {
            // Check every susbsequent value after the term
            for (int j = i + 1; j < arr.Length - 1 && !sumFound; ++j)
            {
                // Compute the sum
                sum = arr[i] + arr[j];

                // If the sum is found, set the flag to true
                if (sum == x)
                    sumFound = true;
            }
        }

        // Return the value of the flag
        return sumFound;
    }

    // Author: Nick Eekhof
    // Description: This function returns a value which is a local max, such that arr[i - 1] < arr[i] > arr[i + 1]. Returns 0 if no local max
    // Parameters: arr => the array
    // Answer to the subsequent question posed: To account for plateaus, we would need to be able to recognize a pattern of plateaus.
    // Once we recognized the pattern, we could then ignore the repeating values, check the values before and after the plateau, 
    // and then see if we had a valid local maximum.
    public static int QuestionThree()
    {
        // Required variables 
        int prev, current, next;
        int[] arr = { 1,7,3,4,5,7,8,9,10 };

        // Handle certain special cases
        if (arr.Length <= 2)
        {
            // Not possible to have a local max meeting the condition in this case
            return 0; 
        }
        else if (arr.Length == 3)
        {
            // The local max must be in the middle, if it does not satisfy the pattern, then we have none
            current = arr[1];
            next = arr[2];
            prev = arr[0];

            if (prev < current && current > next)
                return current;
            else
                return 0;
        }
        else if (arr.Length == 4)
        {
            // Start at the end and work right
            current = arr[1];
            next = arr[2];
            prev = arr[0];

            if (prev < current && current > next)
                return current;
            else
            {
                // Move up one, then check
                current = arr[2];
                next = arr[3];
                prev = arr[1];

                if (prev < current && current > next)
                    return current;
                return 0;
            }
        }
        else
        {
            // Start in the middle of the array and work left
            for (int i = arr.Length / 2; i >= 0; i -= 3)
            {
                // So long as we are in bounds, get the current, next and previous and check
                if (i - 1 >= 0 && i - 1 <= 0 && i >= 0 && i + 1 >= 0)
                {
                    prev = arr[i - 1];
                    current = arr[i];
                    next = arr[i + 1];
                    if (prev < current && current > next)
                        return current;
                }

                // So long as we are in bounds, get the current, next and previous and check
                if (i - 2 >= 0 && i - 1 >= 0 && i >= 0)
                {
                    prev = arr[i - 2];
                    current = arr[i - 1];
                    next = arr[i];
                    if (prev < current && current > next)
                        return current;
                }

                // So long as we are in bounds, get the current, next and previous and check
                if (i >= 0 && i + 1 >= 0 && i + 2 >= 0)
                {
                    prev = arr[i];
                    current = arr[i + 1];
                    next = arr[i + 2];
                    if (prev < current && current > next)
                        return current;
                }
            }

            // Start at the middle and work right
            for (int i = arr.Length / 2; i < arr.Length; i += 3)
            {
                if (i <= arr.Length - 1 && i + 1 <= arr.Length - 1 && i - 1 <= arr.Length - 1)
                {
                    prev = arr[i - 1];
                    current = arr[i];
                    next = arr[i + 1];
                    if (prev < current && current > next)
                        return current;
                }

                // So long as we are in bounds, get the current, next and previous and check
                if (i - 2 <= arr.Length - 1 && i - 1 <= arr.Length - 1 && i <= arr.Length - 1)
                {
                    prev = arr[i - 2];
                    current = arr[i - 1];
                    next = arr[i];
                    if (prev < current && current > next)
                        return current;
                }

                // So long as we are in bounds, get the current, next and previous and check
                if (i <= arr.Length - 1 && i + 1 <= arr.Length - 1 && i + 2 <= arr.Length - 1)
                {
                    prev = arr[i];
                    current = arr[i + 1];
                    next = arr[i + 2];
                    if (prev < current && current > next)
                        return current;
                }
            }
        }

        return 0; // Return 0 if not found
    }

    // Author: Nick Eekhof
    // Description: This function outputs all of the subarrays of an array which are less than some provided value, x
    // Parameters: arr => the array to check, x => the provided value
    public static void QuestionFive(int[] arr, int x)
    {
        // Required variables
        int sum = 0, maxIndex = 0;

        // Sort the list
        Array.Sort(arr);

        // Find the maximum index of which we need to check
        for (int i = 0; i < arr.Length; ++i)
        {
            if (arr[i] > x)
            {
                maxIndex = i;
                break;
            }
        }

        // Iterate over the array
        for (int i = 0; i < maxIndex; ++i)
        {
            for (int j = i + 1; j < maxIndex; ++j)
            {
                sum = arr[i] + arr[j];

                // If a valid subarray is found, output the results, and add them to the list to check for more subarrays
                if (sum < x)
                    Console.WriteLine(arr[i].ToString() + "  " + arr[j].ToString());
            }
        }

        // I am way to tired right now to even try and figure out subsets larger than two...
    }
}
