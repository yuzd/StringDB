﻿using FluentAssertions;

using StringDB.Databases;

using System.Collections.Generic;

using Xunit;

namespace StringDB.Tests
{
	public class MemoryDatabaseTests
	{
		[Fact]
		public void Works()
		{
			var mdb = new MemoryDatabase<string, int>();

			mdb.InsertRange(new KeyValuePair<string, int>[]
			{
				new KeyValuePair<string, int>("a", 1),
				new KeyValuePair<string, int>("b", 2),
				new KeyValuePair<string, int>("c", 3),
			});

			mdb.Keys()
				.Should()
				.BeEquivalentTo
				(
					new[]
					{
						"a", "b", "c"
					}
				);

			mdb.ValuesAggressive()
				.Should()
				.BeEquivalentTo
				(
					new[]
					{
						1, 2, 3
					}
				);

			mdb.InsertRange(new KeyValuePair<string, int>[]
			{
				new KeyValuePair<string, int>("a", 1),
				new KeyValuePair<string, int>("b", 2),
				new KeyValuePair<string, int>("c", 3),
			});

			mdb.Keys()
				.Should()
				.BeEquivalentTo
				(
					new[]
					{
						"a", "b", "c", "a", "b", "c"
					}
				);

			mdb.ValuesAggressive()
				.Should()
				.BeEquivalentTo
				(
					new[]
					{
						1, 2, 3, 1, 2, 3
					}
				);
		}
	}
}