using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class SimsService : BaseService<Sims>, ISimsService
    {
        public override ICollection<Sims> Consult(string param, string field)
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
                case "Sim":
                    return List().Where(i => i.Sim.Equals(param)).ToList();
                case "Data de Criação":
                    DateTime dataCriacao;
                    teste = DateTime.TryParse(param, out dataCriacao);
                    if (!teste)
                    {
                        throw new Exception("A data de criação especificada não é uma data válida");
                    }
                    return List().Where(i => i.Created.Equals(dataCriacao)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }

        public new void Add(Sims item)
        {
            string sim = item.Sim;

            ICollection<Sims> teste = getByData(sim);
            if (teste.Count > 0)
            {
                return;
            }
            base.Add(item);

            UpdateSetting("disparos", "0");
        }

        public ICollection<Sims> getByData(string sim)
        {
            return List().Where(i => i.Sim.Equals(sim) && i.DataAtual.Equals(DateTime.Today)).ToList();
        }

        public Sims getBySim(string sim)
        {
            Sims entity;
            try
            {
                entity = List().First(i => i.Sim.Equals(sim) && i.DataAtual.Equals(DateTime.Today));
                return entity;
            }
            catch (EntityException ex)
            {
                throw ex;
            }
        }

        public void UpdateSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}