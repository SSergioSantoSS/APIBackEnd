using ApiTarefa.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ApiTarefa.Service
{
    public class TarefaService
    {
        private readonly IMongoCollection<Tarefa> _tarefas;

        public TarefaService(ITarefaDataSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tarefas = database.GetCollection<Tarefa>(settings.TarefaCollectionName);
        }

        public List<Tarefa> Get() =>
            _tarefas.Find(Tarefa => true).ToList();

        public Tarefa Get(string id) =>
            _tarefas.Find<Tarefa>(Tarefa => Tarefa.Id == id).FirstOrDefault();

        public Tarefa Create(Tarefa Tarefa)
        {
            _tarefas.InsertOne(Tarefa);
            return Tarefa;
        }

        public void Update(string id, Tarefa TarefaIn) =>
            _tarefas.ReplaceOne(Tarefa => Tarefa.Id == id, TarefaIn);

        public void Remove(string id) =>
            _tarefas.DeleteOne(Tarefa => Tarefa.Id == id);
    }
}
