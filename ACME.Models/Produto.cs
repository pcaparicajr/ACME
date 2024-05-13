using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACME;

namespace ACME.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string NomeProduto { get; set; } = null!;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; } = 0;
        public ICollection<Pedido> Pedidos { get; set; }
        public ICollection<ItensPedido> ItensPedidos { get; set; }
    }
}
