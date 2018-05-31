using System;
using System.Xml;
using System.Net;
using System.IO;
using System.Configuration;

namespace e_billing.parking
{
    class InvoicyClient
    {
        /*public void SendCFE()
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
        }*/
        public void CreateXml(string changeS, double impNoIva, double impIva,int CFEnro,MovimientosCaja movCaja, MovimientoParking movParking) {

            /*string CFE = "<CFE><CFEItem><IdDoc><CFETipoCFE>111</CFETipoCFE><CFESerie>A</CFESerie><CFENro>1234567</CFENro><CFEFchEmis>2018-06-05</CFEFchEmis></IdDoc><Emisor><EmiRznSoc>Cardely</EmiRznSoc><EmiDomFiscal>rivera 2323</EmiDomFiscal><EmiCiudad>Montevideo</EmiCiudad><EmiDepartamento>Montevideo</EmiDepartamento></Emisor><Receptor><RcpTipoDocRecep>2</RcpTipoDocRecep><RcpCodPaisRecep>UY</RcpCodPaisRecep><RcpDocRecep>A</RcpDocRecep><RcpRznSocRecep>A</RcpRznSocRecep><RcpDirRecep>A</RcpDirRecep><RcpCiudadRecep>A</RcpCiudadRecep><RcpDeptoRecep>A</RcpDeptoRecep></Receptor><Totales><TotTpoMoneda>UYU</TotTpoMoneda></Totales><Mandante><MndTipDoc>2</MndTipDoc><MndCodPais>UY</MndCodPais><MndNroDocumento>214378950013</MndNroDocumento><MndRazSocial>Cardely S.R.L.</MndRazSocial><MndEncriptar>S</MndEncriptar></Mandante></CFEItem></CFE>";
            string escapeCFE = CFE.Replace("<", "&lt;").Replace(">", "&gt;");
            string soapEnv = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:gx=""Gx"">
                <soapenv:Header/>
                <soapenv:Body>
                    <gx:WS_EmissionFactura.Execute>
                        <gx:Xmlrecepcao>"+CFE+"</gx:Xmlrecepcao>" +
                   "</gx:WS_EmissionFactura.Execute>" +
               "</soapenv:Body>" +
           "</soapenv:Envelope>";

            return soapEnv;*/

            string CFE = @"<EnvioCFE>
	<Encabezado>
		<EmpCodigo>116</EmpCodigo>
		<EmpPK>APpxzyJiLCq0sFjOY3Wh6w==</EmpPK>
		<EmpCA>5OErsCCY4Ez/gBozYN5rdJShQhUDy</EmpCA>
	</Encabezado>
	<CFE>
		<CFEItem> 
			<IdDoc>
				<CFETipoCFE>101</CFETipoCFE>
				<CFESerie>A</CFESerie>
				<CFENro>"+ CFEnro + @"</CFENro>
				<CFEImpresora>citizen</CFEImpresora>
				<CFEImp>S</CFEImp>
				<CFEImpCantidad>2</CFEImpCantidad>
				<CFEFchEmis>2018-05-30</CFEFchEmis>
				<CFEMntBruto></CFEMntBruto>
				<CFEFmaPago>1</CFEFmaPago>
				<CFEAdenda>Prueba</CFEAdenda>
				<CFEAdendaImagen></CFEAdendaImagen>
				<CFEEfectivo>" + impNoIva + @"</CFEEfectivo>
				<CFEPesoTotal>"+ impNoIva + @"</CFEPesoTotal>
				<CFECambio>"+ changeS + @"</CFECambio>
				<CFEAcimaUI>N</CFEAcimaUI>
				<CFENumReferencia>00001</CFENumReferencia>
				<CFEImpFormato>1</CFEImpFormato>
				<CFEIdCompra>00001</CFEIdCompra>
				<CFEIdCompraApodo></CFEIdCompraApodo>
				<CFEExpClaVenta></CFEExpClaVenta>
				<CFEExpModVenta>1</CFEExpModVenta>
				<CFEExpViaTransporte>9</CFEExpViaTransporte>
				<CFETpoOperacion>2</CFETpoOperacion>
				<CFEQrCode>1</CFEQrCode>
				<CFEDatosAvanzados>1</CFEDatosAvanzados>
				<CFERepImpresa>1</CFERepImpresa>
				<CFEInfAdicional></CFEInfAdicional>
				<CFESecretoProfesional>N</CFESecretoProfesional>
			</IdDoc>
			<Emisor>
				<EmiRznSoc>Cardely S.R.L.</EmiRznSoc>
				<EmiComercial>Parking Eugenio</EmiComercial>
				<EmiGiroEmis>Parking</EmiGiroEmis>
				<EmiTelefono></EmiTelefono>
				<EmiTelefono2></EmiTelefono2>
				<EmiCorreoEmisor></EmiCorreoEmisor>
				<EmiSucursal>Eugenio</EmiSucursal>
				<EmiDomFiscal>Rivera 2323</EmiDomFiscal>
				<EmiCiudad>Montevideo</EmiCiudad>
				<EmiDepartamento>Montevideo</EmiDepartamento>
				<EmiInfAdicional></EmiInfAdicional>
			</Emisor>
			<Receptor>
				<RcpTipoDocRecep></RcpTipoDocRecep>
				<RcpTipoDocDscRecep></RcpTipoDocDscRecep>
				<RcpCodPaisRecep></RcpCodPaisRecep>
				<RcpDocRecep></RcpDocRecep>
				<RcpRznSocRecep></RcpRznSocRecep>
				<RcpDirRecep></RcpDirRecep>
				<RcpCiudadRecep></RcpCiudadRecep>
				<RcpDeptoRecep></RcpDeptoRecep>
				<RcpCP></RcpCP>
				<RcpCorreoRecep></RcpCorreoRecep>
				<RcpInfAdiRecep></RcpInfAdiRecep>
				<RcpDirPaisRecep></RcpDirPaisRecep>
				<RcpDstEntregaRecep></RcpDstEntregaRecep>
				<RcpEmlArchivos></RcpEmlArchivos>
			</Receptor>
			<Mandante>
				<MndTipDoc></MndTipDoc>
				<MndTipDocDsc></MndTipDocDsc>
				<MndCodPais></MndCodPais>
				<MndNroDocumento></MndNroDocumento>
				<MndRazSocial></MndRazSocial>
				<MndEncriptar></MndEncriptar>
			</Mandante>
			<PropietarioMercaderia>
				<PrmTipDocumento></PrmTipDocumento>
				<PrmNroDocumento></PrmNroDocumento>
				<PrmTipDocDsc></PrmTipDocDsc>
				<PrmRznSocial></PrmRznSocial>
				<PrmCodPais></PrmCodPais>
			</PropietarioMercaderia>
			<Totales>
				<TotTpoMoneda>UYU</TotTpoMoneda>
				<TotTpoCambio>UYU</TotTpoCambio>
				<TotMntNoGrv>0</TotMntNoGrv>
				<TotMntExpoyAsim></TotMntExpoyAsim>
				<TotMntImpuestoPerc></TotMntImpuestoPerc>
				<TotMntIVaenSusp></TotMntIVaenSusp>
				<TotMntNetoIvaTasaMin></TotMntNetoIvaTasaMin>
				<TotMntNetoIVATasaBasica>"+impNoIva+@"</TotMntNetoIVATasaBasica>
				<TotMntNetoIVAOtra></TotMntNetoIVAOtra>
				<TotIVATasaMin></TotIVATasaMin>
				<TotIVATasaBasica>22</TotIVATasaBasica>
				<TotMntIVATasaMin></TotMntIVATasaMin>
				<TotMntIVATasaBasica>"+ impIva + @"</TotMntIVATasaBasica>
				<TotMntIVAOtra></TotMntIVAOtra>
				<TotMntTotal>"+movCaja.importe+ @"</TotMntTotal>
				<TotMntTotRetenido></TotMntTotRetenido>
				<TotMntCreditoFiscal></TotMntCreditoFiscal>
				<RetencPercepTot>
					<RetencPercepTotItem>
						<RetPercCodRet></RetPercCodRet>
						<RetPercValRetPerc></RetPercValRetPerc>
						<RetPercValCreditoFiscal></RetPercValCreditoFiscal>
					</RetencPercepTotItem>
				</RetencPercepTot>
				<TotMontoNF></TotMontoNF>
				<TotMntPagar>" + movCaja.importe + @"</TotMntPagar>
			</Totales>
			<CodBarras>
				<CodBarRedPagos>
					<CodBarRedPagCodEmpresa></CodBarRedPagCodEmpresa>
					<CodBarRedPagNroCliente></CodBarRedPagNroCliente>
					<CodBarRedPagFchVencimiento></CodBarRedPagFchVencimiento>
					<CodBarRedPagMoneda></CodBarRedPagMoneda>
					<CodBarRedPagImpMinimo></CodBarRedPagImpMinimo>
					<CodBarRedPagImpTotal></CodBarRedPagImpTotal>
				</CodBarRedPagos>
				<CodBarAbitab>
					<CodBarAbtCodEmpresa></CodBarAbtCodEmpresa>
					<CodBarAbtNroCliente></CodBarAbtNroCliente>
					<CodBarAbtFchVencimiento></CodBarAbtFchVencimiento>
					<CodBarAbtMoneda></CodBarAbtMoneda>
					<CodBarAbtImporte></CodBarAbtImporte>
					<CodBarAbtCuota></CodBarAbtCuota>
					<CodBarAbtMora></CodBarAbtMora>
					<CodBarAbtCuenta></CodBarAbtCuenta>
				</CodBarAbitab>
			</CodBarras>
			<Detalle>
				<Item>
					<CodItem>
						<CodItemItem>
							<IteCodiTpoCod>INT1</IteCodiTpoCod>
							<IteCodiCod>1</IteCodiCod>
						</CodItemItem>
					</CodItem>
					<IteIndFact>3</IteIndFact>
					<IteIndAgenteResp></IteIndAgenteResp>
					<IteNomItem>horas estascionamiento</IteNomItem>
					<IteDscItem>horas estascionamiento</IteDscItem>
					<IteCantidad>1</IteCantidad>
					<IteUniMed></IteUniMed>
					<ItePrecioUnitario>"+impNoIva+@"</ItePrecioUnitario>
					<IteDescuentoPct></IteDescuentoPct>
					<IteDescuentoMonto></IteDescuentoMonto>
					<SubDescuento>
						<SubDescuentoItem>
							<SubDescDescTipo>1</SubDescDescTipo>
							<SubDescDescVal>0</SubDescDescVal>
						</SubDescuentoItem>
					</SubDescuento>
					<IteRecargoPct></IteRecargoPct>
					<IteRecargoMnt></IteRecargoMnt>
					<SubRecargo>
						<SubRecargoItem>
							<SubRecaRecargoTipo>1</SubRecaRecargoTipo>
							<SubRecaRecargoVal>0</SubRecaRecargoVal>
						</SubRecargoItem>
					</SubRecargo>
					<RetencPercep>
						<RetencPercepItem>
							<IteRetPercCodRet></IteRetPercCodRet>
							<IteRetPercDscRet></IteRetPercDscRet>
							<IteRetPercTasa></IteRetPercTasa>
							<IteRetPercMntSujetoaRet></IteRetPercMntSujetoaRet>
							<IteRetPercValRetPerc></IteRetPercValRetPerc>
							<IteRetPerc></IteRetPerc>
						</RetencPercepItem>
					</RetencPercep>
					<IteMontoItem>"+impNoIva+ @"</IteMontoItem>
				</Item>
			</Detalle>
			<SubTotInfo>
				<STIItem>
					<SubTotNroSTI>1</SubTotNroSTI>
					<SubTotGlosaSTI>Subtotal</SubTotGlosaSTI>
					<SubTotOrdenSTI></SubTotOrdenSTI>
					<SubTotValSubtotSTI>" + impNoIva + @"</SubTotValSubtotSTI>
				</STIItem>
			</SubTotInfo>
			<MediosPago>
				<MediosPagoItem>
					<MedPagNroLinMP>1</MedPagNroLinMP>
					<MedPagCodMP></MedPagCodMP>
					<MedPagGlosaMP>efectivo</MedPagGlosaMP>
					<MedPagOrdenMP></MedPagOrdenMP>
					<MedPagValorPago>375</MedPagValorPago>
				</MediosPagoItem>
			</MediosPago>
			<Referencia>
				<ReferenciaItem>
					<RefNroLinRef>1</RefNroLinRef>
					<RefIndGlobal></RefIndGlobal>
					<RefTpoDocRef></RefTpoDocRef>
					<RefSerie></RefSerie>
					<RefNroCFERef></RefNroCFERef>
					<RefRazonRef></RefRazonRef>
					<RefFechaCFEref></RefFechaCFEref>
				</ReferenciaItem>
			</Referencia>
		</CFEItem>
	</CFE>
</EnvioCFE>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(CFE);
            // Save the document to a file and auto-indent the output.
            using (XmlTextWriter writer = new XmlTextWriter(ConfigurationManager.AppSettings["SOAP_XML"].ToString(), null))
            {
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
            }
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




    