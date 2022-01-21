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

// Using Navigational properties and anonymous data set (collection)

// reference: Student Note/Demo/eRestaurant/Linq: Query and Method Syntax/Expressions

// Find all albums release in th 90'x (1990-1999)
// Order the album by ascending year and then by album title
// Display the Year, Title, Artist Name and Release Label

// concern: a) not all properties of Album are to be displayed
//			b) the order of the properties are to be displayed
//			   in a different sequence then the definition of
//			   the properties on the entity
//			c) the artist name is in a separate entity

// solution: use an anonymous dataset

// use the object initialization syntax to create new instances
//	to be produced for the resulting dataset

// the anonymous instance is defined within the .Select by
//		specifying the properties desired in the dataset

Albums
	.Where(x => x.ReleaseYear > 1989 && x.ReleaseYear <= 1999)
	.OrderBy(x => x.ReleaseYear)
	.ThenBy(x => x.Title)
	.Select(x => new
	{
		Year = x.ReleaseYear,
		Title = x.Title,
		Artist = x.Artist.Name,
		Label = x.ReleaseLabel
	})



// Find all albums release in th 90'x (1990-1999)
// Order the album by artist, title
// Display the Artist Name, Title, Year and Release Label

Albums
	.Where(x => x.ReleaseYear > 1989 && x.ReleaseYear <= 1999)
	.OrderBy(x => x.Artist.Name)
	.ThenBy(x => x.ReleaseYear)
	.ThenBy(x => x.Title)
	.Select(x => new
	{
		Name = x.Artist.Name,
		Title = x.Title,
		Year = x.ReleaseYear,
		Label = x.ReleaseLabel
	})


