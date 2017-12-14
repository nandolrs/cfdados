using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "GEOPAIS")]
    public class GEOPAIS : EntidadeOracle
    {
		//Int64 _codigo;

		GEOCONTINENTE _GEOCONTINENTE;



        public GEOPAIS()
        {
			 _GEOCONTINENTE = new GEOCONTINENTE();
 // //_PAGINA = new PAGINA();

            this.evConsultando += GEOPAIS_evConsultando;
        }

        private void GEOPAIS_evConsultando()
        {
			_GEOCONTINENTE.consultar(); 
 //_PAGINA.consultar();
        }

		
        [ATabela(nome = "GEOCONTINENTE")]
        public GEOCONTINENTE geocontinente
        {
            get { return _GEOCONTINENTE; }
            set { _GEOCONTINENTE = value; }
        }

		        string _DS_PAIS;

        DateTime _DT_CADASTRO;

        DateTime _DT_EXCLUSAO;

        DateTime _DT_ALTERACAO;

        Int64 _CD_IBGE;



		        
        [ATabelaColuna(nome ="DS_PAIS", tipo="string")]
		public string DS_PAIS
        {
            get
            {
                return _DS_PAIS;
            }

            set
            {
                _DS_PAIS = value;
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
        
        [ATabelaColuna(nome ="CD_IBGE", tipo="Int64")]
		public Int64 CD_IBGE
        {
            get
            {
                return _CD_IBGE;
            }

            set
            {
                _CD_IBGE = value;
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
