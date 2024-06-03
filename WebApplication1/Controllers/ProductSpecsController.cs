using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/ProductSpecs")]
    [ApiController]
    [Authorize]
    public class ProductSpecsController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();

        public ProductSpecsController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public List<ProductSpecsDto> GetList()
        {
            var ProductSpecs = _context.ProductSpecs.ToList();
            var ProductSpecsDtos = _mapper.Map<List<ProductSpecsDto>>(ProductSpecs);
            return ProductSpecsDtos;
        }
        [HttpGet("{id}")]
        public ProductSpecsDto Get(int id)
        {
            var ProductSpecs = _context.ProductSpecs.FirstOrDefault(x => x.Id == id);
            var ProductSpecsDto = _mapper.Map<ProductSpecsDto>(ProductSpecs);
            return ProductSpecsDto;
        }
        [HttpPost]
        public ProductSpecsAddDto ProductSpecsAddDto(ProductSpecsAddDto ProductSpecsAddDto)
        {
            var ProductSpecs = _mapper.Map<ProductSpecs>(ProductSpecsAddDto);
            ProductSpecs.Created = DateTime.Now;
            ProductSpecs.Updated = DateTime.Now;
            _context.ProductSpecs.Add(ProductSpecs);
            _context.SaveChanges();
            return ProductSpecsAddDto;
        }
        [HttpPut]
        public ProductSpecsDto ProductSpecsUpdateDto(ProductSpecsDto ProductSpecsDto)
        {
            var ProductSpecs = _mapper.Map<ProductSpecs>(ProductSpecsDto);
            ProductSpecs.Updated = DateTime.Now;
            _context.ProductSpecs.Update(ProductSpecs);
            _context.SaveChanges();
            return ProductSpecsDto;
        }
        [HttpDelete("{id}")]
        public ResultDto Delete(int id)
        {
            var ProductSpecs = _context.ProductSpecs.FirstOrDefault(x => x.Id == id);
            if (ProductSpecs != null)
            {
                _context.ProductSpecs.Remove(ProductSpecs);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "ProductSpecs silme işlemi başarılı";
            }
            else
            {
                result.Status = false;
                result.Message = "ProductSpecs silme işlemi başarısız";
            }
            return result;
        }
    }
}
