using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "GEOENDERECO")]
    public class GEOENDERECO : EntidadeOracle
    {
		Int64 _codigo;

		ITTPESSOA _ITTPESSOA;



        public GEOENDERECO()
        {
			 _ITTPESSOA = new ITTPESSOA();
 // //_PAGINA = new PAGINA();

            this.evConsultando += GEOENDERECO_evConsultando;
        }

        private void GEOENDERECO_evConsultando()
        {
			_ITTPESSOA.consultar(); 
 //_PAGINA.consultar();
        }

		
        [ATabela(nome = "ITTPESSOA")]
        public ITTPESSOA ittpessoa
        {
            get { return _ITTPESSOA; }
            set { _ITTPESSOA = value; }
        }

		        string _DS_ENDERECO;

        DateTime _DT_CADASTRO;

        DateTime _DT_ALTERACAO;

        DateTime _DT_EXCLUSAO;

        string _DS_LOGRADOURO;

        string _DS_NUMERO;

        string _DS_COMPLEMENTO;

        string _DS_BAIRRO;

        Int64 _NR_CEP;



		        
        [ATabelaColuna(nome ="DS_ENDERECO", tipo="string")]
		public string DS_ENDERECO
        {
            get
            {
                return _DS_ENDERECO;
            }

            set
            {
                _DS_ENDERECO = value;
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
        
        [ATabelaColuna(nome ="DT_ALTERACAO", tipo="DateTime")]
		public DateTime DT_ALTERACAO
        {
            get
            {
                return _DT_ALTERACAO;
            }

            set
            {
                _DT_ALTERACAO = value;
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
        
        [ATabelaColuna(nome ="DS_LOGRADOURO", tipo="string")]
		public string DS_LOGRADOURO
        {
            get
            {
                return _DS_LOGRADOURO;
            }

            set
            {
                _DS_LOGRADOURO = value;
            }
        }
        
        [ATabelaColuna(nome ="DS_NUMERO", tipo="string")]
		public string DS_NUMERO
        {
            get
            {
                return _DS_NUMERO;
            }

            set
            {
                _DS_NUMERO = value;
            }
        }
        
        [ATabelaColuna(nome ="DS_COMPLEMENTO", tipo="string")]
		public string DS_COMPLEMENTO
        {
            get
            {
                return _DS_COMPLEMENTO;
            }

            set
            {
                _DS_COMPLEMENTO = value;
            }
        }
        
        [ATabelaColuna(nome ="DS_BAIRRO", tipo="string")]
		public string DS_BAIRRO
        {
            get
            {
                return _DS_BAIRRO;
            }

            set
            {
                _DS_BAIRRO = value;
            }
        }
        
        [ATabelaColuna(nome ="NR_CEP", tipo="Int64")]
		public Int64 NR_CEP
        {
            get
            {
                return _NR_CEP;
            }

            set
            {
                _NR_CEP = value;
            }
        }
        

		        
        [ATabelaColuna(nome ="CD_ENDERECO", tipo="Int64", chave =true)]
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
