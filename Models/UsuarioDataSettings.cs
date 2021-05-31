using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTarefa.Models
{
    public class UsuarioDataSettings : IUsuarioDataSettings
    {
        public string UsuarioCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
