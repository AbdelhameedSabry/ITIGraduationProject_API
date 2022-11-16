using ECommerceGP.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceGP.DAL
{
    public class Productrepo:Generic<Product> , IProductRepo
    {
        private readonly ApplicationDbcontext _dbcontext;
        public Productrepo(ApplicationDbcontext dbcontext):base(dbcontext)
        {
              _dbcontext = dbcontext;   
              
        }
       
        public IEnumerable<Product> GetProductBySearchString(string SearchProduct)
        {
            string  SearchString ="";
            if (!string.IsNullOrWhiteSpace(SearchProduct))
            {
                SearchString = SearchProduct.Trim();  
            }
            return _dbcontext.products.Where(a => a.ProductName.Contains(SearchString)).ToList();
        }

        public ResponseProduct ProductPagenation(int CurrentPage)
        {
            var PageResult = 2f;
            var PageCount = Math.Ceiling(_dbcontext.products.Count() / PageResult);
            var product = _dbcontext.products.Skip((CurrentPage - 1) * (int)PageResult).Take((int)PageResult).ToList();

            var response = new ResponseProduct
            {
                CurrentPage = CurrentPage,
                Pages = (int)PageCount,
                Products = product
            };
            return response;
        }
    }
}
