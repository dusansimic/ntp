using System;

namespace graf
{
    class Program
    {
        static void Main(string[] args)
        {
            Graf g = new Graf();
            GrafVertex dusan = new GrafVertex("dusan", 0);
            GrafVertex nenad = new GrafVertex("nenad", 1);
            GrafVertex dunja = new GrafVertex("dunja", 2);
            g.addVertex(dusan);
            g.addVertex(nenad);
            g.addVertex(dunja);
            g.addSused(dusan, nenad);
            g.addSused(dusan, dunja);
            g.addSused(dunja, dusan);
            System.Console.WriteLine(g);
        }
    }
}
