using AutoMapper;
using ECommerceGP.Bl.Dtos.CategoryDtos;
using ECommerceGP.DAL;

namespace ECommerceGP.Bl
{
    public class Cateogorymanager : IcateogoryManeger
    {
        private readonly Icateogoryrepo icateogoryrepo;
        private readonly IMapper mapper;

        public Cateogorymanager(Icateogoryrepo _icateogoryrepo,IMapper _mapper)
        {
            this.icateogoryrepo = _icateogoryrepo;
            mapper = _mapper;

        }
        public void AddCateogory(CateogoryWrite cateogoryWriteDTO)
        {
            using var stream = new MemoryStream();
            cateogoryWriteDTO.image.CopyTo(stream);
            var CategoryDTO = mapper.Map<Cateogory>(cateogoryWriteDTO);
            CategoryDTO.image = stream.ToArray();
            icateogoryrepo.Add(CategoryDTO);
            icateogoryrepo.SaveChanges();
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditCateogory(CateogoryWrite cateogory)
        {
            throw new NotImplementedException();
        }

        public List<cateogoryRead> GetAllCategories()
        {
            var dbCategories = icateogoryrepo.GetAll();
            return mapper.Map<List<cateogoryRead>>(dbCategories);
        }

        public cateogoryRead GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryWithProductsReadDTO? GetCategoryWithProducts(int id)
        {
           var dbcategory= icateogoryrepo.GetCateogoryWithProducts(id);
            return mapper.Map<CategoryWithProductsReadDTO>(dbcategory);
        }
    }
}
