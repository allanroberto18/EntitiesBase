using System;
using Entities.Bases.Models;

namespace Entities.Interfaces.Models
{
    public interface ISimsModel : IBaseModel
    {
        void SetParams(string sim, int status);

        void SetParams(int id, string sim, int quantidade, int status);
    }
}