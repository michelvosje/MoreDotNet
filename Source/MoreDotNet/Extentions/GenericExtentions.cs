﻿namespace MoreDotNet.Extentions
{
    using System;
    using System.Linq.Expressions;

    public static class GenericExtentions
    {
        public static bool IsBetween<T>(this T actual, T lowerBound, T upperBound) where T : IComparable<T>
        {
            return actual.CompareTo(lowerBound) >= 0 && actual.CompareTo(upperBound) < 0;
        }

        public static void ThrowIfArgumentIsNull<T>(this T obj, string parameterName) where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException(parameterName, parameterName + " not allowed to be null");
            }
        }

        public static string GetMemberName<T, TResult>(
            this T anyObject,
            Expression<Func<T, TResult>> expression)
        {
            return ((MemberExpression)expression.Body).Member.Name;
        }
    }
}