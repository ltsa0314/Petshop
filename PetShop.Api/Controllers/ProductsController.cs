using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Api.Dtos;
using PetShop.Domain.Aggregates.ProductAggregate;
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
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(List<ProductDto>))]
        public IActionResult GetAll()
        {
            try
            {
                using var context = _unitOfWork.Create();
                var result = context.Repositories.ProductRepository.GetAll(null, null);
                return Ok(_mapper.Map<List<ProductDto>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("TopSales")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(List<ProductDto>))]
        public IActionResult GetTopSales()
        {
            try
            {
                using var context = _unitOfWork.Create();
                var result = context.Repositories.ProductRepository.GetReportTopSales();
                return Ok(result);
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
        [Produces("application/json", Type = typeof(ProductDto))]
        public IActionResult GetById(int id)
        {
            try
            {
                using var context = _unitOfWork.Create();
                var dto = _mapper.Map<ProductDto>(context.Repositories.ProductRepository.GetById(id));
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
        [Produces("application/json", Type = typeof(ProductDto))]
        public IActionResult Insert(ProductDto dto)
        {
            try
            {
                using IUnitOfWorkAdapter context = _unitOfWork.Create();

                var entity = _mapper.Map<Product>(dto);

                context.Repositories.ProductRepository.Insert(entity);
                context.Commit();
                return Ok(_mapper.Map<ProductDto>(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(void))]
        public IActionResult Update(ProductDto dto)
        {
            try
            {
                using IUnitOfWorkAdapter context = _unitOfWork.Create();

                var entity = _mapper.Map<Product>(dto);

                context.Repositories.ProductRepository.Update(entity);
                context.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        public IActionResult Delete(int id)
        {
            try
            {
                using var context = _unitOfWork.Create();
                context.Repositories.ProductRepository.Delete(id);
                context.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
