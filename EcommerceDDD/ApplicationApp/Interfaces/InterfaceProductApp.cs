﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceProductApp : InterfaceGenericApp<Produto>
    {
        Task AddProduct(Produto produto);
        Task UpdateProduct(Produto produto);

        Task<List<Produto>> ListaProdutoUsuario(string userId);

        Task<List<Produto>> ListaProdutosComEstoque();

        Task<List<Produto>> ListarProdutosCarrinhoUsuario(string userId);

        Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho);
    }
}
