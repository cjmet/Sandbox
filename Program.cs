using Microsoft.EntityFrameworkCore;
using DataLibrary;
using System.Diagnostics;
using AngelHornetLibrary;
using static AngelHornetLibrary.AhLog;
using static DataLibrary.DataLibraryAdvancedSearch;
using static AngelHornetLibrary.AhStrings;


LogMsg("");
var _db = new PlaylistContext();
var _repository = new SongRepository(_db);
Console.WriteLine($"DB:{_db.Songs.Count()} Songs\n");
List<Song> _list = new List<Song>();

// Current Working Version
//(_list, _, _) = AdvancedSearchParse(_list, "IS Artist SEARCH Springst OR Petty OR Seger");



// New ISongRepository Version
//_list = await _repository.SearchQuery("Title", "Test Song");
//(_list, _, _) = AdvancedSearch(_list, "IS Artist SEARCH Springst OR Petty OR Seger");
//_list = await _repository.AdvancedSearchRepository("IS Title SEARCH Test Song");
//(_list, _, _) = await _repository.AdvancedSearchRepository(_list, "IS Artist SEARCH Springst OR Petty OR Seger");
//(_list, _, _) = await _repository.AdvancedSearchRepository(_list, "IS Path SEARCH Jackson Brodie IS Artist OR Lucinda Williams OR First Aid Kit OR Lucinda Williams OR Iris DeMent OR Lori McKenna OR Cowboy Junkies OR Eliza Gilkyson OR Gillian Welch OR Kris DelmHorst OR Lynn Miles OR Madison Violet OR Mary Gauthier OR Nanci Griffith OR Sarah McLachlan");

// Now check Multiple Part Query == 267
(_list, _, _) = await _repository.AdvancedSearchRepository(_list, "IS Path SEARCH Jackson Brodie IS Artist OR Lucinda Williams OR First Aid Kit");
(_list, _, _) = await _repository.AdvancedSearchRepository(_list, "IS Artist OR Lucinda Williams OR Iris DeMent OR Lori McKenna OR Cowboy Junkies");
(_list, _, _) = await _repository.AdvancedSearchRepository(_list, "IS Artist OR Eliza Gilkyson OR Gillian Welch OR Kris DelmHorst OR Lynn Miles");
(_list, _, _) = await _repository.AdvancedSearchRepository(_list, "IS Artist OR Madison Violet OR Mary Gauthier OR Nanci Griffith OR Sarah McLachlan");



_list = _list.OrderBy(s => s.AlphaTitle).ToList();
foreach (var s in _list)
{
    Console.WriteLine($"{TailTruncate(s.Title,30),-30} - {TailTruncate(s.Artist,30),-30} - {TailTruncate(s.Album,30),-30} - {TailTruncate(s.Genre,30).ToString()}");
}


Console.WriteLine($"\nFound: {_list.Count()} Songs");
Console.WriteLine("\nDone.");
Console.ReadLine();

