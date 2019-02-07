using FluentAssertions;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace MongoDB.Bson
{
    public class Test_BsonExtensions
    {
        #region Public Methods

        [Fact]
        public void Array() => TestToDynamic(
            x => new BsonArray(x),
            (x, y) => ((dynamic[])x).Should().Equal(y),
            new[] { "foo", "bar", "baz" }
        );

        [Fact]
        public void BinaryData() => TestToDynamic(
            x => new BsonBinaryData(x),
            (x, y) => ((byte[])x).Should().Equal(y),
            new byte[] { 42, 17, 93 }
        );

        [Fact]
        public void Boolean() => TestToDynamic(x => new BsonBoolean(x), true);

        [Fact]
        public void DateTime() => TestToDynamic(
            x => new BsonDateTime(x),
            new DateTime(1973, 9, 8, 7, 42, 39, DateTimeKind.Utc)
       );

        [Fact]
        public void Decimal128() => TestToDynamic(x => new BsonDecimal128(x), 42.69m);

        [Fact]
        public void Document()
        {
            var str = "foo";
            var num = 42.69;
            var dt = new DateTime(1973, 9, 8, 7, 42, 39, DateTimeKind.Utc);
            var arr = new[] { 42, 69 };

            var testee = new BsonDocument {
                { "str", str },
                { "num", num },
                { "dt", dt },
                { "arr", new BsonArray(arr) },
                { "obj", new BsonDocument {
                    { "str", str },
                    { "num", num }
                }}
            };

            TestToDynamic(testee, x => {
                ((string)x.str).Should().Be(str);
                ((double)x.num).Should().Be(num);
                ((DateTime)x.dt).Should().Be(dt);
                ((dynamic[])x.arr).Should().Equal(arr.Cast<dynamic>().ToArray());
                ((string)x.obj.str).Should().Be(str);
                ((double)x.obj.num).Should().Be(num);
            });
        }

        [Fact]
        public void Double() => TestToDynamic(x => new BsonDouble(x), 42.69d);

        [Fact]
        public void Int32() => TestToDynamic(x => new BsonInt32(x), 42);

        [Fact]
        public void Int64() => TestToDynamic(x => new BsonInt64(x), 42L);

        [Fact]
        public void JavaScript() => TestToDynamic(x => new BsonJavaScript(x), "Lorem ipsum");

        [Fact]
        public void MaxKey() => TestToDynamic(BsonMaxKey.Value, "BsonMaxKey");

        [Fact]
        public void MinKey() => TestToDynamic(BsonMinKey.Value, "BsonMinKey");

        [Fact]
        public void Null() => TestToDynamic(BsonNull.Value, x => ((object)x).Should().BeNull());

        [Fact]
        public void ObjectId() => TestToDynamic(
            x => new BsonObjectId(new ObjectId("5c4749c7dc89373ee0cb549c")),
            "5c4749c7dc89373ee0cb549c"
        );

        [Fact]
        public void RegularExpression() => TestToDynamic(
            x => new BsonRegularExpression(x),
            (x, y) => ((Regex)x).ToString().Should().Be(y),
            "foobar"
        );

        [Fact]
        public void String() => TestToDynamic(x => new BsonString(x), "foo");

        [Fact]
        public void Timestamp() => TestToDynamic(x => new BsonTimestamp(x), 4269L);

        [Fact]
        public void Undefined() => TestToDynamic(BsonUndefined.Value, x => ((object)x).Should().BeNull());

        #endregion Public Methods

        #region Private Methods

        private void TestToDynamic<TBsonType, TCliType>(Func<TCliType, TBsonType> testeeFactory, TCliType expected)
            where TBsonType : BsonValue => TestToDynamic(testeeFactory(expected), expected);

        private void TestToDynamic<TBsonType, TCliType>(TBsonType testee, TCliType expected)
            where TBsonType : BsonValue => TestToDynamic(testee, r => ((TCliType)r).Should().Be(expected));

        private void TestToDynamic<TBsonType, TCliType>(
            Func<TCliType, TBsonType> testeeFactory, Action<dynamic, TCliType> check, TCliType expected
        ) where TBsonType : BsonValue => TestToDynamic(testeeFactory(expected), x => check(x, expected));

        private void TestToDynamic<TBsonType>(TBsonType testee, Action<dynamic> check)
            where TBsonType : BsonValue
        {
            BsonValue testee2 = testee;
            var result = testee.ToDynamic();
            var result2 = testee2.ToDynamic();
            check(result);
            check(result2);
        }

        #endregion Private Methods
    }
}