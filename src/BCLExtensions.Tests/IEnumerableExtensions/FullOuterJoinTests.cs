using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BCLExtensions.Tests.IEnumerableExtensions
{
    public class FullOuterJoinTests
    {
        [Fact]
        public void FailsOnNullInputs()
        {
            var NULL_Enumerable = (IEnumerable<int>)null;
            var NULL_KeySelector = (Func<int, int>)null;
            var NULL_ResultSelector = (Func<int, int, int>)null;

            var validEnumerable = Enumerable.Empty<int>().ToArray();
            var validKeySelector = new Func<int, int>(v => v);
            var validResultSelector = new Func<int, int, int>((l, r) => l + r);

            Assert.Throws<ArgumentNullException>(() => NULL_Enumerable.FullOuterJoin(validEnumerable, validKeySelector, validKeySelector, validResultSelector).ToArray());
            Assert.Throws<ArgumentNullException>(() => validEnumerable.FullOuterJoin(NULL_Enumerable, validKeySelector, validKeySelector, validResultSelector).ToArray());
            Assert.Throws<ArgumentNullException>(() => validEnumerable.FullOuterJoin(validEnumerable, NULL_KeySelector, validKeySelector, validResultSelector).ToArray());
            Assert.Throws<ArgumentNullException>(() => validEnumerable.FullOuterJoin(validEnumerable, validKeySelector, NULL_KeySelector, validResultSelector).ToArray());
            Assert.Throws<ArgumentNullException>(() => validEnumerable.FullOuterJoin(validEnumerable, validKeySelector, validKeySelector, NULL_ResultSelector).ToArray());

            Assert.DoesNotThrow(() => validEnumerable.FullOuterJoin(validEnumerable, validKeySelector, validKeySelector, validResultSelector).ToArray());
        }

        private static void AssertAreEqualIgnoringOrdering<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            Assert.Equal(
                expected.OrderBy(v => v),
                actual.OrderBy(v => v)
            );
        }

        [Fact]
        public void MatchingOnBothSides()
        {
            var left = new[] { 1, 2, 3 };
            var right = new[] { 1, 2, 3 };

            var join = left.FullOuterJoin(right, l => l, r => r, (l, r) => l == r);


            AssertAreEqualIgnoringOrdering(new[] { true, true, true }, join);
        }

        [Fact]
        public void UnmatchingOnTheLeftSide()
        {
            var left = new[] { 1, 2, 3, 4 };
            var right = new[] { 1, 2, 3 };

            var join = left.FullOuterJoin(right, l => l, r => r, (l, r) => l == r);


            AssertAreEqualIgnoringOrdering(new[] { true, true, true, false }, join);
        }

        [Fact]
        public void UnmatchingOnTheRightSide()
        {
            var left = new[] { 1, 2, 3 };
            var right = new[] { 1, 2, 3, 4 };

            var join = left.FullOuterJoin(right, l => l, r => r, (l, r) => l == r);

            AssertAreEqualIgnoringOrdering(new[] { true, true, true, false }, join);
        }

        [Fact]
        public void UnmatchingOnBothSides()
        {
            var left = new[] { 1, 2, 3, 99 };
            var right = new[] { 1, 2, 3, 44 };

            var join = left.FullOuterJoin(right, l => l, r => r, (l, r) => l == r);

            AssertAreEqualIgnoringOrdering(new[] { true, true, true, false, false }, join);
        }

        [Fact]
        public void UnsortedInputs()
        {
            var left = new[] { 4, 2, 3, 1 };
            var right = new[] { 3, 1, 4, 2 };

            var join = left.FullOuterJoin(right, l => l, r => r, (l, r) => l == r);

            AssertAreEqualIgnoringOrdering(new[] { true, true, true, true }, join);
        }

        [Fact]
        public void SelectsProductOfTwoInputsWithRepeatingKeys()
        {
            var left = new[] { 1, 1, 2, 2 };
            var right = new[] { 1, 2 };

            var join = left.FullOuterJoin(right, l => l, r => r, (l, r) => l == r);

            AssertAreEqualIgnoringOrdering(new[] { true, true, true, true }, join);
        }

        public class IntStringTupleEqualityComparer : IEqualityComparer<Tuple<int, string>>
        {
            public bool Equals(Tuple<int, string> x, Tuple<int, string> y)
            {
                return x == null && y == null || x != null && y != null && x.Item1 == y.Item1 && x.Item2 == y.Item2;
            }

            public int GetHashCode(Tuple<int, string> obj)
            {
                var hash = 17;
                hash = hash * 31 + obj.Item1.GetHashCode();
                hash = hash * 31 + obj.Item2.GetHashCode();
                return hash;
            }
        }

        [Fact]
        public void SupportsCustomEqualityComparers()
        {
            var left = new[] {
                //These have matching items on the right
                Tuple.Create(1, "First"),
                Tuple.Create(1, "Second"),

                //These are distinct to the left
                Tuple.Create(1, "Third"),
                Tuple.Create(2, "Fourth"),
            };

            var right = new[] {
                //These have matching items on the left
                Tuple.Create(1, "First"),
                Tuple.Create(1, "Second"),

                //These are distinct to the right
                Tuple.Create(2, "Third"),
                Tuple.Create(3, "Fourth"),
            };

            var comparer = new IntStringTupleEqualityComparer();

            var join = left.FullOuterJoin(right, 
                                          l => l,
                                          r => r,
                                          (l, r) => String.Format("{0}|{1}", l == null ? "NULL" : l.Item2, r == null ? "NULL" : r.Item2), 
                                          keyEqualityComparer: comparer);

            AssertAreEqualIgnoringOrdering(
                new[] {
                    "First|First",
                    "Second|Second",
                    "Third|NULL",
                    "Fourth|NULL",
                    "NULL|Third",
                    "NULL|Fourth",
                }, 
                join
            );
        }
    }
}