using AutoMapper;
using BLL.DTO;
using BLL.Interfaces.IEFServices;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.EF_Services
{
    public class EFUserService : IEFUserService
    {
        private readonly IEFUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public EFUserService(IEFUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> Register(UserRegisterDTO user)
        {
            if(user.ConfirmPassword != user.ConfirmPassword)
            { return "Пароли не совпадают!"; }

            User _user = new User { Email = user.Email, UserName = user.UserName, Money = 0 };

            var result = await _unitOfWork.UserManager.CreateAsync(_user, user.Password);

            if(result.Succeeded)
            { return "Пользователь был успешно зарегистрирован!"; }

            else
            {
                string ErrorMessage = "";
                foreach(var error in result.Errors)
                { ErrorMessage += error.Description + "\n"; }

                return ErrorMessage;
            }

        }

        public async Task<string> Login(UserLoginDTO user)
        {
            User _user = await _unitOfWork.UserManager.FindByNameAsync(user.UserName);

            if (_user != null)
            {
                var result = await _unitOfWork.SignInManager.PasswordSignInAsync(user.UserName, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    var tok = await BuildToken(_user);
                    return "Успешный вход!";
                }

                else
                { return "Неверный пароль!"; }
            }
            return "Пользователь не найден!";
        }

        public async Task<string> Logout()
        {
            await _unitOfWork.SignInManager.SignOutAsync();
            return "Выход успешен!";
        }

        public async Task<string> Create(UserCreateDTO user)
        {
            User _user = new User { Email = user.Email, UserName = user.UserName };

            var result = await _unitOfWork.UserManager.CreateAsync(_user, user.Password);

            if (result.Succeeded)
            {
                await _unitOfWork.SignInManager.SignInAsync(_user, false);
                return "Пользователь Зарегистрирован!";
            }
            else
            {
                string ErrorMessage = "";
                foreach(var error in  result.Errors)
                { ErrorMessage += error.Description + "\n"; }
                return ErrorMessage;
            }
        }

        public async Task<string> Edit(UserEditDTO user)
        {
            User _user = await _unitOfWork.UserManager.FindByIdAsync(Convert.ToString(user.Id));
            
            if(_user != null)
            {
                if(user.Email != "")
                _user.Email = user.Email;
                if(user.UserName != "")
                _user.UserName = user.UserName;

                var result = await _unitOfWork.UserManager.UpdateAsync(_user);

                if(result.Succeeded)
                { return "Данные пользователя успешно изменены!"; }
                else
                {
                    string ErrorMessage = "";
                    foreach (var error in result.Errors)
                    { ErrorMessage += error.Description + "\n"; }
                    return ErrorMessage;
                }
            }
            return "Такого пользователя не существует!";
        }

        public async Task<string> Delete(int id)
        {
            User _user = await _unitOfWork.UserManager.FindByIdAsync(Convert.ToString(id));

            if(_user != null)
            {
                var result = await _unitOfWork.UserManager.DeleteAsync(_user);

                if (result.Succeeded)
                { return "Пользователь был успешно удалён!"; }
                else
                {
                    string ErrorMessage = "";
                    foreach (var error in result.Errors)
                    { ErrorMessage += error.Description + "\n"; }
                    return ErrorMessage;
                }
            }
            return "Такого пользователя не существует!";
        }

        public async Task<string> ChangePassword(UserChangePasswordDTO user)
        {
            User _user = await _unitOfWork.UserManager.FindByIdAsync(Convert.ToString(user.Id));

            if(_user != null)
            {
                IdentityResult result =
                    await _unitOfWork.UserManager.ChangePasswordAsync(_user, user.OldPassword, user.NewPassword);

                if(result.Succeeded)
                {
                    return "Пароль был успещно изменен!";
                }
                else
                {
                    string ErrorMessage = "";
                    foreach (var error in result.Errors)
                    { ErrorMessage += error.Description + "\n"; }
                    return ErrorMessage;
                }
            }
            return "Данного пользователя не существует!";
        }

        public async Task<string> BuildToken(User user)
        {
            var roles = await _unitOfWork.SignInManager.UserManager.GetRolesAsync(user);
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim("accountId", user.Id.ToString()));
            claims.Add(new Claim("email", user.Email));

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(double.Parse(_configuration["JwtExpiryInDays"]));

            JwtSecurityToken token = new JwtSecurityToken
                (
                issuer: _configuration["JwtIssuer"],
                audience: _configuration["JwtAudience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiration,
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
