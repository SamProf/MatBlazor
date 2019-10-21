using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using NUnit.Framework;

namespace MatBlazor.DevUtils
{
    [TestFixture]
    public class TypeConvertorExperiment
    {
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
