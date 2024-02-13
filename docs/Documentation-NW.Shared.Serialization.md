# NW.Shared.Serialization
Contact: numbworks@gmail.com

## Revision History

| Date | Author | Description |
|---|---|---|
| 2024-02-13 | numbworks | Created. |

## Introduction

`NW.Shared.Serialization` is a library that provides a facade over _System.Text.Json.JsonSerializer_ in order to simplify serialization and deserialization activities.

## Getting Started

In order to use the library:

1. download and install the library in your project via NuGet - for ex. by using the Visual Studio UI or the .NET CLI:

```
dotnet add package NW.Shared.Serialization --version 1.0.0
```

2. reference and start using the library:

```csharp
using System;
using NW.Shared.Files;
using NW.Shared.Serialization;

/* ... */

private void Save<T>(T obj, IFileInfoAdapter jsonFile)
{

    _componentBag.LoggingAction(Forecasts.MessageCollection.AttemptingToSaveObjectAs(typeof(T), jsonFile));

    try
    {

        ISerializer<T> serializer = _componentBag.SerializerFactory.Create<T>();
        string content = serializer.Serialize(obj);

        _componentBag.FileManager.WriteAllText(jsonFile, content);

        _componentBag.LoggingAction(Forecasts.MessageCollection.ObjectSuccessfullySaved(typeof(T)));

    }
    catch
    {

        _componentBag.LoggingAction(Forecasts.MessageCollection.ObjectFailedToSave(typeof(T)));

    }

}
/* ... */
```

3. Done!

## Markdown Toolset

Suggested toolset to view and edit this Markdown file:

- [Visual Studio Code](https://code.visualstudio.com/)
- [Markdown Preview Enhanced](https://marketplace.visualstudio.com/items?itemName=shd101wyy.markdown-preview-enhanced)
- [Markdown PDF](https://marketplace.visualstudio.com/items?itemName=yzane.markdown-pdf)
