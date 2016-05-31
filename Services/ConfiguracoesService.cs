using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class ConfiguracoesService : BaseService<Configuracoes>, IConfiguracoesService
    {
        public override ICollection<Configuracoes> Consult(string param, string field)
        {
            if (String.IsNullOrEmpty(param))
            {
                return base.Consult(param, field);
            }
            int id;
            switch (field)
            {
                case "Código":
                    bool teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O parametro para consulta por código deve ter um valor de número inteiro");
                    }
                    return List().Where(i => i.Id.Equals(id)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }
    }
}