using Domain.Interfaces.InterfaceCompraUsuario;
using Entities.Entities;
using infrastructure.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure.Repository.Repositories
{
    public class RepositoryCompraUsuario : RepositoryGenerics<CompraUsuario>, ICompraUsuario
    {

    }
}
