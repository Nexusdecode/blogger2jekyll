blogger2jekyll
==============

A command line tool for converting Blogger content to the Jekyll format used by Github pages. I built blogger2jekyll 
to tackle conversions on a Windows machine where using existing Ruby-based tools wasn't possible. 

## How It Works
blogger2jekyll uses a standard Blogger XML export file to create a set of properly named and formatted files for 
conversion by Jekyll and Liquid by using an XSLT stylesheet. The tool uses an intermediate set of entities to stage the 
data, as this provides better pre-processing and extensibility options.

The bundled stylsheet outputs posts in a HTML format, however, you are free to change the XSLT if you'd prefer to use 
something different, say Markdown or Textile. If anyone finds this useful and wants me to include alternative format  
stylesheets, send a pull request.

By default, posts are output to the __converted_ folder, relative to the execution path of blogger2jekyll.exe. 

A pared-down XML sample of my old Blogger site is provided in the unit test project for testing.

## Limitations
At present blogger2jekyll recognizes page, layout, and configuration-related etnries in the source XML, but these are 
not converted. In other words, only posts will be generated.

## Installation
Download the latest package from the project's [downloads](https://github.com/kcargile/blogger2jekyll/downloads) page. 
Extract the zip to a folder on your machine, add your Blogger XML export, and you're ready to go.

## Building blogger2jekyll Yourself
Clone the repository, open blogger2jekyll.sln in Visual Studio, select the desired configuration, and click Build -> 
Build Solution (F6). Alternatively, you can build from the command line using csc. For example:
```powershell
	csc /target:exe /out:blogger2jekyll.dll /nologo /debug *.cs
```

## Usage
```powershell
	blogger2jekyll /in:<inputpath> /out:<outputpath>
```
* _inputpath_ is the path to your Blogger XML export file.
* _outputpath_ overrides the path where exported posts will be written (defaults to _converted).

## Dependencies
blogger2jekyll is was written in C# and requires the MS.NET Framework version 4.0. The only other external dependency
is log4net, which will be installed automatically by Nuget when you build the solution. Otherwise, all you'll need is 
your Blogger export XML file (see the next section).

## Getting Your Blogger Export File
See Google's documentation on importing and exporting blog data [here]([GitHub](http://support.google.com/blogger/bin/answer.py?hl=en&answer=97416). 

## Issues
If you find an bug please [open an issue](https://github.com/kcargile/blogger2jekyll/issues) or alternatively contact 
me via my [blog](http://www.kriscargile.com). For support, please see this readme.

## License
Released under the GPL license. Use at your own risk. Copyright (c) 2012, Cargile Technology Group, LLC.