
using System;

public static class zUtil {
  public static void utDumpCodeBase(Object obj)
  {
    System.Console.WriteLine(obj.GetType().Assembly.CodeBase);
  }
}

