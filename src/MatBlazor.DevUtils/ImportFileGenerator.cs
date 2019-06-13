using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.DevUtils
{
//    [TestFixture]
    public class ImportFileGenerator
    {
//        [Test]
        public void GenerateImportsFileContent()
        {
            var assembly = typeof(BaseMatDomComponent).Assembly;
            var sb = new StringBuilder();
            foreach (var nam in assembly.GetExportedTypes().Where(i => i.IsSubclassOf(typeof(ComponentBase)))
                .Select(i => i.Namespace).Distinct().OrderBy(i => i))
            {
                sb.AppendLine($"@using {nam}");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}