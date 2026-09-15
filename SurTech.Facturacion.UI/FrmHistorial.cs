using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SurTech.Facturacion.Data.Context;
using SurTech.Facturacion.Services.BusinessLogic;

namespace SurTech.Facturacion.UI
{
    public partial class FrmHistorial : Form
    {
        private int _idComprobanteSeleccionado = 0;

        public FrmHistorial()
        {
            InitializeComponent();
            CargarComprobantes();
        }

        private void CargarComprobantes()
        {
            using (var context = new FacturacionDbContext())
            {
                var comprobantes = context.Comprobantes
                    .Select(c => new
                    {
                        c.IdComprobante,
                        c.TipoComprobante,
                        c.TipoOperacion,
                        c.FechaEmision,
                        c.NetoGravado,
                        c.ImporteIva,
                        c.Total
                    })
                    .OrderByDescending(c => c.FechaEmision)
                    .ToList();

                dgvComprobantes.DataSource = comprobantes;
            }
        }

        private void DgvComprobantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvComprobantes.Rows[e.RowIndex].Cells["IdComprobante"].Value is int idComprobante)
            {
                _idComprobanteSeleccionado = idComprobante;
                CargarDetalleComprobante(idComprobante);
            }
        }

        private void CargarDetalleComprobante(int idComprobante)
        {
            using (var context = new FacturacionDbContext())
            {
                var detalles = context.ComprobantesDetalles
                    .Where(cd => cd.IdComprobante == idComprobante)
                    .Select(cd => new
                    {
                        cd.IdArticulo,
                        cd.Cantidad,
                        cd.PrecioUnitario,
                        cd.Subtotal
                    })
                    .ToList();

                dgvDetalles.DataSource = detalles;
            }
        }


        private void BtnExportar_Click(object? sender, EventArgs e)
        {
            if (_idComprobanteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un comprobante de la lista para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new FacturacionDbContext())
            {
                var comprobante = context.Comprobantes
                    .Include(c => c.Detalles)
                    .FirstOrDefault(c => c.IdComprobante == _idComprobanteSeleccionado);

                if (comprobante != null)
                {
                    using (var saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Documento HTML/Factura (*.html)|*.html";
                        saveFileDialog.FileName = $"Factura_{comprobante.TipoComprobante}_0001-{comprobante.IdComprobante:D8}.html";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            var reporteService = new ReporteService();
                            reporteService.GuardarFacturaPdf(comprobante, "Consumidor Final", saveFileDialog.FileName);

                            MessageBox.Show("Comprobante generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Abrir automáticamente el comprobante en el navegador/visor por defecto
                            Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
                        }
                    }
                }
            }
        }
    }
}