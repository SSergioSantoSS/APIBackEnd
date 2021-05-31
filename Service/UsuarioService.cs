using ApiTarefa.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ApiTarefa.Service
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioService(IUsuarioDataSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _usuarios = database.GetCollection<Usuario>(settings.UsuarioCollectionName);
        }

        public List<Usuario> Get() =>
            _usuarios.Find(Usuario => true).ToList();

        public Usuario Get(string id) =>
            _usuarios.Find<Usuario>(Tarefa => Tarefa.Id == id).FirstOrDefault();

        public Usuario Create(Usuario usuario)
        {
            _usuarios.InsertOne(usuario);
            return usuario;
        }

        public void Update(string id, Usuario usuario) =>
            _usuarios.ReplaceOne(Usuario => usuario.Id == id, usuario);

        public void Remove(string id) =>
            _usuarios.DeleteOne(Usuario => Usuario.Id == id);
    }
}
