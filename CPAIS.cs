using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "PAIS")]
    public class PAIS : Entidade
    {
		Int64 _codigo;

		CONTINENTE _CONTINENTE;


        public PAIS()
        {
			 _CONTINENTE = new CONTINENTE(); // //_PAGINA = new PAGINA();

            this.evConsultando += PAIS_evConsultando;
        }

        private void PAIS_evConsultando()
        {
			_CONTINENTE.consultar();  //_PAGINA.consultar();
        }

		
        [ATabela(nome = "CONTINENTE")]
        public CONTINENTE continente
        {
            get { return _CONTINENTE; }
            set { _CONTINENTE = value; }
        }

		        string _DS_NOME_PAIS;



		        
        [ATabelaColuna(nome ="DS_NOME_PAIS", tipo="string")]
		public string DS_NOME_PAIS
        {
            get
            {
                return _DS_NOME_PAIS;
            }

            set
            {
                _DS_NOME_PAIS = value;
            }
        }
        

		        
        [ATabelaColuna(nome ="CD_PAIS", tipo="Int64", chave =true)]
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
