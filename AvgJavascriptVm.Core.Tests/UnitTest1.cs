using AvgJavascriptVm.Core.BaseTypes;
using AvgJavascriptVm.Core.Infrastructure;
using AvgJavascriptVm.Core.Types;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AvgJavascriptVm.Core.Tests
{
    [TestFixture()]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var global = new GlobalScope();
            var arr = new JsArray(new JsValue[] { new JsString("23232"), }, global);
        }
    }
}
