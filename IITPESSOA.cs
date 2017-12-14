using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "IITPESSOA")]
    public class IITPESSOA : EntidadeOracle
    {
		Int64 _codigo;

		


        public IITPESSOA()
        {
			 // //_PAGINA = new PAGINA();

            this.evConsultando += IITPESSOA_evConsultando;
        }

        private void IITPESSOA_evConsultando()
        {
			 //_PAGINA.consultar();
        }

		

		

		
    }
}
