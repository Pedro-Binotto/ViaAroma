using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaAroma
{
    static class Connection
    {
        private const string server = "localhost";
        private const string database = "teste_cadastros";
        private const string user = "root";
        private const string password = "root";
        
        static public string stringConnection = 
            $"server={server}; database={database}; User Id={user}; password ={password}";
    }
}