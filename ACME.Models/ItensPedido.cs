using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ACME;

namespace ACME.Models
{
    public class ItensPedido
    {
        public int Id { get; set; }
        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }
        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public int Quantidade {  get; set; }
       
        public Pedido Pedido { get; set; } = null!;
      
        public Produto Produto { get; set; } = null!;

    }
}
