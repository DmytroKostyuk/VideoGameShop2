using BLL.DTO;
using BLL.Interfaces.IEFServices;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Validators;
using FluentValidation.Results;
using System;
using DAL.Parameters;
using DAL.Paging;

namespace BLL.Services.EF_Services
{
    public class EFDeveloperService : IEFDeveloperService
    {
        IEFUnitOfWork _efUnitOfWork;
        private readonly IMapper _mapper;

        public EFDeveloperService(IEFUnitOfWork efunitOfWork, IMapper mapper)
        { 
            _efUnitOfWork = efunitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeveloperDTO>> GetAllDevelopers()
        {
            var x = await _efUnitOfWork.EFDeveloperRepository.GetAll();
            List<DeveloperDTO> res = new List<DeveloperDTO>();
            foreach(var i in x)
                res.Add(_mapper.Map<Developer, DeveloperDTO>(i));

                return res;
        }

        public async Task<DeveloperDTO> GetDeveloperById(int Id)
        {
            var x = await _efUnitOfWork.EFDeveloperRepository.Get(Id);
            DeveloperDTO res = _mapper.Map<Developer, DeveloperDTO>(x);

            return res;
        }

        public async Task<string> AddDeveloper(DeveloperDTO developer)
        {
            DeveloperValidator devValidator = new DeveloperValidator();

            ValidationResult result = devValidator.Validate(developer);

            if(result.IsValid)
            {
                var x = _mapper.Map<DeveloperDTO, Developer>(developer);
                await _efUnitOfWork.EFDeveloperRepository.Add(x);
                return "Гений зашел в чат !!!! ";
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

        public async Task DeleteDeveloper(int Id)
        { await _efUnitOfWork.EFDeveloperRepository.Delete(Id); }

        public async Task UpdateDeveloper(DeveloperDTO developer)
        {
            var x = _mapper.Map<DeveloperDTO, Developer>(developer);
            await _efUnitOfWork.EFDeveloperRepository.Update(x);
        }

        public async Task<DeveloperDTO> GetDeveloperByName(string name)
        {
            var x = await _efUnitOfWork.EFDeveloperRepository.GetDeveloperByName(name);
            DeveloperDTO res = _mapper.Map<Developer, DeveloperDTO>(x);

            return res;
        }

        public async Task<PagedList<DeveloperDTO>> GetDevelopersPartly(DeveloperParameters developerParameters)
        {
            var x = await _efUnitOfWork.EFDeveloperRepository.GetDevelopersPartly(developerParameters);
            var res = _mapper.Map<PagedList<DeveloperDTO>>(x);

            return res;
        }
    }
}
