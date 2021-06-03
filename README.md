[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Exceptions?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Exceptions/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Exceptions.svg)](https://www.nuget.org/packages/ByteDev.Exceptions)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.Exceptions/blob/master/LICENSE)

# ByteDev.Exceptions

Small collection of exceptions in a .NET Standard library.

## Installation

ByteDev.Exceptions has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Exceptions is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Exceptions`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Exceptions/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.Exceptions/blob/master/docs/RELEASE-NOTES.md).

## Usage

The library consists of a small set of custom exceptions:

- `ArgumentDefaultException`
- `ArgumentEmptyException`
- `ArgumentNullOrEmptyException`
- `ArgumentNullOrWhiteSpaceException`
- `DependencyNullException`
- `EntityNotFoundException`
- `UnexpectedEnumValueException`

---

### `ArgumentDefaultException`

Use when an argument value cannot be it's `default` value.

Often in such situations the programmer will decide to throw a `ArgumentException`. 

Using a `ArgumentDefaultException` instead can give greater precision of the problem.

```csharp
if (myArg == default)
{
    throw new ArgumentDefaultException(nameof(myArg));
}
```

---

### `ArgumentEmptyException`

Use when an argument value cannot be empty. 

For example in the case of an empty string or empty collection.

Often in such situations the programmer will decide to throw a `ArgumentException`. 

Using a `ArgumentEmptyException` instead can give greater precision of the problem.

```csharp
if (name == string.Empty)
{
    throw new ArgumentEmptyException(nameof(name));
}
```

---

### `ArgumentNullOrEmptyException`

Use when an argument value cannot be null or empty. 

Often in such situations the programmer will decide to throw a `ArgumentException`. 

Using a `ArgumentNullOrEmptyException` instead can give greater precision of the problem.

```csharp
if (string.IsNullOrEmpty(name))
{
    throw new ArgumentNullOrEmptyException(nameof(name));
}
```

---

### `ArgumentNullOrWhiteSpaceException`

Use when an argument string value cannot be null or whitespace.

Often in such situations the programmer will decide to throw a `ArgumentException`. 

Using a `ArgumentNullOrWhiteSpaceException` instead can give greater precision of the problem.

```csharp
if (string.IsNullOrWhiteSpace(name))
{
    throw new ArgumentNullOrWhiteSpaceException(nameof(name));
}
```

---

### `DependencyNullException`

Use when an injected dependency is null.

Classes often have dependencies that are injected at runtime through constructor, method or property injection.

A developer will often check the passed in dependency and if null throw a `ArgumentNullException`. 

Using a `DependencyNullException` instead can give greater precision of the problem.

```csharp
public MyService(IRepository repository)
{
    _repository = repository ?? throw new DependencyNullException(typeof(IRepository));
}
```

---

### `EntityNotFoundException`

Use when an entity is expected to exist and does not.

For example an entity retrieved from storage or a database. 

Sometimes instead of returning `null` from the method throwing an exception may seem more appropriate.

```csharp
var customer = customerRepository.GetCustomer(id);

if (customer == null)
{
    throw new EntityNotFoundException(typeof(Customer), id);
}
```

---

### `UnexpectedEnumValueException`

Use when an unexpected `enum` value is encountered.

```csharp
enum LightStatus
{
    Off,
    Dimmed,
    On
}

// ...

switch (lightStatus)
{
    case LightStatus.Off:
        // do something...
        break;

    case LightStatus.Dimmed:
        // do something...
        break;

    case LightStatus.On:
        // do something...
        break;

    default:
        throw new UnexpectedEnumValueException<LightStatus>(lightStatus);
}
```
