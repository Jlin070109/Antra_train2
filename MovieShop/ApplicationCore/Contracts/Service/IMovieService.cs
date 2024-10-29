using ApplicationCore.Models;
using System.Threading.Tasks;
using ApplicationCore.Models;
namespace ApplicationCore.Contracts.Service;


public interface IMovieService
{
    Task<MovieCardModel> GetMovieDetails(int id);
    // Other method signatures
}
