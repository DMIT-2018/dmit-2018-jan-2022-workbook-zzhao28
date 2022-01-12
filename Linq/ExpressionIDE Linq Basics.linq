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

// Our code is using C# grammar/syntax

// comments are done with slashes
// hotkey make line comment ctrl+k, ctrl+c
//					uncomment ctrl+l,ctrl+u
// alternate is to use ctrl + / as the toggle

// Expression
//	single linq query statements without a semi-colon
//	you can have multiple statements in your file BUT
//		if you do, you MUST highlight the statement to execute

// execute using F5 or the green triangle on the query menu

// to toggle your results on and off (visible) use ctrl + R

// query syntax
//	uses a "sql-like" syntax
//	view the Student Notes for examples under
//		Demo/eRestaurant/Linq Query and Method syntax
//	or Notes/Linq Intro

// remember to set your database usage connection

// query: Find all albums released in 2000. Display the entire
//			album record

from therowinstanceplaceholder in Albums
where therowinstanceplaceholder.ReleaseYear == 2000
select therowinstanceplaceholder

// method syntax
// uses C# method syntax OOP language grammar
// collection: Albums
// to execute a method on the collection you need to use
//	the access operator (dot operator)
// results a resulting collection from the method !!!!!*****
// method name starts with a capital
// methods contain contents with a delegate
// a delegate describes the action to be done

Albums
	.Where(therowinstanceplaceholder => therowinstanceplaceholder.ReleaseYear == 2000)
	.Select(therowinstanceplaceholder => therowinstanceplaceholder)






