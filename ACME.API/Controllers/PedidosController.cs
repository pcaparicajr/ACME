using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ACME.API.Repositories;
using ACME.Models;
using ACME.API.Database;
using System.Security.Cryptography;
using static ACME.API.Controllers.PedidosController;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using static System.Net.Mime.MediaTypeNames;

namespace ACME.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        private readonly IPedidoRepository _repository;

        public static void Main(string[] args)
        {

        }
        private class itens_Pedido
        {
            public int id { get; set; }
            public int idProduto { get; set; }
            public string? nomeProduto { get; set; }
            public decimal valorUnitario { get; set; }
            public int quantidade { get; set; }
        }
        private class lista_Pedidos
        {
            public int id { get; set; }
            public string? nomeCliente { get; set; }
            public string? emailCliente { get; set; }
            public bool pago { get; set; }
            public decimal valorTotal { get; set; }

            public List<itens_Pedido>? itensPedido { get; set; }
        }
        public PedidosController(IPedidoRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var listaPedidosDb = _repository.Get();

            List<lista_Pedidos> listReturn = new List<lista_Pedidos>();
            List<itens_Pedido> listProduto = new List<itens_Pedido>();
            decimal total = 0;
            foreach (var s in listaPedidosDb)
            {
                //listProduto.Clear();
                total = 0;
                listProduto.Clear();
                if (s.ItensPedidos != null)
                {
                    List<ItensPedido> meusPedidos = s.ItensPedidos.ToList();
                    foreach (var p in meusPedidos)
                    {

                        listProduto.Add(new itens_Pedido
                        {
                            id = p.Id,
                            idProduto = p.IdProduto,
                            nomeProduto = p.Produto.NomeProduto,
                            valorUnitario = p.Produto.Valor,
                            quantidade = p.Quantidade
                        }
                            );
                        total = total + (p.Quantidade * p.Produto.Valor);
                    }
                }
                listReturn.Add(new lista_Pedidos
                {
                    id = s.Id,
                    nomeCliente = s.NomeCliente,
                    emailCliente = s.EmailCliente,
                    pago = s.Pago,
                    valorTotal = total,
                    itensPedido = listProduto.ToList()
                }); ; ;
            }
            return Ok(listReturn);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Pedido = _repository.Get(id);
            if (Pedido == null)
                return NotFound("Não encontrado!");
            var listaPedidosDb = _repository.Get();

            List<lista_Pedidos> listReturn = new List<lista_Pedidos>();
            List<itens_Pedido> listProduto = new List<itens_Pedido>();
            decimal total = 0;
            foreach (var s in listaPedidosDb)
            {
                //listProduto.Clear();
                total = 0;
                listProduto.Clear();
                List<ItensPedido> meusPedidos = s.ItensPedidos.ToList();
                foreach (var p in meusPedidos)
                {

                    listProduto.Add(new itens_Pedido
                    {
                        id = p.Id,
                        idProduto = p.IdProduto,
                        nomeProduto = p.Produto.NomeProduto,
                        valorUnitario = p.Produto.Valor,
                        quantidade = p.Quantidade
                    }
                        );
                    total = total + (p.Quantidade * p.Produto.Valor);
                }

                listReturn.Add(new lista_Pedidos
                {
                    id = s.Id,
                    nomeCliente = s.NomeCliente,
                    emailCliente = s.EmailCliente,
                    pago = s.Pago,
                    valorTotal = total,
                    itensPedido = listProduto.ToList()
                }); ; ;
            }
            //return Ok(Pedido);
            return Ok(listReturn);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Pedido Pedido)
        {
            //_repository.Add(Pedido);
            return Ok(Pedido);
        }
        [HttpPost(("{id}"))]
        public IActionResult Add([FromBody] int id,string Nome,string Email)
        {
            var Pedido = _repository.Get(id);
            if (Pedido == null)
            {
                Pedido = new Pedido();
            }

            Pedido.NomeCliente = Nome;
            Pedido.EmailCliente = Email;
   
            _repository.Add(Pedido);
            return Ok(Pedido);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Pedido Pedido, int id)
        {
            _repository.Update(Pedido);

            return Ok(Pedido);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);

            return Ok();
        }
    }
}
