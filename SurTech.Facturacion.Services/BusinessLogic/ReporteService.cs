using System;
using System.IO;
using System.Text;
using SurTech.Facturacion.Core.Entities;
using SurTech.Facturacion.Services.Interfaces;

namespace SurTech.Facturacion.Services.BusinessLogic
{
    public class ReporteService : IReporteService
    {
        public string GenerarHtmlFactura(Comprobante comprobante, string nombreCliente)
        {
            var sb = new StringBuilder();

            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: Arial, sans-serif; margin: 20px; color: #333; }");
            sb.AppendLine(".header { border: 2px solid #333; padding: 15px; margin-bottom: 20px; position: relative; }");
            sb.AppendLine(".tipo-comprobante { position: absolute; top: 10px; right: 20px; border: 2px solid #333; padding: 10px 15px; font-size: 24px; font-weight: bold; }");
            sb.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            sb.AppendLine("th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }");
            sb.AppendLine("th { background-color: #f2f2f2; }");
            sb.AppendLine(".totales { float: right; margin-top: 20px; width: 300px; }");
            sb.AppendLine(".totales-row { display: flex; justify-content: space-between; padding: 5px 0; }");
            sb.AppendLine(".total-final { font-weight: bold; font-size: 16px; border-top: 2px solid #333; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("body>");

            // Encabezado del Comprobante
            sb.AppendLine("<div class='header'>");
            sb.AppendLine($"<div class='tipo-comprobante'>{comprobante.TipoComprobante}</div>");
            sb.AppendLine("<h2>SurTech Software Educativo</h2>");
            sb.AppendLine("<p><strong>CUIT:</strong> 30-71123456-8</p>");
            sb.AppendLine("<p><strong>Condición IVA:</strong> Responsable Inscripto</p>");
            sb.AppendLine($"<p><strong>Fecha de Emisión:</strong> {comprobante.FechaEmision:dd/MM/yyyy HH:mm}</p>");
            sb.AppendLine($"<p><strong>Comprobante N°:</strong> 0001-{comprobante.IdComprobante:D8}</p>");
            sb.AppendLine("<hr/>");
            sb.AppendLine($"<p><strong>Cliente:</strong> {nombreCliente}</p>");
            sb.AppendLine($"<p><strong>Operación:</strong> {comprobante.TipoOperacion}</p>");
            sb.AppendLine("</div>");

            // Tabla de Renglones / Detalle
            sb.AppendLine("<table>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th>Código / Item</th>");
            sb.AppendLine("<th>Cantidad</th>");
            sb.AppendLine("<th>Precio Unitario</th>");
            sb.AppendLine("<th>Subtotal</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            if (comprobante.Detalles != null)
            {
                foreach (var item in comprobante.Detalles)
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine($"<td>Artículo ID: {item.IdArticulo}</td>");
                    sb.AppendLine($"<td>{item.Cantidad}</td>");
                    sb.AppendLine($"<td>${item.PrecioUnitario:F2}</td>");
                    sb.AppendLine($"<td>${item.Subtotal:F2}</td>");
                    sb.AppendLine("</tr>");
                }
            }

            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            // Totales
            sb.AppendLine("<div class='totales'>");
            sb.AppendLine($"<div class='totales-row'><span>Neto Gravado:</span> <span>${comprobante.NetoGravado:F2}</span></div>");
            sb.AppendLine($"<div class='totales-row'><span>IVA (21%):</span> <span>${comprobante.ImporteIva:F2}</span></div>");
            sb.AppendLine($"<div class='totales-row total-final'><span>TOTAL:</span> <span>${comprobante.Total:F2}</span></div>");
            sb.AppendLine("</div>");

            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }

        public void GuardarFacturaPdf(Comprobante comprobante, string nombreCliente, string rutaArchivo)
        {
            string contenidoHtml = GenerarHtmlFactura(comprobante, nombreCliente);
            // Guardamos el documento HTML formatteado preparado para exportar/imprimir
            File.WriteAllText(rutaArchivo, contenidoHtml, Encoding.UTF8);
        }
    }
}