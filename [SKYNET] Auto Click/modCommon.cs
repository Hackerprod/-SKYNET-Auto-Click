using System;
using System.Windows.Forms;

public class Common
{
    public static void Show(object v)
    {
        new frmMessage(v.ToString()).ShowDialog();
    }

    public static string GetTime(int miliseconds)
    {
        DateTime t = new DateTime().AddMilliseconds(miliseconds);

        string Hour = t.Hour == 0 ? "00" : t.Hour.ToString();
        Hour = Hour.Length == 1 ? "0" + Hour : Hour;
        string Minute = t.Minute == 0 ? "00" : t.Minute.ToString();
        Minute = Minute.Length == 1 ? "0" + Minute : Minute;
        string Second = t.Second == 0 ? "00" : t.Second.ToString();
        Second = Second.Length == 1 ? "0" + Second : Second;
        string Millisecond = t.Millisecond.ToString();
        Millisecond = Millisecond.Length == 1 ? "0" + Millisecond : Millisecond;
        Millisecond = Millisecond.Length == 3 ? $"{Millisecond[0]}{Millisecond[1]}" : Millisecond;

        return $"{Hour}:{Minute}:{Second}:{Millisecond}";
    }
}