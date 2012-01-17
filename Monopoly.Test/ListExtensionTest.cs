using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monopoly.Test
{
    [TestClass]
    public class ListExtensionTest
    {
        [TestMethod]
        public void SwappingTwoItems()
        {
            var list = new List<string>();
            list.Add("Hans");
            list.Add("Sepp");

            list.Swap(0, 1);

            Assert.AreEqual("Sepp", list[0]);
            Assert.AreEqual("Hans", list[1]);
        }
    }
}
