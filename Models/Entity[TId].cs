﻿#region header

// <copyright file="Entity[TId].cs" company="mikegrabski.com">
//      Copyright (c) 2012 Mike Grabski. All rights reserved.
// </copyright>

#endregion

using System;

namespace Models
{
    /// <summary>
    /// A generic root entity with a strongly typed ID.
    /// </summary>
    /// <typeparam name="TId">The type of the ID property.</typeparam>
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        private int? _hashCode;

        /// <summary>
        /// Gets the ID of the entity.
        /// </summary>
        public virtual TId Id { get; protected set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj is Entity<TId>) return Equals((Entity<TId>)obj);
            return true;

        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual bool Equals(Entity<TId> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetTypeUnproxied() != other.GetTypeUnproxied()) return false;
            return IsEquivalentTo(other);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            if (_hashCode.HasValue) return _hashCode.Value;

            if (IsTransient()) _hashCode = base.GetHashCode();
            else
            {
                unchecked
                {
                    _hashCode = (GetType().GetHashCode()*397) ^ Id.GetHashCode();
                }
            }

            return _hashCode.Value;
        }

        /// <summary>
        /// Returns whether or not the instance is transient; that is, whether or not it has been attached to a persistence medium.
        /// </summary>
        /// <returns>True if the instance is transient; otherwise, false.</returns>
        public virtual bool IsTransient()
        {
// ReSharper disable CompareNonConstrainedGenericWithNull
            return Id == null || default(TId).Equals(Id);
// ReSharper restore CompareNonConstrainedGenericWithNull
        }

        /// <summary>
        /// Returns the expected type, in the event that the current instance is a proxy.
        /// </summary>
        /// <returns>The unproxied type.</returns>
        public virtual Type GetTypeUnproxied()
        {
            return GetType();
        }

        private bool IsEquivalentTo(Entity<TId> compareTo)
        {
            return !IsTransient() && !compareTo.IsTransient() && Id.Equals(compareTo.Id);
        }
    }
}