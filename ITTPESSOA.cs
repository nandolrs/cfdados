using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "ITTPESSOA")]
    public class ITTPESSOA : EntidadeOracle
    {
		Int64 _codigo;

		


        public ITTPESSOA()
        {
			 // //_PAGINA = new PAGINA();

            this.evConsultando += ITTPESSOA_evConsultando;
        }

        private void ITTPESSOA_evConsultando()
        {
			 //_PAGINA.consultar();
        }

		

		        string _DS_NOME_PESSOA;

        DateTime _DT_CADASTRO;

        DateTime _DT_ALTERACAO;

        DateTime _DT_EXCLUSAO;

        string _NR_CNPJ;

        string _NR_CPF;

        string _NR_IESTADUAL;

        string _NR_IMUNICIPAL;

        string _NR_IESTRANGEIRO;

        Int64 _NR_ISUFRAMA;

        string _NR_IEXPORTADOR;

        string _NR_IFABRICANTE;



		        
        [ATabelaColuna(nome ="DS_NOME_PESSOA", tipo="string")]
		public string DS_NOME_PESSOA
        {
            get
            {
                return _DS_NOME_PESSOA;
            }

            set
            {
                _DS_NOME_PESSOA = value;
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
        
        [ATabelaColuna(nome ="NR_CNPJ", tipo="string")]
		public string NR_CNPJ
        {
            get
            {
                return _NR_CNPJ;
            }

            set
            {
                _NR_CNPJ = value;
            }
        }
        
        [ATabelaColuna(nome ="NR_CPF", tipo="string")]
		public string NR_CPF
        {
            get
            {
                return _NR_CPF;
            }

            set
            {
                _NR_CPF = value;
            }
        }
        
        [ATabelaColuna(nome ="NR_IESTADUAL", tipo="string")]
		public string NR_IESTADUAL
        {
            get
            {
                return _NR_IESTADUAL;
            }

            set
            {
                _NR_IESTADUAL = value;
            }
        }
        
        [ATabelaColuna(nome ="NR_IMUNICIPAL", tipo="string")]
		public string NR_IMUNICIPAL
        {
            get
            {
                return _NR_IMUNICIPAL;
            }

            set
            {
                _NR_IMUNICIPAL = value;
            }
        }
        
        [ATabelaColuna(nome ="NR_IESTRANGEIRO", tipo="string")]
		public string NR_IESTRANGEIRO
        {
            get
            {
                return _NR_IESTRANGEIRO;
            }

            set
            {
                _NR_IESTRANGEIRO = value;
            }
        }
        
        [ATabelaColuna(nome ="NR_ISUFRAMA", tipo="Int64")]
		public Int64 NR_ISUFRAMA
        {
            get
            {
                return _NR_ISUFRAMA;
            }

            set
            {
                _NR_ISUFRAMA = value;
            }
        }
        
        [ATabelaColuna(nome ="NR_IEXPORTADOR", tipo="string")]
		public string NR_IEXPORTADOR
        {
            get
            {
                return _NR_IEXPORTADOR;
            }

            set
            {
                _NR_IEXPORTADOR = value;
            }
        }
        
        [ATabelaColuna(nome ="NR_IFABRICANTE", tipo="string")]
		public string NR_IFABRICANTE
        {
            get
            {
                return _NR_IFABRICANTE;
            }

            set
            {
                _NR_IFABRICANTE = value;
            }
        }
        

		        
        [ATabelaColuna(nome ="CD_PESSOA", tipo="Int64", chave =true)]
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
