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

// Where
// filter method
// the conditions are setup as you would in C#
// beware that linqpad may NOT like some C# syntax (DateTime)
// beware that linq is converted to SQL which may not
//	like certain C# syntax because SQL could not convert

// syntax
// Notice that the method syntax makes uses of Lambda expressions.
// Lambda are common when performing LINQ with the Method syntax.
// .Where(Lambda expression)
// .Where(x => condition [logical operator condition2 ...])

// Find all albums released in the 90s (1990 - 1999)
// Display the entire album records

Albums
	.Where(x => x.ReleaseYear >= 1990
			&& x.ReleaseYear < 2000)
	.Select(x => x)
	
// Find all the albums of the artist Queen.
// concern: the artist name is in another table
//			in an sql Select query you would be using an Inner Join
//			in Linq you DO NOT need to specify your inner Joins
//			instead use the "navigational properties" of your entity
//				to generate the relationship

// .Equals() is an extract match, in sql = (like 'string')
// .Contains() is a string match, in sql like '%' + string + '%'

Albums
	.Where(a => a.Artist.Name.Contains("Queen"))
	.Select(x => x)
	
// Find all albums where the producer (Label) is unknown

Albums
	.Where(x => x.ReleaseLabel.HasValue)
	.Select(x => x)