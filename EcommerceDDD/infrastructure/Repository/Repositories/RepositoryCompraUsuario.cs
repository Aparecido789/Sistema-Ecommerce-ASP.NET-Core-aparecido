using Domain.Interfaces.InterfaceCompraUsuario;
using Entities.Entities;
using infrastructure.Configuration;
using infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Repository.Repositories
{
    public class RepositoryCompraUsuario : RepositoryGenerics<CompraUsuario>, ICompraUsuario
    {
        private readonly DbContextOptions<ContextBase> _optionbuilder;
        public RepositoryCompraUsuario()
        {
            _optionbuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<int> QuantidadeProdutoCarrinhoUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionbuilder))
            {
                return await banco.CompraUsuarios.CountAsync(c => c.UserId.Equals(userId));
            }
        }
    }
}
