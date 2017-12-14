using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "GEOUF")]
    public class GEOUF : EntidadeOracle
    {
		Int64 _codigo;

		GEOPAIS _GEOPAIS;



        public GEOUF()
        {
			 _GEOPAIS = new GEOPAIS();
 // //_PAGINA = new PAGINA();

            this.evConsultando += GEOUF_evConsultando;
        }

        private void GEOUF_evConsultando()
        {
			_GEOPAIS.consultar(); 
 //_PAGINA.consultar();
        }

		
        [ATabela(nome = "GEOPAIS")]
        public GEOPAIS geopais
        {
            get { return _GEOPAIS; }
            set { _GEOPAIS = value; }
        }

		        string _DS_UF;

        DateTime _DT_CADASTRO;

        DateTime _DT_EXCLUSAO;

        DateTime _DT_ALTERACAO;



		        
        [ATabelaColuna(nome ="DS_UF", tipo="string")]
		public string DS_UF
        {
            get
            {
                return _DS_UF;
            }

            set
            {
                _DS_UF = value;
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
