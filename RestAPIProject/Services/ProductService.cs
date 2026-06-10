using AutoMapper;
using RestAPIProject.DTOs;
using RestAPIProject.Models;
using RestAPIProject.Repositories;

namespace RestAPIProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);

            await _repository.AddAsync(entity);

            return _mapper.Map<ProductDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return false;

            await _repository.DeleteAsync(product);

            return true;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var product=await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(product);
        }

        public async  Task<ProductDto?> GetByIdAsync(int id)
        {
            var product= await _repository.GetByIdAsync(id);
            return product==null 
                ?null : _mapper.Map<ProductDto?>(product);

        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return false;

            _mapper.Map(dto, product);

            await _repository.UpdateAsync(product);

            return true;
        }
    }
}
