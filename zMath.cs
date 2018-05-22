
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using static System.Console; // C#6
using static System.Math; // C#6

public static class zMath {
//public class zMath {
//  public zMath() {
//    Console.WriteLine("constructing 'zMath' object");
//    zmath();
//  }

  public static RandomNumberGenerator random = new RNGCryptoServiceProvider();

  public static int demoRound() {
    int lRes = -1;
    double d, dRnd;

    d = PI; dRnd = Round(d, MidpointRounding.AwayFromZero);
    WriteLine("d: {0}, dRnd (away from 0): {1}", d, dRnd);
    d = -12.23; dRnd = Round(d, MidpointRounding.AwayFromZero);
    WriteLine("d: {0}, dRnd (away from 0): {1}", d, dRnd);
    d = 12.23; dRnd = Round(d, MidpointRounding.AwayFromZero);
    WriteLine("d: {0}, dRnd (away from 0): {1}", d, dRnd);
    d = -5.5; dRnd = Round(d, MidpointRounding.AwayFromZero);
    WriteLine("d: {0}, dRnd (away from 0): {1}", d, dRnd);
    d = 5.5; dRnd = Round(d, MidpointRounding.AwayFromZero);
    WriteLine("d: {0}, dRnd (away from 0): {1}", d, dRnd);
    d = -0.5; dRnd = Round(d);
    WriteLine("d: {0}, dRnd: {1}", d, dRnd);
    d = 0.5; dRnd = Round(d);
    WriteLine("d: {0}, dRnd: {1}", d, dRnd);
    return lRes;
  }
  public static string randomString(int length) {

    string sRet = "";
    int lChar;

    byte[] aRandomNumbers = new byte[length];
    random.GetBytes(aRandomNumbers);
    //System.Random rnd = new System.Random();
    for (int l = 0; l < length; l++) {
      //sRet += (char)(1 + Math.Round(rnd.NextDouble() * 25) + 96);
      //sRet += (char)(rnd.Next(97,113));
      lChar = 1 + (int)(Math.Round((decimal)(aRandomNumbers[l] / 255.0) * 25)) + 96;
//      Debugger.Break();
//      Console.WriteLine("crypto random number: '{0}', ascii char: '{1}'",
//                          aRandomNumbers[l], lChar);
      sRet += (char)lChar;
    }

    return sRet;
  }
}
