using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array:");
            List<int> array = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            array.Sort();

            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Enter element to find or \"end\" to exit:");
                string input = Console.ReadLine();

                int toFind = 0;
                if (input == "end")
                {
                    break;
                }
                else
                {
                    toFind = int.Parse(input);
                }

                bool recursive = recursiveBinarySearch(array, toFind, 0, array.Count - 1);
                bool iterative = iterativeBinarySearch(array, toFind, 0, array.Count - 1);

                Console.WriteLine("Recursive: " + (recursive ? "found" : "not found"));
                Console.WriteLine("Iterative: " + (iterative ? "found" : "not found"));
                Console.WriteLine();
            }
        }

        static bool recursiveBinarySearch(List<int> array, int toFind, int left, int right)
        {
            if (left > right)
            {
                return false;
            }

            int mid = (left + right) / 2;

            if (toFind == array[mid])
            {
                return true;
            }
            else if (toFind < array[mid])
            {
                return recursiveBinarySearch(array, toFind, left, mid - 1);
            }
            else
            {
                return recursiveBinarySearch(array, toFind, mid + 1, right);
            }
        }

        static bool iterativeBinarySearch(List<int> array, int toFind, int left, int right)
        {
            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (toFind == array[mid])
                {
                    return true;
                }
                else if (toFind < array[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return false;
        }
    }
}
