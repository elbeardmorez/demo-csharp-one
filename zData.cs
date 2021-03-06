
using System;
using System.Collections;
using System.Collections.Generic;

public class zData {

  public ArrayList al;
  public Dictionary<string, KeyValuePair<string, string>> dic { get; private set; }

  public zData(long q) :
    this(q * 2, false) {}

  public zData(long q, bool random) {
    int l;
    string sVal;
    al = new ArrayList();
    dic = new Dictionary<string, KeyValuePair<string, string>>();
    for (l = 1; l <= q; l++) {
      if (random) {
        sVal = zMath.randomString(20);
        Console.WriteLine("new randomstring generated: '{0}'", sVal);
      } else
        sVal = l.ToString();
      al.Add(new KeyValuePair<string, int>("ArrayList item: " + l, l));
      dic.Add("dic" + l, new KeyValuePair<string, string>("Dictionary item: dic" + l, sVal));
    }
  }

  public override string ToString() {
    foreach (KeyValuePair<string, int> kv in al)
      Console.WriteLine("{0}", kv);

    KeyValuePair<string, string> kv2;
    for (var l = 1; l < dic.Count; l++) {
      kv2 = dic["dic" + l];
      Console.WriteLine("{0}", kv2);
    }
    return "bob!";
  }
}
