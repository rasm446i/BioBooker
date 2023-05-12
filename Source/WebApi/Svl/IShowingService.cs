using BioBooker.Dml;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Svl
{
    public interface IShowingService
    {
        Task<bool> InsertShowingAsync(Showing showing);
    }
}