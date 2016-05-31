using System;

namespace Entities.Interfaces.Models
{
    public interface IPromocoes 
    {
        void SetParams(int mensagemId, DateTime vencimento, int status);

        void SetParams(int id, int mensagemId, DateTime vencimento, int status);
    }
}