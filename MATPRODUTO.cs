using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "MATPRODUTO")]
    public class MATPRODUTO : EntidadeOracle
    {
		Int64 _codigo;

		MATCLASSE _MATCLASSE;



        public MATPRODUTO()
        {
			 _MATCLASSE = new MATCLASSE();
 // //_PAGINA = new PAGINA();

            this.evConsultando += MATPRODUTO_evConsultando;
        }

        private void MATPRODUTO_evConsultando()
        {
			_MATCLASSE.consultar(); 
 //_PAGINA.consultar();
        }

		
        [ATabela(nome = "MATCLASSE")]
        public MATCLASSE matclasse
        {
            get { return _MATCLASSE; }
            set { _MATCLASSE = value; }
        }

		        string _DS_PRODUTO;

        DateTime _DT_CADASTRO;

        DateTime _DT_ALTERACAO;

        DateTime _DT_EXCLUSAO;



		        
        [ATabelaColuna(nome ="DS_PRODUTO", tipo="string")]
		public string DS_PRODUTO
        {
            get
            {
                return _DS_PRODUTO;
            }

            set
            {
                _DS_PRODUTO = value;
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
        

		        
        [ATabelaColuna(nome ="CD_PRODUTO", tipo="Int64", chave =true)]
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
