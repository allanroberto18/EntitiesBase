using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class UsuariosService : BaseService<Usuarios>, IUsuariosService
    {
        public override ICollection<Usuarios> Consult(string param, string field)
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
                case "Nome":
                    return List().Where(i => i.Nome.Contains(param)).ToList();
                case "Email":
                    return List().Where(i => i.Email.Contains(param)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }

        public new ICollection<Usuarios> Consult()
        {
            return List().Where(i => i.Status.Equals(1)).ToList();
        }

        public Usuarios GetRegisterByEmail(string email)
        {
            try
            {
                Usuarios entity = List().First(i => i.Email.Equals(email));
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool TestUsuariosByEmail(string email)
        {
            int count = List().Count(i => i.Email.Equals(email));
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckSenha(string senha, Usuarios entity)
        {
            return CryptSharp.Crypter.CheckPassword(senha, entity.Senha);
        }

        public string ProcessarLogin(string email, string senha)
        {
            if (!TestUsuariosByEmail(email))
            {
                return "Usuário não localizado";
            }
            Usuarios entity = GetRegisterByEmail(email);
            if (!CheckSenha(senha,  entity))
            {
                return "Senha incorreta";
            }
            return "";
        }

        public Usuarios GetLogin(string email, string senha)
        {
            return GetRegisterByEmail(email); ;
        }
    }
}