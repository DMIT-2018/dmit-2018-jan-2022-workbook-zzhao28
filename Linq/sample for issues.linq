<Query Kind="Expression" />

Artists.OrderBy(a => a.Name).Select(a => new { Name = a.Name})