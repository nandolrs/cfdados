using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "MATUNIDADEMEDIDA")]
    public class MATUNIDADEMEDIDA : EntidadeOracle
    {
		Int64 _codigo;

		


        public MATUNIDADEMEDIDA()
        {
			 // //_PAGINA = new PAGINA();

            this.evConsultando += MATUNIDADEMEDIDA_evConsultando;
        }

        private void MATUNIDADEMEDIDA_evConsultando()
        {
			 //_PAGINA.consultar();
        }

		

		        string _DS_UNIDADE_MEDIDA;

        string _DS_SIGLA;

        DateTime _DT_CADASTRO;

        DateTime _DT_EXCLUSAO;

        DateTime _DT_ALTERACAO;



		        
        [ATabelaColuna(nome ="DS_UNIDADE_MEDIDA", tipo="string")]
		public string DS_UNIDADE_MEDIDA
        {
            get
            {
                return _DS_UNIDADE_MEDIDA;
            }

            set
            {
                _DS_UNIDADE_MEDIDA = value;
            }
        }
        
        [ATabelaColuna(nome ="DS_SIGLA", tipo="string")]
		public string DS_SIGLA
        {
            get
            {
                return _DS_SIGLA;
            }

            set
            {
                _DS_SIGLA = value;
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
        

		        
        [ATabelaColuna(nome ="CD_UNIDADE_MEDIDA", tipo="Int64", chave =true)]
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
