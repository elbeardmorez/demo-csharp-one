//#define DIAGNOSTICS

using System.IO;
using System;
using System.Diagnostics;

class Program {

  public static Stopwatch sw;

  static void Main() {

    sw = new Stopwatch();

    fnDemo();
    fnData();
    fnAbstract();
    fnInterface();
    fnMath();
    fnDB();
    fnThreading();
    fnSqlLinq();
  }

  static void fnSqlLinq() {
    Console.WriteLine("\n# fnSqlLinq");

    sw.Restart();

    zSqlLinq sqlLinq = new zSqlLinq();

    sw.Stop();
    Console.WriteLine("[elapsed] {0}", sw.Elapsed);

    return;
  }
  static void fnThreading() {
    Console.WriteLine("\n# fnThreading");

    sw.Restart();

    zThreading threading = new zThreading(100000);
    threading.masterWork(3);

    sw.Stop();
    Console.WriteLine("[elapsed] {0}", sw.Elapsed);

    return;
  }
  static void fnDB() {
    Console.WriteLine("\n# fnDB");

    sw.Restart();

    zDB db = new zDB();

    sw.Stop();
    Console.WriteLine("[elapsed] {0}", sw.Elapsed);

    return;
  }
  static void fnDemo() {
    Console.WriteLine("\n# fnDemo");

    int lRes;

    sw.Restart();

    Demo1_1 d1_1 = new Demo1_1();
    lRes = d1_1.demo1_1(new int[]{-1, 3, -4, 5, 1, -6, 2, 1});
    Console.WriteLine("d1_1: {0}!", lRes);

    sw.Stop();
    Console.WriteLine("Elapsed: {0}", sw.Elapsed);

    sw.Restart();

    Demo1_2 d1_2 = new Demo1_2();
    lRes = d1_2.demo1_2(new int[]{-1, 3, -4, 5, 1, -6, 2, 1});
    Console.WriteLine("d1_2: {0}!", lRes);

    sw.Stop();
    Console.WriteLine("[elapsed] {0}", sw.Elapsed);

    sw.Restart();

    Task1 t1 = new Task1();
    lRes = t1.task1(new int[]{-4, -10, 6, 0, -6, 10, 4});
    Console.WriteLine("task1: {0}!", lRes);

    sw.Stop();
    Console.WriteLine("[elapsed] {0}", sw.Elapsed);

    // task 2 mk i
    sw.Restart();

    Task2_1 t2_1 = new Task2_1();
    lRes = t2_1.task2_1(6, new int[]{-1, 3, -4, 0, 1, -6, 1, 5, 2});
    Console.WriteLine("task2_1: {0}!", lRes);

    sw.Stop();
    Console.WriteLine("[elapsed] {0}", sw.Elapsed);

    // task 2 mk ii
    sw.Restart();

    Task2_2 t2_2 = new Task2_2();
    lRes = t2_2.task2_2(6, new int[]{-1, 3, -4, 0, 1, -6, 1, 5, 2});
    Console.WriteLine("task2_2: {0}!", lRes);

    sw.Stop();
    Console.WriteLine("[elapsed] {0}", sw.Elapsed);

    return;
  }
  static void fnMath() {
    Console.WriteLine("\n# fnMath");

    sw.Restart();

    zMath.demoRound();

    sw.Stop();
    Console.WriteLine("[elapsed] {0}", sw.Elapsed);

    return;
  }
  static void fnInterface() {
    Console.WriteLine("\n# fnInterface");

    sw.Restart();

    sw.Stop();
    Console.WriteLine("[elapsed] {0}", sw.Elapsed);

    return;
  }
  static void fnAbstract() {
    Console.WriteLine("\n# fnAbstract");

    sw.Restart();

    P p = new P();
    p.set_l(12);
    Console.WriteLine("x: " + p.l * 2 + "!");

    sw.Stop();
    Console.WriteLine("[elapsed] {0}", sw.Elapsed);

    return;
  }
  static void fnData() {
    Console.WriteLine("\n# fnData");

    sw.Restart();

    zData data = new zData(10);
    Console.WriteLine("dg: {0}!", data.ToString());

    sw.Stop();
    Console.WriteLine("[elapsed] {0}", sw.Elapsed);

    return;
  }
}
