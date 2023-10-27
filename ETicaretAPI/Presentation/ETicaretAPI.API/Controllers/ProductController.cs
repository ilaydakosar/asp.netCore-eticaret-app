using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private IOrderWriteRepository _orderWriteRepository;


        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            //await   _productWriteRepository.AddRangeAsync(new()
            //   {

            //       new() { Id = Guid.NewGuid(), Name = "product1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 },
            //       new() { Id = Guid.NewGuid(), Name = "product1", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 10 },
            //       new() { Id = Guid.NewGuid(), Name = "product1", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 10 },
            //       new() { Id = Guid.NewGuid(), Name = "product1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 },
            //   });
            // await  _productWriteRepository.SaveAsync();
            //Product p = await _productReadRepository.GetTByIdAsync("910a7491-19f9-46f4-b8c1-0f47fb590c45",false);
            //    p.Name = "Mehmet";
            //await _productWriteRepository.SaveAsync();
            await _productWriteRepository.AddAsync(new() { Name = "C Product", Price = 1.50f, Stock = 10, CreatedDate = DateTime.UtcNow });
            await _productWriteRepository.SaveAsync();
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetTByIdAsync(id);
            return Ok(product);
        }
    }
}