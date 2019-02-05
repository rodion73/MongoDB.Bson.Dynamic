using FluentAssertions;
using Xunit;

namespace MongoDB.Bson
{
    public class Test_BsonExtensions
    {
        #region Public Methods

        [Fact]
        public void ToDynamic_Array()
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
        public void ToDynamic_BinaryData()
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
        public void ToDynamic_Boolean()
        {
            var data = true;
            var testee1 = new BsonBoolean(data);
            BsonValue testee2 = testee1;
            var result1 = testee1.ToDynamic();
            var result2 = testee2.ToDynamic();
            ((bool)result1).Should().Be(data);
            ((bool)result2).Should().Be(data);
        }

        #endregion Public Methods
    }
}