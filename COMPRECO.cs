using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "COMPRECO")]
    public class COMPRECO : EntidadeOracle
    {
		Int64 _codigo;

		


        public COMPRECO()
        {
			 // //_PAGINA = new PAGINA();

            this.evConsultando += COMPRECO_evConsultando;
        }

        private void COMPRECO_evConsultando()
        {
			 //_PAGINA.consultar();
        }

		

		        string _DS_PRECO;

        DateTime _DT_CADASTRO;

        DateTime _DT_ALTERACAO;

        DateTime _DT_EXCLUSAO;

        DateTime _DT_VIGENCIA_INICIO;

        DateTime _DT_VIGENCIA_FINAL;

        DateTime _DT_VIGENCIA_PRORROGADA;



		        
        [ATabelaColuna(nome ="DS_PRECO", tipo="string")]
		public string DS_PRECO
        {
            get
            {
                return _DS_PRECO;
            }

            set
            {
                _DS_PRECO = value;
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
        
        [ATabelaColuna(nome ="DT_VIGENCIA_INICIO", tipo="DateTime")]
		public DateTime DT_VIGENCIA_INICIO
        {
            get
            {
                return _DT_VIGENCIA_INICIO;
            }

            set
            {
                _DT_VIGENCIA_INICIO = value;
            }
        }
        
        [ATabelaColuna(nome ="DT_VIGENCIA_FINAL", tipo="DateTime")]
		public DateTime DT_VIGENCIA_FINAL
        {
            get
            {
                return _DT_VIGENCIA_FINAL;
            }

            set
            {
                _DT_VIGENCIA_FINAL = value;
            }
        }
        
        [ATabelaColuna(nome ="DT_VIGENCIA_PRORROGADA", tipo="DateTime")]
		public DateTime DT_VIGENCIA_PRORROGADA
        {
            get
            {
                return _DT_VIGENCIA_PRORROGADA;
            }

            set
            {
                _DT_VIGENCIA_PRORROGADA = value;
            }
        }
        

		        
        [ATabelaColuna(nome ="CD_PRECO", tipo="Int64", chave =true)]
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
