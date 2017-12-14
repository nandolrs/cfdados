using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Types;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

using System.Data.SqlClient;
using System.Collections;

using System.ComponentModel.DataAnnotations.Schema;

namespace cf.dados
{

    public interface iUsuario
    {
        void autenticar();
    }

}
