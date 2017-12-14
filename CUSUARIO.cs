using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf.dados
{
    [ATabela(nome = "USUARIO")]
    public class USUARIO : Entidade, cf.dados.iUsuario
    {
		Int64 _codigo;

        string _DS_NOME_USUARIO;

        DateTime _DT_CADASTRO;

        DateTime _DT_EXCLUSAO;

        string _DS_SENHA;

        string _DS_EMAIL;

        DateTime _DT_ATIVACAO;
		        
        [ATabelaColuna(nome ="DS_NOME_USUARIO", tipo="string")]
		public string DS_NOME_USUARIO
        {
            get
            {
                return _DS_NOME_USUARIO;
            }

            set
            {
                _DS_NOME_USUARIO = value;
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
        
        [ATabelaColuna(nome ="DS_SENHA", tipo="string")]
		public string DS_SENHA
        {
            get
            {
                return _DS_SENHA;
            }

            set
            {
                _DS_SENHA = value;
            }
        }
        
        [ATabelaColuna(nome ="DS_EMAIL", tipo="string")]
		public string DS_EMAIL
        {
            get
            {
                return _DS_EMAIL;
            }

            set
            {
                _DS_EMAIL = value;
            }
        }
        
        [ATabelaColuna(nome ="DT_ATIVACAO", tipo="DateTime")]
		public DateTime DT_ATIVACAO
        {
            get
            {
                return _DT_ATIVACAO;
            }

            set
            {
                _DT_ATIVACAO = value;
            }
        }
		        
        [ATabelaColuna(nome ="CD_USUARIO", tipo="Int64", chave =true)]
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

        public USUARIO()
        {
            // //_PAGINA = new PAGINA();

            this.evConsultando += USUARIO_evConsultando;
        }

        private void USUARIO_evConsultando()
        {
            //_PAGINA.consultar();
        }

        public void autenticar()
        {
            // se o login e senha não forem informados, lança erro

            if (_DS_NOME_USUARIO == null || _DS_NOME_USUARIO.Length == 0 || _DS_SENHA == null || _DS_SENHA.Length == 0)
            {
                throw new Exception("Informe o nome do usuário.");
            }
            
            // se não encontrar, lança erro
             
            this.pesquisar();
            if (this.Count <= 0)
            {
                throw new Exception("Usuário não encontrado.");
            }

        }


    }
}
