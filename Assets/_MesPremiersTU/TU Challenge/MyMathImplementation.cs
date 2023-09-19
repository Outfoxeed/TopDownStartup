using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TU_Challenge
{
    public class MyMathImplementation
    {
        internal static int Add(int a, int b)
        {
            return a + b;
        }

        // Destructive func
        internal static List<int> GenericSort(List<int> toSort, Func<int, int, int> isInOrder)
        {
            if (toSort == null)
            {
                throw new ArgumentException("Given list to sort is null");
            }
            if (isInOrder == null)
            {
                throw new ArgumentException("isInOrder comparer is null");
            }
            
            for (int i = 0; i < toSort.Count; i++)
            {
                bool sorted = true;
                for (int j = 0; j < toSort.Count - 1; j++)
                {
                    int comparison = isInOrder.Invoke(toSort[j], toSort[j + 1]);
                    if (comparison == -1)
                    {
                        sorted = false;
                        (toSort[j], toSort[j + 1]) = (toSort[j + 1], toSort[j]);
                    }
                }

                if (sorted)
                {
                    break;
                }
            }

            return toSort;
        }

        internal static List<int> GetAllPrimary(int a)
        {
            List<int> results = new();
            for (int i = 1; i <= a; i++)
            {
                if (!IsPrimary(i))
                {
                    continue;
                }
                
                results.Add(i);
            }
            return results;
        }

        internal static bool IsDivisible(int a, int b)
        {
            return a % b == 0;
        }

        internal static bool IsEven(int a)
        {
            return a % 2 == 0;
        }

        internal static int IsInOrder(int a, int b)
        {
            if (a == b)
            {
                return 0;
            }
            return a < b ? 1 : -1;
        }

        internal static int IsInOrderDesc(int arg1, int arg2)
        {
            return -IsInOrder(arg1, arg2);
        }

        internal static bool IsListInOrder(List<int> list)
        {
            for (int i = 0; i < list.Count-1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    return false;
                }   
            }
            return true;
        }

        internal static bool IsMajeur(int age)
        {
            if (age < 0)
            {
                throw new ArgumentException("Given age is negative");
            }

            if (age > 140)
            {
                throw new ArgumentException("Given age is to high");
            }
            return age >= 18;
        }

        internal static bool IsPrimary(int a)
        {
            if (a <= 1)
            {
                return false;
            }
            
            for (int i = 2; i < a; i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        internal static int Power(int a, int b)
        {
            int result = 1;
            for (int i = 0; i < b; i++)
            {
                result *= a;
            }
            return result;
        }

        internal static int Power2(int a)
        {
            return a * a;
        }

        // Destructive method
        internal static List<int> Sort(List<int> toSort)
        {
            return GenericSort(toSort, IsInOrder);
        }
    }
}
