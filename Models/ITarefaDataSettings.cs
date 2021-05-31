using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTarefa.Models
{
    public interface ITarefaDataSettings
    {
        string TarefaCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        
    }
}
