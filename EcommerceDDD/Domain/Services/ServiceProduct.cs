using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
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

            if (ValidaNome && ValidaValor)
            {
                produto.Estado = true;
                await _product.Add(produto);
            }
        }

        public async Task UpdateProduct(Produto produto)
        {
            var ValidaNome = produto.ValidarPropriedadeString(produto.Nome, "Nome");
            var ValidaValor = produto.ValidarPropriedadeDecimal(produto.Valor, "Valor");

            if (ValidaNome && ValidaValor)
            {
                await _product.Update(produto);
            }
        }
    }
}
