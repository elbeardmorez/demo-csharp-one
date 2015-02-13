
using System;
using System.Collections;
using System.Data;
using System.Data.Linq;

public class zLINQ {
  public zLINQ() {

    int l;

    var db = new Test("Server=127.0.0.1;Port=5432;User Id=pedro;Password=pedro;Database=test;DbLinqProvider=PostgreSql;DbLinqConnectionType=Npgsql.NpgsqlConnection, Npgsql, Version=2.2.3.0, Culture=neutral, PublicKeyToken=5d8b90d52f46fda7");

    l = 1;
    foreach(var tr in db.TiesTo) {
      Console.WriteLine(l + "|" + tr.ID + "|" + tr.Name);
      l++;
    }

  }
}

