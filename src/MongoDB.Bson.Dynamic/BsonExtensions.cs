using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace MongoDB.Bson
{
    public static class BsonExtensions
    {
        #region Public Methods

        public static dynamic ToDynamic(this BsonValue bsonValue)
        {
            if (bsonValue is BsonArray bsonArray)
            {
                return bsonArray.ToDynamic();
            }

            if (bsonValue is BsonBinaryData bsonBinaryData)
            {
                return bsonBinaryData.ToDynamic();
            }

            if (bsonValue is BsonBoolean bsonBoolean)
            {
                return bsonBoolean.ToDynamic();
            }

            if (bsonValue is BsonDateTime bsonDateTime)
            {
                return bsonDateTime.ToDynamic();
            }

            if (bsonValue is BsonDecimal128 bsonDecimal128)
            {
                return bsonDecimal128.ToDynamic();
            }

            if (bsonValue is BsonDocument bsonDocument)
            {
                return bsonDocument.ToDynamic();
            }

            if (bsonValue is BsonDouble bsonDouble)
            {
                return bsonDouble.ToDynamic();
            }

            if (bsonValue is BsonInt32 bsonInt32)
            {
                return bsonInt32.ToDynamic();
            }

            if (bsonValue is BsonInt64 bsonInt64)
            {
                return bsonInt64.ToDynamic();
            }

            if (bsonValue is BsonJavaScript bsonJavaScript)
            {
                return bsonJavaScript.ToDynamic();
            }

            if (bsonValue is BsonMaxKey bsonMaxKey)
            {
                return bsonMaxKey.ToDynamic();
            }

            if (bsonValue is BsonMinKey bsonMinKey)
            {
                return bsonMinKey.ToDynamic();
            }

            if (bsonValue is BsonNull bsonNull)
            {
                return bsonNull.ToDynamic();
            }

            if (bsonValue is BsonObjectId bsonObjectId)
            {
                return bsonObjectId.ToDynamic();
            }

            if (bsonValue is BsonRegularExpression bsonRegularExpression)
            {
                return bsonRegularExpression.ToDynamic();
            }

            if (bsonValue is BsonString bsonString)
            {
                return bsonString.ToDynamic();
            }

            if (bsonValue is BsonTimestamp bsonTimestamp)
            {
                return bsonTimestamp.ToDynamic();
            }

            if (bsonValue is BsonUndefined bsonUndefined)
            {
                return bsonUndefined.ToDynamic();
            }

            return null;
        }

        public static dynamic ToDynamic(this BsonArray bsonArray) => bsonArray.Select(x => x.ToDynamic()).ToArray();

        public static dynamic ToDynamic(this BsonBinaryData bsonBinaryData) => bsonBinaryData.Bytes;

        public static dynamic ToDynamic(this BsonBoolean bsonBoolean) => bsonBoolean.Value;

        public static dynamic ToDynamic(this BsonDateTime bsonDateTime) => bsonDateTime.ToUniversalTime();

        public static dynamic ToDynamic(this BsonDecimal128 bsonDecimal128) => bsonDecimal128.ToDecimal();

        public static dynamic ToDynamic(this BsonDocument bsonDocument)
        {
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (var bsonElement in bsonDocument)
            {
                expando.Add(bsonElement.Name, bsonElement.Value.ToDynamic());
            }

            return expando;
        }

        public static dynamic ToDynamic(this BsonDouble bsonDouble) => bsonDouble.Value;

        public static dynamic ToDynamic(this BsonInt32 bsonInt32) => bsonInt32.Value;

        public static dynamic ToDynamic(this BsonInt64 bsonInt64) => bsonInt64.Value;

        public static dynamic ToDynamic(this BsonJavaScript bsonJavaScript) => bsonJavaScript.Code;

        public static dynamic ToDynamic(this BsonMaxKey bsonMaxKey) => bsonMaxKey.ToString();

        public static dynamic ToDynamic(this BsonMinKey bsonMinKey) => bsonMinKey.ToString();

        public static dynamic ToDynamic(this BsonNull bsonNull) => null;

        public static dynamic ToDynamic(this BsonObjectId bsonObjectId) => bsonObjectId.ToString();

        public static dynamic ToDynamic(this BsonRegularExpression bsonRegularExpression) => bsonRegularExpression.ToRegex();

        public static dynamic ToDynamic(this BsonString bsonString) => bsonString.Value;

        public static dynamic ToDynamic(this BsonTimestamp bsonTimestamp) => bsonTimestamp.Value;

        public static dynamic ToDynamic(this BsonUndefined bsonUndefined) => null;

        #endregion Public Methods
    }
}