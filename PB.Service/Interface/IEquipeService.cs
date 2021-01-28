using PB.Domain;
using System;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IEquipeService
    {
        List<Equipe> Get();
        Equipe Get(int codigo);
        List<DateTime> GetEquipeProximosPagamentos(int codigo);
        int Insert(Equipe equipe);
        int Update(Equipe equipe);
        int Delete(int codigo);
    }
}
