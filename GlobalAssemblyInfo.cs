/* 
 * blogger2jekyll - Blogger to Jekyll conversion utility
 * Copyright (c) 2012 Cargile Techology Group, LLC
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */ 

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
