using FluentAssertions;
using System;
using Xunit;

namespace MongoDB.Bson
{
    public class Test_BsonExtensions
    {
        #region Public Methods

        [Fact]
        public void Array()
        {
            var data = new[] { "foo", "bar", "baz" };
            var testee1 = new BsonArray(data);
            BsonValue testee2 = testee1;
            var result1 = testee1.ToDynamic();
            var result2 = testee2.ToDynamic();
            ((dynamic[])result1).Should().Equal(data);
            ((dynamic[])result2).Should().Equal(data);
        }

        [Fact]
        public void BinaryData()
        {
            var data = new byte[] { 42, 17, 93 };
            var testee1 = new BsonBinaryData(data);
            BsonValue testee2 = testee1;
            var result1 = testee1.ToDynamic();
            var result2 = testee2.ToDynamic();
            ((byte[])result1).Should().Equal(data);
            ((byte[])result2).Should().Equal(data);
        }

        [Fact]
        public void Boolean()
        {
            var data = true;
            TestToDynamic(new BsonBoolean(data), data);
        }

        [Fact]
        public void DateTime()
        {
            var data = new DateTime(1973, 9, 8, 7, 42, 39, DateTimeKind.Utc);
            TestToDynamic(new BsonDateTime(data), data);
        }

        [Fact]
        public void Decimal128()
        {
            var data = 42.69m;
            TestToDynamic(new BsonDecimal128(data), data);
        }

        #endregion Public Methods

        #region Private Methods

        private void TestToDynamic<TBsonType, TCliType>(TBsonType testee, TCliType expected) where TBsonType : BsonValue
        {
            BsonValue testee2 = testee;
            var result = testee.ToDynamic();
            var result2 = testee2.ToDynamic();
            ((TCliType)result).Should().Be(expected);
            ((TCliType)result2).Should().Be(expected);
        }

        #endregion Private Methods
    }
}