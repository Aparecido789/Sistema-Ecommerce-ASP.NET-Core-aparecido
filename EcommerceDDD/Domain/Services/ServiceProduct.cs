using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProduct _product;
        public ServiceProduct(IProduct iProduct)
        {
            _product = iProduct;
        }
        public async Task AddProduct(Produto produto)
        {
            var ValidaNome = produto.ValidarPropriedadeString(produto.Nome, "Nome");
            var ValidaValor = produto.ValidarPropriedadeDecimal(produto.Valor, "Valor");
            var ValidaQtdEstoque = produto.ValidarPropriedadeInt(produto.QtdEstoque, "QtdEstoque");

            if (ValidaNome && ValidaValor && ValidaQtdEstoque)
            {
                produto.DataCadastro = DateTime.Now;
                produto.DataAlteracao = DateTime.Now;
                produto.Estado = true;
                await _product.Add(produto);
            }
        }

        public async Task<List<Produto>> ListaProdutosComEstoque(Expression<Func<Produto, bool>> exproduto)
        {
            return await _product.ListaProdutos(p => p.QtdEstoque > 0);
        }

        public async Task UpdateProduct(Produto produto)
        {
            var ValidaNome = produto.ValidarPropriedadeString(produto.Nome, "Nome");
            var ValidaValor = produto.ValidarPropriedadeDecimal(produto.Valor, "Valor");
            var ValidaQtdEstoque = produto.ValidarPropriedadeInt(produto.QtdEstoque, "QtdEstoque");

            if (ValidaNome && ValidaValor && ValidaQtdEstoque)
            {
                produto.DataAlteracao = DateTime.Now;
                await _product.Update(produto);
            }
        }
    }
}
