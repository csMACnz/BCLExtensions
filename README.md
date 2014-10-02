BCLExtensions
=============

Base Class Library Extensions for C# base class library classes, across .Net, Silverlight, WinRT.

For now, this is build upon the most generic PCL possible, but may explore specific additional components if required.

[![Build status](https://ci.appveyor.com/api/projects/status/j06g6b18e976wx3b)](https://ci.appveyor.com/project/MarkClearwater/bclextensions)

PCL Profile(Profile328)
-----------------------
* .Net Framework 4
* Silverlight 5
* Windows 8/8.1(winrt)
* Windows Phone 8.1
* Window Phone Silverlight 8
* Xamarin.Android
* Xamarin.iOS

At some point this can include nuget packages.

Proposed Extensions
===================

String Extensions
-----------------
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


Generic Extensions
-----------------
* bool IsNull<T>(this T item) where T : object
* bool IsNotNull<T>(this T item) where T : object
* T GetValueOrDefault<T>(this T item, T default) where T : object

Timespan Extensions
-------------------
* TimeSpan Years(this int value)
* TimeSpan Months(this int value)
* TimeSpan Weeks(this int value)
* TimeSpan Days(this int value)
* TimeSpan Hours(this int value)
* TimeSpan Minutes(this int value)
* TimeSpan Seconds(this int value)
* TimeSpan Milliseconds(this int value)

DateTime Extensions
-------------------
* DateTime Ago(this TimeSpan interval)
* DateTime Since(this TimeSpan interval, DateTime origin)


(Mutable)Collection Extensions
-------------------
T RemoveEach<T>(this ICollection<T> collecton)
T RemoveEach<T>(this ICollection<T> collecton, Func<T, bool> whereExpression)
T RemoveEach<T>(this ICollection<T> collecton, Func<T, int, bool> whereExpression)
T RemoveEachInReverse<T>(this ICollection<T> collection)
T RemoveEachInReverse<T>(this ICollection<T> collection, Func<T, bool> whereExpression)
T RemoveEachInReverse<T>(this ICollection<T> collection, Func<T, int, bool> whereExpression)
T RemoveEachByIndex<T>(this ICollection<T> collection)
T RemoveEachByIndex<T>(this ICollection<T> collection, Func<T, bool> whereExpression)
T RemoveEachByIndex<T>(this ICollection<T> collection, Func<T, int, bool> whereExpression)
T RemoveEachByIndexInReverse<T>(this ICollection<T> collection)
T RemoveEachByIndexInReverse<T>(this ICollection<T> collection, Func<T, bool> whereExpression)
T RemoveEachByIndexInReverse<T>(this ICollection<T> collection, Func<T, int, bool> whereExpression)

Completed Extensions
====================
* string FormatWith(this string format, params object[] parameters);
