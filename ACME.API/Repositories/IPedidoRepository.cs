using ACME.Models;
using ACME.API.Repositories;

namespace ACME.API.Repositories
{
    public interface IPedidoRepository
    {
        List<Pedido> Get();
        Pedido Get(int id); 
        void Add(Pedido pedido);
        void Update(Pedido pedido);
        void Delete(int id);

    }
}
