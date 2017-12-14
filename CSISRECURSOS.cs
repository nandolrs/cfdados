using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "SISRECURSOS")]
    public class SISRECURSOS : Entidade
    {
		Int64 _codigo;

		string _DS_NOME_RECURSO;

        DateTime _DT_CADASTRO;

        DateTime _DT_EXCLUSAO;
                
        object _STREAM; //object
		        
        [ATabelaColuna(nome ="DS_NOME_RECURSO", tipo="string")]
		public string DS_NOME_RECURSO
        {
            get
            {
                return _DS_NOME_RECURSO;
            }

            set
            {
                _DS_NOME_RECURSO = value;
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

        [ATabelaColuna(nome = "STREAM", tipo = "BLOB")]
        public object STREAM // object
        {
            get
            {
                return _STREAM;
            }

            set
            {
                _STREAM = value;
            }
        }

        [ATabelaColuna(nome ="CD_SISRECURSO", tipo="Int64", chave =true)]
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
