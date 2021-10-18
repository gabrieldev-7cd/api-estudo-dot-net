using System;
using AutoMapper;
using Manager.Services.DTO;
using System.Threading.Tasks;
using Manager.API.ViewModels;
using Manager.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Manager.Services.Interfaces;
using Manager.API.utilities;

namespace Manager.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {   
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var userCreated = await _userService.Create(userDTO);
                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com Sucesso!",
                    Success = true,
                    Data = userCreated
                });
            }
            
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}