using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "COMPRECOITEM")]
    public class COMPRECOITEM : EntidadeOracle
    {
		Int64 _codigo;

		COMPRECO _COMPRECO;
MATEMBALADO _MATEMBALADO;



        public COMPRECOITEM()
        {
			 _COMPRECO = new COMPRECO();
 _MATEMBALADO = new MATEMBALADO();
 // //_PAGINA = new PAGINA();

            this.evConsultando += COMPRECOITEM_evConsultando;
        }

        private void COMPRECOITEM_evConsultando()
        {
			_COMPRECO.consultar(); 
_MATEMBALADO.consultar(); 
 //_PAGINA.consultar();
        }

		
        [ATabela(nome = "COMPRECO")]
        public COMPRECO compreco
        {
            get { return _COMPRECO; }
            set { _COMPRECO = value; }
        }
        [ATabela(nome = "MATEMBALADO")]
        public MATEMBALADO matembalado
        {
            get { return _MATEMBALADO; }
            set { _MATEMBALADO = value; }
        }

		        string _DS_ITEM;

        DateTime _DT_CADASTRO;

        DateTime _DT_ALTERACAO;

        DateTime _DT_EXCLUSAO;

        Decimal _VL_UNITARIO;



		        
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
        
        [ATabelaColuna(nome ="VL_UNITARIO", tipo="Decimal")]
		public Decimal VL_UNITARIO
        {
            get
            {
                return _VL_UNITARIO;
            }

            set
            {
                _VL_UNITARIO = value;
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
