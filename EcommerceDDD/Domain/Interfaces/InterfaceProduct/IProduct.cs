using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceProduct
{
    public interface IProduct : IGenerics<Produto>
    {
        Task<List<Produto>> ListaProdutoUsuario(string userId);
        Task<List<Produto>> ListaProdutos(Expression<Func<Produto, bool>> exproduto);

        Task<List<Produto>> ListarProdutoCarrinhoUsuario(string userId);

        Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho);

    }
}
