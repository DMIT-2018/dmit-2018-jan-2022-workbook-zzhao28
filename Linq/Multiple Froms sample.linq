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

// Multiple non-joined tables: Froms (query syntax) or .SelectMany() (method syntax)
//	TableA -> TableB -> TableC (grandparent -> parent -> grandchild)
// report from TableA and TableC but not from TableB

// report from Albums and PlaylistTracks but not from Track

// one possible way of doing the query is to "join" the table using the
//	 join clouse

// However this limits and confinds the optimization the Linq and Sql can
//	 create
// it works BUT you should FIRST ALWAYS consider using navigation properties
//		BEFORE doing your own join conditions

// List all albums (Title) of the 70's with the number of songs that
//	 exists on the album. Also, list the song, the playlistName and
//	 the owner of the playlist.

//	 Album -> Tracks -> PlaylistTracks has a parent called Playlist
//	 using Album, PlaylistTracks and parents .Track and .Playlist

// method and query syntax
Albums
	.Where(a => a.ReleaseYear > 1969 && a.ReleaseYear < 1980)
	.Select(a => new
				{
					title = a.Title,
					trackcount = a.Tracks.Count(),
					playlistsongs = from tr in a.Tracks
										from pltrk in tr.PlaylistTracks
										select new
										{
											song = pltrk.Track.Name,
											playlist = pltrk.Playlist.Name,
											listowner = pltrk.Playlist.UserName
										}
				})
	.OrderBy(a => a.title)

// method syntax only
Albums
   .Where(a => ((a.ReleaseYear > 1969) && (a.ReleaseYear < 1980)))
   .Select(
	  a =>
		 new
		 {
			 title = a.Title,
			 trackcount = a.Tracks.Count(),
			 playlistsongs = a.Tracks
			   .SelectMany(
				  tr => tr.PlaylistTracks,
				  (tr, pltrk) =>
					 new
					 {
						 song = pltrk.Track.Name,
						 playlist = pltrk.Playlist.Name,
						 listowner = pltrk.Playlist.UserName
					 }
			   )
		 }
   )
   .OrderBy(a => a.title)