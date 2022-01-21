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

// Using the ternary operator

//	condition(s) ? true value: false value

// both true value and false value MUST resolve to a 
// Single piece of data (a single value)

// compare to a conditional statement

// if (condition(s))
//  [{]
//		true path (complex logic)
//  [}]
// else
//  [{]
//		false path (complex logic)
//	[}]

// just like a conditional statement which can
//	have nested logic, the true value and false value
//	can have nested ternary operators as long as
//	the final result is a SINGLE value.

// List all albums by release label. Any album with
// no label should be indicated as Unknown. List Title,
// label and artist name.


// solution solving techniques (understand problem)
//	collection: Albums
//	ordering: by release label
//	fields: title, label and artist name (anonymous dataset)

// design
//	method syntax
//	 OrderBy()
//	 Select( => new)
//	 navigational property Artist -> name
//	 *** label is either the data value or Unkown (if null)

// coding and testing
Albums
	//.OrderBy(a => a.ReleaseLabel)
	.Select(a => new
			{
				Title = a.Title,
				Label = a.ReleaseLabel == null ? "Unknown" : a.ReleaseLabel,
				Artist = a.Artist.Name
			})
	.OrderBy(a => a.Label)

// List all albums showing the Title, Artist name, Year and decade
// of release (oldies, 70s, 80s, 90s or modern).
// Order by artist.

Albums
	.OrderBy(a => a.Artist.Name)
	.Select(a => new
			{
				Title = a.Title,
				Artist = a.Artist.Name,
				Year = a.ReleaseYear,
				Decade = a.ReleaseYear < 1970 ? "Oldies" :
									(a.ReleaseYear < 1980 ? "70s" :
									(a.ReleaseYear < 1990 ? "80s" :
									(a.ReleaseYear < 2000 ? "90s" : "Modern")))
			})
// if condition
//		oldies
//	else
//	{
// 		if condition
//			70s
//		else
//		{
// 			if condition
//				80s
//			else
//			{
// 				if condition
//					90s
//				else
//					modern
//			}
//		}
//	}



// Order by release decade (oldest to newest)
Albums
	.Select(a => new
			{
				Title = a.Title,
				Artist = a.Artist.Name,
				Year = a.ReleaseYear,
				Decade = a.ReleaseYear < 1970 ? "Oldies" :
									(a.ReleaseYear < 1980 ? "70s" :
									(a.ReleaseYear < 1990 ? "80s" :
									(a.ReleaseYear < 2000 ? "90s" : "Modern")))
			})
	.OrderBy(a => a.Year)
	
	
	
	