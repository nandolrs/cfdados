using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "CONTINENTE")]
    public class CONTINENTE : Entidade
    {
		Int64 _codigo;

		string _DS_NOME_CONTINENTE;
		        
        [ATabelaColuna(nome ="DS_NOME_CONTINENTE", tipo="string")]
		public string DS_NOME_CONTINENTE
        {
            get
            {
                return _DS_NOME_CONTINENTE;
            }

            set
            {
                _DS_NOME_CONTINENTE = value;
            }
        }
        

		        
        [ATabelaColuna(nome ="CD_CONTINENTE", tipo="Int64", chave =true)]
		public override Int64 codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                _codigo = value;
            }
        }

    }



}
