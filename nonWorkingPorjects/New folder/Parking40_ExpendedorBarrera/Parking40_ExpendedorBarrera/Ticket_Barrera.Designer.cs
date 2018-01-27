namespace Parking40_ExpendedorBarrera
{
    partial class Ticket_Barrera
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel_Entrada = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel_Hora = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel_Ticket = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel_Fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.Codigo_Barras = new DevExpress.XtraReports.UI.XRBarCode();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel_Entrada,
            this.xrLabel_Hora,
            this.xrLabel_Ticket,
            this.xrLabel_Fecha,
            this.Codigo_Barras});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 571.4375F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(13.22917F, 317.3942F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(756.7708F, 58.41989F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "PARKING ESTER";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel_Entrada
            // 
            this.xrLabel_Entrada.Dpi = 254F;
            this.xrLabel_Entrada.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel_Entrada.LocationFloat = new DevExpress.Utils.PointFloat(13.22925F, 501.2467F);
            this.xrLabel_Entrada.Name = "xrLabel_Entrada";
            this.xrLabel_Entrada.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel_Entrada.SizeF = new System.Drawing.SizeF(399.5208F, 45.1908F);
            this.xrLabel_Entrada.StylePriority.UseFont = false;
            this.xrLabel_Entrada.StylePriority.UseTextAlignment = false;
            this.xrLabel_Entrada.Text = "Entrada:";
            this.xrLabel_Entrada.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel_Hora
            // 
            this.xrLabel_Hora.Dpi = 254F;
            this.xrLabel_Hora.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel_Hora.LocationFloat = new DevExpress.Utils.PointFloat(427.5208F, 462.9149F);
            this.xrLabel_Hora.Name = "xrLabel_Hora";
            this.xrLabel_Hora.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel_Hora.SizeF = new System.Drawing.SizeF(278.9167F, 58.41995F);
            this.xrLabel_Hora.StylePriority.UseFont = false;
            this.xrLabel_Hora.StylePriority.UseTextAlignment = false;
            this.xrLabel_Hora.Text = "Hora:";
            this.xrLabel_Hora.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel_Hora.Visible = false;
            // 
            // xrLabel_Ticket
            // 
            this.xrLabel_Ticket.Dpi = 254F;
            this.xrLabel_Ticket.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel_Ticket.LocationFloat = new DevExpress.Utils.PointFloat(13.22917F, 444.3941F);
            this.xrLabel_Ticket.Name = "xrLabel_Ticket";
            this.xrLabel_Ticket.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel_Ticket.SizeF = new System.Drawing.SizeF(399.5208F, 45.1908F);
            this.xrLabel_Ticket.StylePriority.UseFont = false;
            this.xrLabel_Ticket.Text = "Ticket:";
            // 
            // xrLabel_Fecha
            // 
            this.xrLabel_Fecha.Dpi = 254F;
            this.xrLabel_Fecha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel_Fecha.LocationFloat = new DevExpress.Utils.PointFloat(13.22917F, 388.8316F);
            this.xrLabel_Fecha.Name = "xrLabel_Fecha";
            this.xrLabel_Fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel_Fecha.SizeF = new System.Drawing.SizeF(693.2083F, 45.1908F);
            this.xrLabel_Fecha.StylePriority.UseFont = false;
            this.xrLabel_Fecha.Text = "Fecha:";
            // 
            // Codigo_Barras
            // 
            this.Codigo_Barras.Dpi = 254F;
            this.Codigo_Barras.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.Codigo_Barras.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Codigo_Barras.Module = 5.08F;
            this.Codigo_Barras.Name = "Codigo_Barras";
            this.Codigo_Barras.Padding = new DevExpress.XtraPrinting.PaddingInfo(25, 25, 0, 0, 254F);
            this.Codigo_Barras.SizeF = new System.Drawing.SizeF(790F, 306.5833F);
            this.Codigo_Barras.StylePriority.UseFont = false;
            this.Codigo_Barras.StylePriority.UseTextAlignment = false;
            this.Codigo_Barras.Symbology = code128Generator1;
            this.Codigo_Barras.Text = "34";
            this.Codigo_Barras.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 3F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Ticket_Barrera
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 3);
            this.PageHeight = 1000;
            this.PageWidth = 795;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 31.75F;
            this.Version = "10.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel xrLabel_Fecha;
        private DevExpress.XtraReports.UI.XRBarCode Codigo_Barras;
        private DevExpress.XtraReports.UI.XRLabel xrLabel_Entrada;
        private DevExpress.XtraReports.UI.XRLabel xrLabel_Hora;
        private DevExpress.XtraReports.UI.XRLabel xrLabel_Ticket;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
    }
}
