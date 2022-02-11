using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Api.Dtos;
using PetShop.Domain.SeedWork.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Api.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthenticationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpPost("Login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(UserDto))]
        public IActionResult Login(LoginRequestDto dto)
        {
            try
            {
                using IUnitOfWorkAdapter context = _unitOfWork.Create();
                var isValid = context.Repositories.UserRepository.Exists(x => x.UserName == dto.UserName && x.Password == dto.Password);
                if (isValid)
                {
                    var user = context.Repositories.UserRepository.GetByFilter(x => x.UserName == dto.UserName, null).FirstOrDefault();
                    return Ok(user);
                }
                else {
                    throw new ArgumentException("Usuario o Contraseña invalidos");                
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
