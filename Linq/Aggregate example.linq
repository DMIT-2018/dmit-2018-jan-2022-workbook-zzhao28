<Query Kind="Expression">
  <Connection>
    <ID>500a336c-eb1b-44f7-8fd3-2dedfa777146</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>DESKTOP-KHG3QVL\SQLEXPRESS</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
  </Connection>
</Query>

// Aggregates
// .Count()	counts the number of instances in the collection
// .Sum(x => ...) sums (totals) a numeric field (numeric expression) in the collection
// .Min(x => ...) finds the minumum value of a collection of values for a field
// .Max(x => ...) finds the maximum value of a collection of values for a field
// .Average(x => ...) finds the average value of a collection of values for a field

// IMPORTANT!!!!
// Aggregates work ONLY on a collection of values for a particular field
// Aggregates DO NOT work on a single row

// syntax
// query
// 	(from ....
//	 ...
//	select expression).aggregate()
// the expression is resolved to a single value for Sum, Min, Max, Average

// method
//	collectionset.aggregate(x => expression)
//	collectionset.Select(x => expression).aggregate()
//	collectionset.Count()	//.Count() does not contain an expression
// the expression is resolved to a single value for Sum, Min, Max, Average

// you can use multiple aggregates on a single column .Sum(x => expression).Min(x => expression)

// Find the average playing time (length) of track in our music collection

// thought process
// average is an aggregate
// what is the collection? a track is a member of the Tracks table
// what is the expression? Milliseconds

// query
(from x in Tracks
select x.Milliseconds).Average()

// method
//Tracks.Average() // aborts because collection has multiple fields
Tracks.Average(x => x.Milliseconds)
Tracks.Select(x => x.Milliseconds).Average()

// List all Albums of the 60s showing the title, artist and various
// aggregates for albums contining tracks.

// For each album show the number of tracks, the longest playing track,
// the shortest playing track, the total price of all tracks and the
// average playing length of the album tracks

// HINT: Albums has two navigational properties
//			Artist: points to the single parent record
//			Tracks: points to the collection of child records (tracks) of the album

Albums
	.Where(x => x.ReleaseYear > 1959 && x.ReleaseYear < 1970
			&& x.Tracks.Count() > 0)
	.Select(x => new
			{
				Title = x.Title,
				Artist = x.Artist.Name,
				NumberOfTracks = x.Tracks.Count(),
				LongestTrack = x.Tracks.Max(tr => tr.Milliseconds),
				ShortestTrack = (from tr in x.Tracks
								 select tr.Milliseconds).Min(),
				TotalPrice = x.Tracks.Sum(tr => tr.UnitPrice),
				AverageTrackLength = x.Tracks.Average(tr => tr.Milliseconds),
			})











