using Domain.Interfaces.InterfaceProduct;
using Entities.Entities;
using Entities.Entities.Enums;
using infrastructure.Configuration;
using infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Repository.Repositories
{
    public class RepositoryProduct : RepositoryGenerics<Produto>, IProduct
    {
        private readonly DbContextOptions<ContextBase> _optionBuilder;
        public RepositoryProduct()
        {
            _optionBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<List<Produto>> ListarProdutoCarrinhoUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionBuilder))
            {
                var produtoCarrinhoUsuario = await (from p in banco.Produto
                                             join c in banco.CompraUsuarios on p.Id equals c.IdProduto
                                             where c.UserId.Equals(userId) && c.EstadoCompra == EstadoCompra.Produto_Carrinho
                                             select new Produto 
                                             { 
                                                 Id = p.Id,
                                                 Nome = p.Nome,
                                                 Descricao = p.Descricao,
                                                 Observacao = p.Observacao,
                                                 Valor = p.Valor,
                                                 QtdCompra = c.Quantidade,
                                                 IdProdutoCarrinho = c.Id
                                             }).AsNoTracking().ToListAsync();

                return produtoCarrinhoUsuario;
            }
        }

        public async Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho)
        {
            using (var banco = new ContextBase(_optionBuilder))
            {
                var produtoCarrinhoUsuario = await (from p in banco.Produto
                                                    join c in banco.CompraUsuarios on p.Id equals c.IdProduto
                                                    where c.Id.Equals(idProdutoCarrinho) && c.EstadoCompra == EstadoCompra.Produto_Carrinho
                                                    select new Produto
                                                    {
                                                        Id = p.Id,
                                                        Nome = p.Nome,
                                                        Descricao = p.Descricao,
                                                        Observacao = p.Observacao,
                                                        Valor = p.Valor,
                                                        QtdCompra = c.Quantidade,
                                                        IdProdutoCarrinho = c.Id
                                                    }).AsNoTracking().FirstOrDefaultAsync();

                return produtoCarrinhoUsuario;
            }
        }

        public async Task<List<Produto>> ListaProdutos(Expression<Func<Produto, bool>> exproduto)
        {
            using (var banco = new ContextBase(_optionBuilder))
            {
                return await banco.Produto.Where(exproduto).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Produto>> ListaProdutoUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionBuilder))
            {
                return await banco.Produto.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
            }
        }

        
    }
}
