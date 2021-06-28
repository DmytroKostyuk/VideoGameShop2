using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces.IEFServices
{
    public interface IEFGenreService
    {
        Task<string> AddGenre(GenreDTO genre);

        Task UpdateGenre(GenreDTO genre);

        Task DeleteGenre(int Id);

        Task<GenreDTO> GetGenreById(int Id);

        Task<IEnumerable<GenreDTO>> GetAllGenres();

        Task<GenreDTO> GetGenreByName(string name);
    }
}
