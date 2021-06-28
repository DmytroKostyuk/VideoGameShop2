using BLL.DTO;
using BLL.Interfaces.IEFServices;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Validators;
using FluentValidation.Results;

namespace BLL.Services.EF_Services
{
    public class EFGenreService : IEFGenreService
    {
        IEFUnitOfWork _efUnitOfWork;
        private readonly IMapper _mapper;

        public EFGenreService(IEFUnitOfWork efunitOfWork, IMapper mapper)
        {
            _efUnitOfWork = efunitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenres()
        {
            var x = await _efUnitOfWork.EFGenreRepository.GetAll();
            List<GenreDTO> res = new List<GenreDTO>();
            foreach (var i in x)
                res.Add(_mapper.Map<Genre, GenreDTO>(i));

            return res;
        }

        public async Task<GenreDTO> GetGenreById(int Id)
        {
            var x = await _efUnitOfWork.EFGenreRepository.Get(Id);
            GenreDTO res = _mapper.Map<Genre, GenreDTO>(x);

            return res;
        }

        public async Task<string> AddGenre(GenreDTO genre)
        {
            GenreValidator genreValidator = new GenreValidator();

            ValidationResult result = genreValidator.Validate(genre);

            if (result.IsValid)
            {
                var x = _mapper.Map<GenreDTO, Genre>(genre);
                await _efUnitOfWork.EFGenreRepository.Add(x);
                return "Жанр был успешно добавлен!";
            }
            else
            {
                string error = "";
                foreach (var failure in result.Errors)
                {
                    error = "Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage;
                }
                return error;
            }
        }

        public async Task DeleteGenre(int Id)
        { await _efUnitOfWork.EFGenreRepository.Delete(Id); }

        public async Task UpdateGenre(GenreDTO genre)
        {
            var x = _mapper.Map<GenreDTO, Genre>(genre);
            await _efUnitOfWork.EFGenreRepository.Update(x);
        }

        public async Task<GenreDTO> GetGenreByName(string name)
        {
            var x = await _efUnitOfWork.EFGenreRepository.GetGenreByName(name);
            GenreDTO res = _mapper.Map<Genre, GenreDTO>(x);

            return res;
        }
    }
}