using Entity;
using BzLayer;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
MoviesBz movie=new MoviesBz();
List<Movie>movielist=movie.GetMovies();
if(movielist!=null)
{
    foreach(var i in movielist)
    Console.WriteLine($"{i.Id} {i.Name} {i.Ratings} {i.Ryear}");
}
else
Console.WriteLine("No movies present");
//This is a line.
