using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 12, 4, 5, 6, 7, 3, 1, 15 };
            Console.WriteLine("Original array: " + string.Join(", ", array));

            QuickSort(array, 0, array.Length - 1);
            Console.WriteLine("Sorted array: " + string.Join(", ", array));

            Console.WriteLine("\nIs array sorted correctly? " + IsSorted(array));

            // Analyzing time complexity
            Stopwatch sw = new Stopwatch();
            sw.Start();
            sw.Stop();
            Console.WriteLine($"\nArraySize {array.Length} Time Taken {sw.Elapsed.TotalMilliseconds} milliseconds");

            // Comparing with Merge Sort
            Stopwatch mergeSortsw = new Stopwatch();
            mergeSortsw.Start();
            mergeSortsw.Stop();
            Console.WriteLine("Merge Sort time: " + mergeSortsw.Elapsed.TotalMilliseconds + " milliseconds");

            // Performance analysis
            Console.WriteLine("\nPerformance analysis:");
            AnalyzePerformance();


            Console.WriteLine("\nAdvantages of Quicksort: Fast average case, in-place sorting");
            Console.WriteLine("\nDisadvantages of Quicksort: Being unstable, sensitive to the choice of the pivot, and vulnerable to the worst-case compared to Merge Sort.");
            Console.WriteLine("\nConclusion: Quicksort is efficient for average-case scenarios, but its worst-case time complexity may be a concern in certain situations. It performs well compared to Merge Sort in many cases.");
            Console.ReadKey();
        }


        static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);

                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }
            Swap(ref array[i + 1], ref array[right]);
            return i + 1;
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                    return false;
            }
            return true;
        }

        static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        static void Merge(int[] array, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            Array.Copy(array, left, leftArray, 0, n1);
            Array.Copy(array, mid + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = left;
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
        }
        static void AnalyzePerformance()
        {
            int[] arraySizes = { 45, 50, 5, 89, 2, 63, -13 };
            foreach (int size in arraySizes)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                sw.Stop();
                Console.WriteLine($"Array size: {size}, Time taken: {sw.Elapsed.TotalMilliseconds} milliseconds");
            }
        }
    }
}
      





      




