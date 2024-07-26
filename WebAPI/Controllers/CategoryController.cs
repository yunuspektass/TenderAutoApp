using Business.DTOs.Category;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController:ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryGetDto>>> GetList()
    {
        var categoriesDto = await _categoryService.GetList();

        return Ok(categoriesDto);
    }
    
    [HttpGet("{id:int}")] 
    public async Task<ActionResult<CategoryGetDto>> GetItem(int id)
    {
        var categoryDto = await _categoryService.GetItem(id);

        if (categoryDto == null)
        {
            return NotFound(); 
        }
        
        return Ok(categoryDto); 
    }
    
    [HttpPost] 
    public async Task<ActionResult<CategoryCreateDto>> PostItem(CategoryCreateDto categoryCreateDto)
    {
        var CreatedcategoryDto = await _categoryService.PostItem(categoryCreateDto);
     
        return Ok();
    }
    
    [HttpPut("{id:int}")] 
    public async Task<IActionResult> PutItem(int id, CategoryUpdateDto categoryUpdateDto)
    {
        if (id != categoryUpdateDto.Id)
        {
            return BadRequest(); 
        }

        var result = await _categoryService.PutItem(id, categoryUpdateDto);

        if (!result)
        {
            return NotFound(); 
        }
        
        return NoContent(); 
    }
    
    [HttpDelete("{id:int}")] 
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _categoryService.DeleteItem(id);

        if (!result)
        {
            return NotFound();  
        }
        
        return NoContent(); 
    }
    
}