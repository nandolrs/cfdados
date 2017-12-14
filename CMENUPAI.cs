using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "MENUPAI_VW")]
    public class MENUPAI : Entidade
    {
		Int64 _codigo;

		


        public MENUPAI()
        {
			 // //_PAGINA = new PAGINA();

            this.evConsultando += MENUPAI_evConsultando;
        }

        private void MENUPAI_evConsultando()
        {
			 //_PAGINA.consultar();
        }

		

		string _DS_MENUPAI;

        DateTime _DT_CADASTRO;

        DateTime _DT_MODIFICACAO;

        DateTime _DT_EXCLUSAO;



		        
        [ATabelaColuna(nome ="DS_MENUPAI", tipo="string")]
		public string DS_MENUPAI
        {
            get
            {
                return _DS_MENUPAI;
            }

            set
            {
                _DS_MENUPAI = value;
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
        
        [ATabelaColuna(nome ="DT_MODIFICACAO", tipo="DateTime")]
		public DateTime DT_MODIFICACAO
        {
            get
            {
                return _DT_MODIFICACAO;
            }

            set
            {
                _DT_MODIFICACAO = value;
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
        

		        
        [ATabelaColuna(nome ="CD_MENUPAI", tipo="Int64", chave =true)]
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
