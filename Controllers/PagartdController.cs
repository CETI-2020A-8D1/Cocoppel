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
    public class PagartdController : ControllerBase
    {
        private readonly CocoppelContext _context;

        public PagartdController(CocoppelContext context)
        {
            _context = context;
        }

        // POST: api/pagartd
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> PostDebitCard([FromBody]Transaccion transaccion)
        {
            var tarjetaDebito = _context.TarjetaDebito.Where( td => td.Numero.Equals(transaccion.Tarjeta.Numero)).First();

            if (tarjetaDebito == null || tarjetaDebito.Valida == false) {
                return NotFound();
            }

            var cuentaCheques = await _context.CuentaCheques.FindAsync(tarjetaDebito.IdnumeroDeCuenta);

            var CuentaChequesDeposito = await _context.CuentaCheques.FindAsync(transaccion.NumeroCuenta);

            var fecha = new DateTime(transaccion.Tarjeta.Año, transaccion.Tarjeta.Mes, 1);

            if (tarjetaDebito.FechaCaducidad != fecha || tarjetaDebito.Cvv != transaccion.Tarjeta.Cvv) {
                return Unauthorized();
            }

            if (transaccion.Precio > cuentaCheques.Balance || CuentaChequesDeposito == null)
            {
                return StatusCode(StatusCodes.Status402PaymentRequired);
            }
            else {
                cuentaCheques.Balance -= transaccion.Precio;
                CuentaChequesDeposito.Balance += transaccion.Precio;
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
