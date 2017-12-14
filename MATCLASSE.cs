using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "MATCLASSE")]
    public class MATCLASSE : EntidadeOracle
    {
		Int64 _codigo;

		


        public MATCLASSE()
        {
			 // //_PAGINA = new PAGINA();

            this.evConsultando += MATCLASSE_evConsultando;
        }

        private void MATCLASSE_evConsultando()
        {
			 //_PAGINA.consultar();
        }

		

		        string _DS_CLASSE;

        DateTime _DT_CADASTRO;

        DateTime _DT_EXCLUSAO;

        DateTime _DT_ALTERACAO;



		        
        [ATabelaColuna(nome ="DS_CLASSE", tipo="string")]
		public string DS_CLASSE
        {
            get
            {
                return _DS_CLASSE;
            }

            set
            {
                _DS_CLASSE = value;
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
        

		        
        [ATabelaColuna(nome ="CD_CLASSE", tipo="Int64", chave =true)]
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
