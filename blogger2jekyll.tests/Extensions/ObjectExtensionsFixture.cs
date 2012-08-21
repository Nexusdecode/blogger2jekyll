using System;
using blogger2jekyll.Extensions;
using NUnit.Framework;

namespace blogger2jekyll.tests.Extensions
{
    [TestFixture]
    public class ObjectExtensionsFixture
    {
        [Test]
        public void TestIsParameterNull()
        {
            new object().CheckNull();

            object o = null;
            Assert.Throws<ArgumentNullException>(() => o.CheckNull());
        }

        [Test]
        public void TestIsParameterNullWithNull()
        {
            object obj = null;
            Assert.That(() => obj.CheckNull(), Throws.TypeOf<ArgumentNullException>().With.Message.EqualTo("Value cannot be null."));
        }

        [Test]
        public void TestIsParameterNullWithName()
        {
            new object().CheckNull("parameter1");
        }

        [Test]
        public void TestIsParameterNullWithNullAndName()
        {
            object obj = null;
            Assert.That(() => obj.CheckNull("parameter1"), Throws.TypeOf<ArgumentNullException>().With.Message.EqualTo("Value cannot be null.\r\nParameter name: parameter1"));
        }
    }
}
