using Entity;
namespace DataLayer;
public class DataAccess
{
      public static List<Movie>movieList=new List<Movie>()
      {
        new Movie{Id=1,Name="Toofan",Ryear=2023,Ratings=1},
        new Movie{Id=1,Name="Bahubali",Ryear=2022,Ratings=2},
        new Movie{Id=1,Name="Singham",Ryear=2021,Ratings=3},
        new Movie{Id=1,Name="Ludo",Ryear=2020,Ratings=4},
        new Movie{Id=1,Name="KGF",Ryear=2023,Ratings=5},
        
      };
      public List<Movie> GetMovies()
      {
        return movieList;
      }
}
