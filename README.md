blogger2jekyll
==============

A command line tool for converting Blogger content to the Jekyll format used by Github pages. I built blogger2jekyll 
to tackle conversions on a Windows machine where using existing Ruby-based tools wasn't possible. 

## How It Works
blogger2jekyll uses a standard Blogger XML export file to create a set of properly named and formatted files for 
conversion by Jekyll and Liquid by using an XSLT stylesheet. The tool uses an intermediate set of entities to stage the 
data, as this provides better pre-processing and extensibility options.

The bundled stylsheet ouputs posts in a HTML format, however, you are free to change the XSLT if you'd prefer to use 
something different, say Markdown or Textile. If anyone finds this useful and buids stylesheets in either of these 
format's, I'll happily pull them into the mainline.

## Limitations
At present blogger2jekyll recognizes page, layout, and configuration-related etnries in the source XML, but these are 
not converted. In other words, only posts will be generated.

## Building blogger2jekyll
Clone the repository, open blogger2jekyll.sln in Visual Studio, select the desired configuration, and click Build -> 
Build Solution (F6). Alternatively, you can build from the command line using MSBUILD:
```powershell
  TBD
```

## Usage
```powershell
  TBD
```

## Dependencies
blogger2jekyll is was written in C# and requires the MS.NET Framework version 4.0. The only other external dependency
is log4net, which will be installed automatically by Nuget when you build the solution. Otherwise, all you'll need is 
your Blogger export XML file (see the next section).

## Getting Your Blogger Export File
See Google's documenation on importing and exporting blog data [here]([GitHub](http://support.google.com/blogger/bin/answer.py?hl=en&answer=97416). 

## License
Released under the GPL license. Use at your own risk.