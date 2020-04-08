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
    [Route("api/pagartd")]
    [ApiController]
    public class PagarConTarjetaDebitoController : ControllerBase
    {
        private readonly CocoppelContext _context;

        public PagarConTarjetaDebitoController(CocoppelContext context)
        {
            _context = context;
        }

        // POST: api/pagartd
        [HttpPost]
        public async Task<IActionResult> PostDebitCard(string numeroTarjetaDebito, int CuentaChequesADepositar, DateTime fechaDeCaducidadTarjetaDebito, int cvvTarjetaDebito, decimal precioAPagar)
        {
            var tarjetaDebito = _context.TarjetaDebito.Where( td => td.Numero.Equals(numeroTarjetaDebito)).First();

            if (tarjetaDebito == null || tarjetaDebito.Valida == false) {
                return NotFound();
            }

            var cuentaCheques = await _context.CuentaCheques.FindAsync(tarjetaDebito.IdnumeroDeCuenta);

            var CuentaChequesDeposito = await _context.CuentaCheques.FindAsync(CuentaChequesADepositar);

            if (tarjetaDebito.FechaCaducidad != fechaDeCaducidadTarjetaDebito || tarjetaDebito.Cvv != cvvTarjetaDebito) {
                return Unauthorized();
            }

            if (precioAPagar > cuentaCheques.Balance || CuentaChequesDeposito == null)
            {
                return StatusCode(StatusCodes.Status402PaymentRequired);
            }
            else {
                cuentaCheques.Balance -= precioAPagar;
                CuentaChequesDeposito.Balance += precioAPagar;
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
