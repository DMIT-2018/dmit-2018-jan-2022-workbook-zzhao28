<Query Kind="Statements">
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

// Statement IDE
// you can have multiple queries written in this IDE environment
// you can execute a query individually by highlighting
//	the desired query first
// BY DEFAULT executing a file in this environment executes
//		ALL queries, top to bottom

// IMPORTANT
// queries in this environment MUST be written using the
//		C# language grammar for a statement. This means that
//		each statement must end in a semi-colon
// result MUST be placed in a receiving variable
// to display the results, use the Linqpad method .Dump()


// query syntax
// query: Find all albums released in 2000. Display the entire
//		album record
var paramyear = 1990;
var resultsq = from x in Albums
				where x.ReleaseYear == paramyear
				select x;
//resultsq.Dump();


// method syntax
Albums
	.Where(x => (x.ReleaseYear == 2000))
	.Select(x => x)
	.Dump();