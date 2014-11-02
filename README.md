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
* string SafeToString&lt;T&gt;(this T item)
* string SafeTrim(this string value)
* string SafeTrimStart(this string value)
* string SafeTrimEnd(this string value)
* string SafeTruncate(this string value)
* bool IsNullOrWhitespace(this String s);
* bool IsNotNullOrWhitespace(this String s);


Generic Extensions
-----------------
* bool IsNull&lt;T&gt;(this T item) where T : object
* bool IsNotNull&lt;T&gt;(this T item) where T : object
* T GetValueOrDefault&lt;T&gt;(this T item, T default) where T : object


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
* ICollection&lt;T&gt; RemoveEach&lt;T&gt;(this ICollection&lt;T&gt; collecton)
* ICollection&lt;T&gt; RemoveEach&lt;T&gt;(this ICollection&lt;T&gt; collecton, Func&lt;T, bool&gt; whereExpression)
* ICollection&lt;T&gt; RemoveEach&lt;T&gt;(this ICollection&lt;T&gt; collecton, Func&lt;T, int, bool&gt; whereExpression)
* ICollection&lt;T&gt; RemoveEachInReverse&lt;T&gt;(this ICollection&lt;T&gt; collection)
* ICollection&lt;T&gt; RemoveEachInReverse&lt;T&gt;(this ICollection&lt;T&gt; collection, Func&lt;T, bool&gt; whereExpression)
* ICollection&lt;T&gt; RemoveEachInReverse&lt;T&gt;(this ICollection&lt;T&gt; collection, Func&lt;T, int, bool&gt; whereExpression)
* ICollection&lt;T&gt; RemoveEachByIndex&lt;T&gt;(this ICollection&lt;T&gt; collection)
* ICollection&lt;T&gt; RemoveEachByIndex&lt;T&gt;(this ICollection&lt;T&gt; collection, Func&lt;T, bool&gt; whereExpression)
* ICollection&lt;T&gt; RemoveEachByIndex&lt;T&gt;(this ICollection&lt;T&gt; collection, Func&lt;T, int, bool&gt; whereExpression)
* ICollection&lt;T&gt; RemoveEachByIndexInReverse&lt;T&gt;(this ICollection&lt;T&gt; collection)
* ICollection&lt;T&gt; RemoveEachByIndexInReverse&lt;T&gt;(this ICollection&lt;T&gt; collection, Func&lt;T, bool&gt; whereExpression)
* ICollection&lt;T&gt; RemoveEachByIndexInReverse&lt;T&gt;(this ICollection&lt;T&gt; collection, Func&lt;T, int, bool&gt; whereExpression)
* ICollection&lt;T&gt; OrNullIfEmpty(this ICollection&lt;T&gt; items);
* ICollection&lt;T&gt; OrEmptyIfNull(this ICollection&lt;T&gt; items);
* IList&lt;T&gt; OrNullIfEmpty(this IList&lt;T&gt; items);
* IList&lt;T&gt; OrEmptyIfNull(this IList&lt;T&gt; items);
* List&lt;T&gt; OrNullIfEmpty(this List&lt;T&gt; items);
* List&lt;T&gt; OrEmptyIfNull(this List&lt;T&gt; items);
* T[] OrNullIfEmpty(this T[] items);
* T[] OrEmptyIfNull(this T[] items);

IEnumerable Extensions
----------------------
* IEnumerable&lt;T&gt; OrNullIfEmpty(this IEnumerable&lt;T&gt; items);
* IEnumerable&lt;T&gt; OrEmptyIfNull(this IEnumerable&lt;T&gt; items);

Dictionary Extensions
---------------------
* Dictionary<&lt;TKey, TValue&gt; OrNullIfEmpty(this Dictionary<&lt;TKey, TValue&gt; dictionary);
* Dictionary<&lt;TKey, TValue&gt; OrEmptyIfNull(this Dictionary<&lt;TKey, TValue&gt; dictionary);

Completed Extensions
====================
* string FormatWith(this string format, params object[] parameters);
