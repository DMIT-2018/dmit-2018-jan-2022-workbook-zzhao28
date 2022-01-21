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

// Sorting

// there is a significant difference between query syntax and method syntax

// query syntax is much like sql
//		orderby field [asc/]desc [,field [asc/]desc] , ...]
// asc ascending, desc descending
// asc is the default option

// method syntax is a series of individual methods
//	.OrderBy(x => field)
//	.OrderByDescending(x => x.field)
//	after one of these two beginning methods
//	.ThenBy(x => x.field)
//	.ThenByDescending(x => x.field)

// Find all albums release in the 90'x (1990-1999)
// Order the album by ascending year and then by album title
// Display the entire album record

// often the ordering phrase may be done with the work "within"
// without the "within" the implied order is major to minor in the list of fields
// with the "within" the implied order is minor to major in the list of fields

// Order by album title within ascending year

// query syntax
from x in Albums
where x.ReleaseYear > 1989 && x.ReleaseYear <= 1999
orderby x.ReleaseYear, x.Title
select x

// method syntax
Albums
	.Where(x => x.ReleaseYear > 1989 && x.ReleaseYear <= 1999)
	.OrderBy(x => x.ReleaseYear)
	.ThenBy(x => x.Title)
	.Select(x => x)




