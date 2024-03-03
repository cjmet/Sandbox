using Microsoft.EntityFrameworkCore;
using DataLibrary;
using System.Diagnostics;
using AngelHornetLibrary;
using static AngelHornetLibrary.AhLog;

LogTrace("");

var _rock = "rockies";
var _roll = "Song1";

IQueryable<Song>? _selectionSet = new List<Song>().AsQueryable();

_rock = _rock.ToLower();
_roll = _roll.ToLower();
var _db = new PlaylistContext();
Console.WriteLine($"Debug[732] DB:{_db.Songs.Count()}");

{ // Debug
    Console.WriteLine("Debug[738] and Breakpoint");
    var _select = _db.Songs.Where(s => s.Id < 0).DefaultIfEmpty();      // This should always be an empty song, and type IQueryable<Song?>?, but not null.

    Console.WriteLine($"Debug[740] First_Set:{_select.Count()}");

    var _test = _db.Songs.Where(s => s.Title.ToLower().Contains(_roll)).DefaultIfEmpty();
    Console.WriteLine($"Debug[741] SecondSet:{_test.Count()}");

    var _res = _select.Union(_test);
    Console.WriteLine($"Debug[744] Union:{_res.Count()}");

    foreach (var _song in _res)
    {
        if (_song == null)
        {
            Console.WriteLine($"Debug[748] Song:NULL");
            continue;
        }
        Console.WriteLine($"Debug[748] Song[{_song.Id}]: {_song.Title}");
    }

    Console.WriteLine($"Debug[744] Union:{_res.Count()}");

    _res = _select.Intersect(_test);
    Console.WriteLine($"Debug[744] Intersect:{_res.Count()}");

    _res = _select.Except(_test);
    Console.WriteLine($"Debug[744] Except:{_res.Count()}");

} // /Debug
