using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "PAGINA")]
    public class PAGINA : Entidade
    {
		Int64 _codigo;

		string _DS_NOME_PAGINA;

        string _DS_URL;

        DateTime _DT_CADASTRO;

        DateTime _DT_EXCLUSAO;
		        
        [ATabelaColuna(nome ="DS_NOME_PAGINA", tipo="string")]
		public string DS_NOME_PAGINA
        {
            get
            {
                return _DS_NOME_PAGINA;
            }

            set
            {
                _DS_NOME_PAGINA = value;
            }
        }
        
        [ATabelaColuna(nome ="DS_URL", tipo="string")]
		public string DS_URL
        {
            get
            {
                return _DS_URL;
            }

            set
            {
                _DS_URL = value;
            }
        }
        
        [ATabelaColuna(nome ="DT_CADASTRO", tipo="DateTime")]
		public DateTime DT_CADASTRO
        {
            get
            {
                return _DT_CADASTRO;
            }

            set
            {
                _DT_CADASTRO = value;
            }
        }
        
        [ATabelaColuna(nome ="DT_EXCLUSAO", tipo="DateTime")]
		public DateTime DT_EXCLUSAO
        {
            get
            {
                return _DT_EXCLUSAO;
            }

            set
            {
                _DT_EXCLUSAO = value;
            }
        }
        

		        
        [ATabelaColuna(nome ="CD_PAGINA", tipo="Int64", chave =true)]
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
