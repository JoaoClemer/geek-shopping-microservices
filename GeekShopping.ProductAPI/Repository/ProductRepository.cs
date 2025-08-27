using AutoMapper;
using GeekShopping.ProductAPI.Data.DataTransferObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;

        private readonly MySQLContext _context;

        public ProductRepository(IMapper mapper, MySQLContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<ProductDTO> Create(ProductDTO productDTO )
        {
            var product = _mapper.Map<Product>(productDTO);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);

                if(product == null)
                    return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<ProductDTO>> FindAll()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> FindById(long id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Update(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }
    }
}
