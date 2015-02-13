
using System.Collections.Generic;

public interface sparks {
  string getName(Person p);
}

public class Person {

  private string zName;
  public string name {
    get {
      return zName;
    }
    set {
       zName = value;
    }
  }

  // ctor
  public Person() {
    zName = "bob";
  }
}
