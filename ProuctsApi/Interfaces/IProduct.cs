using ProuctsApi.Domains;

namespace ProuctsApi.Interfaces
{
    public interface IProduct
    {
        List<Products> Listar();

        void Cadastrar (Products products);

        void Deletar(Guid id);

        Products BuscarPorId(Guid id);

        void Atualizar(Guid id, Products product);
    }
}

