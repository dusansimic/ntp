using System;

namespace mojtipstring
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] string1 = {'H', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd'};
            MojString s = new MojString(string1);
            
            MojString[] s1 = s.Split('o');
            for (int i = 0; i < s1.Length; i++) {
                s1[i].Print(true);
            }
        }
    }
}
