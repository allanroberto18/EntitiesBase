using System;
using System.Collections.Generic;
using Entities.Bases.Services;
using Entities.Models;

namespace Entities.Interfaces.Services
{
    public interface IAgendasMensagensService : IBaseService<AgendasMensagens>
    {
        ICollection<AgendasMensagens> ConsultByMensagemByEnvio(int mensagem, DateTime envio);
        bool ValidarNovo(int id, DateTime dataAtual);
        new void Add(AgendasMensagens item);
    }
}