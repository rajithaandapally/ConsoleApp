using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp;

namespace ConsoleAppTests
{
    [TestClass]
    public class StateServiceTest
    {
        [TestMethod]
        public void ValidStateAbbreviationTest()
        {
            //positive test Script
            StateService svc = new StateService();
            StateData res = svc.GetStateData("TX");
            Assert.IsNotNull(res);
            Assert.AreEqual("Houston", res.LargestCity);
            Assert.AreEqual("Austin", res.Capital);
        }
        [TestMethod]
        public void ValidStateNameTest()
        {
            //positive test Script
            StateService svc = new StateService();
            StateData res = svc.GetStateData("Texas");
            Assert.IsNotNull(res);
            Assert.AreEqual("Houston", res.LargestCity);
            Assert.AreEqual("Austin", res.Capital);
        }
        [TestMethod]
        public void ValidStateNameCasesensitiveTest()
        {
            //positive test Script
            StateService svc = new StateService();
            StateData res = svc.GetStateData("texas");
            Assert.IsNotNull(res);
            Assert.AreEqual("Houston", res.LargestCity);
            Assert.AreEqual("Austin", res.Capital);
        }
        [TestMethod]
        public void ValidStateAbbreviationCasesensitiveTest()
        {
            //positive test Script
            StateService svc = new StateService();
            StateData res = svc.GetStateData("tx");
            Assert.IsNotNull(res);
            Assert.AreEqual("Houston", res.LargestCity);
            Assert.AreEqual("Austin", res.Capital);
        }
        //Negitive Test
        [TestMethod]
        public void InvalidStateAbbreviationTest()
        {
            StateService svc = new StateService();
            StateData res = svc.GetStateData("XX");
            Assert.IsNull(res);            
        }

        [TestMethod]
        public void InvalidStateNameTest()
        {
            StateService svc = new StateService();
            StateData res = svc.GetStateData("abcdefgh");
            Assert.IsNull(res);
        }
        [TestMethod]
        public void EmptyInputTest()
        {
            StateService svc = new StateService();
            StateData res = svc.GetStateData("");
            Assert.IsNull(res);
        }
        [TestMethod]
        public void NullInputTest()
        {
            StateService svc = new StateService();
            StateData res = svc.GetStateData(null);
            Assert.IsNull(res);
        }

    }
}
