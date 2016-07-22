using System.Data.Entity;

namespace Entities
{
    class EntityContextInitializer : CreateDatabaseIfNotExists<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            Models.Usuarios master = new Models.Usuarios();
            master.SetParams("Master", "master@smssim.com", "master1234", 1);

            Models.Usuarios usuario = new Models.Usuarios();
            usuario.SetParams("Usuário", "usuario@smssim.com", "resolve", 1);

            Models.Mensagens mensagem = new Models.Mensagens();
            mensagem.SetParams(1,"Feliz Aniversário",3,1);

            context.Database.Connection.Open();

            context.Usuarios.Add(master);
            context.Usuarios.Add(usuario);
            context.Mensagens.Add(mensagem);

            context.SaveChanges();

            context.Database.Connection.Close();

            base.Seed(context);
        }
    }
}
