using Microsoft.EntityFrameworkCore;
using DataLibrary;
using System.Diagnostics;
using AngelHornetLibrary;
using static AngelHornetLibrary.AhLog;
using System.Text.RegularExpressions;

LogTrace("");
var _db = new PlaylistContext();
Console.WriteLine($"Debug[732] DB:{_db.Songs.Count()}");

// Modular Advanced Search

// "Search"
List<string> tests = [
    "Rock",
    "Rock AND Roll",
    "OR Roll",
    "AND rock OR Roll", 
    "AND rock OR Roll AND Rock OR"
    ];

foreach (var test in tests)
{
    Console.WriteLine($"\nTest: {test}");
    ParseSearch(test);
}




static List<Song> ParseSearch(string searchString)
{
    // Op str Op .*
    // Op str$
    // str Op .* 

    var _s = searchString.Trim();
    Regex _regexSearchOperators = new Regex(@"^(AND|OR|NOT)\b(.*)\b$");



    Match _matchOp;

    _s = _s.Trim();
    _matchOp = _regexSearchOperators.Match(_s);

    

    if (_matchOp.Success)
    {
        foreach (Group _group in _matchOp.Groups)
        {
            Console.WriteLine($"Group: {_group.Value}");
        }

    }
    else
    {
        Console.WriteLine("No Match");
    }


    return new List<Song>();
}

