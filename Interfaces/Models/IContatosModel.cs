using System;
using Entities.Bases.Models;

namespace Entities.Interfaces.Models
{
    public interface IContatosModel : IBaseModel
    {
        void SetParams(string nome, int sexo, string telefone, int status);
        void SetParams(string nome, int sexo, string telefone, DateTime dataNascimento, int status);
        void SetParams(int id, string nome, int sexo, string telefone, int status);
        void SetParams(int id, string nome, int sexo, string telefone, DateTime dataNascimento, int status);
    }
}