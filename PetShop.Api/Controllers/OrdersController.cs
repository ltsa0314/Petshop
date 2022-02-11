using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Api.Dtos;
using PetShop.Domain.Aggregates.OrderAggregate;
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
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrdersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(List<OrderDto>))]
        public IActionResult GetAll()
        {
            try
            {
                using var context = _unitOfWork.Create();
                var result = context.Repositories.OrderRepository.GetAll(null).ToList();
                return Ok(_mapper.Map<List<OrderDto>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(OrderDto))]
        public IActionResult GetById(int id)
        {
            try
            {
                using var context = _unitOfWork.Create();
                var dto = _mapper.Map<OrderDto>(context.Repositories.OrderRepository.GetById(id));
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(OrderDto))]
        public IActionResult Insert(OrderDto dto)
        {
            try
            {
                using IUnitOfWorkAdapter context = _unitOfWork.Create();

                var entity = _mapper.Map<Order>(dto);

                context.Repositories.OrderRepository.Insert(entity);
                context.Commit();
                return Ok(_mapper.Map<OrderDto>(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
