using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Telerik.Web.UI;

namespace BitchainWeb.Classes
{
    public static class Funcoes
    {
        public static void ConfiguraReport(ReportDocument cr)
        {
            var cs = ConfigurationManager.ConnectionStrings["BaseConnectionString"].ConnectionString;
            var css = cs.Split(';');
            var srv = css.Single(c => c.StartsWith("Data Source")).Split('=')[1];
            var bco = css.Single(c => c.StartsWith("Initial Catalog")).Split('=')[1];
            var its = bool.Parse(css.Single(c => c.StartsWith("Integrated Security")).Split('=')[1]);
            var usr = string.Empty;
            var pwd = string.Empty;
            if (!its)
            {
                usr = css.Single(c => c.StartsWith("Uid")).Split('=')[1];
                pwd = css.Single(c => c.StartsWith("Pwd")).Split('=')[1];
            }

            var crConnectionInfo = new ConnectionInfo()
            {
                ServerName = srv,
                DatabaseName = bco,
                IntegratedSecurity = its
            };

            if (!its)
            {
                crConnectionInfo.UserID = usr;
                crConnectionInfo.Password = pwd;
            }

            foreach (Table table in cr.Database.Tables)
            {
                table.LogOnInfo.ConnectionInfo = crConnectionInfo;
                table.ApplyLogOnInfo(table.LogOnInfo);
                table.Location = string.Format("{0}.dbo.{1}", bco, table.Location.Substring(table.Location.LastIndexOf(".") + 1));
            }

            foreach (ReportDocument sr in cr.Subreports)
            {
                foreach (Table table in sr.Database.Tables)
                {
                    table.LogOnInfo.ConnectionInfo = crConnectionInfo;
                    table.ApplyLogOnInfo(table.LogOnInfo);
                }
            }
        }

        public static string Criptografa(string Dados)
        {
            var dadosRetorno = string.Empty;
            var dadoEncriptado = CryptoServiceHelper.RijndaelHelper.Default.Encrypt(Dados);
            try
            {
                dadosRetorno = CryptoServiceHelper.UrlHelper.UrlTokenEncode(dadoEncriptado);
                return dadosRetorno;
            }
            finally
            {
                dadoEncriptado = null;
                dadosRetorno = null;
            }
        }

        public static string Descriptografa(string Dados)
        {
            var dadosRetorno = string.Empty;
            var dadoEncriptado = CryptoServiceHelper.UrlHelper.UrlTokenDecode(Dados);
            try
            {
                string query = CryptoServiceHelper.RijndaelHelper.Default.Decrypt(dadoEncriptado);
                return query;
            }
            finally
            {
                dadoEncriptado = null;
                dadosRetorno = null;
            }
        }

        public static bool VerificaCnpj(string cnpj)
        {
            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
                return validaCnpj(cnpj);
            else
                return false;
        }

        public static bool VerificaCPF(string cpf)
        {
            if (cpf == "00000000000" || cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444" || cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888" || cpf == "99999999999")
                return false;
            else if (Regex.IsMatch(cpf, @"(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)"))
                return validaCpf(cpf);
            else
                return false;
        }

        private static bool validaCEI(string cei)
        {
            var peso = "115830024688";
            var ceibase = cei.Substring(0, 11);
            var soma = 0;
            var digito = 0;

            for (var i = 0; i <= 10; i++)
                soma += int.Parse(ceibase[i].ToString()) * int.Parse(peso[i].ToString());

            var digitos = soma.ToString().Substring(soma.ToString().Length - 2, 2);
            var soma2 = int.Parse(digitos[0].ToString()) + int.Parse(digitos[1].ToString());
            var soma3 = 10 - int.Parse(soma2.ToString()[soma2.ToString().Length - 1].ToString());

            if (soma3 < 10)
                digito = soma3;

            return (cei[11] == digito.ToString()[0]);
        }

