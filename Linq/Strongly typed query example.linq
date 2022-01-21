<Query Kind="Program">
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

void Main()
{
	// Strongly typed queris
	
	// Anonymous dataset from a query does NOT have a specified class definition
	// Strongly type query dataset HAS a specified class definition
	
	// Find all songs that contain a partial string of the Track name.
	
	// imagining the following is in the code-behind of our Razor page
	string partialSongName = "dance";
	List<SongList> results = SongsByPartialName(partialSongName);
	results.Dump();
	
}

// You can define other methods, fields, classes and namespaces here

// imagine the following method exists in a service in your BLL

List<SongList> SongsByPartialName(string partialSongName)
{
	// to change and Anonymous dataset to a strongly typed dataset
	//	add the datatype to the new operator
	
	// one could use var variablename = OR
	// 			 use IEnumerable<T> variablename = where T is a defined class
	
	IEnumerable<SongList> songCollection = Tracks
						.Where(t => t.Name.Contains(partialSongName))
						.Select(t => new SongList
						{
							Album = t.Album.Title,
							Song = t.Name,
							Artist = t.Album.Artist.Name
						});
	return songCollection.ToList();
}

// developer define data type
public class SongList
{
	public string Album{get;set;}
	public string Song{get;set;}
	public string Artist{get;set;}
}














