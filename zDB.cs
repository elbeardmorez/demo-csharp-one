
using System;
//#if DIAGNOSTICS
//#else
using System.Diagnostics;
//#endif
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Npgsql;

public class zDB {
  public zDB() {

    NpgsqlConnection npgcon;
    NpgsqlCommand npgcmd;
    Stopwatch sw = new Stopwatch();
    string s, sCommand, sTest;
    int l;

    // scalar
    npgcon = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=pedro;Password=pedro;Database=template1;");
    zUtil.utDumpCodeBase(npgcon);
    npgcon.Open();
    npgcmd = new NpgsqlCommand("select datname as name from pg_catalog.pg_database", npgcon);
    Console.WriteLine("scalar value: {0}", npgcmd.ExecuteScalar());
    npgcon.Close();

    // test db
    npgcon = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=pedro;Password=pedro;Database=test;");
    npgcon.Open();

    // drop table
    try {
      npgcmd = new NpgsqlCommand("drop table tiesto", npgcon);
      Console.WriteLine("dropped table, res: {0}", npgcmd.ExecuteNonQuery());
    } catch(Exception ex) {
      Console.WriteLine("[error] {0} | {1}", ex.GetType(), ex.Message);
    }
//    Debugger.Break();

    // create table and content
    try {
      npgcmd = new NpgsqlCommand("create table tiesto(id Integer, name Text)", npgcon);
      Console.WriteLine("non-query res: {0}", npgcmd.ExecuteNonQuery());
    } catch(Exception ex) {
      Console.WriteLine("[error] {0} | {1}", ex.GetType(), ex.Message);
    }

    // add some data
    zData data = new zData(100, true);
    try {

      // individual inserts
      sTest = "multiple individual inserts";
      l = 1;
      sw.Restart();
      foreach (KeyValuePair<string, string>kv in data.dic.Values) {
        sCommand = "insert into tiesto values(" + l + ", '" + kv.Value + "')";
//        Console.WriteLine("executing query: {0}", sCommand);
        npgcmd = new NpgsqlCommand(sCommand, npgcon);
        npgcmd.ExecuteNonQuery();
        l++;
      }
      Console.WriteLine("added {0} records to table", l);
      sw.Stop();
      Console.WriteLine("[elapsed] {0} | {1}", sw.Elapsed, sTest);

      // single concatenated values
      sTest = "concatenated values, single insert";
      l = 1;
      sw.Restart();
      sCommand = "insert into tiesto values ";
      foreach (KeyValuePair<string, string>kv in data.dic.Values) {
        sCommand += "(" + l + ", '" + kv.Value + "'),";
        l++;
      }
      sCommand = sCommand.Trim(',');
//      Console.WriteLine("executing query: {0}", sCommand);
      npgcmd = new NpgsqlCommand(sCommand, npgcon);
      l = npgcmd.ExecuteNonQuery();
      Console.WriteLine("added {0} records to table", l);
      sw.Stop();
      Console.WriteLine("[elapsed] {0} | {1}", sw.Elapsed, sTest);

      // data reader
      sCommand = "select * from tiesto";
      npgcmd = new NpgsqlCommand(sCommand, npgcon);
      NpgsqlDataReader npgrdr = npgcmd.ExecuteReader();
      l = 1;
      while (npgrdr.Read()) {
        s = "";
        for (l = 0; l < npgrdr.FieldCount; l++)
          s += npgrdr[l] + "|";
        Console.WriteLine("idx: {0} | {1}", l, s.Trim('|'));
        l++;
      }

    } catch(Exception ex) {
      Console.WriteLine("[error] {0} | {1}", ex.GetType(), ex.Message);
    }
    // command.Parameters.Add(new NpgsqlParameter("value1", NpgsqlDbType.Integer))

    npgcon.Close();
  }
}
