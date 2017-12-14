using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "MENU")]
    public class MENU : Entidade
    {
		Int64 _codigo;

        MENUPAI _MENUPAI;
        PAGINA _PAGINA;



        public MENU()
        {
            _MENUPAI = new MENUPAI();
            _PAGINA = new PAGINA();
             // //_PAGINA = new PAGINA();

            this.evConsultando += MENU_evConsultando;
        }

        private void MENU_evConsultando()
        {
            _MENUPAI.consultarDependencia();
            _PAGINA.consultarDependencia(); 
            //_PAGINA.consultar();
        }

        public void pesquisarRaiz()
        {
            string sSql = "select a.* from menu a where a.cd_menupai is null";
            this.pesquisar(sSql);
        }

        public void pesquisarFilhos()
        {
            string sSql = "select a.* from menu a where a.cd_menupai is not  null";
            this.pesquisar(sSql);
        }

        [ATabela(nome = "MENUPAI")]
        public MENUPAI menupai
        {
            get { return _MENUPAI; }
            set { _MENUPAI = value; }
        }
        [ATabela(nome = "PAGINA")]
        public PAGINA pagina
        {
            get { return _PAGINA; }
            set { _PAGINA = value; }
        }

		string _DS_NOME_MENU;

        DateTime _DT_CADASTRO;

        DateTime _DT_EXCLUSAO;
		        
        [ATabelaColuna(nome ="DS_NOME_MENU", tipo="string")]
		public string DS_NOME_MENU
        {
            get
            {
                return _DS_NOME_MENU;
            }

            set
            {
                _DS_NOME_MENU = value;
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
        

		        
        [ATabelaColuna(nome ="CD_MENU", tipo="Int64", chave =true)]
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
