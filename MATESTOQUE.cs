using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "MATESTOQUE")]
    public class MATESTOQUE : EntidadeOracle
    {
		Int64 _codigo;

		MATEMBALADO _MATEMBALADO;
MATLOCAL _MATLOCAL;



        public MATESTOQUE()
        {
			 _MATEMBALADO = new MATEMBALADO();
 _MATLOCAL = new MATLOCAL();
 // //_PAGINA = new PAGINA();

            this.evConsultando += MATESTOQUE_evConsultando;
        }

        private void MATESTOQUE_evConsultando()
        {
			_MATEMBALADO.consultar(); 
_MATLOCAL.consultar(); 
 //_PAGINA.consultar();
        }

		
        [ATabela(nome = "MATEMBALADO")]
        public MATEMBALADO matembalado
        {
            get { return _MATEMBALADO; }
            set { _MATEMBALADO = value; }
        }
        [ATabela(nome = "MATLOCAL")]
        public MATLOCAL matlocal
        {
            get { return _MATLOCAL; }
            set { _MATLOCAL = value; }
        }

		        string _DS_ESTOQUE;

        DateTime _DT_CADASTRO;

        DateTime _DT_ALTERACAO;

        DateTime _DT_EXCLUSAO;

        Decimal _NR_QUANTIDADE;

        Decimal _NR_QUANTIDADE_MINIMA;

        Decimal _NR_QUANTIDADE_PEDIDO;

        Decimal _NR_QUANTIDADE_MAXIMA;



		        
        [ATabelaColuna(nome ="DS_ESTOQUE", tipo="string")]
		public string DS_ESTOQUE
        {
            get
            {
                return _DS_ESTOQUE;
            }

            set
            {
                _DS_ESTOQUE = value;
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
        
        [ATabelaColuna(nome ="NR_QUANTIDADE", tipo="Decimal")]
		public Decimal NR_QUANTIDADE
        {
            get
            {
                return _NR_QUANTIDADE;
            }

            set
            {
                _NR_QUANTIDADE = value;
            }
        }
        
        [ATabelaColuna(nome ="NR_QUANTIDADE_MINIMA", tipo="Decimal")]
		public Decimal NR_QUANTIDADE_MINIMA
        {
            get
            {
                return _NR_QUANTIDADE_MINIMA;
            }

            set
            {
                _NR_QUANTIDADE_MINIMA = value;
            }
        }
        
        [ATabelaColuna(nome ="NR_QUANTIDADE_PEDIDO", tipo="Decimal")]
		public Decimal NR_QUANTIDADE_PEDIDO
        {
            get
            {
                return _NR_QUANTIDADE_PEDIDO;
            }

            set
            {
                _NR_QUANTIDADE_PEDIDO = value;
            }
        }
        
        [ATabelaColuna(nome ="NR_QUANTIDADE_MAXIMA", tipo="Decimal")]
		public Decimal NR_QUANTIDADE_MAXIMA
        {
            get
            {
                return _NR_QUANTIDADE_MAXIMA;
            }

            set
            {
                _NR_QUANTIDADE_MAXIMA = value;
            }
        }
        

		        
        [ATabelaColuna(nome ="CD_ESTOQUE", tipo="Int64", chave =true)]
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
