using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "CIDADE")]
    public class CIDADE : Entidade
    {
		Int64 _codigo;

		UF _UF;


        public CIDADE()
        {
			 _UF = new UF(); // //_PAGINA = new PAGINA();

            this.evConsultando += CIDADE_evConsultando;
        }

        private void CIDADE_evConsultando()
        {
			_UF.consultar();  //_PAGINA.consultar();
        }

		
        [ATabela(nome = "UF")]
        public UF uf
        {
            get { return _UF; }
            set { _UF = value; }
        }

		        string _DS_NOME_CIDADE;



		        
        [ATabelaColuna(nome ="DS_NOME_CIDADE", tipo="string")]
		public string DS_NOME_CIDADE
        {
            get
            {
                return _DS_NOME_CIDADE;
            }

            set
            {
                _DS_NOME_CIDADE = value;
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
