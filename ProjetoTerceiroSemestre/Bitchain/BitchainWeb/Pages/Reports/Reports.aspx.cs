using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using BitchainWeb.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Text;
using Telerik.Web.UI;
using Telerik.Windows.Zip;

namespace BitchainWeb.Pages.Reports
{
    public partial class Reports : System.Web.UI.Page
    {
        private ReportClass cr;
        private string queryEncrypt;
        private string query;
        private string[] filtros;
        private string rpt;
        private string tipo;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new BaseDataContext())
                {
                    db.CommandTimeout = 600;
                    queryEncrypt = Request.QueryString["q"] ?? string.Empty;
                    query = string.Empty;
                    filtros = new string[0];
                    rpt = string.Empty;
                    tipo = string.Empty;

                    if (queryEncrypt != string.Empty)
                    {
                        var dadoEncriptado = CryptoServiceHelper.UrlHelper.UrlTokenDecode(queryEncrypt);
                        query = CryptoServiceHelper.RijndaelHelper.Default.Decrypt(dadoEncriptado);
                        dadoEncriptado = null;
                        filtros = query.Split('&');
                        rpt = RecuperaValor(filtros, "RPT");
                        tipo = RecuperaValor(filtros, "Tipo");
                    }
                    else
                    {
                        rpt = Request.QueryString["RPT"].ToString();
                        tipo = Request.QueryString["Tipo"].ToString();
                    }

                    if (rpt == "ListaDeBancos" && tipo == "Excel")
                    {
                        using (cr = new ListaDeBancos())
                        {
                            Funcoes.ConfiguraReport(cr);
                            cr.ExportToHttpResponse(tipo == "PDF" ? ExportFormatType.PortableDocFormat : ExportFormatType.Excel, Response, tipo == "Excel", rpt);
                        }
                    }
                    else if (rpt == "ListaDeContas" && tipo == "Excel")
                    {
                        using (cr = new ListaDeContas())
                        {
                            Funcoes.ConfiguraReport(cr);
                            cr.ExportToHttpResponse(tipo == "PDF" ? ExportFormatType.PortableDocFormat : ExportFormatType.Excel, Response, tipo == "Excel", rpt);
                        }
                    }
                    else if (rpt == "ListaDeMoedas" && tipo == "Excel")
                    {
                        using (cr = new ListaDeMoedas())
                        {
                            Funcoes.ConfiguraReport(cr);
                            cr.ExportToHttpResponse(tipo == "PDF" ? ExportFormatType.PortableDocFormat : ExportFormatType.Excel, Response, tipo == "Excel", rpt);
                        }
                    }
                    else if (rpt == "ListaDeTransacoes" && tipo == "Excel")
                    {
                        using (cr = new ListaDeTransacoes())
                        {
                            Funcoes.ConfiguraReport(cr);
                            cr.ExportToHttpResponse(tipo == "PDF" ? ExportFormatType.PortableDocFormat : ExportFormatType.Excel, Response, tipo == "Excel", rpt);
                        }
                    }
                    else if (rpt == "ListaDeUsuarios" && tipo == "Excel")
                    {
                        using (cr = new ListaDeUsuarios())
                        {
                            Funcoes.ConfiguraReport(cr);
                            cr.ExportToHttpResponse(tipo == "PDF" ? ExportFormatType.PortableDocFormat : ExportFormatType.Excel, Response, tipo == "Excel", rpt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //String exDetail = String.Format("Exception message: {0}{1}Exception Source: {2}{1}Exception StackTrace: {3}{1}", ex.Message, Environment.NewLine, ex.Source, ex.StackTrace);

            }
        }

        private void Page_Unload(object sender, EventArgs e)
        {
            if (cr != null)
            {
                cr.Close();
                cr.Dispose();
                GC.Collect();
            }

            queryEncrypt = null;
            query = null;
            filtros = null;
            rpt = null;
            tipo = null;
        }

        private string RecuperaValor(string[] filtros, string filtro)
        {
            return filtros.Single(f => f.Split('=')[0] == filtro).Split('=')[1];
        }
    }
}