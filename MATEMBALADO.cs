using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "MATEMBALADO")]
    public class MATEMBALADO : EntidadeOracle
    {
		Int64 _codigo;

		MATEMBALAGEM _MATEMBALAGEM;
MATPRODUTO _MATPRODUTO;



        public MATEMBALADO()
        {
			 _MATEMBALAGEM = new MATEMBALAGEM();
 _MATPRODUTO = new MATPRODUTO();
 // //_PAGINA = new PAGINA();

            this.evConsultando += MATEMBALADO_evConsultando;
        }

        private void MATEMBALADO_evConsultando()
        {
			_MATEMBALAGEM.consultar(); 
_MATPRODUTO.consultar(); 
 //_PAGINA.consultar();
        }

		
        [ATabela(nome = "MATEMBALAGEM")]
        public MATEMBALAGEM matembalagem
        {
            get { return _MATEMBALAGEM; }
            set { _MATEMBALAGEM = value; }
        }
        [ATabela(nome = "MATPRODUTO")]
        public MATPRODUTO matproduto
        {
            get { return _MATPRODUTO; }
            set { _MATPRODUTO = value; }
        }

		        string _DS_EMBALADO;

        DateTime _DT_CADASTRO;

        DateTime _DT_ALTERACAO;

        DateTime _DT_EXCLUSAO;



		        
        [ATabelaColuna(nome ="DS_EMBALADO", tipo="string")]
		public string DS_EMBALADO
        {
            get
            {
                return _DS_EMBALADO;
            }

            set
            {
                _DS_EMBALADO = value;
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
        

		        
        [ATabelaColuna(nome ="CD_EMBALADO", tipo="Int64", chave =true)]
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
