using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceProduct
{
    public interface IProduct : IGenerics<Produto>
    {
        Task<List<Produto>> ListaProdutoUsuario(string userId);
    }
}
