using System;
using System.Collections;
using System.Collections.Generic;  // explicit type declaration

class Demo1_1 {
    public int demo1_1(int[] A) {
        // write your code in C# 5.0 with .NET 4.5 (Mono)

        int l, lRes = -1;
        Stack<double> stSum = new Stack<double>();
        double lastSum = 0;
        for (l = 0; l < A.Length - 1; l++) {
            // Console.WriteLine("idx: {0}, val: {1}", l, A[l]);
            lastSum += A[l];
            stSum.Push(lastSum);
        }
        Console.WriteLine("sum: {0}", stSum);
        for (l = 0; l < A.Length; l++) {

        }

        // return -1 for no equ idx
        return lRes;
    }
}

class Demo1_2 {
    public int demo1_2(int[] A) {
        // write your code in C# 5.0 with .NET 4.5 (Mono)
        int l, lRes = -1;
        double leftSum = 0, rightSum = 0;
        Stack<double> st = new Stack<double>();
//        Stack st = new Stack(); // non Generic ..requires members func casts

        for (l = 0; l < A.Length; l++) {
            leftSum += A[l];
            st.Push(leftSum);
        }
        //Console.WriteLine("leftSum: {0}, st: {1}", leftSum, st);

        st.Pop();
        st.Pop();
        for (l = A.Length - 1; l > 0; l--) {
            rightSum += A[l];
            leftSum = st.Pop();
//            leftSum = (double)(st.Pop());  // non Generic ..requires members func casts
            Console.WriteLine("leftSum: {0}, rightSum: {1}", leftSum, rightSum);
            if (leftSum == rightSum) {
                lRes = l + 1;
                break;
            }
        }
        // expect 1, 3, or 7
        return lRes;
    }
}

class Task1 {
    public int task1(int[] A) {
        // write your code in C# 5.0 with .NET 4.5 (Mono)

        int lRes = -1;

        if (A.Length == 0)
            return 0;

        return lRes;
    }
}

class Task2_1 {
    public int task2_1(int K, int[] A) {
        // write your code in C# 5.0 with .NET 4.5 (Mono)

        int l, j, lRes, lNum = A.Length;

        if (lNum == 0)
          return 0;
        if (lNum > 40000)
          return 0;

        // O(N^2)
        lRes = 0;
        for (l = 0; l < lNum; l++) {
          for (j = 0; j < lNum; j++) {
            if (A[l] + A[j] == K)
              lRes++;
          }
        }
//        Console.WriteLine("complimentary: {0}!", lRes);

        return lRes;
    }
}

class Task2_2 {
    public int task2_2(int K, int[] A) {
        // write your code in C# 5.0 with .NET 4.5 (Mono)

        int l, j, lRes, lNum = A.Length;

        if (lNum == 0)
          return 0;
        if (lNum > 40000)
          return 0;

        // O(N^2) ..but can at least be less!
        Array.Sort(A);
        l = 0;
        lRes = 0;
        while ((l < lNum) && (A[0] + A[l] <= K)) {
          for (j = 0; j < lNum; j++) {
            if (A[l] + A[j] == K)
              lRes++;
          }
          l++;
        }
//        Console.WriteLine("complimentary: {0}!", lRes);

        return lRes;
    }
}

