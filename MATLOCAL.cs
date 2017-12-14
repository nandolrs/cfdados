using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "MATLOCAL")]
    public class MATLOCAL : EntidadeOracle
    {
		Int64 _codigo;

		


        public MATLOCAL()
        {
			 // //_PAGINA = new PAGINA();

            this.evConsultando += MATLOCAL_evConsultando;
        }

        private void MATLOCAL_evConsultando()
        {
			 //_PAGINA.consultar();
        }

		

		        string _DS_LOCAL;

        DateTime _DT_CADASTRO;

        DateTime _DT_ALTERACAO;

        DateTime _DT_EXCLUSAO;



		        
        [ATabelaColuna(nome ="DS_LOCAL", tipo="string")]
		public string DS_LOCAL
        {
            get
            {
                return _DS_LOCAL;
            }

            set
            {
                _DS_LOCAL = value;
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
        

		        
        [ATabelaColuna(nome ="CD_LOCAL", tipo="Int64", chave =true)]
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
