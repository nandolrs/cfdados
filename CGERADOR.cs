using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace cf.dados
{
    [ATabela(nome = "ALL_TABLES")]
    public class Gerador : Entidade 
    {
        cf.util.Biblioteca oLib = new util.Biblioteca();

        string _owner;
        string _table_name;
        //string _column_name;
        //string _data_type;
        //Int64 _char_length;
        //Int64 _data_length;
        //Int64 _data_precision;
        //Int64 _data_scale;

        [ATabelaColuna(nome = "owner", tipo = "string")]
        public string  owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        [ATabelaColuna(nome = "table_name", tipo = "string")]
        public string table_name
        {
            get { return _table_name; }
            set { _table_name = value; }
        }

        //a.owner, a.column_name, a.data_type, a.char_length, a.data_length, a.data_precision, a.data_scale

        string _namespace;
        string _schema;

        public void buscarTabelas()
        {
            string sRecursoScriptColunas = oLib.obtemRecursoTexto("CUTIL.RECURSOS.SCRIPTENTIDADES.TXT");
            consultar(sRecursoScriptColunas);
        }

        
        public void gerarClasses(string[] tabelas, string SGDB)
        {

            foreach (string sTabela in tabelas)
            {
                char lf = '\n';

                string sRecursoModeloClasse = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOCLASSE.TXT");
                string sRecursoModeloPropriedadeVariavel = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOPROPRIEDADESVARIAVEL.TXT");
                string sRecursoModeloPropriedade = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOPROPRIEDADES.TXT");
                string sRecursoModeloPropriedadeChave = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOPROPRIEDADESCHAVE.TXT");
                string sRecursoScriptColunas = oLib.obtemRecursoTexto("CUTIL.RECURSOS.SCRIPTCOLUNAS.TXT");
                string sRecursoScriptDependencias = oLib.obtemRecursoTexto("CUTIL.RECURSOS.SCRIPTDEPENDENCIAS.TXT");
                string sRecursoDependenciaVariavel = "<CLASSE_NOME> _<CLASSE_NOME>;" + lf;
                string sRecursoDependenciaInicializa = " _<CLASSE_NOME> = new <CLASSE_NOME>();" + lf;
                string sRecursoDependenciaConsulta =  "_<CLASSE_NOME>.consultar(); " + lf;
                string sRecursoDependenciaPropriedade = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOCLASSEDEPENDENCIAPROPRIEDADE.TXT");
                string sSqlColunas = sRecursoScriptColunas.Replace("<TABELA_NOME>", sTabela);
                System.Data.DataSet oDataSet = consultando(sSqlColunas);

                string sSqlDependencias = sRecursoScriptDependencias.Replace("<TABELA_NOME>", sTabela);
                System.Data.DataSet oDataSetDependencias = consultando(sSqlDependencias);

                string[] sPropriedades = { };
                string[] sPropriedadesChaves = { };
                string[] sPropriedadesVariaveis = { };
                string[] sDependenciasVariaveis = { };
                string[] sDependenciasInicializa = { };
                string[] sDependenciasConsultas = { };
                string[] sDependenciasPropriedades = { };

                // busca as dependencias

                string[][] aTabelas = { };
                foreach (System.Data.DataRow oDataRowDependencias in oDataSetDependencias.Tables[0].Rows)
                {
                    Int64 nColumnId = int.Parse(oDataRowDependencias["column_id"].ToString());
                    string sTabelaNome = oDataRowDependencias["table_name"].ToString();
                    string sColunaNome = oDataRowDependencias["column_name"].ToString();
                    string[] aTabela = { nColumnId.ToString(), sTabelaNome, sColunaNome, null };
                    if (nColumnId == 1)
                    {
                        Array.Resize(ref aTabelas, aTabelas.Length + 1);
                        aTabelas[aTabelas.Length - 1] = aTabela;
                    }
                    else
                    {
                        aTabela = aTabelas[aTabelas.Length - 1];
                        aTabela[3] = sColunaNome;
                    }
                }

                // monta

                int i = 0;

                foreach (System.Data.DataRow oDataRow in oDataSet.Tables[0].Rows)
                {
                    string sColunaNome = oDataRow["column_name"].ToString();


                    // tipo da propriedade

                    string sTipo = oDataRow["data_type"].ToString();

                    if (sTipo == "NUMBER")
                    {
                        sTipo = "Int64";
                    }
                    else if (sTipo.IndexOf("CHAR") >= 0)
                    {
                        sTipo = "string";
                    }
                    else if (sTipo.IndexOf("TIMESTAMP") >= 0)
                    {
                        sTipo = "DateTime";
                    }
                    else if (sTipo.IndexOf("DATE") >= 0)
                    {
                        sTipo = "DateTime";
                    }

                    i += 1;

                    if (i == 1) // é uma chave
                    {
                        // propriedade chave

                        string sPropriedadeChave = sRecursoModeloPropriedadeChave;
                        sPropriedadeChave = sPropriedadeChave.Replace("<PROPRIEDADE_TIPO>", sTipo);
                        sPropriedadeChave = sPropriedadeChave.Replace("<PROPRIEDADE_NOME>", sColunaNome);

                        // adiciona a propriedade chave na matriz

                        Array.Resize(ref sPropriedadesChaves, sPropriedadesChaves.Length + 1);
                        sPropriedadesChaves[sPropriedadesChaves.Length - 1] = sPropriedadeChave;
                    }
                    else
                    {
                        bool bDependencia = false;
                        foreach (string[] sDependencia in aTabelas)
                        {
                            if (sDependencia[2] == sColunaNome)
                            {
                                bDependencia = true;
                                break;
                            }
                        }

                        if (!bDependencia) // é uma propriedade simples
                        {
       
                            // variável da propriedade

                            string sPropriedadeVariavel = sRecursoModeloPropriedadeVariavel;
                            sPropriedadeVariavel = sPropriedadeVariavel.Replace("<PROPRIEDADE_TIPO>", sTipo);
                            sPropriedadeVariavel = sPropriedadeVariavel.Replace("<PROPRIEDADE_NOME>", sColunaNome);


                            // adiciona a variavel da propriedade na matriz

                            Array.Resize(ref sPropriedadesVariaveis, sPropriedadesVariaveis.Length + 1);
                            sPropriedadesVariaveis[sPropriedadesVariaveis.Length - 1] = sPropriedadeVariavel;

                            // nome da propriedade

                            string sPropriedade = sRecursoModeloPropriedade;
                            sPropriedade = sPropriedade.Replace("<PROPRIEDADE_TIPO>", sTipo);
                            sPropriedade = sPropriedade.Replace("<PROPRIEDADE_NOME>", sColunaNome);

                            // adiciona a propriedade na matriz

                            Array.Resize(ref sPropriedades, sPropriedades.Length + 1);
                            sPropriedades[sPropriedades.Length - 1] = sPropriedade;
                        }


                    }

                }

                // trata as depdendências

                foreach (string[] dependencia in aTabelas)
                {
                    string sDependenciaTabelaNome = dependencia[1];

                    // dependencias (variaveis)

                    string sDependenciaVariavel = sRecursoDependenciaVariavel;
                    sDependenciaVariavel = sDependenciaVariavel.Replace("<CLASSE_NOME>", sDependenciaTabelaNome);

                    // adiciona a propriedade chave na matriz

                    Array.Resize(ref sDependenciasVariaveis, sDependenciasVariaveis.Length + 1);
                    sDependenciasVariaveis[sDependenciasVariaveis.Length - 1] = sDependenciaVariavel;

                    // dependencias (inicializa)

                    string sDependenciaInicializa = sRecursoDependenciaInicializa;
                    sDependenciaInicializa = sDependenciaInicializa.Replace("<CLASSE_NOME>", sDependenciaTabelaNome);

                    // adiciona a propriedade chave na matriz

                    Array.Resize(ref sDependenciasInicializa, sDependenciasInicializa.Length + 1);
                    sDependenciasInicializa[sDependenciasInicializa.Length - 1] = sDependenciaInicializa;

                    // dependencias (consultas)

                    string sDependenciaConsulta = sRecursoDependenciaConsulta;
                    sDependenciaConsulta = sDependenciaConsulta.Replace("<CLASSE_NOME>", sDependenciaTabelaNome);

                    // adiciona a propriedade chave na matriz

                    Array.Resize(ref sDependenciasConsultas, sDependenciasConsultas.Length + 1);
                    sDependenciasConsultas[sDependenciasConsultas.Length - 1] = sDependenciaConsulta;

                    // dependencias (propriedades)

                    string sDependenciaPropriedade = sRecursoDependenciaPropriedade;
                    sDependenciaPropriedade = sDependenciaPropriedade.Replace("<CLASSE_NOME>", sDependenciaTabelaNome);
                    sDependenciaPropriedade = sDependenciaPropriedade.Replace("<CLASSE_PROPRIEDADE_NOME>", sDependenciaTabelaNome.ToLower());

                    // adiciona a propriedade chave na matriz

                    Array.Resize(ref sDependenciasPropriedades, sDependenciasPropriedades.Length + 1);
                    sDependenciasPropriedades[sDependenciasPropriedades.Length - 1] = sDependenciaPropriedade;
                }

                // salva no arquivo

                string sArquivoNome = "c:\\temp\\" + sTabela +"_"+ DateTime.Now.ToString("hhmmss") + ".cs";

                System.IO.FileStream oFileStream = new FileStream(sArquivoNome, FileMode.CreateNew);

                // nome da classe

                sRecursoModeloClasse = sRecursoModeloClasse.Replace("<CLASSE_NOME>", sTabela);
                sRecursoModeloClasse = sRecursoModeloClasse.Replace("<SGDB>", SGDB);

                // variáveis das propriedades

                string sPropriedadeVariavelSaida = "";

                foreach (string sPropriedadeVariavel in sPropriedadesVariaveis)
                {
                    sPropriedadeVariavelSaida += sPropriedadeVariavel;
                }

                sRecursoModeloClasse = sRecursoModeloClasse.Replace("<CLASSE_PROPRIEDADES_VARIAVEIS>", sPropriedadeVariavelSaida);

                // propriedades da classe

                string sPropriedadeSaida = "";

                foreach (string sPropriedade in sPropriedades)
                {
                    sPropriedadeSaida += sPropriedade;
                }

                foreach (string sPropriedade in sPropriedadesChaves)
                {
                    sPropriedadeSaida += sPropriedade;
                }

                sRecursoModeloClasse = sRecursoModeloClasse.Replace("<CLASSE_PROPRIEDADES>", sPropriedadeSaida);

                // dependencias da classe (variaveis)

                string sDependenciaVariavelSaida = "";

                foreach (string sDependenciaVariavel in sDependenciasVariaveis)
                {
                    sDependenciaVariavelSaida += sDependenciaVariavel;
                }

                sRecursoModeloClasse = sRecursoModeloClasse.Replace("<CLASSES_DEPENDENTES_VARIAVEIS>", sDependenciaVariavelSaida);

                // dependencias da classe (inicializa)

                string sDependenciaInicializaSaida = "";

                foreach (string sDependenciaIncializa in sDependenciasInicializa)
                {
                    sDependenciaInicializaSaida += sDependenciaIncializa;
                }

                sRecursoModeloClasse = sRecursoModeloClasse.Replace("<CLASSES_DEPENDENTES_INICIALIZA>", sDependenciaInicializaSaida);


                // dependencias da classe (consultas)

                string sDependenciaConsultaSaida = "";

                foreach (string sDependenciaConsulta in sDependenciasConsultas)
                {
                    sDependenciaConsultaSaida += sDependenciaConsulta;
                }

                sRecursoModeloClasse = sRecursoModeloClasse.Replace("<CLASSES_DEPENDENTES_CONSULTA>", sDependenciaConsultaSaida);

                // dependencias da classe (propriedades)

                string sDependenciaPropriedadeSaida = "";

                foreach (string sDependenciaPropriedade in sDependenciasPropriedades)
                {
                    sDependenciaPropriedadeSaida += sDependenciaPropriedade;
                }

                sRecursoModeloClasse = sRecursoModeloClasse.Replace("<CLASSES_DEPENDENTES_PROPRIEDADES>", sDependenciaPropriedadeSaida);

                // salva o arquivo finalmente

                byte[] bRecursoModeloClasse = new UTF8Encoding(true).GetBytes(sRecursoModeloClasse);
                oFileStream.Write(bRecursoModeloClasse, 0, bRecursoModeloClasse.Length);

                oFileStream.Close();

            }

        }

        public void gerarPaginas(string[] tabelas)
        {
            gerarPaginasP(tabelas);
            gerarPaginasM(tabelas);
        }

        public void gerarPaginasP(string[] tabelas)
        {

            //<PAGINA_NOME>
            //<CLASSE_NOME>
            //<PROPRIEDADE_NOME>

            foreach (string sTabela in tabelas)
            {

                //string[] sPropriedades = { };
                //string[] sPropriedadesChaves = { };
                //string[] sPropriedadesVariaveis = { };

                // ASPX

                cf.dados.SISRECURSOS oSisRecurso = new SISRECURSOS();
                //oSisRecurso.DS_NOME_RECURSO = "MODELOPAGINAP.ASPX";
                //oSisRecurso.pesquisar();

                //if (oSisRecurso.Count == 0) { throw new Exception("Recurso não encontrado."); }

                byte[] bTexto = (byte[])oSisRecurso.STREAM;

                //string sRecursoModeloAspx = Encoding.UTF8.GetString(bTexto);

                string sRecursoModeloAspx = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOPAGINAP.ASPX.TXT");


                // CS

                //oSisRecurso = null; oSisRecurso = new SISRECURSOS();
                //oSisRecurso.DS_NOME_RECURSO = "MODELOPAGINAP.ASPX.CS";
                //oSisRecurso.pesquisar();

                //if (oSisRecurso.Count == 0) { throw new Exception("Recurso não encontrado."); }

                //bTexto = (byte[])oSisRecurso.STREAM;

                //string sRecursoModeloCS = Encoding.UTF8.GetString(bTexto);

                // C:\Users\nando\documents\visual studio 2015\Projects\CFUTIL\CUTIL\RECURSOS\MODELOPAGINAP.ASPX.CS.TXT

                string sRecursoModeloCS = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOPAGINAP.ASPX.CS1.TXT");

                // DESIGNER

                //oSisRecurso = null; oSisRecurso = new SISRECURSOS();
                //oSisRecurso.DS_NOME_RECURSO = "MODELOPAGINAP.ASPX.DESIGNER.CS";
                //oSisRecurso.pesquisar();

                //if (oSisRecurso.Count == 0) { throw new Exception("Recurso não encontrado."); }

                //bTexto = (byte[])oSisRecurso.STREAM;

                //string sRecursoModeloDesigner = Encoding.UTF8.GetString(bTexto);
                string sRecursoModeloDesigner = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOPAGINAP.ASPX.DESIGNER.CS1.TXT");

                // DESIGNER (CAMPO CHAVE)

                //oSisRecurso = null; oSisRecurso = new SISRECURSOS();
                //oSisRecurso.DS_NOME_RECURSO = "MODELOCAMPOCHAVEDESIGNER";
                //oSisRecurso.pesquisar();

                //if (oSisRecurso.Count == 0) { throw new Exception("Recurso não encontrado."); }

                //bTexto = (byte[])oSisRecurso.STREAM;

                //string sRecursoModeloCampoChaveDesigner = Encoding.UTF8.GetString(bTexto);
                string sRecursoModeloCampoChaveDesigner = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOCAMPOCHAVEDESIGNER.TXT");


                string[] sRecursoModeloCampoChaveDesigners = { };

                // DESIGNER (CAMPO)

                //oSisRecurso = null; oSisRecurso = new SISRECURSOS();
                //oSisRecurso.DS_NOME_RECURSO = "MODELOCAMPODESIGNER";
                //oSisRecurso.pesquisar();

                //if (oSisRecurso.Count == 0) { throw new Exception("Recurso não encontrado."); }

                //bTexto = (byte[])oSisRecurso.STREAM;

                //string sRecursoModeloCampoDesigner = Encoding.UTF8.GetString(bTexto);
                string sRecursoModeloCampoDesigner = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOCAMPODESIGNER.TXT");

                string[] sRecursoModeloCampoDesigners = { };

                //

                string sRecursoScriptColunas = oLib.obtemRecursoTexto("CUTIL.RECURSOS.SCRIPTCOLUNAS.TXT");

                int i = 0;

                string sSqlColunas = sRecursoScriptColunas.Replace("<TABELA_NOME>", sTabela);
                System.Data.DataSet oDataSet = consultando(sSqlColunas);

                foreach (System.Data.DataRow oDataRow in oDataSet.Tables[0].Rows)
                {
                    string sColunaNome =  oDataRow["column_name"].ToString();
                    String sLabelColunaNome = "LB_" + sTabela + "_" + sColunaNome;

                    i += 1;

                    if (i == 2) // é um nome  sColunaNome.ToLower().IndexOf("nome") > 0) // é um nome/descrição
                        {
                        // propriedade nome

                        // ASPX

                        sRecursoModeloAspx = sRecursoModeloAspx.Replace("<PROPRIEDADE_NOME>", sColunaNome); // <%$Resources:cf.language,inputEntrar%>
                        sRecursoModeloAspx = sRecursoModeloAspx.Replace("<LABEL_PROPRIEDADE_NOME>", sLabelColunaNome); // <%$Resources:cf.language,inputEntrar%>

                        //// DESGNER (CAMPO)

                        //string sFragmento = sRecursoModeloCampoDesigner;
                        //sFragmento = sFragmento.Replace("<CAMPO_INPUT>", sColunaNome);

                        //Array.Resize(ref sRecursoModeloCampoDesigners, sRecursoModeloCampoDesigners.Length + 1);
                        //sRecursoModeloCampoDesigners[sRecursoModeloCampoDesigners.Length - 1] = sFragmento;

                    }
                    else if (i==1) // é uma chave
                    {
                        // propriedade chave

                        // ASPX

                        sRecursoModeloAspx = sRecursoModeloAspx.Replace("<PROPRIEDADE_CODIGO>", sColunaNome);

                        //// DESIGNER (CAMPO CHAVE)

                        //string sFragmento = sRecursoModeloCampoChaveDesigner;
                        //sFragmento = sFragmento.Replace("<CAMPO_CHAVE>", sColunaNome);

                        //Array.Resize(ref sRecursoModeloCampoChaveDesigners, sRecursoModeloCampoChaveDesigners.Length + 1);
                        //sRecursoModeloCampoChaveDesigners[sRecursoModeloCampoChaveDesigners.Length - 1] = sFragmento;
                    }
                }

                // descarrega o DESIGNER

                sRecursoModeloDesigner = sRecursoModeloDesigner.Replace("<PAGINA_NOME>", sTabela.ToLower());

                //foreach (string sDesignerCampoChave in sRecursoModeloCampoChaveDesigners)
                //{
                //    sRecursoModeloDesigner = sRecursoModeloDesigner.Replace("<PAGINA_CAMPOS_CHAVES>", sDesignerCampoChave);
                //}
                //sRecursoModeloDesigner = sRecursoModeloDesigner.Replace("<PAGINA_NOME>", sTabela.ToLower());
                //sRecursoModeloDesigner = sRecursoModeloDesigner.Replace("<CLASSE_NOME>", sTabela);

                // descarregao o aspx

                sRecursoModeloAspx = sRecursoModeloAspx.Replace("<PAGINA_NOME>", sTabela.ToLower());

                sRecursoModeloCS = sRecursoModeloCS.Replace("<PAGINA_NOME>", sTabela.ToLower());
                sRecursoModeloCS = sRecursoModeloCS.Replace("<CLASSE_NOME>", sTabela);
                // salva no arquivo aspx

                string sArquivoNome = "c:\\temp\\" + sTabela.ToLower() + "P_" + DateTime.Now.ToString("hhmmss") + ".aspx";
                System.IO.FileStream oFileStream = new FileStream(sArquivoNome, FileMode.CreateNew);

                byte[] bRecursoModeloClasse = new UTF8Encoding(true).GetBytes(sRecursoModeloAspx);
                oFileStream.Write(bRecursoModeloClasse, 0, bRecursoModeloClasse.Length);
                oFileStream.Close();

                // salva no arquivo cs 

                sArquivoNome = "c:\\temp\\" + sTabela.ToLower() + "P_" + DateTime.Now.ToString("hhmmss") + ".aspx.cs";
                oFileStream = new FileStream(sArquivoNome, FileMode.CreateNew);

                bRecursoModeloClasse = new UTF8Encoding(true).GetBytes(sRecursoModeloCS);
                oFileStream.Write(bRecursoModeloClasse, 0, bRecursoModeloClasse.Length);
                oFileStream.Close();


                // salva no arquivo designer 

                sArquivoNome = "c:\\temp\\" + sTabela.ToLower() + "P_" + DateTime.Now.ToString("hhmmss") + ".aspx.designer.cs";
                oFileStream = new FileStream(sArquivoNome, FileMode.CreateNew);

                bRecursoModeloClasse = new UTF8Encoding(true).GetBytes(sRecursoModeloDesigner);
                oFileStream.Write(bRecursoModeloClasse, 0, bRecursoModeloClasse.Length);
                oFileStream.Close();

            }

        }

        public void gerarPaginasM(string[] tabelas)
        {
            //<PAGINA_NOME>
            //<CLASSE_NOME>
            //<PROPRIEDADE_NOME>
            foreach (string sTabela in tabelas)
            {
                //string[] sPropriedades = { };
                //string[] sPropriedadesChaves = { };
                //string[] sPropriedadesVariaveis = { };

                // ASPX

                //cf.dados.SISRECURSOS oSisRecurso = new SISRECURSOS();
                //oSisRecurso.DS_NOME_RECURSO = "MODELOPAGINAM.ASPX";
                //oSisRecurso.pesquisar();

                //if (oSisRecurso.Count == 0) { throw new Exception("Recurso não encontrado."); }

                //byte[] bTexto = (byte[])oSisRecurso.STREAM;

                //string sRecursoModeloAspx = Encoding.UTF8.GetString(bTexto);
                string sRecursoModeloAspx = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOPAGINAM.ASPX.TXT");


                // ASPX (CAMPO CHAVE)

                //oSisRecurso = new SISRECURSOS();
                //oSisRecurso.DS_NOME_RECURSO = "MODELOCAMPOCHAVE";
                //oSisRecurso.pesquisar();

                //if (oSisRecurso.Count == 0) { throw new Exception("Recurso não encontrado."); }

                //bTexto = (byte[])oSisRecurso.STREAM;

                //string sRecursoModeloCampoChaveAspx = Encoding.UTF8.GetString(bTexto);
                string sRecursoModeloCampoChaveAspx = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOCAMPOCHAVE.TXT");

                string[] sRecursoModeloCampoChaveAspxs = { };

                // ASPX (CAMPO)

                //oSisRecurso = new SISRECURSOS();
                //oSisRecurso.DS_NOME_RECURSO = "MODELOCAMPO";
                //oSisRecurso.pesquisar();

                //if (oSisRecurso.Count == 0) { throw new Exception("Recurso não encontrado."); }

                //bTexto = (byte[])oSisRecurso.STREAM;

                //string sRecursoModeloCampoAspx = Encoding.UTF8.GetString(bTexto);
                string sRecursoModeloCampoAspx = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOCAMPO.TXT");

                string[] sRecursoModeloCampoAspxs = { };

                // ASPX (CAMPO REFERENCIA)

                //oSisRecurso = new SISRECURSOS();
                //oSisRecurso.DS_NOME_RECURSO = "MODELOCAMPOREFERENCIA";
                //oSisRecurso.pesquisar();

                //if (oSisRecurso.Count == 0) { throw new Exception("Recurso não encontrado."); }

                //bTexto = (byte[])oSisRecurso.STREAM;

                //string sRecursoModeloCampoAspxReferencia = Encoding.UTF8.GetString(bTexto);
                string sRecursoModeloCampoAspxReferencia = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOCAMPOREFERENCIA.TXT");

                string[] sRecursoModeloCampoAspxReferencias = { };


                // CS

                //oSisRecurso = null; oSisRecurso = new SISRECURSOS();
                //oSisRecurso.DS_NOME_RECURSO = "MODELOPAGINAM.ASPX.CS";
                //oSisRecurso.pesquisar();

                //if (oSisRecurso.Count == 0) { throw new Exception("Recurso não encontrado."); }

                //bTexto = (byte[])oSisRecurso.STREAM;

                //string sRecursoModeloCS = Encoding.UTF8.GetString(bTexto);
                string sRecursoModeloCS = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOPAGINAM.ASPX.CS1.TXT");

                // DESIGNER

                //oSisRecurso = null; oSisRecurso = new SISRECURSOS();
                //oSisRecurso.DS_NOME_RECURSO = "MODELOPAGINAM.ASPX.DESIGNER.CS";
                //oSisRecurso.pesquisar();

                //if (oSisRecurso.Count == 0) { throw new Exception("Recurso não encontrado."); }

                //bTexto = (byte[])oSisRecurso.STREAM;

                //string sRecursoModeloDesigner = Encoding.UTF8.GetString(bTexto);
                string sRecursoModeloDesigner = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOPAGINAM.ASPX.DESIGNER.CS1.TXT");

                string[] sRecursoModeloDesigners = { };


                // DESIGNER (CAMPO CHAVE)

                //oSisRecurso = null; oSisRecurso = new SISRECURSOS();
                //oSisRecurso.DS_NOME_RECURSO = "MODELOCAMPOCHAVEDESIGNER";
                //oSisRecurso.pesquisar();

                //if (oSisRecurso.Count == 0) { throw new Exception("Recurso não encontrado."); }

                //bTexto = (byte[])oSisRecurso.STREAM;

                //string sRecursoModeloCampoChaveDesigner = Encoding.UTF8.GetString(bTexto);
                string sRecursoModeloCampoChaveDesigner = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOCAMPOCHAVEDESIGNER.TXT");

                string[] sRecursoModeloCampoChaveDesigners = { };

                // DESIGNER (CAMPO)

                //oSisRecurso = null; oSisRecurso = new SISRECURSOS();
                //oSisRecurso.DS_NOME_RECURSO = "MODELOCAMPODESIGNER";
                //oSisRecurso.pesquisar();

                //if (oSisRecurso.Count == 0) { throw new Exception("Recurso não encontrado."); }

                //bTexto = (byte[])oSisRecurso.STREAM;

                //string sRecursoModeloCampoDesigner = Encoding.UTF8.GetString(bTexto);
                string sRecursoModeloCampoDesigner = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOCAMPODESIGNER.TXT");

                string[] sRecursoModeloCampoDesigners = { };

                // DESIGNER (CAMPO REFERENCIA)

                //oSisRecurso = null; oSisRecurso = new SISRECURSOS();
                //oSisRecurso.DS_NOME_RECURSO = "MODELOCAMPOREFERENCIADESIGNER";
                //oSisRecurso.pesquisar();

                //if (oSisRecurso.Count == 0) { throw new Exception("Recurso não encontrado."); }

                //bTexto = (byte[])oSisRecurso.STREAM;

                //string sRecursoModeloCampoReferenciaDesigner = Encoding.UTF8.GetString(bTexto);
                string sRecursoModeloCampoReferenciaDesigner = oLib.obtemRecursoTexto("CUTIL.RECURSOS.MODELOCAMPOREFERENCIADESIGNER.TXT");

                string[] sRecursoModeloCampoReferenciaDesigners = { };

                //

                string sRecursoScriptColunas = oLib.obtemRecursoTexto("CUTIL.RECURSOS.SCRIPTCOLUNAS.TXT");
                string sRecursoScriptDependencias = oLib.obtemRecursoTexto("CUTIL.RECURSOS.SCRIPTDEPENDENCIAS.TXT");

                // dependencias (chaves estrangeiras/fk)

                string sSqlDependencias = sRecursoScriptDependencias.Replace("<TABELA_NOME>", sTabela);
                System.Data.DataSet oDataSetDependencias = consultando(sSqlDependencias);
                

                string[][] aTabelas = {  };
                foreach (System.Data.DataRow oDataRowDependencias in oDataSetDependencias.Tables[0].Rows)
                {
                    Int64 nColumnId = int.Parse(oDataRowDependencias["column_id"].ToString());
                    string sTabelaNome = oDataRowDependencias["table_name"].ToString();
                    string sColunaNome = oDataRowDependencias["column_name"].ToString();
                    string[] aTabela = { nColumnId.ToString(), sTabelaNome, sColunaNome,null };
                    if (nColumnId == 1)
                    {
                        Array.Resize(ref aTabelas, aTabelas.Length + 1);
                        aTabelas[aTabelas.Length - 1] = aTabela;
                    }
                    else
                    {
                        aTabela = aTabelas[aTabelas.Length - 1];
                        aTabela[3] = sColunaNome;
                        //aTabelas[aTabelas.Length - 1] = aTabela;
                    }
                }

                //

                int i = 0;

                string sSqlColunas = sRecursoScriptColunas.Replace("<TABELA_NOME>", sTabela);
                System.Data.DataSet oDataSet = consultando(sSqlColunas);

                foreach (System.Data.DataRow oDataRow in oDataSet.Tables[0].Rows)
                {
                    string sColunaNome = oDataRow["column_name"].ToString();
                    Int64 nColumnId = int.Parse(oDataRow["column_id"].ToString());

                    i += 1;

                    if (false) // sColunaNome.ToLower().IndexOf("nome") > 0 // é um nome/descrição
                    {



                    }
                    else if (nColumnId == 1) //  i == 1 ; é uma chave
                    {
                        // ASPX

                        //sRecursoModeloAspx = sRecursoModeloAspx.Replace("<PROPRIEDADE_CODIGO>", sColunaNome);

                        // ASPX (CAMPO CHAVE)

                        string sFragmento = sRecursoModeloCampoChaveAspx;
                        sFragmento = sFragmento.Replace("<CAMPO_CHAVE>", sTabela + "_CODIGO"); //  + sColunaNome

                        Array.Resize(ref sRecursoModeloCampoChaveAspxs, sRecursoModeloCampoChaveAspxs.Length + 1);
                        sRecursoModeloCampoChaveAspxs[sRecursoModeloCampoChaveAspxs.Length - 1] = sFragmento;

                        // DESIGNER (CAMPO CHAVE)

                        sFragmento = sRecursoModeloCampoChaveDesigner;
                        sFragmento = sFragmento.Replace("<CAMPO_CHAVE>", sTabela + "_CODIGO"); //  + sColunaNome

                        Array.Resize(ref sRecursoModeloCampoChaveDesigners, sRecursoModeloCampoChaveDesigners.Length + 1);
                        sRecursoModeloCampoChaveDesigners[sRecursoModeloCampoChaveDesigners.Length - 1] = sFragmento;
                    }
                    else // pode ser um campo referência - chave estrangeira - fk - chave estrangeira 
                    {
                        string sReferenciaCodigo="";
                        string sReferenciaNome = "";
                        string sReferenciaTabela = "";

                        foreach (string[] sReferencia in aTabelas)
                        {
                            if (sReferencia[2] == sColunaNome)
                            {
                                sReferenciaTabela = sReferencia[1];
                                if (sReferencia[0] == "1") // codigo
                                {
                                    sReferenciaCodigo = sColunaNome;
                                    sReferenciaNome = sReferencia[3];
                                }

                                //break;
                            }

                        }
                        if (sReferenciaCodigo != "") // campo referência
                        {
                            // ASPX (CAMPO )

                            string sFragmento = sRecursoModeloCampoAspxReferencia;

                            sFragmento = sFragmento.Replace("<CAMPO_TITULO>", sReferenciaTabela + "_NOME");
                            sFragmento = sFragmento.Replace("<CAMPO_INPUT>", sReferenciaTabela + "_CODIGO"); // " +  sReferenciaCodigo
                            sFragmento = sFragmento.Replace("<CAMPO_INPUT_NOME>", sReferenciaTabela + "_" + sReferenciaNome); // "_NOME"
                            sFragmento = sFragmento.Replace("<PAGINA_NOME>", sReferenciaTabela.ToLower());
                            sFragmento = sFragmento.Replace("<CAMPO_INPUT>", sReferenciaTabela.ToLower());

                            Array.Resize(ref sRecursoModeloCampoAspxReferencias, sRecursoModeloCampoAspxReferencias.Length + 1);
                            sRecursoModeloCampoAspxReferencias[sRecursoModeloCampoAspxReferencias.Length - 1] = sFragmento;

                            // DESIGNER CAMPO REFERENCIA

                            sFragmento = sRecursoModeloCampoReferenciaDesigner;

                            sFragmento = sFragmento.Replace("<CAMPO_INPUT>", sReferenciaTabela + "_CODIGO"); //  + sReferenciaCodigo
                            sFragmento = sFragmento.Replace("<CAMPO_INPUT_NOME>", sReferenciaTabela + "_NOME");

                            Array.Resize(ref sRecursoModeloCampoReferenciaDesigners, sRecursoModeloCampoReferenciaDesigners.Length + 1);
                            sRecursoModeloCampoReferenciaDesigners[sRecursoModeloCampoReferenciaDesigners.Length - 1] = sFragmento;

                        }
                        else //é um campo normal
                        {
                            // ASPX

                            //sRecursoModeloAspx = sRecursoModeloAspx.Replace("<PROPRIEDADE_NOME>", sColunaNome);

                            // ASPX (CAMPO)

                            string sFragmento = sRecursoModeloCampoAspx;
                            sFragmento = sFragmento.Replace("<CAMPO_TITULO>", sColunaNome);
                            sFragmento = sFragmento.Replace("<CAMPO_INPUT>", sTabela.ToUpper() + "_" + sColunaNome);

                            Array.Resize(ref sRecursoModeloCampoAspxs, sRecursoModeloCampoAspxs.Length + 1);
                            sRecursoModeloCampoAspxs[sRecursoModeloCampoAspxs.Length - 1] = sFragmento;

                            // DESIGNER (CAMPO)

                            sFragmento = sRecursoModeloCampoDesigner;
                            sFragmento = sFragmento.Replace("<CAMPO_INPUT>", sTabela + "_" + sColunaNome);

                            Array.Resize(ref sRecursoModeloCampoDesigners, sRecursoModeloCampoDesigners.Length + 1);
                            sRecursoModeloCampoDesigners[sRecursoModeloCampoDesigners.Length - 1] = sFragmento;
                        }
                    }

                }

                // descarrega o ASPX (<PAGINA_NOME>)

                sRecursoModeloAspx = sRecursoModeloAspx.Replace("<PAGINA_NOME>", sTabela.ToLower());

                // descarrega o ASPX (<PAGINA_CAMPOS_CHAVES>)

                string sPaginasCamposChaves = "";

                foreach (string sAspxCampoChave in sRecursoModeloCampoChaveAspxs)
                {
                    sPaginasCamposChaves += sAspxCampoChave;

                }
                sRecursoModeloAspx = sRecursoModeloAspx.Replace("<PAGINA_CAMPOS_CHAVES>", sPaginasCamposChaves);


                // descarrega o ASPX (<PAGINA_CAMPOS>)

                string sPaginasCampos = "";

                foreach (string sAspxCampo in sRecursoModeloCampoAspxs)
                {
                    sPaginasCampos += sAspxCampo;

                }
                sRecursoModeloAspx = sRecursoModeloAspx.Replace("<PAGINA_CAMPOS>", sPaginasCampos);



                // descarrega o ASPX (<PAGINA_CAMPOS_REFERENCIA>)

                string sPaginasCamposReferencia = "";

                foreach (string sAspxCampoReferencia in sRecursoModeloCampoAspxReferencias)
                {
                    sPaginasCamposReferencia += sAspxCampoReferencia;

                }
                sRecursoModeloAspx = sRecursoModeloAspx.Replace("<PAGINA_CAMPOS_REFERENCIA>", sPaginasCamposReferencia);

                // descarrega o DESIGNER (<PAGINA_NOME>)

                sRecursoModeloDesigner = sRecursoModeloDesigner.Replace("<PAGINA_NOME>", sTabela.ToLower());

                // descarrega o DESIGNER (<PAGINA_CAMPOS_CHAVES>)

                foreach (string sDesignerCampoChave in sRecursoModeloCampoChaveDesigners)
                {
                    sRecursoModeloDesigner = sRecursoModeloDesigner.Replace("<PAGINA_CAMPOS_CHAVES>", sDesignerCampoChave);
                }

                // descarrega o DESIGNER (<PAGINA_CAMPOS>)

                string sPaginasCamposDesigner = "";

                foreach (string sDesignerCampo in sRecursoModeloCampoDesigners)
                {
                    sPaginasCamposDesigner += sDesignerCampo;
                }
                sRecursoModeloDesigner = sRecursoModeloDesigner.Replace("<PAGINA_CAMPOS>", sPaginasCamposDesigner);


                // descarrega o DESIGNER (<PAGINA_CAMPOS_REFERENCIA>)

                string sPaginasCamposReferenciaDesigner = "";

                foreach (string sDesignerCampo in sRecursoModeloCampoReferenciaDesigners)
                {
                    sPaginasCamposReferenciaDesigner += sDesignerCampo;
                }
                sRecursoModeloDesigner = sRecursoModeloDesigner.Replace("<PAGINA_CAMPOS_REFERENCIA>", sPaginasCamposReferenciaDesigner);

                //

                sRecursoModeloCS = sRecursoModeloCS.Replace("<PAGINA_NOME>", sTabela.ToLower());
                sRecursoModeloCS = sRecursoModeloCS.Replace("<CLASSE_NOME>", sTabela);

                // salva no arquivo aspx

                string sArquivoNome = "c:\\temp\\" + sTabela.ToLower() + "M_" + DateTime.Now.ToString("hhmmss") + ".aspx";
                System.IO.FileStream oFileStream = new FileStream(sArquivoNome, FileMode.CreateNew);

                byte[] bRecursoModeloClasse = new UTF8Encoding(true).GetBytes(sRecursoModeloAspx);
                oFileStream.Write(bRecursoModeloClasse, 0, bRecursoModeloClasse.Length);
                oFileStream.Close();

                // salva no arquivo cs 

                sArquivoNome = "c:\\temp\\" + sTabela.ToLower() + "M_" + DateTime.Now.ToString("hhmmss") + ".aspx.cs";
                oFileStream = new FileStream(sArquivoNome, FileMode.CreateNew);

                bRecursoModeloClasse = new UTF8Encoding(true).GetBytes(sRecursoModeloCS);
                oFileStream.Write(bRecursoModeloClasse, 0, bRecursoModeloClasse.Length);
                oFileStream.Close();


                // salva no arquivo designer 

                sArquivoNome = "c:\\temp\\" + sTabela.ToLower() + "M_" + DateTime.Now.ToString("hhmmss") + ".aspx.designer.cs";
                oFileStream = new FileStream(sArquivoNome, FileMode.CreateNew);

                bRecursoModeloClasse = new UTF8Encoding(true).GetBytes(sRecursoModeloDesigner);
                oFileStream.Write(bRecursoModeloClasse, 0, bRecursoModeloClasse.Length);
                oFileStream.Close();

            }

        }

    }
}
