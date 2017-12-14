using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "COMCONDICAO")]
    public class COMCONDICAO : EntidadeOracle
    {
		Int64 _codigo;

		


        public COMCONDICAO()
        {
			 // //_PAGINA = new PAGINA();

            this.evConsultando += COMCONDICAO_evConsultando;
        }

        private void COMCONDICAO_evConsultando()
        {
			 //_PAGINA.consultar();
        }

		

		        string _DS_CONDICAO;

        DateTime _DT_CADASTRO;

        DateTime _DT_ALTERACAO;

        DateTime _DT_EXCLUSAO;

        Int64 _NR_IND_PAGAMENTO;



		        
        [ATabelaColuna(nome ="DS_CONDICAO", tipo="string")]
		public string DS_CONDICAO
        {
            get
            {
                return _DS_CONDICAO;
            }

            set
            {
                _DS_CONDICAO = value;
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
        
        [ATabelaColuna(nome ="NR_IND_PAGAMENTO", tipo="Int64")]
		public Int64 NR_IND_PAGAMENTO
        {
            get
            {
                return _NR_IND_PAGAMENTO;
            }

            set
            {
                _NR_IND_PAGAMENTO = value;
            }
        }
        

		        
        [ATabelaColuna(nome ="CD_CONDICAO", tipo="Int64", chave =true)]
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
