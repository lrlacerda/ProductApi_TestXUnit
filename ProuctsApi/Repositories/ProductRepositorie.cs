using ProuctsApi.Contexts;
using ProuctsApi.Domains;
using ProuctsApi.Interfaces;

namespace ProuctsApi.Repositories
{
    public class ProductRepositorie : IProduct
    {
        private readonly ProductContext ctx;

        public ProductRepositorie()
        {
            ctx = new ProductContext();
        }

        public void Atualizar(Guid id, Products product)
        {
            var p = ctx.Product.Find(id);

            if(product.Name != null)
                p.Name = product.Name;
            if(product.Price != null)
                p.Price = product.Price;

            ctx.Product.Update(p);
            ctx.SaveChanges();  
        }

        public Products BuscarPorId(Guid id)
        {
            var p = ctx.Product.Find(id);

            return p;
        }

        public void Cadastrar(Products products)
        {
            ctx.Product.Add(products);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var produ = ctx.Product.Find(id);

            ctx.Product.Remove(produ);

            ctx.SaveChanges();
        }

        public List<Products> Listar()
        {
            return ctx.Product.ToList();
        }
    }
}
