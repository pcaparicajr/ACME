using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACME;

namespace ACME.Models
{
    public class Pedido
    {
       
        public int Id { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string NomeCliente { get; set; } = null!;
        [Column(TypeName = "varchar(60)")]
        public string EmailCliente { get; set; } = null!;
        public DateTimeOffset? DataCriacao { get; set; }
        public bool Pago { get; set; } = false;

        public ICollection<Produto> Produtos { get; set; }
    
        public ICollection<ItensPedido> ItensPedidos { get; set; }
    }
}
