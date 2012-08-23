using System.Reflection;
using System.Runtime.InteropServices;
using log4net.Config;

[assembly: AssemblyCompany("Cargile Technology Group, LLC")]
[assembly: AssemblyProduct("blogger2jekyll")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("1.1.0.0")]
[assembly: AssemblyFileVersion("1.1.0.0")]
[assembly: XmlConfigurator(Watch = true)]

#if !DEBUG
[assembly: AssemblyConfiguration("Relase")]
#else
[assembly: AssemblyConfiguration("Debug")]
#endif
