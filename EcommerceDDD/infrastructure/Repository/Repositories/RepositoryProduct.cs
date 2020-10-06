using Domain.Interfaces.InterfaceProduct;
using Entities.Entities;
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
