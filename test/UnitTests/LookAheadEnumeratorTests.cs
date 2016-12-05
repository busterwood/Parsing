using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using BusterWood.Parsing;

namespace UnitTests
{
    [TestFixture]
    public class LookAheadEnumeratorTests
    {
        [Test]
        public void initially_Current_and_next_have_the_default_value()
        {
            LookAheadEnumerator<char> testing = CreateEnumerator("abc");
            Assert.AreEqual(default(char), testing.Current, "Current");
            Assert.AreEqual(default(char), testing.Next, "Next");
        }

        [Test]
        public void calling_movenext_sets_current_and_next()
        {
            LookAheadEnumerator<char> testing = CreateEnumerator("abc");
            Assert.IsTrue(testing.MoveNext());
            Assert.AreEqual('a', testing.Current, "Current");
            Assert.AreEqual('b', testing.Next, "Next");
        }

        [Test]
        public void can_move_to_second_item()
        {
            LookAheadEnumerator<char> testing = CreateEnumerator("abc");
            Assert.IsTrue(testing.MoveNext());
            Assert.IsTrue(testing.MoveNext());
            Assert.AreEqual('b', testing.Current, "Current");
            Assert.AreEqual('c', testing.Next, "Next");
        }

        [Test]
        public void when_moving_to_last_entry_next_is_default()
        {
            LookAheadEnumerator<char> testing = CreateEnumerator("a");
            Assert.IsTrue(testing.MoveNext());
            Assert.AreEqual('a', testing.Current, "Current");
            Assert.AreEqual(default(char), testing.Next, "Next");
        }

        [Test]
        public void when_at_the_end_both_current_and_next_are_default()
        {
            LookAheadEnumerator<char> testing = CreateEnumerator("a");
            Assert.IsTrue(testing.MoveNext());
            Assert.IsFalse(testing.MoveNext());
            Assert.AreEqual(default(char), testing.Current, "Current");
            Assert.AreEqual(default(char), testing.Next, "Next");
        }

        private static LookAheadEnumerator<char> CreateEnumerator(string text)
        {
            return new LookAheadEnumerator<char>(((IEnumerable<char>)text).GetEnumerator());
        }
    }
}
