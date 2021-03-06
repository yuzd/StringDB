﻿using FluentAssertions;

using StringDB.Databases;
using StringDB.Fluency;
using StringDB.IO;
using StringDB.IO.Compatibility;
using StringDB.Transformers;

using System;
using System.IO;

using Xunit;

namespace StringDB.Tests
{
	public class FluencyTests
	{
		[Fact]
		public void ReturnsMemoryDatabase()
		{
			var db = new DatabaseBuilder()
				.UseMemoryDatabase<int, string>();

			db
				.Should()
				.BeOfType<MemoryDatabase<int, string>>();
		}

		[Fact]
		public void ReturnsIODatabase()
		{
			var db = new DatabaseBuilder()
				.UseIODatabase(new StoneVaultIODevice(new MemoryStream()));

			db
				.Should()
				.BeOfType<IODatabase>();
		}

		[Fact]
		public void ReturnsIODatabase_WhenUsingBuilderPattern()
		{
			var db = new DatabaseBuilder()
				.UseIODatabase(builder => builder.UseStoneVault(new MemoryStream()));

			db
				.Should()
				.BeOfType<IODatabase>();
		}

		[Fact]
		public void ReturnsTransformDatabase()
		{
			var db = new DatabaseBuilder()
				.UseMemoryDatabase<string, int>()
				.WithTransform(new MockTransformer().Reverse(), new MockTransformer());

			db.Should()
				.BeOfType<TransformDatabase<string, int, int, string>>();
		}

		[Fact]
		public void ReturnsThreadLockDatabase()
		{
			var db = new DatabaseBuilder()
				.UseMemoryDatabase<string, int>()
				.WithThreadLock();

			db.Should()
				.BeOfType<ThreadLockDatabase<string, int>>();
		}

		[Fact]
		public void ReturnsCacheDatabase()
		{
			var db = new DatabaseBuilder()
				.UseMemoryDatabase<string, int>()
				.WithCache();

			db.Should()
				.BeOfType<CacheDatabase<string, int>>();
		}

		[Fact]
		public void CreatesStringDB5_0_0LowlevelDatabaseIODevice()
		{
			var dbiod = new DatabaseIODeviceBuilder()
				.UseStringDB(StringDBVersions.v5_0_0, new MemoryStream());

			dbiod
				.Should()
				.BeOfType<DatabaseIODevice>();
		}

		[Fact]
		public void CreatesStringDB10_0_0LowlevelDatabaseIODevice()
		{
			var dbiod = new DatabaseIODeviceBuilder()
				.UseStringDB(StringDBVersions.v10_0_0, new MemoryStream());

			dbiod
				.Should()
				.BeOfType<DatabaseIODevice>();

			((DatabaseIODevice)dbiod)
				.LowLevelDatabaseIODevice
				.Should()
				.BeOfType<StringDB10_0_0LowlevelDatabaseIODevice>();
		}

		[Fact]
		public void LatestIsJust10()
		{
			var dbiod = new DatabaseIODeviceBuilder()
				.UseStringDB(StringDBVersions.Latest, new MemoryStream());

			dbiod
				.Should()
				.BeOfType<DatabaseIODevice>();

			((DatabaseIODevice)dbiod)
				.LowLevelDatabaseIODevice
				.Should()
				.BeOfType<StringDB10_0_0LowlevelDatabaseIODevice>();
		}

		[Fact]
		public void ThrowsOnInvalidStringDBCreation()
		{
			Action throws = () => new DatabaseIODeviceBuilder()
				.UseStringDB((StringDBVersions)1337, new MemoryStream());

			throws.Should()
				.ThrowExactly<NotSupportedException>();
		}

		[Fact]
		public void CreatesStoneVaultIODevice()
		{
			var dbiod = new DatabaseIODeviceBuilder()
				.UseStoneVault(new MemoryStream());

			dbiod
				.Should()
				.BeOfType<StoneVaultIODevice>();
		}
	}
}