﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SpbLeague.Data.Interfaces;
using SpbLeague.Domain.Enums;
using SpbLeague.Domain.Helpers;
using SpbLeague.Domain.Models;
using SpbLeague.Domain.Response;
using SpbLeague.Domain.ViewModels;
using SpbLeague.Service.Interfeces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using SpbLeague.Domain.Enum;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SpbLeague.Service.Implementations
{
    public class AccountService
    {
        private readonly IConfiguration _config;
        private readonly IBaseRepository<User> _userRepository;
        

        public AccountService(IConfiguration config, IBaseRepository<User> userRepository
            )
        {
            _config = config;
            _userRepository = userRepository;
        }

        /*public async Task<BaseResponse<User>> Login(LoginViewModel userLogin)
        {
            try
            {
                //var user = await _userRepository.GetByEmail(userLogin.Email);
                
                if (user == null)
                {
                    return new BaseResponse<User>()
                    {
                        Description = "Пользователь с таким email не зарегестрирован",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                if(user.PasswordHash != HashPasswordHelper.HashPassowrd(userLogin.Password))
                {
                    return new BaseResponse<User>()
                    {
                        Description = "Неверный пароль",
                        StatusCode = StatusCode.PasswordIncorrect
                    };
                }

                var token = Authenticate(user);
                return new BaseResponse<User>()
                {
                    Data = user,
                    Description = token,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<User>> Register(RegisterViewModel register)
        {
            //var user = await _userRepository.GetByEmail(register.Email);
            var user = await _userManager.FindByEmailAsync(register.Email);
            try
            {
                if(user != null)
                {
                    return new BaseResponse<User>()
                    {
                        Description = "Пользователь с таким логином уже есть"
                    };
                }

                var newUser = new IdentityUser
                {
                    UserName = register.Name,
                    Email = register.Email,
                };

                var result = await _userManager.CreateAsync(user, register.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
                //_userRepository.Create(user);
                var token = Authenticate(user);

                return new BaseResponse<User>()
                {
                    Data = user,
                    Description = token,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
            
        }

        private string Authenticate(User user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims: claims,
              expires: DateTime.Now.AddHours(24),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/
    }
}
