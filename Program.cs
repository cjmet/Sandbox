using Microsoft.EntityFrameworkCore;
using DataLibrary;



var _db = new PlaylistContext();
var _playlist = _db.Songs.Where(s => s.Title.Contains("Acoustic"));
var _songs = _db.Songs.Where(s => s.Title.Contains("Rock"));
var _results = _songs;


_results = _playlist.Union(_songs);         // OR
_results = _playlist.Intersect(_songs);     // AND
_results = _playlist.Except(_songs);        // NOT

