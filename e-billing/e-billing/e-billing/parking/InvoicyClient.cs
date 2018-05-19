using System;
using System.Xml;
using System.Net;
using System.IO;

namespace e_billing.parking
{
    class InvoicyClient
    {
        public void SendCFE()
        {
            var _url = "https://testing.invoicy.com.uy/InvoiCy/aws_emissionfactura.aspx";
            var _action = "Gxaction/AWS_EMISSIONFACTURA.Execute";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                Console.Write(soapResult);
            }
        }

        private  HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private  XmlDocument CreateSoapEnvelope()
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(CreateXml());

            return soapEnvelopeDocument;
        }
        public string CreateXml() {
            
            string CFE = "<CFE><CFEItem><IdDoc><CFETipoCFE>111</CFETipoCFE><CFESerie>A</CFESerie><CFENro>1234567</CFENro><CFEFchEmis>2018-06-05</CFEFchEmis></IdDoc><Emisor><EmiRznSoc>Cardely</EmiRznSoc><EmiDomFiscal>rivera 2323</EmiDomFiscal><EmiCiudad>Montevideo</EmiCiudad><EmiDepartamento>Montevideo</EmiDepartamento></Emisor><Receptor><RcpTipoDocRecep>2</RcpTipoDocRecep><RcpCodPaisRecep>UY</RcpCodPaisRecep><RcpDocRecep>A</RcpDocRecep><RcpRznSocRecep>A</RcpRznSocRecep><RcpDirRecep>A</RcpDirRecep><RcpCiudadRecep>A</RcpCiudadRecep><RcpDeptoRecep>A</RcpDeptoRecep></Receptor><Totales><TotTpoMoneda>UYU</TotTpoMoneda></Totales><Mandante><MndTipDoc>2</MndTipDoc><MndCodPais>UY</MndCodPais><MndNroDocumento>214378950013</MndNroDocumento><MndRazSocial>Cardely S.R.L.</MndRazSocial><MndEncriptar>S</MndEncriptar></Mandante></CFEItem></CFE>";
            string escapeCFE = CFE.Replace("<", "&lt;").Replace(">", "&gt;");
            string soapEnv = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:gx=""Gx"">
                <soapenv:Header/>
                <soapenv:Body>
                    <gx:WS_EmissionFactura.Execute>
                        <gx:Xmlrecepcao>"+CFE+"</gx:Xmlrecepcao>" +
                   "</gx:WS_EmissionFactura.Execute>" +
               "</soapenv:Body>" +
           "</soapenv:Envelope>";

            return soapEnv;
        }

        private  void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}




    