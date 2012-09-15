BCLExtensions
=============

Base Class Library Extensions for C# base class library classes, across .Net, Silverlight, WinRT.

Proposed Extensions
-------------------
* string FormatWith(this string format, params object[] parameters);
* string ValueOrEmptyIfNull(this string value)
* string ValueOrEmptyIfNullOrWhiteSpace(this string value)
* string ValueOrIfNull(this string value, String replacement)
* string ValueOrIfNullOrWhitespace(this string value, String replacement)
* string Left(this string value, int length)
* string Right(this string value, int length)
* string SafeLeft(this string value, int length)
* string SafeRight(this string value, int length)
* string SafeToString<T>(this T item)
* string SafeTrim(this string value)
* string SafeTrimStart(this string value)
* string SafeTrimEnd(this string value)
* string SafeTruncate(this string value)
* bool IsNullOrWhitespace(this String s);
* bool IsNotNullOrWhitespace(this String s);
* bool IsNull<T>(this T item) where T : object
* bool IsNotNull<T>(this T item) where T : object
* T GetValueOrDefault<T>(this T item, T default) where T : object
* TimeSpan Years(this int value)
* TimeSpan Months(this int value)
* TimeSpan Weeks(this int value)
* TimeSpan Days(this int value)
* TimeSpan Hours(this int value)
* TimeSpan Minutes(this int value)
* TimeSpan Seconds(this int value)
* TimeSpan Milliseconds(this int value)
* DateTime Ago(this TimeSpan interval)
* DateTime Since(this TimeSpan interval, DateTime origin)

Completed Extensions
--------------------
[Nothing Yet]