using NUnit.Framework;
using SingletonPatten;

namespace SingletonTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            Singleton<string> sValue1 = Singleton<string>.Instance;
            Singleton<string> sValue2 = Singleton<string>.Instance;

            sValue1.Value = "test";
            Singleton<string> s1 = Singleton<string>.Instance;

            sValue2.Value = "string";
            Singleton<string> s2 = Singleton<string>.Instance;

            Assert.AreEqual(s1, s2);
        }

        [Test]
        public void Test2()
        {
            Singleton<string> sValue = Singleton<string>.Instance;
            Singleton<int> iValue = Singleton<int>.Instance;

            Assert.AreNotSame(sValue, iValue);
        }
    }
}