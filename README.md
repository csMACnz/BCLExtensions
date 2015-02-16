BCLExtensions
=============

[![License](http://img.shields.io/:license-mit-blue.svg)](http://csmacnz.mit-license.org)
[![NuGet](https://img.shields.io/nuget/v/BCLExtensions.svg)](https://www.nuget.org/packages/BCLExtensions)
[![NuGet](https://img.shields.io/nuget/dt/BCLExtensions.svg)](https://www.nuget.org/packages/BCLExtensions)
[![Gratipay](http://img.shields.io/gratipay/csMACnz.svg)](https://gratipay.com/csMACnz/)
[![Badges](http://img.shields.io/:badges-13/13-ff6799.svg)](https://github.com/badges/badgerbadgerbadger)

[![Stories in Ready](https://badge.waffle.io/csmacnz/BCLExtensions.png?label=ready&title=Ready)](https://waffle.io/csmacnz/BCLExtensions)
[![Stories in progress](https://badge.waffle.io/csmacnz/BCLExtensions.png?label=in%20progress&title=In%20Progress)](https://waffle.io/csmacnz/BCLExtensions)
[![Issue Stats](http://www.issuestats.com/github/csMACnz/BCLExtensions/badge/pr)](http://www.issuestats.com/github/csMACnz/BCLExtensions)
[![Issue Stats](http://www.issuestats.com/github/csMACnz/BCLExtensions/badge/issue)](http://www.issuestats.com/github/csMACnz/BCLExtensions)

[![AppVeyor Build status](https://img.shields.io/appveyor/ci/MarkClearwater/bclextensions.svg)](https://ci.appveyor.com/project/MarkClearwater/bclextensions)
[![Travis Build Status](https://img.shields.io/travis/csMACnz/BCLExtensions.svg)](https://travis-ci.org/csMACnz/BCLExtensions)

[![Coverage Status](https://img.shields.io/coveralls/csMACnz/BCLExtensions.svg)](https://coveralls.io/r/csMACnz/BCLExtensions?branch=master)
[![Coverity Scan Build Status](https://scan.coverity.com/projects/3770/badge.svg)](https://scan.coverity.com/projects/3770)

Base Class Library Extensions for C# base class library classes, across .Net, Silverlight, WinRT.

For now, this is build upon the most generic PCL possible, but may explore specific additional components if required.

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
* string Left(this string value, int length)
* string Right(this string value, int length)
* string SafeLeft(this string value, int length)
* string SafeRight(this string value, int length)
* string SafeToString&lt;T&gt;(this T item)
* string SafeTrim(this string value)
* string SafeTrimStart(this string value)
* string SafeTrimEnd(this string value)
* string SafeTruncate(this string value)
* string ToLines(this string value)
* string ToNoBlankLines(this string value)
* string JoinWith(this string value, string delimiter)
* string JoinAsLines(this string value)
* long NumberOfLines(this string s);
* long NumberOfNonBlankLines(this string s);
* bool IsNumeric(this string value, bool trimWhitespace = true)

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
* void AddRange&lt;T&gt;(this ICollection&lt;T&gt; collection, IEnumerable&lt;T&gt; itemsToAppend)
* ICollection&lt;T&gt; RemoveEach&lt;T&gt;(this ICollection&lt;T&gt; collection)
* ICollection&lt;T&gt; RemoveEach&lt;T&gt;(this ICollection&lt;T&gt; collection, Func&lt;T, bool&gt; whereExpression)
* ICollection&lt;T&gt; RemoveEach&lt;T&gt;(this ICollection&lt;T&gt; collection, Func&lt;T, int, bool&gt; whereExpression)
* ICollection&lt;T&gt; RemoveEachInReverse&lt;T&gt;(this ICollection&lt;T&gt; collection)
* ICollection&lt;T&gt; RemoveEachInReverse&lt;T&gt;(this ICollection&lt;T&gt; collection, Func&lt;T, bool&gt; whereExpression)
* ICollection&lt;T&gt; RemoveEachInReverse&lt;T&gt;(this ICollection&lt;T&gt; collection, Func&lt;T, int, bool&gt; whereExpression)
* ICollection&lt;T&gt; OrNullIfEmpty(this ICollection&lt;T&gt; collection)
* ICollection&lt;T&gt; OrEmptyIfNull(this ICollection&lt;T&gt; collection)


IList Extensions
----------------------
* IList&lt;T&gt; RemoveEach&lt;T&gt;(this IList&lt;T&gt; items)
* IList&lt;T&gt; RemoveEach&lt;T&gt;(this IList&lt;T&gt; items, Func&lt;T, bool&gt; whereExpression)
* IList&lt;T&gt; RemoveEach&lt;T&gt;(this IList&lt;T&gt; items, Func&lt;T, int, bool&gt; whereExpression)
* IList&lt;T&gt; RemoveEachInReverse&lt;T&gt;(this IList&lt;T&gt; items)
* IList&lt;T&gt; RemoveEachInReverse&lt;T&gt;(this IList&lt;T&gt; items, Func&lt;T, bool&gt; whereExpression)
* IList&lt;T&gt; RemoveEachInReverse&lt;T&gt;(this IList&lt;T&gt; items, Func&lt;T, int, bool&gt; whereExpression)
* IList&lt;T&gt; RemoveEachByIndex&lt;T&gt;(this IList&lt;T&gt; items)
* IList&lt;T&gt; RemoveEachByIndex&lt;T&gt;(this IList&lt;T&gt; items, Func&lt;T, bool&gt; whereExpression)
* IList&lt;T&gt; RemoveEachByIndex&lt;T&gt;(this IList&lt;T&gt; items, Func&lt;T, int, bool&gt; whereExpression)
* IList&lt;T&gt; RemoveEachByIndexInReverse&lt;T&gt;(this IList&lt;T&gt; items)
* IList&lt;T&gt; RemoveEachByIndexInReverse&lt;T&gt;(this IList&lt;T&gt; items, Func&lt;T, bool&gt; whereExpression)
* IList&lt;T&gt; RemoveEachByIndexInReverse&lt;T&gt;(this IList&lt;T&gt; items, Func&lt;T, int, bool&gt; whereExpression)
* IList&lt;T&gt; OrNullIfEmpty(this IList&lt;T&gt; items)
* IList&lt;T&gt; OrEmptyIfNull(this IList&lt;T&gt; items)


List Extensions
----------------------
* List&lt;T&gt; RemoveEach&lt;T&gt;(this List&lt;T&gt; items)
* List&lt;T&gt; RemoveEach&lt;T&gt;(this List&lt;T&gt; items, Func&lt;T, bool&gt; whereExpression)
* List&lt;T&gt; RemoveEach&lt;T&gt;(this List&lt;T&gt; items, Func&lt;T, int, bool&gt; whereExpression)
* List&lt;T&gt; RemoveEachInReverse&lt;T&gt;(this List&lt;T&gt; items)
* List&lt;T&gt; RemoveEachInReverse&lt;T&gt;(this List&lt;T&gt; items, Func&lt;T, bool&gt; whereExpression)
* List&lt;T&gt; RemoveEachInReverse&lt;T&gt;(this List&lt;T&gt; items, Func&lt;T, int, bool&gt; whereExpression)
* List&lt;T&gt; RemoveEachByIndex&lt;T&gt;(this List&lt;T&gt; items)
* List&lt;T&gt; RemoveEachByIndex&lt;T&gt;(this List&lt;T&gt; items, Func&lt;T, bool&gt; whereExpression)
* List&lt;T&gt; RemoveEachByIndex&lt;T&gt;(this List&lt;T&gt; items, Func&lt;T, int, bool&gt; whereExpression)
* List&lt;T&gt; RemoveEachByIndexInReverse&lt;T&gt;(this List&lt;T&gt; items)
* List&lt;T&gt; RemoveEachByIndexInReverse&lt;T&gt;(this List&lt;T&gt; items, Func&lt;T, bool&gt; whereExpression)
* List&lt;T&gt; RemoveEachByIndexInReverse&lt;T&gt;(this List&lt;T&gt; items, Func&lt;T, int, bool&gt; whereExpression)
* List&lt;T&gt; OrNullIfEmpty(this List&lt;T&gt; items)
* List&lt;T&gt; OrEmptyIfNull(this List&lt;T&gt; items)


IEnumerable Extensions
----------------------
* List&lt;T&gt; ToListOf&lt;T&gt;(this IEnumerable items)
* List&lt;T&gt; SafeToListOf&lt;T&gt;(this IEnumerable items)
* List&lt;T&gt; SafeToList&lt;T&gt;(this IEnumerable&lt;T&gt; items)
* T[] SafeToArray&lt;T&gt;(this IEnumerable&lt;T&gt; items)
* Dictionary&lt;TKey, TItem&gt; SafeToDictionary&lt;TItem, TKey&gt;(this IEnumerable&lt;T&gt; items, Func&lt;TItem, TKey&gt; keySelector)
* HashSet&lt;T&gt; SafeToHashSet&lt;T&gt;(this IEnumerable&lt;T&gt; items)
* HashSet&lt;T&gt; SafeToHashSet&lt;T&gt;(this IEnumerable&lt;T&gt; items, IEqualityComparer&lt;T&gt; equalityComparer)


Dictionary Extensions
---------------------
* Dictionary&lt;TKey, TValue&gt; OrNullIfEmpty(this Dictionary&lt;TKey, TValue&gt; dictionary)
* Dictionary&lt;TKey, TValue&gt; OrEmptyIfNull(this Dictionary&lt;TKey, TValue&gt; dictionary)
* T GetValueOrDefault&lt;TKey, TValue&gt;(this Dictionary&lt;TKey, TValue&gt; dictionary, TKey key) where TValue : struct
* T GetValueOrDefault&lt;TKey, TValue&gt;(this Dictionary&lt;TKey, TValue&gt; dictionary, TKey key, TValue defaultValue)


Type Extensions
---------------
* bool DerivesFrom&lt;Type&gt;(this object item) where T : class
* bool IsNullable(this Type itemType)
* IEnumerable&lt;Type&gt; SafeGetTypes(this Assembly assembly)


EnumExtensions
--------------
* void EnsureIsEnum&lt;T&gt;() where T : struct, IComparable, IConvertible, IFormattable
* bool IsEnum&lt;T&gt;() where T : struct, IComparable, IConvertible, IFormattable
* void EnsureIsEnum(this object enumerationValue)
* bool IsEnum(this object enumerationValue)


IntExtensions
-------------
* bool IsBetween(this int value, int lowerLimit, int upperLimit)
* bool IsBetweenExclusive(this int value, int lowerLimit, int upperLimit)
* bool IsBetween(this int value, ExclusiveInteger lowerLimit, ExclusiveInteger upperLimit)
* bool IsBetween(this int value, InclusiveInteger lowerLimit, ExclusiveInteger upperLimit)
* bool IsBetween(this int value, ExclusiveInteger lowerLimit, InclusiveInteger upperLimit)
* bool IsBetween(this int value, InclusiveInteger lowerLimit, InclusiveInteger upperLimit)
* InclusiveInteger Inclusive(this int value)
* ExclusiveInteger Exclusive(this int value)

Example : 5.IsBetween(2.Exclusive(), 5.Inclusive())


LongExtensions
-------------
* bool IsBetween(this long value, long lowerLimit, long upperLimit)
* bool IsBetweenExclusive(this long value, long lowerLimit, long upperLimit)
* bool IsBetween(this long value, ExclusiveLongInteger lowerLimit, ExclusiveLongInteger upperLimit)
* bool IsBetween(this long value, InclusiveLongInteger lowerLimit, ExclusiveLongInteger upperLimit)
* bool IsBetween(this long value, ExclusiveLongInteger lowerLimit, InclusiveLongInteger upperLimit)
* bool IsBetween(this long value, InclusiveLongInteger lowerLimit, InclusiveLongInteger upperLimit)
* InclusiveLongInteger Inclusive(this long value)
* ExclusiveLongInteger Exclusive(this long value)

Example: 5.IsBetween(2.Exclusive(), 5.Inclusive())


DecimalExtensions
-------------
* bool IsBetween(this decimal value, decimal lowerLimit, decimal upperLimit)
* bool IsBetweenExclusive(this decimal value, decimal lowerLimit, decimal upperLimit)
* bool IsBetween(this decimal value, ExclusiveDecimal lowerLimit, ExclusiveDecimal upperLimit)
* bool IsBetween(this decimal value, InclusiveDecimal lowerLimit, ExclusiveDecimal upperLimit)
* bool IsBetween(this decimal value, ExclusiveDecimal lowerLimit, InclusiveDecimal upperLimit)
* bool IsBetween(this decimal value, InclusiveDecimal lowerLimit, InclusiveDecimal upperLimit)
* InclusiveDecimal Inclusive(this decimal value)
* ExclusiveDecimal Exclusive(this decimal value)

Example: (5m).IsBetween((2m).Exclusive(), (5m).Inclusive())


Func Extensions
----------------------
* Action AsActionUsing&lt;T1, T2, T3, TResult&gt;(this Func&lt;T1, T2, T3, TResult&gt; action, T1 parameter1, T2 parameter2, T3 parameter3)
* Action AsActionUsing&lt;T1, T2, T3, T4, TResult&gt;(this Func&lt;T1, T2, T3, T4, TResult&gt; action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
* Action AsActionUsing&lt;T1, T2, T3, T4, T5, TResult&gt;(this Func&lt;T1, T2, T3, T4, T5, TResult&gt; action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
* Action AsActionUsing&lt;T1, T2, T3, T4, T5, T6, TResult&gt;(this Func&lt;T1, T2, T3, T4, T5, T6, TResult&gt; action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6)
* Action AsActionUsing&lt;T1, T2, T3, T4, T5, T6, T7, TResult&gt;(this Func&lt;T1, T2, T3, T4, T5, T6, T7, TResult&gt; action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7)
* Action AsActionUsing&lt;T1, T2, T3, T4, T5, T6, T7, T8, TResult&gt;(this Func&lt;T1, T2, T3, T4, T5, T6, T7, T8, TResult&gt; action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7, T8 parameter8)


Action Extensions
----------------------
* Action AsActionUsing&lt;T1&gt;(this Action&lt;T1&gt; action, T1 parameter1)
* Action AsActionUsing&lt;T1, T2&gt;(this Action&lt;T1, T2&gt; action, T1 parameter1, T2 parameter2)
* Action AsActionUsing&lt;T1, T2, T3&gt;(this Action&lt;T1, T2, T3&gt; action, T1 parameter1, T2 parameter2, T3 parameter3)
* Action AsActionUsing&lt;T1, T2, T3, T4&gt;(this Action&lt;T1, T2, T3, T4&gt; action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
* Action AsActionUsing&lt;T1, T2, T3, T4, T5&gt;(this Action&lt;T1, T2, T3, T4, T5&gt; action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
* Action AsActionUsing&lt;T1, T2, T3, T4, T5, T6&gt;(this Action&lt;T1, T2, T3, T4, T5, T6&gt; action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6)
* Action AsActionUsing&lt;T1, T2, T3, T4, T5, T6, T7&gt;(this Action&lt;T1, T2, T3, T4, T5, T6, T7&gt; action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7)
* Action AsActionUsing&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(this Action&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt; action, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7, T8 parameter8)


ExpressionExtensions
--------------------
* string GetMemberName&lt;TExpressionBody&gt;(this Expression&lt;TExpressionBody&gt; expression)


Example: ExpressionExtensions.GetMemberName(() =&gt; MyProperty)


Other
-----
* Build implementation of ContractAnnotation

Completed Extensions
====================

Object Extensions
-----------------
* void EnsureIsNotNull(this object instance)
* void EnsureIsNotNull(this object instance, string argumentName)
* bool IsNotNull(this object instance)
* bool IsNull(this object instance)


Generic Extensions
-----------------
* T GetValueOrDefault&lt;T&gt;(this T item, T defaultValue) where T : class


IEnumerable Extensions
----------------------
* bool IsNotEmpty&lt;TItem&gt;(this IEnumerable&lt;TItem&gt; items)
* bool IsNullOrEmpty&lt;TItem&gt;(this IEnumerable&lt;TItem&gt; items)
* IEnumerable&lt;TItem&gt; OrEmptyIfNull&lt;TItem&gt;(this IEnumerable&lt;TItem&gt; items)
* IEnumerable&lt;TItem&gt; OrNullIfEmpty&lt;TItem&gt;(this IEnumerable&lt;TItem&gt; items)


String Extensions
-----------------
* string FormatWith(this string format, params object[] parameters)
* bool IsNotNullOrWhitespace(this String s)
* bool IsNullOrWhitespace(this String s)
* string ValueOrEmptyIfNull(this string value)
* string ValueOrEmptyIfNullOrWhitespace(this string value)
* string ValueOrIfNull(this string value, String replacement)
* string ValueOrIfNullOrWhitespace(this string value, String replacement)
* string ValueOrNullIfWhitespace(this string value)


Type Extensions
---------------
* bool IsOfType&lt;T&gt;(this object item)


Array Extensions
----------------------
* void Clear&lt;T&gt;(this T[] items)
* T[] OrNullIfEmpty&lt;T&gt;(this T[] items)
* T[] OrEmptyIfNull&lt;T&gt;(this T[] items) 


Func Extensions
----------------------
* Action AsAction&lt;T&gt;(this Func&lt;T&gt; function)
* Action AsActionUsing&lt;TOutput, TParameter&gt;(this Func&lt;TParameter, TOutput&gt; function, TParameter parameter)
* Action AsActionUsing&lt;TOutput, TParameter1, TParameter2&gt;(this Func&lt;TParameter1, TParameter2, TOutput&gt; function, TParameter1 parameter1, TParameter2 parameter2)
