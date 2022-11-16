using ECommerceGP.DAL;
using System.ComponentModel;

namespace ECommerceGP.DAL;

public interface Icateogoryrepo:IGeneric<Cateogory>
{
    Cateogory? GetCateogoryWithProducts(int id);
}
