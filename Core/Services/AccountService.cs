using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IJwtService jwtService;

        public AccountService(UserManager<User> userManager, IMapper mapper, IJwtService jwtService)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.jwtService = jwtService;
        }
        public async Task Register(RegisterDto model)
        {
            //var user = new User()
            //{
            //    UserName = model.Email,
            //    Email = model.Email,
            //    Birthdate = model.Birthdate,
            //    PhoneNumber = model.PhoneNumber
            //};
            var user = mapper.Map<User>(model);

            var result =  await userManager.CreateAsync(user,model.Password);

            if (!result.Succeeded)
            {
                var messages = string.Join("\n", result.Errors.Select(x => x.Description));
                throw new HttpException(messages, HttpStatusCode.BadRequest);
            }
        }
        public async Task<LoginResponse> Login(LoginDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
                throw new HttpException("Invalid login or password.", HttpStatusCode.BadRequest);

            return new LoginResponse
            {
                Token = jwtService.CreateToken(jwtService.GetClaims(user))
            };
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

    }
}
