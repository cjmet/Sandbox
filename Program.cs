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
    "AND rock OR Roll AND Rock NOT",
    "Rock Rolling Stones Down the AND Mountain",
    "IS Title Soft Rock OR Heavy Metal NOT Metallica",
    "== Title ?? Soft Rock || Heavy Metal !! Metallica",
    "&& Rock", 
    "|| Rock", 
    "!! Rock",
    "== Roll",
    "?? Rock",
    ];

foreach (var test in tests)
{
    Console.WriteLine($"\nTest: {test}");
    ParseSearch(test);
}
Console.ReadLine();



static List<Song> ParseSearch(string _searchString)
{
    //  &&  ||  !! ==   ??
    // (AND|OR|NOT|IS|SEARCH)
    var _s = _searchString.Trim();
    Regex _regexSearchOperators = new Regex(@"^\s*(AND|OR|NOT|IS|SEARCH|&&|\|\||!!|==|\?\?)\s(.*)$");
    Regex _regexSearchStrings = new Regex(@"\b\s+(AND|OR|NOT|IS|SEARCH|&&|\|\||!!|==|\?\?)\s(.*)");

    _searchString = _searchString.Trim();
    var _matchOp = _regexSearchOperators.Match(_searchString);
    string _operator1 = "";
    string _operator2 = "";
    string _search = "";


    if (_matchOp.Success)
    {
        _operator1 = _matchOp.Groups[1].Value;
        _searchString = _matchOp.Groups[2].Value;
    }
    else
    {
        _operator1 = "SEARCH";
    }


    var _matchStr = _regexSearchStrings.Match(_searchString);
    if (_matchStr.Success)
    {
        _operator2 = _matchStr.Groups[1].Value;
        _search = _searchString.Substring(0,_matchStr.Groups[1].Index).Trim();
        _searchString = _searchString.Substring(_matchStr.Groups[1].Index).Trim();
        //_search = _matchStr.Groups[1].Value;
        //_searchString = _matchStr.Groups[2].Value;
    }
    else if ( _searchString.Length > 0)
    {
        _search = _searchString;
        _searchString = "";
    }
    else
    {
        Console.WriteLine($"Syntax Error: No Search String found in \"{_operator1} {_searchString}\"");
        _search = "Syntax Error!";
    }

    //Console.WriteLine($"Operator: {_operator} Search: {_search} Remainder: {_searchString}");
    var _op = $"[{_operator1}]";
    Console.WriteLine($"{_op,-8} [{_search}] :: [{_operator2}] / [{_searchString}]");


    if (_searchString.Length > 0)
    {
       ParseSearch(_searchString);
    }
   
    return new List<Song>();
}

