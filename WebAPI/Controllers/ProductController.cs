using Business.DTOs.Product;
using Business.DTOs.Urun;
using Business.GenericRepository.BaseRep;
using Core.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController:ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductGetDto>>> GetList()
    {
        var productDtos = await _productService.GetList();
        return Ok(productDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductGetDto>> GetItem(int id)
    {
        var productDto = await _productService.GetItem(id);

        if (productDto == null)
        {
            return NotFound();
        }

        return Ok(productDto);
    }

    [HttpPost]
    public async Task<ActionResult<ProductCreateDto>> PostItem(ProductCreateDto productCreateDto)
    {
        var createdProductDto = await _productService.PostItem(productCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, ProductUpdateDto productUpdateDto)
    {
        if (id != productUpdateDto.Id)
        {
            return BadRequest();
        }

        var result = await _productService.PutItem(id, productUpdateDto);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _productService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

}
