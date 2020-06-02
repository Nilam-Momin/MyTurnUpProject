using NUnit.Framework;
using System.Collections;

namespace TurnUpNUnitTestProject
{
    public static class MyDataClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("12", "1st Des");
                yield return new TestCaseData("34", "2nd desc");
            }
        }
        

        
    }
}