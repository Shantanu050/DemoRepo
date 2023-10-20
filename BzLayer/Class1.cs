using Entity;
using DataLayer;
namespace BzLayer;
public class MoviesBz
{
  public List<Movie> GetMovies()
  {
     DataAccess dataAccess=new DataAccess();
     return dataAccess.GetMovies();
  }
}
