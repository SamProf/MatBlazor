using NUnit.Framework;
using System;

namespace MatBlazor.DevUtils
{
    [TestFixture]
    public class OverflowExp
    {

        [Test]
        public void Test1()
        {
            checked
            {
                float v = float.MaxValue;
                Console.WriteLine(v);
                Console.WriteLine((float)(v + 10000000000000));
                Console.WriteLine(((float)(v + 10000000000000000000)) == v);
                
            }
        }
        
    }
}