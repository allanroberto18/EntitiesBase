using System;
using Entities.Bases.Models;

namespace Entities.Interfaces.Models
{
    public interface IAgendasMensagensModel : IBaseModel
    {
        void SetParams(int mensagem, DateTime envio, int status);

        void SetParams(int id, int mensagem, DateTime envio, int status);
    }
}