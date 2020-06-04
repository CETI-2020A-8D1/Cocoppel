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

    /// <summary>
    /// Controlador PagartcController
    /// Usado para pagar una transacción con una tarjeta de crédito
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PagartcController : ControllerBase
    {
        /// <summary>
        /// Conexión a la base de datos
        /// </summary>
        private readonly CocoppelContext _context;

        /// <summary>
        /// Constructor PagartcController
        /// Inicializa el controlador con una conexión a base de datos
        /// </summary>
        /// <param name="context">Contexto de la base de datos</param>
        public PagartcController(CocoppelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método PostCreditCard
        /// Usado para buscar la tarjeta de crédito pasada en la transacción, realizar la transacción y devolver un código HTTP
        /// </summary>
        /// <param name="transaccion">JSON de la transacción. Contiene información de la tarjeta de crédito, a que cuenta se deposita y que monto</param>
        /// <returns></returns>
        // POST: api/pagartc
        [HttpPost]
        public async Task<IActionResult> PostCreditCard([FromBody]Transaccion transaccion)
        {
            // Busca la tarjeta de crédito
            var tarjetaCredito = _context.TarjetaCredito.Where( tc => tc.Numero.Equals(transaccion.Tarjeta.Numero)).First();

            // Revisa si el resultado es null o la tarjeta no es válida, retorna código HTTP Not Found si cumple las condiciones
            if (tarjetaCredito == null || tarjetaCredito.Valida == false) {
                return NotFound();
            }


            var lineaCredito = await _context.LineaCredito.FindAsync(tarjetaCredito.IdlineaCredito);

            var CuentaChequesDeposito = await _context.CuentaCheques.FindAsync(transaccion.NumeroCuenta);

            var fecha = new DateTime(transaccion.Tarjeta.Año, transaccion.Tarjeta.Mes, 1);


            // Revisa que la fecha de caducidad y el cvv concuerden, autentica a la persona que posee la tarjeta, retorna código HTTP Unauthorized si no concuerdan los valores
            if (tarjetaCredito.FechaCaducidad != fecha || tarjetaCredito.Cvv != transaccion.Tarjeta.Cvv) {
                return Unauthorized();
            }

            // Revisa que tenga fondos la tarjeta y que la cuenta a depositar exista, retorna código HTTP Payment Required si no cumple con los requisitos
            if (transaccion.Precio > lineaCredito.SaldoRestante || CuentaChequesDeposito == null)
            {
                return StatusCode(StatusCodes.Status402PaymentRequired);
            }

            // Finalmente, realiza la transacción y retorna código HTTP OK
            else {
                lineaCredito.SaldoRestante -= transaccion.Precio;
                CuentaChequesDeposito.Balance += transaccion.Precio;
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
