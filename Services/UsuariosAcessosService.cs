using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class UsuariosAcessosService : BaseService<UsuariosAcessos>, IUsuariosAcessosService
    {
        public override ICollection<UsuariosAcessos> Consult(string param, string field)
        {
            if (String.IsNullOrEmpty(param))
            {
                return base.Consult(param, field);
            }
            int id;
            bool teste;
            switch (field)
            {
                case "Código":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O parametro para consulta por código deve ter um valor de número inteiro");
                    }
                    return List().Where(i => i.Id.Equals(id)).ToList();
                case "Usuario":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O parametro para consulta por código do usuário deve ter um valor de número inteiro");
                    }
                    return List().Where(i => i.UsuarioId.Equals(id)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }

        public void LiberarPrimeiroAcesso()
        {
            int count = Consult().Count;
            if (count > 0)
            {
                return;
            }
            Configuracoes entity = new Configuracoes();
            entity.SetParams(DateTime.Today, DateTime.Today.AddDays(7), 1);

            ConfiguracoesService servico = new ConfiguracoesService();
            servico.Add(entity);
        }
    }
}