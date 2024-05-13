using ACME.API.Database;
using ACME.Models;
using Microsoft.EntityFrameworkCore;
using ACME.API.Repositories;

namespace ACME.API.Repositories
{

    public class PedidoRepository : IPedidoRepository
    {
        private readonly ACMEContext _db;
        public PedidoRepository(ACMEContext db)
        {
            _db = db;
        }
 
        public List<Pedido> Get()
        {
           
   
            return _db.Pedidos.Include(a => a.Produtos).OrderBy(a => a.Id).ToList();

        }
        public Pedido Get(int id)
        {
            return _db.Pedidos.Include(a => a.Produtos).FirstOrDefault(a => a.Id == id);
        }

        public void Add(Pedido Pedido)
        {

            _db.Pedidos.Add(Pedido);
            _db.SaveChanges();
        }
        public void Update(Pedido Pedido)
        {
            _db.Pedidos.Update(Pedido);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
       
            _db.Pedidos.Remove(Get(id));
            _db.SaveChanges();
        }


    }
}
