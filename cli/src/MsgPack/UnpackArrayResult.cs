﻿#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2010 FUJIWARA, Yusuke
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
#endregion -- License Terms --

using System;
using System.Collections.Generic;
using System.Globalization;

namespace MsgPack
{
	/// <summary>
	///		Represents result of direct conversion from the byte array.
	/// </summary>
	/// <typeparam name="T">Type of value.</typeparam>
	public struct UnpackArrayResult<T> : IEquatable<UnpackArrayResult<T>>
	{
		private readonly int _newOffset;

		/// <summary>
		///		Get new offset of input byte array.
		/// </summary>
		/// <value>
		///		New offset of input byte array.
		///		If this value equals to old offset, then a value of <see cref="Value"/> property is not undifined.
		/// </value>
		public int NewOffset
		{
			get { return this._newOffset; }
		}

		private readonly T _value;

		/// <summary>
		///		Get retrieved value from the byte array.
		/// </summary>
		/// <value>
		///		Retrieved value from the byte array.
		///		If <see cref="NewOffset"/> equals to old offset, then a value of this property is not undefined.
		/// </value>
		public T Value
		{
			get { return this._value; }
		}

		internal UnpackArrayResult( T value, int newOffset )
		{
			this._value = value;
			this._newOffset = newOffset;
		}

		/// <summary>
		///		Compare two instances are equal.
		/// </summary>
		/// <param name="obj"><see cref="UnpackArrayResult&lt;T&gt;"/> instance.</param>
		/// <returns>
		///		If <paramref name="obj"/> is <see cref="UnpackArrayResult&lt;T&gt;"/> and its value is equal to this instance, then true.
		///		Otherwise false.
		/// </returns>
		public override bool Equals( object obj )
		{
			if ( !( obj is UnpackArrayResult<T> ) )
			{
				return false;
			}
			else
			{
				return this.Equals( ( UnpackArrayResult<T> )obj );
			}
		}

		/// <summary>
		///		Compare two instances are equal.
		/// </summary>
		/// <param name="other"><see cref="UnpackArrayResult&lt;T&gt;"/> instance.</param>
		/// <returns>
		///		Whether value of <paramref name="other"/> is equal to this instance or not.
		/// </returns>
		public bool Equals( UnpackArrayResult<T> other )
		{
			return this._newOffset == other._newOffset && EqualityComparer<T>.Default.Equals( this._value, other._value );
		}

		/// <summary>
		///		Get hash code of this instance.
		/// </summary>
		/// <returns>Hash code of this instance.</returns>
		public override int GetHashCode()
		{
			return this._newOffset.GetHashCode() ^ ( this._value == null ? 0 : this._value.GetHashCode() );
		}

		/// <summary>
		///		Get string representation of this object.
		/// </summary>
		/// <returns>String representation of this object.</returns>
		/// <remarks>
		///		<note>
		///			DO NOT use this value programmically. 
		///			The purpose of this method is informational, so format of this value subject to change.
		///		</note>
		/// </remarks>
		public override string ToString()
		{
			return String.Format( CultureInfo.CurrentCulture, "{0}@{1}", this._value, this._newOffset );
		}

		/// <summary>
		///		Compare two instances are equal.
		/// </summary>
		/// <param name="left"><see cref="UnpackArrayResult&lt;T&gt;"/> instance.</param>
		/// <param name="right"><see cref="UnpackArrayResult&lt;T&gt;"/> instance.</param>
		/// <returns>
		///		Whether value of <paramref name="left"/> and <paramref name="right"/> are equal each other or not.
		/// </returns>
		public static bool operator ==( UnpackArrayResult<T> left, UnpackArrayResult<T> right )
		{
			return left.Equals( right );
		}

		/// <summary>
		///		Compare two instances are not equal.
		/// </summary>
		/// <param name="left"><see cref="UnpackArrayResult&lt;T&gt;"/> instance.</param>
		/// <param name="right"><see cref="UnpackArrayResult&lt;T&gt;"/> instance.</param>
		/// <returns>
		///		Whether value of <paramref name="left"/> and <paramref name="right"/> are not equal each other or are equal.
		/// </returns>		
		public static bool operator !=( UnpackArrayResult<T> left, UnpackArrayResult<T> right )
		{
			return !left.Equals( right );
		}
	}
}
