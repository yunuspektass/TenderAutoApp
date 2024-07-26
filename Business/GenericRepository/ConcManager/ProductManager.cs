using AutoMapper;
using Business.DTOs.Product;
using Business.DTOs.Urun;
using Business.GenericRepository.BaseRep;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class ProductManager:IProductService
{
    private readonly ProductRepository _productRepository;
    private readonly IMapper _autoMapper;
    private readonly IMailService _mailService;

    public ProductManager(ProductRepository productRepository, IMapper autoMapper, IMailService mailService)
    {
        _autoMapper = autoMapper;
        _productRepository = productRepository;
        _mailService = mailService;
    }
        
        
        
    public async Task<IEnumerable<ProductGetDto>> GetList()
    {
        var products = await _productRepository.GetItems();
        var productDtos = _autoMapper.Map<List<ProductGetDto>>(products);
        return productDtos;
    }

    public async Task<ProductGetDto> GetItem(int id)
    {
        var product = await _productRepository.GetItem(id);

        if (product == null)
        {
            return null;
        }

        var productDto = _autoMapper.Map<ProductGetDto>(product);

        return productDto;
    }

    public async Task<ProductCreateDto> PostItem(ProductCreateDto productCreateDto)
    {
        var product = _autoMapper.Map<Product>(productCreateDto);

        await _productRepository.Add(product);

        var resultDto = _autoMapper.Map<ProductCreateDto>(product);

        await _mailService.SendEmailAsync("test@gmail.com", "Ürün Eklendi",
            productCreateDto.ProductName + " İsimli ürün listenize eklenmiştir");

        return resultDto;
    }

    public async Task<bool> PutItem(int id, ProductUpdateDto productUpdateDto)
    {
        var existingProduct = await _productRepository.GetItem(id);

        if (existingProduct == null)
        {
            return false;
        }
        

        _autoMapper.Map(productUpdateDto, existingProduct); 

        await _productRepository.Update(existingProduct);

        await _mailService.SendEmailAsync("test@gmail.com", "Ürün Güncelleme",
            productUpdateDto.Id + " Numaralı ürün listenizde güncellenmiştir.");

        return true;
    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingProduct = await _productRepository.Find(id);

        if (existingProduct == null)
        {
            return false;
        }

        await _productRepository.Delete(existingProduct);

        await _mailService.SendEmailAsync("test@gmail.com", "Ürün Silindi",
            id + " Numaralı ürün listenizden silinmiştir");

        return true;
    }
}