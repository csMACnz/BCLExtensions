BCLExtensions
=============

Base Class Library Extensions for C# base class library classes, across .Net, Silverlight, WinRT.

Proposed Extensions
-------------------
* String FormatWith(this String format, params object[] parameters);
* String ValueOrEmptyIfNull(this String value)
* String ValueOrEmptyIfNullOrWhiteSpace(this String value)
* String ValueOrIfNull(this String value, String replacement)
* String ValueOrIfNullOrWhitespace(this String value, String replacement)
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