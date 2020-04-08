using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cocoppel.Models;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace Cocoppel.Controllers
{
    [Route("api/pagartc")]
    [ApiController]
    public class PagarConTarjetaCreditoController : ControllerBase
    {
        private readonly CocoppelContext _context;

        public PagarConTarjetaCreditoController(CocoppelContext context)
        {
            _context = context;
        }

        // POST: api/pagartc
        [HttpPost]
        public async Task<IActionResult> PostCreditCard(string numeroTarjetaCredito, int CuentaChequesADepositar, DateTime fechaDeCaducidadTarjetaCredito, int cvvTarjetaCredito, decimal precioAPagar)
        {
            var tarjetaCredito = _context.TarjetaCredito.Where( tc => tc.Numero.Equals(numeroTarjetaCredito)).First();

            if (tarjetaCredito == null || tarjetaCredito.Valida == false) {
                return NotFound();
            }

            var lineaCredito = await _context.LineaCredito.FindAsync(tarjetaCredito.IdlineaCredito);

            var CuentaCheques = await _context.CuentaCheques.FindAsync(CuentaChequesADepositar);

            if (tarjetaCredito.FechaCaducidad != fechaDeCaducidadTarjetaCredito || tarjetaCredito.Cvv != cvvTarjetaCredito) {
                return Unauthorized();
            }

            if (precioAPagar > lineaCredito.SaldoRestante || CuentaCheques == null)
            {
                return StatusCode(StatusCodes.Status402PaymentRequired);
            }
            else {
                lineaCredito.SaldoRestante -= precioAPagar;
                CuentaCheques.Balance += precioAPagar;
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
