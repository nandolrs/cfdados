using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "COMPEDIDOITEM")]
    public class COMPEDIDOITEM : EntidadeOracle
    {
		Int64 _codigo;

		COMPEDIDO _COMPEDIDO;
MATEMBALADO _MATEMBALADO;



        public COMPEDIDOITEM()
        {
			 _COMPEDIDO = new COMPEDIDO();
 _MATEMBALADO = new MATEMBALADO();
 // //_PAGINA = new PAGINA();

            this.evConsultando += COMPEDIDOITEM_evConsultando;
        }

        private void COMPEDIDOITEM_evConsultando()
        {
			_COMPEDIDO.consultar(); 
_MATEMBALADO.consultar(); 
 //_PAGINA.consultar();
        }

		
        [ATabela(nome = "COMPEDIDO")]
        public COMPEDIDO compedido
        {
            get { return _COMPEDIDO; }
            set { _COMPEDIDO = value; }
        }
        [ATabela(nome = "MATEMBALADO")]
        public MATEMBALADO matembalado
        {
            get { return _MATEMBALADO; }
            set { _MATEMBALADO = value; }
        }

		        string _DS_ITEM;

        DateTime _DT_CADASTRO;

        DateTime _DT_EXCLUSAO;

        DateTime _DT_ALTERACAO;



		        
        [ATabelaColuna(nome ="DS_ITEM", tipo="string")]
		public string DS_ITEM
        {
            get
            {
                return _DS_ITEM;
            }

            set
            {
                _DS_ITEM = value;
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
        

		        
        [ATabelaColuna(nome ="CD_ITEM", tipo="Int64", chave =true)]
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
