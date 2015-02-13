
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

public class zThreading {

  // master list lock object
  private static Object oMasterIdxsLock = new Object();
  private static Object oRecordsToDoLock = new Object();

  // progress count
  public static volatile int lRecordsToDo;
  public int lRecordsTotal;
  public static double dIterations;

  Dictionary<string, KeyValuePair<string, string>> dMasterIdxs;
  private Thread[] threads;
  private int tmMax = 100000;

  // constructor
  public zThreading(int lRecords) {
    Console.WriteLine("[info] constructing zThreading object");
    lRecordsTotal = lRecords;
    lRecordsToDo = lRecords;
    dIterations = 0;
  }

  public void update(int id, ref List<string> aIdxs) {
    lock(oMasterIdxsLock) {
//      Console.WriteLine("thread{0}: executing {1} records", id, aIdxs.Count);
      foreach(string s in aIdxs) {
        if (!dMasterIdxs.ContainsKey("dic" + s))
          throw new Exception("abort on missing key: 'dic" + s + "'");
        else {
//          Console.WriteLine("executing record: '{0} | {1}', remaining: '{2} | {3}''",
//                            "dic" + s, dMasterIdxs["dic" + s].Value,
//                             dMasterIdxs.Count, lRecordsToDo);
          dMasterIdxs.Remove("dic" + s);
        }
      }
      aIdxs.Clear();
    }
  }

  public void workerWork(object data) {

    List<int> aData;
    List<string> aHits = new List<string>();
    Dictionary<string, string> dIdxs;

    int id, lRangeStart, lRangeEnd;
    int l, lRange, lOrder, lHits, lRandomNumber;
    double iterations = 0;
    string s, sMax, sKey;
    Stopwatch sw = new Stopwatch();

    aData = (List<int>)data;
    id = aData[0];
    lRangeStart = aData[1];
    lRangeEnd = aData[2];

    lRange = lRangeEnd - lRangeStart + 1;
    lOrder = lRange.ToString().Length;

    // create thread's workload
    dIdxs = new Dictionary<string, string>();
    for (l = lRangeStart; l <= lRangeEnd; l++) {
      dIdxs.Add(l.ToString(), l.ToString());
    }

    // main worker loop
    lHits = 0;
    sw.Restart();
    while (dIdxs.Count > 0 && sw.ElapsedMilliseconds < tmMax) {
      s = "";
      sMax = "";
      while (s.Length < lOrder) {
        byte[] aRandom = new byte[1];
        zMath.random.GetBytes(aRandom);
        s += ((float)aRandom[0] / 255 * 99).ToString("00");
        sMax += "99";
      }
      lRandomNumber = 1 + (int)(int.Parse(s) / (float)(int.Parse(sMax)) * (float)(lRange - 1));
      sKey = (lRangeStart + lRandomNumber - 1).ToString();
      if (dIdxs.ContainsKey(sKey)) {
//        Console.WriteLine("thread{0} hit! | sKey: '{1}', rnd: '{2}', rnd bytes: '{3}', range size: '{4}'",
//                          id, sKey, lRandomNumber, s, lRange);
        // hit!
        lHits++;
        aHits.Add(sKey);
        dIdxs.Remove(sKey);
        if (lHits % 50 == 0) {
          // update progress
          lock(oRecordsToDoLock) {
            lRecordsToDo -= 50;
          }
        }
        if (lHits % 2500 == 0 || lHits == lRange) {
          // update master indexes
//          Console.WriteLine("thread{0}: local idxs: {1}, hits: {2}", id, dIdxs.Count, lHits);
          update(id, ref aHits);
          if (lHits == lRange) {
            lock(oRecordsToDoLock) {
              lRecordsToDo -= (lHits % 50);
            }
          }
        }
      }
      iterations++;
    }

    if (dIdxs.Count > 0 && sw.ElapsedMilliseconds >= tmMax) {
      Console.WriteLine("[info] thread{0}: timeout, unprocessed: '{1}, hits: '{2}/{3}'",
                         id, dIdxs.Count, lHits, lRange);
      foreach(KeyValuePair<string,string>kv in dIdxs)
        Console.WriteLine("unprocessed record: key|{0}, value|{1}", kv.Key, kv.Value);
    }
    Console.WriteLine("[info] thread{0}: iterations: '{1}'", id, iterations);
    dIterations += iterations;

  } // workerWork

  public void masterWork(int lThreads) {

    int l, l1, l2, lRange, lProgress;

    // build random data
    zData data = new zData(lRecordsToDo, true);
    dMasterIdxs = data.dic;

    // create thread pool
    threads = new Thread[lThreads];
    for (l = 0; l < lThreads; l++)
      threads[l] = new Thread(workerWork);

    // activate threads
    lRange = (int)(lRecordsTotal / (float)lThreads);
    l1 = 1;
    l2 = l1 + lRange - 1;
    for (l = 1; l <= lThreads; l++) {
      if (l == lThreads)
        l2 = lRecordsTotal;
      Console.WriteLine("l: '{0}', l1: '{1}', l2: '{2}'", l, l1, l2);
      threads[l-1].Start((object)(new List<int>(){ l, l1, l2 }));
      while (!threads[l-1].IsAlive)
        Thread.Sleep(1);
      l1 = l2 + 1;
      l2 = l1 + lRange - 1;
    }

//    Debugger.Break();

    bool exec = true;
    while (exec) {

      lProgress = (int)((float)lRecordsToDo / lRecordsTotal * 100);
      Console.WriteLine("[info] elapsed: '{0}', remaining work: '{1}/{2} ({3}%)'",
                        Program.sw.Elapsed, lRecordsToDo, lRecordsTotal, lProgress);

      exec = false;
      foreach(Thread t in threads) {
        if (t.IsAlive) {
          exec = true;
          break;
        }
      }

      if (exec) {
        l = 1;
        foreach(Thread t in threads) {
          if (t.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
            Console.WriteLine("thread{0}: blocking", l);
          l++;
        }
        Thread.Sleep(100);
      }
    }
    Console.WriteLine("[info] records: '{0}', iterations: '{1}', efficiency: '{2}%'",
                       lRecordsTotal, dIterations, ((float)lRecordsTotal / dIterations * 100).ToString("0.00"));

  } // masterWork
}

