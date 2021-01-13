using NUnit.Framework;
using System;
using System.ComponentModel;

namespace MatBlazor.DevUtils
{
    [TestFixture]
    public class TypeConvertorExperiment
    {
        [Test]
        public void Test2()
        {
            var q = new Uri("http://localhost:62765/DatePicker#Example");
            Console.WriteLine(q.Fragment);
            
        }
        
        [Test]
        public void Test1()
        {
            var conv = TypeDescriptor.GetConverter(typeof(DateTime?));
            

            DateTime? d1 = (DateTime?)conv.ConvertFromString("1.1");
            Console.WriteLine(d1 == DateTime.MinValue);
            Console.WriteLine(d1);
        }
    }
}
