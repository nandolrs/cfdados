using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "COMOPERACAO")]
    public class COMOPERACAO : EntidadeOracle
    {
		Int64 _codigo;

		


        public COMOPERACAO()
        {
			 // //_PAGINA = new PAGINA();

            this.evConsultando += COMOPERACAO_evConsultando;
        }

        private void COMOPERACAO_evConsultando()
        {
			 //_PAGINA.consultar();
        }

		

		        string _DS_OPERACAO;

        DateTime _DT_CADASTRO;

        DateTime _DT_ALTERACAO;

        DateTime _DT_EXCLUSAO;

        Int64 _NR_ID_SENTIDO;

        Int64 _NR_ID_PRESENCA;



		        
        [ATabelaColuna(nome ="DS_OPERACAO", tipo="string")]
		public string DS_OPERACAO
        {
            get
            {
                return _DS_OPERACAO;
            }

            set
            {
                _DS_OPERACAO = value;
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
        
        [ATabelaColuna(nome ="NR_ID_SENTIDO", tipo="Int64")]
		public Int64 NR_ID_SENTIDO
        {
            get
            {
                return _NR_ID_SENTIDO;
            }

            set
            {
                _NR_ID_SENTIDO = value;
            }
        }
        
        [ATabelaColuna(nome ="NR_ID_PRESENCA", tipo="Int64")]
		public Int64 NR_ID_PRESENCA
        {
            get
            {
                return _NR_ID_PRESENCA;
            }

            set
            {
                _NR_ID_PRESENCA = value;
            }
        }
        

		        
        [ATabelaColuna(nome ="CD_OPERACAO", tipo="Int64", chave =true)]
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
