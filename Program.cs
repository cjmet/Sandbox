using static AngelHornetLibrary.CLI.CliSystem;


using Microsoft.VisualStudio.Shell;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

using System;
using System.IO;
using System.Reflection;

using System;
using EnvDTE;
using EnvDTE80;
using System.Reflection;


class Program
{
    static void Main(string[] args)
    {
        string fileName = FindFileInVisualStudio("filename.txt");
        Console.WriteLine($"Filename: {fileName}");

    }
}