        private static bool validaCnpj(string cnpj)
        {
            Int32[] digitos, soma, resultado;
            Int32 nrDig;
            String ftmt;
            Boolean[] cnpjOk;
            cnpj = cnpj.Replace("/", "");
            cnpj = cnpj.Replace(".", "");
            cnpj = cnpj.Replace("-", "");

            if (cnpj == "00000000000000")
                return false;

            ftmt = "6543298765432";
            digitos = new Int32[14];
            soma = new Int32[] { 0, 0 };
            resultado = new Int32[] { 0, 0 };
            cnpjOk = new Boolean[] { false, false };

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(cnpj.Substring(nrDig, 1));

                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));

                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);

                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                        cnpjOk[nrDig] = (digitos[12 + nrDig] == 0);
                    else
                        cnpjOk[nrDig] = (digitos[12 + nrDig] == (
                        11 - resultado[nrDig]));
                }
                return (cnpjOk[0] && cnpjOk[1]);
            }

            catch
            {
                return false;
            }
        }

        private static bool validaCpf(string cpf)
        {
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;

            int soma;
            int resto;

            try
            {
                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");

                if (cpf.Length != 11)
                    return false;

                tempCpf = cpf.Substring(0, 9);

                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * (multiplicador1[i]);

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                int soma2 = 0;

                for (int i = 0; i < 10; i++)
                    soma2 += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                resto = soma2 % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();
                return cpf.EndsWith(digito);
            }
            finally
            {
                multiplicador1 = null;
                multiplicador2 = null;
                tempCpf = null;
                digito = null;
            }
        }
        
        public static string MascaraCPFCNPJ(string documento)
        {
            var sDocumento = documento.Trim();
            if (sDocumento.Length == 11)
                return sDocumento.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            else if (sDocumento.Length == 14)
                return sDocumento.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
            else
                return sDocumento;
        }

        public static string MascaraCNAE(int? documento)
        {
            var sDocumento = string.Empty;

            if (documento != null)
                sDocumento = documento.ToString();

            if (sDocumento.Length == 7)
                sDocumento = sDocumento.Insert(4, "-").Insert(6, "/");

            return sDocumento;
        }

        public static string DataString(DateTime? data)
        {
            var sRet = string.Empty;

            if (data != null)
            {
                var dData = (DateTime) data;
                sRet = dData.ToShortDateString();
            }

            return sRet;
        }

        public static string LimitaString(string valor, int tamanho)
        {
            return valor.Length > tamanho ? valor.Substring(0, tamanho - 1) : valor;
        }

        public static bool ValidaData(string data)
        {
            var resposta = true;

            try
            {

                var dt = Convert.ToDateTime(data);
            }
            catch
            {
                resposta = false;
            }


            return resposta;
        }

        public static string ValorString(decimal? valor)
        {
            return decimalString(valor, "c2");
        }

        public static string NumeroString(decimal? valor)
        {
            return decimalString(valor, "n2");
        }

        private static string decimalString(decimal? valor, string formato)
        {
            var sRet = string.Empty;

            if (valor != null)
            {
                var dValor = (decimal) valor;
                sRet = dValor.ToString(formato);
            }

            return sRet;
        }

        public static string SimNao(byte? valor)
        {
            var sRet = string.Empty;

            if (valor == 0)
                sRet = "Não";
            else if (valor == 1)
                sRet = "Sim";

            return sRet;
        }

        public static string Adesao(string valor)
        {
            var sRet = string.Empty;

            if (valor == "F")
                sRet = "Facultativo";
            else if (valor == "C")
                sRet = "Compulsório";

            return sRet;
        }

        public static string Custeio(byte? valor)
        {
            var sRet = string.Empty;

            if (valor == 1)
                sRet = "Contributário";
            else if (valor == 2)
                sRet = "Não Contributário";
            else if (valor == 3)
                sRet = "Parcialmente Contributário";

            return sRet;
        }

        public static string FaturaSituacao(string situacao)
        {
            if (situacao == "A")
                return "Ativo";
            else if (situacao == "C")
                return "Cancelada";
            else if (situacao == "E")
                return "Recusada";
            else if (situacao == "F")
                return "Aguardando Arquivo";
            else if (situacao == "N")
                return "Renovado";
            else if (situacao == "O")
                return "Orçamento";
            else if (situacao == "P")
                return "Pendência Corretor";
            else if (situacao == "R")
                return "Em análise";
            else if (situacao == "S")
                return "Suspenso";
            else if (situacao == "U")
                return "Última Aceitação";
            else
                return situacao;
        }

        public static List<Situacao> ListaSimNao()
        {
            var ll = new List<Situacao>()
            {
                new Situacao {ID = 0, Descricao = "Não"},
                new Situacao {ID = 1, Descricao = "Sim"}
            };

            return ll;
        }

        public static List<Situacao> ListaTipoFamilia()
        {
            var ll = new List<Situacao>()
            {
                new Situacao {ID = 1, Descricao = "AP"},
                new Situacao {ID = 2, Descricao = "CENTRAPE"}
            };

            return ll;
        }
        public static List<SituacaoS> ListaSimNaoTexto()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS {ID = "N", Descricao = "Não"},
                new SituacaoS {ID = "S", Descricao = "Sim"}
            };

            return ll;
        }
        public static List<SituacaoNF> ListaSituacaoNF()
        {
            var ll = new List<SituacaoNF>()
            {
                new SituacaoNF {        Descricao = "Pendente Envio"},
                new SituacaoNF {ID = 1, Descricao = "NF Enviada"},
                new SituacaoNF {ID = 2, Descricao = "Aceita"},
                new SituacaoNF {ID = 3, Descricao = "Recusada"},
                new SituacaoNF {ID = 4, Descricao = "Pendente NF Física"},


            };

            return ll;
        }

        public static List<SituacaoS> ListaPessoa()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS {ID = "F", Descricao = "Física"},
                new SituacaoS {ID = "J", Descricao = "Jurídica"}
            };

            return ll;
        }

        public static List<Situacao> ListaCobrancaSituacao()
        {
            var ll = new List<Situacao>()
            {
                new Situacao {ID = 1, Descricao = "Em aberto"},
                new Situacao {ID = 6, Descricao = "Pago"},
                new Situacao {ID = 8, Descricao = "Estornada"},

            };

            return ll;
        }

        public static List<Situacao> ListaSeguradoLock()
        {
            var ll = new List<Situacao>()
            {
                new Situacao {ID = 9, Descricao = "Restrito"},
                new Situacao {ID = 2, Descricao = "Aprovado"},
                new Situacao {ID = 3, Descricao = "Reprovado"}
            };

            return ll;
        }

        public static List<Situacao> ListaSeguradoSituacao()
        {
            var ll = new List<Situacao>()
            {
                new Situacao {ID = 1, Descricao = "Inclusão"},
                new Situacao {ID = 3, Descricao = "Exclusão"},
                new Situacao {ID = 5, Descricao = "Alteração"},
                new Situacao {ID = 9, Descricao = ""}
            };

            return ll;
        }

        public static List<Situacao> ListaCorretorCategoria()
        {
            var ll = new List<Situacao>()
            {
                new Situacao {ID = 1, Descricao = "Representante"},
                new Situacao {ID = 2, Descricao = "Gerencia"},
                new Situacao {ID = 3, Descricao = "Comercial"},
                new Situacao {ID = 4, Descricao = "Matriz"},
                new Situacao {ID = 5, Descricao = "Substabelecido" }
            };

            return ll;
        }

        public static List<Situacao> ListaCorretorStatus()
        {
            var ll = new List<Situacao>()
            {
                new Situacao {ID = 0, Descricao = "Inativo"},
                new Situacao {ID = 1, Descricao = "Ativo"},
                new Situacao {ID = 2, Descricao = "Em Cadastro"},
                new Situacao {ID = 3, Descricao = "Aguardando Aprovação"},
                new Situacao {ID = 4, Descricao = "Rejeitado" }
            };

            return ll;
        }

        public static List<SituacaoS> ListaCorretorDeposito()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "C", Descricao = "Cheque"},
                new SituacaoS { ID = "D", Descricao = "DOC"}
            };

            return ll;
        }

        public static List<SituacaoS> ListaUsuarioCorretorTipo()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "FUN", Descricao = "Funcionário"},
                new SituacaoS { ID = "RTE", Descricao = "Resp. Técnico"},
                new SituacaoS { ID = "MTR", Descricao = "Master"}
            };

            return ll;
        }

        public static List<SituacaoS> ListaProdutoTipo()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "CG", Descricao = "Capital Global"},
                new SituacaoS { ID = "IND", Descricao = "Individual"},
                new SituacaoS { ID = "PME", Descricao = "Pequena e Média Empersa"}
            };

            return ll;
        }

        public static List<SituacaoS> ListaSelecaoCobertura()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "M", Descricao = "Múltipla Escolha"},
                new SituacaoS { ID = "P", Descricao = "Plano"}
            };

            return ll;
        }

        public static List<Situacao> ListaCusteio()
        {
            var ll = new List<Situacao>()
            {
                new Situacao { ID = 1, Descricao = "Contributário"},
                new Situacao { ID = 2, Descricao = "Não Contributário"},
                new Situacao { ID = 3, Descricao = "Parcialmente Contributário"},
                new Situacao { ID = 9, Descricao = "Todos"}
            };

            return ll;
        }

        public static List<SituacaoS> ListaAdesao()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "C", Descricao = "Compulsório"},
                new SituacaoS { ID = "F", Descricao = "Facultativo"},
                new SituacaoS { ID = "9", Descricao = "Todos"}
            };

            return ll;
        }

        public static List<SituacaoS> ListaCoberturaTPValores()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "F", Descricao = "Reais"},
                new SituacaoS { ID = "V", Descricao = "Taxa"},
            };

            return ll;
        }

        public static List<SituacaoS> ListaCoberturaTPCobertura()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "V", Descricao = "Cobertura Securitária"},
                new SituacaoS { ID = "A", Descricao = "Assistências"}
                //new SituacaoS { ID = "B", Descricao = "Benefícios"},
            };

            return ll;
        }

        public static List<Situacao> ListaFrequenciaEmissao()
        {
            var ll = new List<Situacao>()
            {
                new Situacao { ID = 12, Descricao = "Anual"},
                new Situacao { ID =  1, Descricao = "Mensal"}
            };

            return ll;
        }

        public static List<Situacao> ListaParcelamento()
        {
            var ll = new List<Situacao>()
            {
                new Situacao { ID = 12, Descricao = "12 Parcelas"},
                new Situacao { ID =  1, Descricao = "1 Parcela"}
            };

            return ll;
        }

        public static List<SituacaoS> ListaMultiplicadorCoberturaBase()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "1", Descricao = "100%"},
                new SituacaoS { ID = "2", Descricao = "200%"},
                new SituacaoS { ID = "1,50", Descricao = "150%"},
                new SituacaoS { ID = "0,50", Descricao = "50%"},
                new SituacaoS { ID = "0,25", Descricao = "25%"}
            };

            return ll;
        }

        public static List<Situacao> ListaPrestadorServico()
        {
            var ll = new List<Situacao>()
            {
                new Situacao { ID = 0, Descricao = "Sem prestador"},
                new Situacao { ID = 1, Descricao = "Zurich Capitalização"},
                new Situacao { ID = 2, Descricao = "Invest Capitalização"},
                new Situacao { ID = 3, Descricao = "E-Pharma"},
                new Situacao { ID = 4, Descricao = "Facil Assist"}
            };

            return ll;
        }

        public static List<SituacaoS> ListaProdutoCategoria()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "MORTE", Descricao = "Morte"},
                new SituacaoS { ID = "MA", Descricao = "MA"},
                new SituacaoS { ID = "IPA", Descricao = "IPA"},
                new SituacaoS { ID = "SORTEIO", Descricao = "Sorteio"},
                new SituacaoS { ID = "FUNERAL", Descricao = "Funeral"},
                new SituacaoS { ID = "ALIMENT", Descricao = "Alimentação"},
                new SituacaoS { ID = "REMEDIO", Descricao = "Medicamento"},
                new SituacaoS { ID = "RESID", Descricao = "Residencial"},
                new SituacaoS { ID = "NUTRI", Descricao = "Nutricional"}
            };

            return ll;
        }

        public static List<SituacaoS> ListaOrgaoExpedidor()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "SSP", Descricao = "Secretaria Seguranca Publica"},
                new SituacaoS { ID = "CREA", Descricao = "Conselho Regional Arquitetura"},
                new SituacaoS { ID = "CRM", Descricao = "Conselho Regional de Medicina"},
                new SituacaoS { ID = "SPSP", Descricao = "SECRET DE POLICIA E SEG PUBLIC"},
                new SituacaoS { ID = "SJS", Descricao = "SECRETARIA DA JUSTICA E SEGURA"},
                new SituacaoS { ID = "DETRAN", Descricao = "DEP NACIONAL DE TRANSITO"},
                new SituacaoS { ID = "UFRJ", Descricao = "Univ Fed do Rio de Janeiro"},
                new SituacaoS { ID = "OAB", Descricao = "Ordem dos Advogados do Brasil"},
                new SituacaoS { ID = "IPF", Descricao = "Instituto Pereira Faustino"},
                new SituacaoS { ID = "MEC", Descricao = "Ministério da Educação"},
                new SituacaoS { ID = "IML", Descricao = "IML"},
                new SituacaoS { ID = "SUPERIOR T", Descricao = "SUPERIOR TRIBUNAL FEDERAL"},
                new SituacaoS { ID = "CRC", Descricao = "CRC"},
                new SituacaoS { ID = "SJT", Descricao = "SJT"},
                new SituacaoS { ID = "SSI", Descricao = "SSI"},
                new SituacaoS { ID = "MINEX", Descricao = "MINEX"},
                new SituacaoS { ID = "CTPS", Descricao = "CTPS"},
                new SituacaoS { ID = "CPROF", Descricao = "CPROF"},
                new SituacaoS { ID = "CRO", Descricao = "CRO"},
                new SituacaoS { ID = "CREME", Descricao = "CREME"},
                new SituacaoS { ID = "SJTC", Descricao = "SJTC"},
                new SituacaoS { ID = "DPF", Descricao = "DPF"},
                new SituacaoS { ID = "AERON", Descricao = "AERON"},
                new SituacaoS { ID = "CONS REG E", Descricao = "CONS REG ECONOMIA"},
                new SituacaoS { ID = "MIN EXERCI", Descricao = "MIN DEFESA (EXERCITO)"},
                new SituacaoS { ID = "BM", Descricao = "BM"},
                new SituacaoS { ID = "EXERC", Descricao = "EXERC"},
                new SituacaoS { ID = "IFP", Descricao = "INSTITUTO FELIX PACHECO"},
                new SituacaoS { ID = "PC", Descricao = "POLICIA CIVIL" }
            };

            return ll;
        }

        public class Situacao
        {
            public int ID { get; set; }
            public string Descricao { get; set; }
        }
        public class SituacaoNF
        {
            public int? ID { get; set; }
            public string Descricao { get; set; }
        }

        public class SituacaoS
        {
            public string ID { get; set; }
            public string Descricao { get; set; }
        }

        public static string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".docx":
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case ".doc":
                    return "application/msword";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mp3"; //audio/mpeg3
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".png":
                    return "image/png";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }

        public static List<Situacao> ListaQuadrante()
        {
            var ll = new List<Situacao>()
            {
                new Situacao { ID = 1},
                new Situacao { ID = 2},
                new Situacao { ID = 3},
                new Situacao { ID = 4},
            };

            return ll;
        }

        public static List<SituacaoS> ListaCorretorComissao()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "A", Descricao = "Agenciador"},
                new SituacaoS { ID = "C", Descricao = "Corretor"},
            };

            return ll;
        }

        public static List<SituacaoS> ListaCorretorComissaoAgenciador()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "A", Descricao = "Agenciador"},
            };

            return ll;
        }

        public static List<SituacaoS> ListaCorretorFontePagadoraComissao()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "A", Descricao = "Agenciador"},
                new SituacaoS { ID = "C", Descricao = "Corretor"},
                new SituacaoS {  Descricao="Todos" },


            };

            return ll;
        }

        public static List<Situacao> ListaComissaoOperacao()
        {
            var ll = new List<Situacao>()
            {
                new Situacao { ID = 1, Descricao = "Automática"},
                new Situacao { ID = 2, Descricao = "Manual"},
            };

            return ll;
        }

        public static List<SituacaoS> ListaComissaoTipoLancamento()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "A", Descricao = "Agenciamento"},
                new SituacaoS { ID = "C", Descricao = "Corretagem"},
                new SituacaoS { ID = "D", Descricao = "Desconto"},
            };

            return ll;
        }


        public static List<SituacaoS> ListaComissaoTipoTransacao()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "CSC", Descricao = "Comissão Crédito"},
                new SituacaoS { ID = "CSD", Descricao = "Comissão Débito"},
                new SituacaoS { ID = "ESD", Descricao = "Estorno Débito"},
                new SituacaoS { ID = "ASC", Descricao = "Adiantamento Crédito"},
                new SituacaoS { ID = "ASD", Descricao = "Adiantamento Débito"},
                new SituacaoS { ID = "BSC", Descricao = "Bônus Crédito"},
                new SituacaoS { ID = "BSD", Descricao = "Bônus Débito"},
                new SituacaoS { ID = "DJD", Descricao = "Débito Judicial"},
            };

            return ll;
        }

        public static List<SituacaoS> ListaUF()
        {
            var ll = new List<SituacaoS>()
            {
                new SituacaoS { ID = "AC" },
                new SituacaoS { ID = "AL" },
                new SituacaoS { ID = "AM" },
                new SituacaoS { ID = "AP" },
                new SituacaoS { ID = "BA" },
                new SituacaoS { ID = "CE" },
                new SituacaoS { ID = "DF" },
                new SituacaoS { ID = "ES" },
                new SituacaoS { ID = "GO" },
                new SituacaoS { ID = "MA" },
                new SituacaoS { ID = "MG" },
                new SituacaoS { ID = "MS" },
                new SituacaoS { ID = "MT" },
                new SituacaoS { ID = "PA" },
                new SituacaoS { ID = "PB" },
                new SituacaoS { ID = "PE" },
                new SituacaoS { ID = "PI" },
                new SituacaoS { ID = "PR" },
                new SituacaoS { ID = "RJ" },
                new SituacaoS { ID = "RN" },
                new SituacaoS { ID = "RO" },
                new SituacaoS { ID = "RR" },
                new SituacaoS { ID = "RS" },
                new SituacaoS { ID = "SC" },
                new SituacaoS { ID = "SE" },
                new SituacaoS { ID = "SP" },
                new SituacaoS { ID = "TO" }
            };

            return ll;
        }

        public static List<Situacao> ListaSituacaoAprovacao()
        {
            var ll = new List<Situacao>()
            {
                new Situacao { ID = 1, Descricao = "Aprovação do Substabelecido"},
                new Situacao { ID = 2, Descricao = "Aprovação de Repasse"},
            };

            return ll;
        }

        public static bool ValidaEmail(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
                return false;

            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        public static string GetXMLFromObject(object o)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                StringWriter sw = new StringWriter();
                XmlTextWriter tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
                return sw.ToString();
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

            return string.Empty;
        }

        public static string ValidaMatricula(string matricula, string siape)
        {
            matricula = matricula.Contains('|') ? matricula.Split('|')[0] : matricula;
            if (matricula.Length > 7)
            {
                matricula = matricula.TrimStart('0');
                if (matricula.Length > 7)
                {
                    matricula = string.Format("{0}", matricula.ToString().Substring(0, 7));
                }
            }

            decimal novaMatricula;
            decimal.TryParse(matricula, out novaMatricula);
            const string completa = "00000000";
            string matriculaSiape = string.Concat(siape.Trim(), completa.Substring(0, 7 - novaMatricula.ToString().Length), novaMatricula.ToString());
            long numeroAcumulado = 0;
            int[] numero = new int[12];
            int[] fator = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i <= (matriculaSiape.Length - 1); i++)
            {
                int.TryParse(matriculaSiape[i].ToString(), out numero[i]);
                numero[i] = fator[i] * numero[i];
                numeroAcumulado = numeroAcumulado + numero[i];
            }

            long digito = 0;
            switch (numeroAcumulado % 11)
            {
                case 0:
                    digito = 1;
                    break;
                case 1:
                    digito = 0;
                    break;
                default:
                    digito = 11 - (numeroAcumulado % 11);
                    break;
            }

            return string.Concat(novaMatricula.ToString(), digito.ToString());
        }

        private static int ValidaMatriculaMultiplicaValor(string[] valorArray)
        {
            var valorValidar = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var intSoma = 0;
            var intIdx = 0;

            for (int intPos = valorArray.Length; intPos > 0; intPos--)
            {
                intSoma += Convert.ToInt32(valorArray[intIdx].ToString()) * valorValidar[intIdx];
                intIdx++;
            }

            return intSoma;
        }
        public class Matricula
        {
            public int Nr_Matricula { get; set; }
        }

        [Serializable]
        public class GrupoProduto
        {
            public string NM_AGRUPADOR { get; set; }
        }

        [Serializable]
        public class RetornoStatusXmlViper
        {
            public string StatusOK { get; set; }
            public string StatusERRO { get; set; }
            public string CPF { get; set; }
            public string StatusMSG { get; set; }
            public string Tempo { get; set; }
            public string DataConsulta { get; set; }
            public string SaldoRestanteCliente { get; set; }
            public string ID { get; set; }
            public string Tempo1 { get; set; }
            public List<RetornoXmlViperBeneficio> ListaDadosBeneficios { get; set; }
        }

        [Serializable]
        public class RetornoParamRecibo
        {
            public int ID_ParamRecibo { get; set; }
            public int ID_ReciboGrupo { get; set; }
            public string TP_Comissao { get; set; }
        }

        [Serializable]
        public class RetornoXmlViperBeneficio
        {
            public string Beneficio { get; set; }
            public string BeneficioMascarado { get; set; }
            public string Nome { get; set; }
            public string DataNascimento { get; set; }
            public string Mae { get; set; }
            public string DataInicioBeneficio { get; set; }
            public string Especie { get; set; }
            public string NIT { get; set; }
            public string Municipio { get; set; }
            public string UF { get; set; }
        }




        public static RetornoStatusXmlViper RetornaDadosXmlViper(string xmlDadosViper)
        {
            var retornoStatusXmlViper = new RetornoStatusXmlViper();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlDadosViper);

            XmlNodeList xnListConsulta = xmlDoc.GetElementsByTagName("CONSULTA");

            for (int i = 0; i < xnListConsulta.Count; i++)
            {
                foreach (XmlNode item in xnListConsulta[i])
                {
                    if (item.Name == "OK")
                        retornoStatusXmlViper.StatusOK = item.InnerText;
                    if (item.Name == "ERRO")
                        retornoStatusXmlViper.StatusERRO = item.InnerText;
                    if (item.Name == "MSG")
                        retornoStatusXmlViper.StatusMSG = item.InnerText;
                    if (item.Name == "TEMPO" && string.IsNullOrEmpty(retornoStatusXmlViper.Tempo))
                        retornoStatusXmlViper.Tempo = item.InnerText;
                    if (item.Name == "DATA_CONSULTA")
                        retornoStatusXmlViper.DataConsulta = item.InnerText;
                    if (item.Name == "SALDO_RESTANTE_CLIENTE")
                        retornoStatusXmlViper.SaldoRestanteCliente = item.InnerText;
                    if (item.Name == "TEMPO")
                        retornoStatusXmlViper.Tempo1 = item.InnerText;
                }
            }

            XmlNodeList xnListConsultaCPF = xmlDoc.GetElementsByTagName("RESULTADO");
            retornoStatusXmlViper.ListaDadosBeneficios = new List<RetornoXmlViperBeneficio>();

            if (xnListConsultaCPF.Count > 0)
            {
                for (int i = 0; i < xnListConsultaCPF.Count; i++)
                {
                    var retornoXmlViperBeneficio = new RetornoXmlViperBeneficio();
                    foreach (XmlNode item in xnListConsultaCPF[i])
                    {
                        if (item.Name == "BENEFICIO")
                        {
                            retornoXmlViperBeneficio.Beneficio = item.InnerText;
                            var pad = '*';
                            if (!string.IsNullOrEmpty(retornoXmlViperBeneficio.Beneficio))
                            {
                                retornoXmlViperBeneficio.BeneficioMascarado = retornoXmlViperBeneficio.Beneficio.Substring(retornoXmlViperBeneficio.Beneficio.Length - 6, 6).PadLeft(10, pad);
                            }
                        }

                        if (item.Name == "NOME")
                            retornoXmlViperBeneficio.Nome = item.InnerText;
                        if (item.Name == "DATA_NASCIMENTO")
                            retornoXmlViperBeneficio.DataNascimento = item.InnerText;
                        if (item.Name == "MAE")
                            retornoXmlViperBeneficio.Mae = item.InnerText;
                        if (item.Name == "DATA_INICIO_BENEFICIO")
                            retornoXmlViperBeneficio.DataInicioBeneficio = item.InnerText;
                        if (item.Name == "ESPECIE")
                            retornoXmlViperBeneficio.Especie = item.InnerText;
                        if (item.Name == "NIT")
                            retornoXmlViperBeneficio.NIT = item.InnerText;
                        if (item.Name == "MUNICIPIO")
                            retornoXmlViperBeneficio.Municipio = item.InnerText;
                        if (item.Name == "UF")
                            retornoXmlViperBeneficio.UF = item.InnerText;
                    }
                    if (i != 0)
                    {
                        retornoStatusXmlViper.ListaDadosBeneficios.Add(retornoXmlViperBeneficio);
                    }
                }
            }

            if (retornoStatusXmlViper.ListaDadosBeneficios.Count == 0)
            {
                XmlNodeList xnListConsultaSemDados = xmlDoc.GetElementsByTagName("RESULTADO");
                foreach (XmlNode item in xnListConsultaSemDados[0])
                {
                    if (item.Name == "OK")
                        retornoStatusXmlViper.StatusOK = item.InnerText;
                    if (item.Name == "ERRO")
                        retornoStatusXmlViper.StatusERRO = item.InnerText;
                    if (item.Name == "MSG")
                        retornoStatusXmlViper.StatusMSG = item.InnerText;
                    if (item.Name == "TEMPO" && string.IsNullOrEmpty(retornoStatusXmlViper.Tempo))
                        retornoStatusXmlViper.Tempo = item.InnerText;
                    if (item.Name == "DATA_CONSULTA")
                        retornoStatusXmlViper.DataConsulta = item.InnerText;
                    if (item.Name == "SALDO_RESTANTE_CLIENTE")
                        retornoStatusXmlViper.SaldoRestanteCliente = item.InnerText;
                    if (item.Name == "TEMPO")
                        retornoStatusXmlViper.Tempo1 = item.InnerText;
                }
            }
            return retornoStatusXmlViper;
        }
        public static bool ValidaDecimal(string vlr)
        {
            var response = true;

            try
            {
                var valor = Decimal.Parse(vlr);
            }
            catch
            {
                response = false;
            }
            return response;
        }
        public static bool ValidaNumerico(string vlr)
        {
            var response = true;

            try
            {
                var valor = long.Parse(vlr);
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }

        public static bool ValidarMatriculaAssociacao(string codMatricula)
        {
            int valorVErificador = 11;
            int[] multiplicadorBase = { 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int valorTotalCalculado = 0;
            string digito = codMatricula.PadLeft(10, '0').Substring(9, 1);
            string codMatriculaSemDigito = codMatricula.PadLeft(10, '0').Substring(0, 9);
            for (int i = 0; i < 9; i++)
            {
                valorTotalCalculado += Convert.ToInt32(codMatriculaSemDigito.Substring(i, 1)) * multiplicadorBase[i];
            }
            int resto = valorTotalCalculado % valorVErificador;
            int digitoCalculado = valorVErificador - resto;
            if (digitoCalculado > 9)
            {
                digitoCalculado = 0;
            }
            bool digitoValido = digitoCalculado == Convert.ToInt32(digito);
            return digitoValido;
        }
        public static string RetornaValoresCombox(RadComboBox combobox)
        {
            var valor = string.Empty;
            var index = 1;

            if (combobox.CheckedItems.Count > 0)
            {
                foreach (var item in combobox.CheckedItems)
                {
                    if (index == 1 && combobox.CheckedItems.Count > index)
                        valor += item.Value + ",";
                    else if (combobox.CheckedItems.Count > index)
                        valor += item.Value + ",";

                    if (combobox.CheckedItems.Count == index)
                        valor += item.Value;

                    if (item.Value == "0")
                    {
                        valor = "0";
                        break;
                    }

                    index++;
                }
            }
            else
            {
                valor = "0";
            }

            return valor;
        }
        public static string RetornaValoresSemValidarValorZeroCombox(RadComboBox combobox)
        {
            var valor = string.Empty;
            var index = 1;

            if (combobox.CheckedItems.Count > 0)
            {
                foreach (var item in combobox.CheckedItems)
                {
                    if (index == 1 && combobox.CheckedItems.Count > index)
                        valor += item.Value + ",";
                    else if (combobox.CheckedItems.Count > index)
                        valor += item.Value + ",";

                    if (combobox.CheckedItems.Count == index)
                        valor += item.Value;

                    index++;
                }
            }
            else
            {
                valor = " ";
            }

            return valor;
        }

        public static void CheckAllValoresCombox(RadComboBox combobox)
        {
            foreach (RadComboBoxItem item in combobox.Items)
            {
                item.Checked = true;
            }            
        }

        public static string RetornaValoresComboxPadrao(RadComboBox combobox)
        {
            var valor = string.Empty;
            var index = 1;

            if (combobox.Items.Count > 0)
            {
                foreach (RadComboBoxItem item in combobox.Items)
                {
                    if (item.Value.ToString() == "0")
                    {
                        index++;
                        continue;
                    }

                    if (index == 1 && combobox.Items.Count > index)
                        valor += item.Value.ToString() + ",";
                    else if (combobox.Items.Count > index)
                        valor += item.Value.ToString() + ",";

                    if (combobox.Items.Count == index)
                        valor += item.Value.ToString();
                  
                    index++;
                }
            }
            else
            {
                valor = "0";
            }

            return valor;
        }

        internal static object RetornaValoresListas(IEnumerable<int> lista)
        {
            var valor = string.Empty;
            var index = 1;

            if (lista.Count() > 0)
            {
                foreach(var item in lista)
                {
                    if (index == 1 && lista.Count() > index)
                        valor += item.ToString() + ",";
                    else if (lista.Count() > index)
                        valor += item.ToString() + ",";

                    if (lista.Count() == index)
                        valor += item.ToString();

                    index++;
                }
            }

            return valor;
        }

        public static bool ValidaNumeroNoTexto(string Valor)
        {            
            bool validado = Valor.Any(c => char.IsDigit(c));

            return validado;
        }

        public static bool ValidacaracteresEspeciais(string Valor)
        {
            var pattern = @"(?i)[^0-9a-z.\s]";
            var validado = Regex.IsMatch(Valor, pattern, RegexOptions.IgnoreCase);

            return validado;
        }
        public static bool ValidacaracteresEspeciaisNome(string Valor)
        {
            var pattern = @"(?i)[^0-9a-z\s]";
            var validado = Regex.IsMatch(Valor, pattern, RegexOptions.IgnoreCase);

            return validado;
        }

        public static bool ValidacaracteresEspeciaisEmail(string Valor)
        {
            var pattern = @"(?i)[^0-9a-z@._\s]";
            var validado = Regex.IsMatch(Valor, pattern, RegexOptions.IgnoreCase);

            return validado;
        }
        public static string RemoveCaracteres(this string text)
        {
            string resultString = string.Empty;
            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(text, "");
            return resultString;
        }

        public static string RemoveCaracteresSolicitados(this string text)
        {
            var caracteres = "-;(;);?";
            var retorno = text.Replace("'", " ").Replace(";", " ").Replace("\"", " ").Replace("*", " ").Replace("\\", " ").Replace("/", " ");

            foreach (var caracter in caracteres.Split(';'))
            {
                retorno = retorno.Replace(caracter, " ");
            }

            return retorno;

        }
        public static string RemoveCaracteresSolicitados_(string text)
        {
            Regex rgx = new Regex(@"[0-9aA-zZ\s]");
            var caracteres = "-;(;);?";
            var retorno = text;
            var str = string.Empty;

            foreach (var caracter in retorno.ToCharArray())
            {
                str += rgx.IsMatch(caracter.ToString()) ?
                    caracter.ToString() :
                    PossuiCaractereNaoPreterido(caracter.ToString()) ? (PossuiAcentos(caracter.ToString()) ? caracter.ToString() : " ")
                    : caracter.ToString();
            }

            if (!str.Equals(string.Empty))
                retorno = str;

            return retorno;

        }
        public static bool PossuiCaractereNaoPreterido(string text)
        {
            var resp = false;
            Regex rgx = new Regex(@"[0-9aA-zZ\s]");

            resp = !rgx.IsMatch(text.ToString());

            return resp;

        }
        public static bool PossuiAcentos(string letter)
        {
            var resp = false;

            if (!letter.Equals(string.Empty))
            {
                var text = letter.Normalize(NormalizationForm.FormD).ToCharArray();

                resp = (CharUnicodeInfo.GetUnicodeCategory(text[0]) != UnicodeCategory.NonSpacingMark);
            }

            return resp;

        }
        public static string RemoveAccentos(this string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            if (text != null)
            {
                var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
                foreach (char letter in arrayText)
                {
                    if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                        sbReturn.Append(letter);
                }
            }
            else
            {
                sbReturn.Append("");
            }

            return sbReturn.ToString();
        }

        public static DateTime RetornaDataRestringirRelatorioPerfil(string restringirRelatorio)
        {
            var data = DateTime.Now;
            var quantidade = 0;
            if (restringirRelatorio.ToLower().Contains("dia"))
            {
                quantidade = int.Parse(restringirRelatorio.Trim().ToLower().Replace("dia", ""));
                data = data.AddDays(-quantidade);
            }
            else if (restringirRelatorio.ToLower().Contains("mês"))
            {
                quantidade = int.Parse(restringirRelatorio.Trim().ToLower().Replace("mês", ""));
                data = data.AddMonths(-quantidade);
            }
            else if (restringirRelatorio.ToLower().Contains("ano"))
            {
                quantidade = int.Parse(restringirRelatorio.Trim().ToLower().Replace("ano", ""));
                data = data.AddYears(-quantidade);
            }
            return data;
        }

        public static int RetornDiferenciaDias(DateTime dataInicial, DateTime dataFinal)
        {
            var quantidadeDias = 0;

            quantidadeDias = (int) dataFinal.AddDays(1).Subtract(dataInicial).TotalDays;

            return quantidadeDias;
        }
        public static Binary GerarQRCode(long numero)
        {
            Binary numeroQRCode = null;

            var qrCode = new RadBarcode();
            qrCode.Type = BarcodeType.QRCode;
            qrCode.OutputType = BarcodeOutputType.EmbeddedPNG;
            qrCode.QRCodeSettings.Mode = Telerik.Web.UI.Barcode.Modes.CodeMode.Byte;
            qrCode.QRCodeSettings.ErrorCorrectionLevel = Telerik.Web.UI.Barcode.Modes.ErrorCorrectionLevel.L;
            qrCode.QRCodeSettings.DotSize = 3;
            qrCode.QRCodeSettings.Version = 2;
            qrCode.QRCodeSettings.ECI = Telerik.Web.UI.Barcode.Modes.ECIMode.None;
            qrCode.Text = string.Format("{0:0000000000}", numero);

            using (MemoryStream ms = new MemoryStream())
            {
                qrCode.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                numeroQRCode = new System.Data.Linq.Binary(ms.GetBuffer());
            }
            return numeroQRCode;
        }

        public static int CalcularIdade(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day)) age--;
            return age;
        }

        public class DocPendente
        {
            string nomeDocumento;
            int codigoTipoDocumento;
            string codigoSabemi;

            
            public int CodigoTipoDocumento
            {
                get { return codigoTipoDocumento; }
                set { codigoTipoDocumento = value; }
            }
            
            public string CodigoSabemi
            {
                get { return codigoSabemi; }
                set { codigoSabemi = value; }
            }
            
            public string NomeDocumento
            {
                get { return nomeDocumento; }
                set { nomeDocumento = value; }
            }
        }

        public class ProposstaAneliseExterna
        {
            public int ID_Proposta { get; set; }
            public string NM_Motivo { get; set; }
            public DateTime DT_Solicitacao { get; set; }
            public bool FL_Enviado { get; set; }
        }

        public static int DigitoM10(long intNumero)
        {
            int[] intPesos = { 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            string strText = intNumero.ToString();

            if (strText.Length > 16)
                throw new Exception("Número não suportado pela função!");

            int intSoma = 0;
            int intIdx = 0;
            for (int intPos = strText.Length - 1; intPos >= 0; intPos--)
            {
                intSoma += Convert.ToInt32(strText[intPos].ToString()) * intPesos[intIdx];
                intIdx++;
            }

            intSoma = intSoma % 10;
            intSoma = 10 - intSoma;
            if (intSoma == 10)
            {
                intSoma = 0;
            }

            return intSoma;
        }
    }
}