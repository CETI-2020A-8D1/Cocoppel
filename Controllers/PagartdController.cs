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
    /// Controlador PagartdController
    /// Usado para pagar una transacción con una tarjeta de débito
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PagartdController : ControllerBase
    {
        /// <summary>
        /// Conexión a la base de datos
        /// </summary>
        private readonly CocoppelContext _context;

        /// <summary>
        /// Constructor PagartdController
        /// Inicializa el controlador con una conexión a base de datos
        /// </summary>
        /// <param name="context">Contexto de la base de datos</param>
        public PagartdController(CocoppelContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Método PostDebitCard
        /// Usado para buscar la tarjeta de débito pasada en la transacción, realizar la transacción y devolver un código HTTP
        /// </summary>
        /// <param name="transaccion">JSON de la transacción. Contiene información de la tarjeta de débito, a que cuenta se deposita y que monto</param>
        /// <returns></returns>
        // POST: api/pagartd
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> PostDebitCard([FromBody]Transaccion transaccion)
        {
            // Busca la tarjeta de débito
            var tarjetaDebito = _context.TarjetaDebito.Where( td => td.Numero.Equals(transaccion.Tarjeta.Numero)).First();

            // Revisa si el resultado es null o la tarjeta no es válida, retorna código HTTP Not Found si cumple las condiciones
            if (tarjetaDebito == null || tarjetaDebito.Valida == false) {
                return NotFound();
            }

            var cuentaCheques = await _context.CuentaCheques.FindAsync(tarjetaDebito.IdnumeroDeCuenta);

            var CuentaChequesDeposito = await _context.CuentaCheques.FindAsync(transaccion.NumeroCuenta);

            var fecha = new DateTime(transaccion.Tarjeta.Año, transaccion.Tarjeta.Mes, 1);

            // Revisa que la fecha de caducidad y el cvv concuerden, autentica a la persona que posee la tarjeta, retorna código HTTP Unauthorized si no concuerdan los valores
            if (tarjetaDebito.FechaCaducidad != fecha || tarjetaDebito.Cvv != transaccion.Tarjeta.Cvv) {
                return Unauthorized();
            }

            // Revisa que tenga fondos la tarjeta y que la cuenta a depositar exista, retorna código HTTP Payment Required si no cumple con los requisitos
            if (transaccion.Precio > cuentaCheques.Balance || CuentaChequesDeposito == null)
            {
                return StatusCode(StatusCodes.Status402PaymentRequired);
            }
            // Finalmente, realiza la transacción y retorna código HTTP OK
            else
            {
                cuentaCheques.Balance -= transaccion.Precio;
                CuentaChequesDeposito.Balance += transaccion.Precio;
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
