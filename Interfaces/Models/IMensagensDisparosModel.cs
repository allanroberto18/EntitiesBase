using System;
using Entities.Bases.Models;

namespace Entities.Interfaces.Models
{
    public interface IMensagensDisparosModel : IBaseModel
    {
        void SetParams(int mensagem, int contato, int tamanho, DateTime envio, int status);

        void SetParams(int id, int mensagem, int contato, int tamanho, DateTime envio, int status);
    }
}