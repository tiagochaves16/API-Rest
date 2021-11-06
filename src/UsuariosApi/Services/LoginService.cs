﻿using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Request;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LoginService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogarUsuario(LoginRequest request)
        {
            var resultadoidentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultadoidentity.Result.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Login falhou");
        }
    }
}
