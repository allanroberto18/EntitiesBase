using System;
using Entities.Bases.Models;

namespace Entities.Interfaces.Models
{
    public interface IConfiguracoesModel : IBaseModel
    {
        void SetParams(DateTime inicio, DateTime fim, int status);

        void SetParams(int id, DateTime inicio, DateTime fim, int status);
    }
}