using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 6, 2, 7, 8, 0, 9, 3, 1, 5 };
            Sort(ref arr);
        }

        static void Sort(ref int[] arr)
        {
            int[] temp = new int[arr.Length];
            Sort(ref arr, 0, arr.Length - 1, ref temp);
            Print(temp);
        }

        static void Print(int[] arr)
        {
            foreach (var i in arr)
            {
                Console.WriteLine(i.ToString() + " ");
            }
        }

        static void Sort(ref int[] arr, int low, int high, ref int[] temp)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                Sort(ref arr, low, mid, ref temp);
                Sort(ref arr, mid + 1, high, ref temp);
                Marge(ref arr, low, mid, high, ref temp);
            }
        }

        static void Marge(ref int[] arr, int low, int mid, int high, ref int[] temp)
        {
            int i = low;
            int j = mid + 1;
            int k = 0;
            while (i <= mid && j <= high)
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                }
            }
            while (i <= mid)
            {
                temp[k++] = arr[i++];
            }
            while (j <= high)
            {
                temp[k++] = arr[j++];
            }
            k = 0;
            //将temp中的元素全部拷贝到原数组中
            while (low <= high)
            {
                arr[low++] = temp[k++];
            }
        }
    }
}
