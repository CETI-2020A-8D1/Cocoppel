using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cocoppel.Models;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using Cocoteca.Models;

namespace Cocoppel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagartcController : ControllerBase
    {
        private readonly CocoppelContext _context;

        public PagartcController(CocoppelContext context)
        {
            _context = context;
        }

        // POST: api/pagartc
        [HttpPost]
        public async Task<IActionResult> PostCreditCard([FromBody]Transaccion transaccion)
        {
            var tarjetaCredito = _context.TarjetaCredito.Where( tc => tc.Numero.Equals(transaccion.Tarjeta.Numero)).First();

            if (tarjetaCredito == null || tarjetaCredito.Valida == false) {
                return NotFound();
            }

            var lineaCredito = await _context.LineaCredito.FindAsync(tarjetaCredito.IdlineaCredito);

            var CuentaChequesDeposito = await _context.CuentaCheques.FindAsync(transaccion.NumeroCuenta);

            var fecha = new DateTime(transaccion.Tarjeta.Año, transaccion.Tarjeta.Mes, 1);

            if (tarjetaCredito.FechaCaducidad != fecha || tarjetaCredito.Cvv != transaccion.Tarjeta.Cvv) {
                return Unauthorized();
            }

            if (transaccion.Precio > lineaCredito.SaldoRestante || CuentaChequesDeposito == null)
            {
                return StatusCode(StatusCodes.Status402PaymentRequired);
            }
            else {
                lineaCredito.SaldoRestante -= transaccion.Precio;
                CuentaChequesDeposito.Balance += transaccion.Precio;
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
