using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "GEOCIDADE")]
    public class GEOCIDADE : EntidadeOracle
    {
		Int64 _codigo;

		GEOUF _GEOUF;



        public GEOCIDADE()
        {
			 _GEOUF = new GEOUF();
 // //_PAGINA = new PAGINA();

            this.evConsultando += GEOCIDADE_evConsultando;
        }

        private void GEOCIDADE_evConsultando()
        {
			_GEOUF.consultar(); 
 //_PAGINA.consultar();
        }

		
        [ATabela(nome = "GEOUF")]
        public GEOUF geouf
        {
            get { return _GEOUF; }
            set { _GEOUF = value; }
        }

		        string _DS_CIDADE;

        DateTime _DT_CADASTRO;

        DateTime _DT_ALTERACAO;

        DateTime _DT_EXCLUSAO;



		        
        [ATabelaColuna(nome ="DS_CIDADE", tipo="string")]
		public string DS_CIDADE
        {
            get
            {
                return _DS_CIDADE;
            }

            set
            {
                _DS_CIDADE = value;
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
        

		        
        [ATabelaColuna(nome ="CD_CIDADE", tipo="Int64", chave =true)]
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
