# 📖 Noisrev.League.IO.RST

***This is a library that parses and manipulates League of Legends RST files.***

![NetStandard](https://img.shields.io/badge/.Net%20Standard-v2.0-brightgreen) ![LICENSE](https://img.shields.io/github/license/noisrev/noisrev.league.io.rst) [![Downloads](https://img.shields.io/nuget/dt/noisrev.league.io.rst)](https://www.nuget.org/stats/packages/Noisrev.League.IO.RST?groupby=Version) [![PackageVersion](https://img.shields.io/nuget/v/noisrev.league.io.rst)](https://www.nuget.org/packages/Noisrev.League.IO.RST/)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FNoisrev%2FNoisrev.League.IO.RST.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FNoisrev%2FNoisrev.League.IO.RST?ref=badge_shield)

![NetFramework](https://img.shields.io/badge/.Net%20Framework->=4.6.1-green) ![NetCore](https://img.shields.io/badge/.Net%20Core->=v2.0-blue) [![CodeQL](https://github.com/Noisrev/Noisrev.League.IO.RST/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/Noisrev/Noisrev.League.IO.RST/actions/workflows/codeql-analysis.yml) [![.NET](https://github.com/Noisrev/Noisrev.League.IO.RST/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Noisrev/Noisrev.League.IO.RST/actions/workflows/dotnet.yml)

[![Bilibili](https://img.shields.io/badge/dynamic/json?color=ff69b4&label=bilibili&query=%24.data.totalSubs&url=https%3A%2F%2Fapi.spencerwoo.com%2Fsubstats%2F%3Fsource%3Dbilibili%26queryKey%3D176863848)](https://space.bilibili.com/176863848)

# ✨ RST (Riot String Table) 
The RST file is a file that stores a list of strings.

It is used to store the game text and messages for **League of Legends**.
- champion name, skill description, skin name, etc...
- *Like:* **"Riven"**, **"Championship Riven 2016"**, **"\<mainText>\<stats>\<attention>%i:scaleAP% 25\</attention> Ability Power\<br>\<attention>%i:scaleMPen% 15%\</attention> Magic Penetration\</stats>\</mainText>\<br>"**
- And more...

***If you would like to see more details about the RST file, please see: [RSTFile.cs](Noisrev.League.IO.RST/RSTFile.cs).***

# 📢 Notice

In version 3.0, I refactored most of the read and write code to improve performance.
A faster BytesReader and a BytesWriter were created to optimize read and write operations.

| Method |              Runtime |      Mean | Allocated |
|------- |--------------------- |----------:|----------:|
| (Version 3)
|   Open |             .NET 6.0 |  74.13 ms |     36 MB |
|  Write |             .NET 6.0 |  52.20 ms |     30 MB |
| (Before)
|   Open |             .NET 6.0 |  323.0 ms |    120 MB |
|  Write |             .NET 6.0 |  434.6 ms |     46 MB |

***Read and write will now be faster and less memory allocated than before!***

# 🎉 Release Note

***3.1.2***
- Enable `source link` support for the nuget package in project.
- Improve and optimize the code.

***3.1.1***
- Add multi-target framework.
- Update project properties and package references.
- Enable `nullable` for project and improve the code.

***3.1***
- Fix a bug (https://github.com/Noisrev/Noisrev.League.IO.RST/issues/4) where the end byte of the written string is not 0.

***v3.0***
- Added new RSTBuilder (content to build RSTFile).
- Deprecated **Extensions.Data.xxHash.core20** package, change to use **Standart.Hash.xxHash** package.
- New BytesReader and BytesWriter were created to improve performance.
- Optimized Read and Write performance of RSTFile (now **76%** faster (Read) and **87%** (Write)).
- Set the Release Optimize to true (I've never noticed that before...).
- Test projects are tested using BenchmarkDotnet.
- Update and fix some code comments.

***v2.0***
- Change it to Dictionary for faster retrieval and storage.
- Disabling Hash changes (read only).

***v1.4.1.2***
- Update "Equals" Method.

***v1.4.1.1***
- Add indexer to RSTFile and add check for duplicates.

***v1.4.1***
- Optimizing the Equals method.
- Add "Load" and "Write" methods to support file path input.

***v1.4.0***
- Fixed a bug in version 1.3.3 (This bug causes the file contents to not be written out correctly).
- Changed Framework to ".NET Standard 2.0" to be compatible with ".NET Framework" and ".NET Core".

***~~v1.3.3~~*** **[Deprecated]** 🙄
- Add the RST file version enumeration.

***v1.3.2***
- Added a new RType extension function that returns the corresponding RType based on the input Version(int or byte).
- Fixed some code comments.
- Fill in the missing Api documentation.

***v1.3.1***
- Change the get method for "DataOffset".

***v1.3.0***
- Support RST v5.
- Fix some code.
- Correct some code comments.

***v1.2.1***
- Remove unnecessary code.

***v1.2***
- Remove lazy loading mode.
- Add the "SetConfig" method. // This is only applicable to RST files in version 2.1

***v1.1***
- Add "Insert" method.

***v1.0***
- Support for reading and writing RST.
- Support loading RST files using lazy loading mode.
- Add" Add", "Find", "Remove", "ReplaceAll" methods.
- Add "RST Hash Algorithm".

# 🚀 Install
- Install in Visual Studio using NuGet Package Manager.
- .NET CLI : `dotnet add package Noisrev.League.IO.RST`

# 💡 Simple
```
using Noisrev.League.IO.RST;

var rst = RSTFile.Load("your rst file path");
```


## License
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FNoisrev%2FNoisrev.League.IO.RST.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2FNoisrev%2FNoisrev.League.IO.RST?ref=badge_large)
