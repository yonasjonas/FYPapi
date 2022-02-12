using AutoMapper;
using BC = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Accounts;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IFileUploadService
    {
       
    }

    public class FileUploadService : IFileUploadService
    {

    }
}
