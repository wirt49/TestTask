using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Data
{
    public class ReadData
    {
        public static IEnumerable<TestCaseData> ValidLoginTestData
        {
            get
            {
                yield return new TestCaseData("genuineUser@mail.com", "1234567", "https://qa.sorted.com/newtrack/loginsuccess");
            }
        }
    }
}
