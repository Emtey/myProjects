using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    /* Sam's house has an apple tree and an orange tree that yield an abundance of fruit. In the diagram below, the red region denotes his house, where
      is the start point, and is the endpoint. The apple tree is to the left of his house, and the orange tree is to its right. You can assume the trees
      are located on a single point, where the apple tree is at point, and the orange tree is at point 
      */
      /* input s and t are beginning area of Sam's house
       * a and b are the amount of apples and oranges respectively
       */

    // Complete the countApplesAndOranges function below.
    static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
    {
        int appleCount = 0;
        int orangeCount = 0;

        foreach (int apple in apples)
        {
            int dropLocation = (a + apple);
            if (dropLocation >= s && dropLocation <= t)
                appleCount++;
        }

        foreach (int orange in oranges)
        {
            int dropLocation = (b + orange);
            if (dropLocation >= s && dropLocation <= t)
                orangeCount++;
        }

        Console.WriteLine(appleCount + "\n" + orangeCount);

    }

    /* testing set:
     * 7 11
     * 5 15
     * 3 2
     * -2 2 1
     * 5 -6
     * Output:
     * 1
     * 1
     */

    static void Main(string[] args)
    {
        string[] st = Console.ReadLine().Split(' ');

        int s = Convert.ToInt32(st[0]);

        int t = Convert.ToInt32(st[1]);

        string[] ab = Console.ReadLine().Split(' ');

        int a = Convert.ToInt32(ab[0]);

        int b = Convert.ToInt32(ab[1]);

        string[] mn = Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        int[] apples = Array.ConvertAll(Console.ReadLine().Split(' '), applesTemp => Convert.ToInt32(applesTemp))
        ;

        int[] oranges = Array.ConvertAll(Console.ReadLine().Split(' '), orangesTemp => Convert.ToInt32(orangesTemp))
        ;
        countApplesAndOranges(s, t, a, b, apples, oranges);
    }
}
