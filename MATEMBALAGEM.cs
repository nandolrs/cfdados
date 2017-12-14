using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "MATEMBALAGEM")]
    public class MATEMBALAGEM : EntidadeOracle
    {
		Int64 _codigo;

		MATUNIDADEMEDIDA _MATUNIDADEMEDIDA;



        public MATEMBALAGEM()
        {
			 _MATUNIDADEMEDIDA = new MATUNIDADEMEDIDA();
 // //_PAGINA = new PAGINA();

            this.evConsultando += MATEMBALAGEM_evConsultando;
        }

        private void MATEMBALAGEM_evConsultando()
        {
			_MATUNIDADEMEDIDA.consultar(); 
 //_PAGINA.consultar();
        }

		
        [ATabela(nome = "MATUNIDADEMEDIDA")]
        public MATUNIDADEMEDIDA matunidademedida
        {
            get { return _MATUNIDADEMEDIDA; }
            set { _MATUNIDADEMEDIDA = value; }
        }

		        string _DS_EMBALAGEM;

        Decimal _NR_PESO;

        Decimal _NR_CAPACIDADE;

        DateTime _DT_CADASTRO;

        DateTime _DT_EXCLUSAO;

        DateTime _DT_ALTERACAO;



		        
        [ATabelaColuna(nome ="DS_EMBALAGEM", tipo="string")]
		public string DS_EMBALAGEM
        {
            get
            {
                return _DS_EMBALAGEM;
            }

            set
            {
                _DS_EMBALAGEM = value;
            }
        }
        
        [ATabelaColuna(nome ="NR_PESO", tipo="Decimal")]
		public Decimal NR_PESO
        {
            get
            {
                return _NR_PESO;
            }

            set
            {
                _NR_PESO = value;
            }
        }
        
        [ATabelaColuna(nome ="NR_CAPACIDADE", tipo="Decimal")]
		public Decimal NR_CAPACIDADE
        {
            get
            {
                return _NR_CAPACIDADE;
            }

            set
            {
                _NR_CAPACIDADE = value;
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
        

		        
        [ATabelaColuna(nome ="CD_EMBALAGEM", tipo="Int64", chave =true)]
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
