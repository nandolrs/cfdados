using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "MATPEDIDOITEM")]
    public class MATPEDIDOITEM : EntidadeOracle
    {
		Int64 _codigo;

		MATEMBALADO _MATEMBALADO;
MATPEDIDO _MATPEDIDO;



        public MATPEDIDOITEM()
        {
			 _MATEMBALADO = new MATEMBALADO();
 _MATPEDIDO = new MATPEDIDO();
 // //_PAGINA = new PAGINA();

            this.evConsultando += MATPEDIDOITEM_evConsultando;
        }

        private void MATPEDIDOITEM_evConsultando()
        {
			_MATEMBALADO.consultar(); 
_MATPEDIDO.consultar(); 
 //_PAGINA.consultar();
        }

		
        [ATabela(nome = "MATEMBALADO")]
        public MATEMBALADO matembalado
        {
            get { return _MATEMBALADO; }
            set { _MATEMBALADO = value; }
        }
        [ATabela(nome = "MATPEDIDO")]
        public MATPEDIDO matpedido
        {
            get { return _MATPEDIDO; }
            set { _MATPEDIDO = value; }
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
