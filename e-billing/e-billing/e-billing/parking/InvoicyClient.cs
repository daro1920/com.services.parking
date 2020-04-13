using System;
using System.Xml;
using System.Net;
using System.IO;
using System.Configuration;

namespace e_billing.parking
{
    class InvoicyClient
    {
        
        public void CreateXml(string changeS, double impNoIva, double impIva,int CFEnro,int hours,string desc,
            string empCod, string empCA, string empPK, MovimientosCaja movCaja, MovimientoParking movParking) {

            
            string CFE = @"<EnvioCFE>
	            <Encabezado>
		            <EmpCodigo>" + empCod + @"</EmpCodigo>
		            <EmpPK>" + empPK + @"</EmpPK>
		            <EmpCA>" + empCA + @"</EmpCA>
	            </Encabezado>
	            <CFE>
		            <CFEItem> 
			            <IdDoc>
				            <CFETipoCFE>101</CFETipoCFE>
				            <CFESerie>A</CFESerie>
				            <CFENro>" + CFEnro + @"</CFENro>
				            <CFEImpresora>citizen</CFEImpresora>
				            <CFEImp>S</CFEImp>
				            <CFEImpCantidad>1</CFEImpCantidad>
				            <CFEFchEmis>" + DateTime.Now.ToString("yyyy-MM-dd") + @"</CFEFchEmis>
				            <CFEFmaPago>1</CFEFmaPago>
				            <CFEAdenda>"+ desc + @"</CFEAdenda>
				            <CFEEfectivo>" + impNoIva + @"</CFEEfectivo>
				            <CFEPesoTotal>"+ impNoIva + @"</CFEPesoTotal>
				            <CFECambio>"+ changeS + @"</CFECambio>
				            <CFEAcimaUI>N</CFEAcimaUI>
				            <CFENumReferencia>00001</CFENumReferencia>
				            <CFEImpFormato>1</CFEImpFormato>
				            <CFEIdCompra>00001</CFEIdCompra>
				            <CFEExpModVenta>1</CFEExpModVenta>
				            <CFEExpViaTransporte>9</CFEExpViaTransporte>
				            <CFETpoOperacion>2</CFETpoOperacion>
				            <CFEQrCode>1</CFEQrCode>
				            <CFEDatosAvanzados>1</CFEDatosAvanzados>
				            <CFERepImpresa>1</CFERepImpresa>
				            <CFESecretoProfesional>N</CFESecretoProfesional>
			            </IdDoc>
			            <Emisor>
				            <EmiRznSoc>Cardely S.R.L.</EmiRznSoc>
				            <EmiComercial>Parking Eugenio</EmiComercial>
				            <EmiGiroEmis>Parking</EmiGiroEmis>
				            <EmiSucursal>Eugenio</EmiSucursal>
				            <EmiDomFiscal>Rivera 2323</EmiDomFiscal>
				            <EmiCiudad>Montevideo</EmiCiudad>
				            <EmiDepartamento>Montevideo</EmiDepartamento>
			            </Emisor>
			            <Totales>
				            <TotTpoMoneda>UYU</TotTpoMoneda>
				            <TotTpoCambio>UYU</TotTpoCambio>
				            <TotMntNoGrv>0</TotMntNoGrv>
				            <TotMntNetoIVATasaBasica>"+impNoIva+@"</TotMntNetoIVATasaBasica>
				            <TotIVATasaBasica>22</TotIVATasaBasica>
				            <TotMntIVATasaBasica>"+ impIva + @"</TotMntIVATasaBasica>
				            <TotMntTotal>"+movCaja.importe+ @"</TotMntTotal>
				            <TotMntPagar>" + movCaja.importe + @"</TotMntPagar>
			            </Totales>
			            <Detalle>
				            <Item>
					            <CodItem>
						            <CodItemItem>
							            <IteCodiTpoCod>INT1</IteCodiTpoCod>
							            <IteCodiCod>1</IteCodiCod>
						            </CodItemItem>
					            </CodItem>
					            <IteIndFact>3</IteIndFact>
					            <IteNomItem>" + desc + @"</IteNomItem>
					            <IteDscItem>" + hours + @" Horas</IteDscItem>
					            <IteCantidad>1</IteCantidad>
					            <ItePrecioUnitario>" + impNoIva+@"</ItePrecioUnitario>
					            <SubDescuento>
						            <SubDescuentoItem>
							            <SubDescDescTipo>1</SubDescDescTipo>
							            <SubDescDescVal>0</SubDescDescVal>
						            </SubDescuentoItem>
					            </SubDescuento>
					            <SubRecargo>
						            <SubRecargoItem>
							            <SubRecaRecargoTipo>1</SubRecaRecargoTipo>
							            <SubRecaRecargoVal>0</SubRecaRecargoVal>
						            </SubRecargoItem>
					            </SubRecargo>
					            <IteMontoItem>"+impNoIva+ @"</IteMontoItem>
				            </Item>
			            </Detalle>
			            <SubTotInfo>
				            <STIItem>
					            <SubTotNroSTI>1</SubTotNroSTI>
					            <SubTotGlosaSTI>Subtotal</SubTotGlosaSTI>
					            <SubTotValSubtotSTI>" + impNoIva + @"</SubTotValSubtotSTI>
				            </STIItem>
			            </SubTotInfo>
			            <MediosPago>
				            <MediosPagoItem>
					            <MedPagNroLinMP>1</MedPagNroLinMP>
					            <MedPagGlosaMP>efectivo</MedPagGlosaMP>
					            <MedPagValorPago>375</MedPagValorPago>
				            </MediosPagoItem>
			            </MediosPago>
			            <Referencia>
				            <ReferenciaItem>
					            <RefNroLinRef>1</RefNroLinRef>
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

        public void CreateXmlRUT(string changeS, double impNoIva, double impIva, int CFEnro,string RUT,
            string raZoc ,int hours,string desc, string empCod, string empCA, string empPK, 
            MovimientosCaja movCaja, MovimientoParking movParking)
        {

            
            string CFE = @"<EnvioCFE>
	            <Encabezado>
		             <EmpCodigo>" + empCod + @"</EmpCodigo>
		            <EmpPK>" + empPK + @"</EmpPK>
		            <EmpCA>" + empCA + @"</EmpCA>
	            </Encabezado>
	            <CFE>
		            <CFEItem> 
			            <IdDoc>
				            <CFETipoCFE>111</CFETipoCFE>
				            <CFESerie>A</CFESerie>
				            <CFENro>" + CFEnro + @"</CFENro>
				            <CFEImpresora>citizen</CFEImpresora>
				            <CFEImp>S</CFEImp>
				            <CFEImpCantidad>1</CFEImpCantidad>
				            <CFEFchEmis>"+ DateTime.Now.ToString("yyyy-MM-dd")+ @"</CFEFchEmis>
				            <CFEFmaPago>1</CFEFmaPago>
				            <CFEAdenda>"+ desc + @"</CFEAdenda>
				            <CFEEfectivo>" + impNoIva + @"</CFEEfectivo>
				            <CFEPesoTotal>" + impNoIva + @"</CFEPesoTotal>
				            <CFECambio>" + changeS + @"</CFECambio>
				            <CFEAcimaUI>N</CFEAcimaUI>
				            <CFENumReferencia>00001</CFENumReferencia>
				            <CFEImpFormato>1</CFEImpFormato>
				            <CFEIdCompra>00001</CFEIdCompra>
				            <CFEExpModVenta>1</CFEExpModVenta>
				            <CFEExpViaTransporte>9</CFEExpViaTransporte>
				            <CFETpoOperacion>2</CFETpoOperacion>
				            <CFEQrCode>1</CFEQrCode>
				            <CFEDatosAvanzados>1</CFEDatosAvanzados>
				            <CFERepImpresa>1</CFERepImpresa>
				            <CFESecretoProfesional>N</CFESecretoProfesional>
			            </IdDoc>
			            <Emisor>
				            <EmiRznSoc>Cardely S.R.L.</EmiRznSoc>
				            <EmiComercial>Parking Eugenio</EmiComercial>
				            <EmiGiroEmis>Parking</EmiGiroEmis>
				            <EmiSucursal>Eugenio</EmiSucursal>
				            <EmiDomFiscal>Rivera 2323</EmiDomFiscal>
				            <EmiCiudad>Montevideo</EmiCiudad>
				            <EmiDepartamento>Montevideo</EmiDepartamento>
			            </Emisor>
			            <Receptor>
				            <RcpTipoDocRecep>2</RcpTipoDocRecep>
				            <RcpTipoDocDscRecep>" + RUT + @"</RcpTipoDocDscRecep>
				            <RcpCodPaisRecep>UY</RcpCodPaisRecep>
				            <RcpDocRecep>" + RUT + @"</RcpDocRecep>
				            <RcpRznSocRecep>"+ raZoc + @"</RcpRznSocRecep>
			            </Receptor>
			            <Totales>
				            <TotTpoMoneda>UYU</TotTpoMoneda>
				            <TotTpoCambio>UYU</TotTpoCambio>
				            <TotMntNoGrv>0</TotMntNoGrv>
				            <TotMntNetoIVATasaBasica>" + impNoIva + @"</TotMntNetoIVATasaBasica>
				            <TotIVATasaBasica>22</TotIVATasaBasica>
				            <TotMntIVATasaBasica>" + impIva + @"</TotMntIVATasaBasica>
				            <TotMntTotal>" + movCaja.importe + @"</TotMntTotal>
				            <TotMntPagar>" + movCaja.importe + @"</TotMntPagar>
			            </Totales>
			            <Detalle>
				            <Item>
					            <CodItem>
						            <CodItemItem>
							            <IteCodiTpoCod>INT1</IteCodiTpoCod>
							            <IteCodiCod>1</IteCodiCod>
						            </CodItemItem>
					            </CodItem>
					            <IteIndFact>3</IteIndFact>
					            <IteNomItem>"+ desc + @"</IteNomItem>
					            <IteDscItem>" + hours + @" Horas</IteDscItem>
					            <IteCantidad>1</IteCantidad>
					            <ItePrecioUnitario>" + impNoIva + @"</ItePrecioUnitario>
					            <SubDescuento>
						            <SubDescuentoItem>
							            <SubDescDescTipo>1</SubDescDescTipo>
							            <SubDescDescVal>0</SubDescDescVal>
						            </SubDescuentoItem>
					            </SubDescuento>
					            <SubRecargo>
						            <SubRecargoItem>
							            <SubRecaRecargoTipo>1</SubRecaRecargoTipo>
							            <SubRecaRecargoVal>0</SubRecaRecargoVal>
						            </SubRecargoItem>
					            </SubRecargo>
					            <IteMontoItem>" + impNoIva + @"</IteMontoItem>
				            </Item>
			            </Detalle>
			            <SubTotInfo>
				            <STIItem>
					            <SubTotNroSTI>1</SubTotNroSTI>
					            <SubTotGlosaSTI>Subtotal</SubTotGlosaSTI>
					            <SubTotValSubtotSTI>" + impNoIva + @"</SubTotValSubtotSTI>
				            </STIItem>
			            </SubTotInfo>
			            <MediosPago>
				            <MediosPagoItem>
					            <MedPagNroLinMP>1</MedPagNroLinMP>
					            <MedPagGlosaMP>efectivo</MedPagGlosaMP>
					            <MedPagValorPago>375</MedPagValorPago>
				            </MediosPagoItem>
			            </MediosPago>
			            <Referencia>
				            <ReferenciaItem>
					            <RefNroLinRef>1</RefNroLinRef>
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

    }
}




    