﻿using JetBrains.Annotations;

using StringDB.Databases;

using System.Runtime.CompilerServices;

namespace StringDB.Fluency
{
	/// <summary>
	/// Fluent extensions for a <see cref="ThreadLockDatabase{TKey,TValue}"/>.
	/// </summary>
	[PublicAPI]
	public static class ThreadLockDatabaseExtensions
	{
		/// <summary>
		/// Apply a lock to a database.
		/// </summary>
		/// <typeparam name="TKey">The type of key.</typeparam>
		/// <typeparam name="TValue">The type of value.</typeparam>
		/// <param name="database">The database to put a lock on.</param>
		/// <returns>A <see cref="ThreadLockDatabase{TKey,TValue}"/>.</returns>
		[NotNull]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IDatabase<TKey, TValue> WithThreadLock<TKey, TValue>
		(
			[NotNull] this IDatabase<TKey, TValue> database
		)
			=> new ThreadLockDatabase<TKey, TValue>(database);
	}
}