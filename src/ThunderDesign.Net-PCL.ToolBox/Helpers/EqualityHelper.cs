using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ThunderDesign.Net_PCL.ToolBox.Helpers
{
    public static class EqualityHelper
    {
        public static bool Equality<T>(ref T backingStore, T value)
        {
            if (typeof(T) == typeof(string))
            {
                return StringEquality(ref backingStore, value);
            }
            else if (typeof(IStructuralEquatable).IsAssignableFrom(typeof(T)))
            {
                return StructureEquality(ref backingStore, value);
            }
            else if (typeof(T).IsValueType)
            {
                return ValueEquality(ref backingStore, value);
            }
            else
            {
                return ReferenceEquality(ref backingStore, value);
            }
        }

        /// <summary>
        /// Checks for equality between two string values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore"></param>
        /// <param name="value"></param>
        /// <returns cref="bool" indicating whether the two values are equal.></returns>
        /// <exception cref="InvalidOperationException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StringEquality<T>(ref T backingStore, T value)
        {
            if (typeof(T) != typeof(string))
            {
                throw new InvalidOperationException($"Type: {typeof(T)} cannot be used with string types.");
            }

            return string.Equals(backingStore as string, value as string, StringComparison.Ordinal);
        }

        /// <summary>
        /// Checks for equality between two structural values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore"></param>
        /// <param name="value"></param>
        /// <returns cref="bool" indicating whether the two values are equal.></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StructureEquality<T>(ref T backingStore, T value)
        {
            if (!typeof(IStructuralEquatable).IsAssignableFrom(typeof(T)))
            {
                throw new InvalidOperationException($"Type: {typeof(T)} cannot be used with structural types.");
            }
            else if (backingStore == null && value == null)
            {
                return true;
            }
            else if (backingStore == null || value == null)
            {
                return false;
            }

            var structuralEquatable = backingStore as IStructuralEquatable;
            return structuralEquatable.Equals(value, StructuralComparisons.StructuralEqualityComparer);
        }

        /// <summary>
        /// Checks for equality between two value types.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore"></param>
        /// <param name="value"></param>
        /// <returns cref="bool" indicating whether the two values are equal.></returns>
        /// <exception cref="InvalidOperationException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValueEquality<T>(ref T backingStore, T value)
        {
            if (!typeof(T).IsValueType)
            {
                throw new InvalidOperationException($"Type: {typeof(T)} cannot be used with value types.");
            }

            return EqualityComparer<T>.Default.Equals(backingStore, value);
        }

        /// <summary>
        /// Checks for equality between two reference types.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore"></param>
        /// <param name="value"></param>
        /// <returns cref="bool" indicating whether the two values are equal.></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ReferenceEquality<T>(ref T backingStore, T value)
        {
            return ReferenceEquals(backingStore, value);
        }
    }
}
