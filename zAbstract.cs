
public abstract class test() {
    static int l = 11;
    public static int get_l(int j) {
        return (++j+l);
    }
}

public class P() {
    public int l;
    public void set_l(int j) {
        l = test.get_l(j);
    }
}