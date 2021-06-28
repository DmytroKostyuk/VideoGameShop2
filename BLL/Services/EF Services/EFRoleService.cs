using AutoMapper;
using BLL.DTO;
using BLL.Interfaces.IEFServices;
using BLL.Validators;
using DAL.Entities;
using DAL.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.EF_Services
{
    public class EFRoleService : IEFRoleService
    {
        private readonly IEFUnitOfWork _eFUnitOfWork;
        private readonly IMapper _mapper;

        public EFRoleService(IEFUnitOfWork eFUnitOfWork, IMapper mapper)
        {
            _eFUnitOfWork = eFUnitOfWork;
            _mapper = mapper;
        }

        public async Task<string> CreateRole(RoleDTO role)
        {
            RoleValidator genreValidator = new RoleValidator();

            ValidationResult result = genreValidator.Validate(role);

            if (result.IsValid)
            {
                var _role = _mapper.Map<RoleDTO, MyRole>(role);
                await _eFUnitOfWork.RoleManager.CreateAsync(_role);
                return "Роль была успешно добавлена";
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

        public async Task AppointRole(int userId, string role)
        {
            User user = await _eFUnitOfWork.UserManager.FindByIdAsync(Convert.ToString(userId));

            await _eFUnitOfWork.UserManager.AddToRoleAsync(user, role);
        }

        public async Task<IList<string>> GetRoleById(int id)
        {
            User user = await _eFUnitOfWork.UserManager.FindByIdAsync(Convert.ToString(id));
            IList<string> userRoles = null;
            if (user != null)
                userRoles = await _eFUnitOfWork.UserManager.GetRolesAsync(user);
            return userRoles;
        }
    }
}
