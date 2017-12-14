using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "UF")]
    public class UF : Entidade
    {
		Int64 _codigo;

		PAIS _PAIS;


        public UF()
        {
			 _PAIS = new PAIS(); // //_PAGINA = new PAGINA();

            this.evConsultando += UF_evConsultando;
        }

        private void UF_evConsultando()
        {
			_PAIS.consultar();  //_PAGINA.consultar();
        }

		
        [ATabela(nome = "PAIS")]
        public PAIS pais
        {
            get { return _PAIS; }
            set { _PAIS = value; }
        }

		        string _DS_NOME_UF;

        string _DS_SIGLA;



		        
        [ATabelaColuna(nome ="DS_NOME_UF", tipo="string")]
		public string DS_NOME_UF
        {
            get
            {
                return _DS_NOME_UF;
            }

            set
            {
                _DS_NOME_UF = value;
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
        

		        
        [ATabelaColuna(nome ="CD_UF", tipo="Int64", chave =true)]
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
