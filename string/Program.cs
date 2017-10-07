using System;

namespace mojtipstring
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] string1 = {'H', 'e', 'r', 'l', 'd'};
            char[] string2 = {'l', 'l', 'o', ' ', 'w', 'o'};
            MojString s1 = new MojString(string1);
            MojString s2 = new MojString(string2);
            
            s1.Insert(2, s2);
            s1.Print(true);
            MojString s3 = s1.Substring(2, 3);
            s3.Print(true);
        }
    }
}
