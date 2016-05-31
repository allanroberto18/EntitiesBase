using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class ContatosService : BaseService<Contatos>, IContatosService
    {
        public override ICollection<Contatos> Consult(string param, string field)
        {
            if (String.IsNullOrEmpty(param))
            {
                return base.Consult();
            }

            int id;
            bool teste;

            switch (field)
            {
                case "Código":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código especificado não é um número inteiro");
                    }
                    return List().Where(i => i.Id.Equals(id)).ToList();
                case "Nome":
                    return List().Where(i => i.Nome.Contains(param)).ToList();
                case "Telefone":
                    return List().Where(i => i.Telefone.Equals(param)).ToList();
                case "Data de Nascimento":
                    DateTime dataNascimento;
                    teste = DateTime.TryParse(param, out dataNascimento);
                    if (!teste)
                    {
                        throw new Exception("A data de nascimento especificada não é uma data válida");
                    }
                    return List().Where(i => i.DataNascimento.Equals(dataNascimento)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }

        public ICollection<Contatos> Consult(string param, string field, int sexo)
        {
            if (sexo == 3)
            {
                return Consult(param, field);
            }

            if (String.IsNullOrEmpty(param))
            {
                return List().Where(i => i.Sexo.Equals(sexo)).ToList();
            }

            int id;
            bool teste;

            switch (field)
            {
                case "Código":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código especificado não é um número inteiro");
                    }
                    return List().Where(i => i.Id.Equals(id) && i.Sexo.Equals(sexo)).ToList();
                case "Nome":
                    return List().Where(i => i.Nome.Contains(param) && i.Sexo.Equals(sexo)).ToList();
                case "Telefone":
                    return List().Where(i => i.Telefone.Equals(param) && i.Sexo.Equals(sexo)).ToList();
                case "Data de Nascimento":
                    DateTime dataNascimento;
                    teste = DateTime.TryParse(param, out dataNascimento);
                    if (!teste)
                    {
                        throw new Exception("A data de nascimento especificada não é uma data válida");
                    }
                    return List().Where(i => i.DataNascimento.Equals(dataNascimento) && i.Sexo.Equals(sexo)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1) && i.Sexo.Equals(sexo)).ToList();
            }
        }

        public new ICollection<Contatos> Consult()
        {
            return List().Where(i => i.Status.Equals(1)).OrderByDescending(i => i.Id).ToList();
        }
    }
}