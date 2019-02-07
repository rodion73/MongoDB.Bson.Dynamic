# MongoDB.Bson.Dynamic


Extension methods to convert any BsonValue to dynamics.

## Installation

### Nuget

> Install-Package MongoDB.Bson.Dynamic -Version 1.0.0

### .NET CLI

> dotnet add package MongoDB.Bson.Dynamic --version 1.0.0

## Sample usage

```csharp
using MongoDB.Bson;

var doc = new BsonDocument {
    { "StringProperty", "Foo" },
    { "NumberProperty", 42 },
    { "DateTimeProperty", DateTime.Now },
    { "ArrayProperty", new BsonArray {"hello", "world"} },
    { "NestedDoc", new BsonDocument {
        { "StringProperty", "Bar" },
        { "NumberProperty", 69}
    }}
};

var dynamicDoc = doc.ToDynamic();

Console.WriteLine(dynamicDoc.StringProperty); // "Foo"
Console.WriteLine(dynamicDoc.NumberProperty); // 42
Console.WriteLine(dynamicDoc.DateTimeProperty); // UTC datetime
Console.WriteLine(dynamicDoc.ArrayProperty[0]); // "hello"
Console.WriteLine(dynamicDoc.ArrayProperty[1]); // "world"
Console.WriteLine(dynamicDoc.NestedDoc.StringProperty); // "Bar"
Console.WriteLine(dynamicDoc.NestedDoc.NumberProperty); // 69

```
