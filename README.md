# StringDB
<p align="center">
    <img src="https://rawcdn.githack.com/SirJosh3917/StringDB/master/icons/banner_ad.png" alt="StringDB" />
</p>

[![AppVeyor Build Status][badge_appveyor_build_image]][badge_appveyor_build_page]

[```Install-Package StringDB```][link_nuget]

StringDB embodies 2 things:

 - [Tiny][section_tiny]
 - [Modularity][section_modular]

## Get Started Right Now (for skimmers)

Skimming? Here's what you need to know:

| Feature   |   Description |
| ---  |  --- |
| new DatabaseBuilder() | Empty class that has extension methods built onto it to fluently create databases. |
| StringDatabase | Generally useless. Static class with helper methods to create string key/value DBs. |

Here's a code sample to get you started immedietly.
```cs
var transformer = new StringTransformer();
using (var db = new DatabaseBuilder()
	.UseIODatabase(builder => builder.UseStringDB
		(
			StringDBVersions.Latest,
			File.Open("my-db.db", FileMode.OpenOrCreate, FileAccess.ReadWrite)
		))
	.WithTransform(transformer, transformer))
{
	db.Insert("test", "value");
}
```

## Tiny ![icon_tiny]

StringDB is *tiny*. Use *tiny* amounts of RAM, and *tiny* amounts of space.

### [StringDB 10.0.0 file size after single inserts with 128 length keys and 1024 length values][source_insert_test]

| Inserts | Size (in KB, 1000 bytes) | Absolute Minimum Size Possible | StringDB Overhead Percentage |
| --- | --- | --- | --- |
| 1 | 1.172 KB | 1.152 KB | 1.706485% |
| 50 | 58.208 KB | 57.6 KB | 1.04453% |
| 100 | 116.408 KB | 115.2 KB | 1.037729% |

This chart shows the size of a StringDB file after multiple *single inserts*. Every key is 128 bytes long, and every value is 1024 bytes long. By doing single inserts, file size is dramatically affected due to the additional overhead for the index chain.

### [StringDB 10.0.0 file size after an insert range with 128 length keys and 1024 length values][source_insertrange_test]

| Elements in Insert Range | Size (in KB, 1000 bytes) | Absolute Minimum Size Possible | StringDB Overhead Percentage |
| --- | --- | --- | --- |
| 1 | 1.172 KB | 1.152 KB | 1.706485% |
| 50 | 57.963 KB | 57.6 KB | 0.626262% |
| 100 | 115.913 KB | 115.2 KB | 0.615117% |

This chart shows the size of a StringDB file after a single insert range with the amount of items specified.

## Modular ![icon_modular]

StringDB was made to be *modular*. Pick up features and use them as you need them, *when* you need them.

By chaining database types to extend functionality, you become freed and can easily add and extend functionality without sacrificing cleanliness or testability.

```cs
using (var db = new DatabaseBuilder()
	.UseMemoryDatabase<string, string>()
	.WithThreadLock()
	.WithCache())
{
}
```

## Addons

StringDB will officially maintain support for integration with some libraries. [View them here.][link_addons]

## We welcome issues!

Don't be afraid to make an issue about anything and everything!

- Is there something weird with how databases are created? Submit an issue!
- Is there something that you wish you could do but can't? Submit an issue!
- Is this library not suitable for your purposes? Submit an isssue!
- Want it to do something? Submit an issue!

I'd be more then happy to see someone actually using my library, and by fixing that issue I can help satisfy users in the future in addition to yourself!

Need immediate assistence? [Join the discord!](https://discord.gg/wVcnkKJ)

[icon_banner_ad]: ./icons/banner_ad.png
[icon_modular]: ./icons/modular.png
[icon_tiny]: ./icons/tiny.png
[icon_understand]: ./icons/understand.png

[badge_appveyor_build_image]: https://ci.appveyor.com/api/projects/status/github/SirJosh3917/StringDB?svg=true
[badge_appveyor_build_page]: https://ci.appveyor.com/project/sirjosh3917/stringdb

[link_nuget]: https://www.nuget.org/packages/StringDB
[link_addons]: ./addons/addons.md

[section_modular]: #modular-
[section_tiny]: #tiny-
[section_understandable]: #understandable-
[section_simple]: #simple-

[source_insert_test]: ./src/StringDB.PerformanceNumbers/SingleInsertFileSize.cs
[source_insertrange_test]: ./src/StringDB.PerformanceNumbers/InsertRangeFileSize.cs

[wiki_stringdb_format]: https://github.com/SirJosh3917/StringDB/wiki/StringDB-10.0.0-Format
[wiki_tutorials]: https://github.com/SirJosh3917/StringDB/wiki/Getting-Started