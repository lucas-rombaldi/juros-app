using System;
using Microsoft.AspNetCore.Mvc;
using JurosApp.SharedKernel.Commons;
using JurosApp.SharedKernel.Api.Attributes;

namespace JurosApp.SharedKernel.Api
{
    [StatusResponse]
    [Route("[controller]")]
    public class JurosBaseController : ControllerBase
    {
        protected virtual string GenericBadRequestErrorMessage => nameof(BadRequest);

        protected virtual string GenericNotFoundErrorMessage => nameof(NotFound);

        /// <summary>
        /// Retorna um resultado contendo código HTTP 200 - OK e um valor.
        /// O valor é transformado em um <see cref="Commons.Status"/> caso não o seja.
        /// </summary>
        /// <param name="value">Valor a ser retornado.</param>
        /// <returns>Resultado com um objeto de <see cref="Commons.Status"/> contendo valor.</returns>
        [NonAction]
        public override OkObjectResult Ok(object value)
        {
            if (!(value is Status))
                value = new Status<object>(value: value);

            return base.Ok(value);
        }

        /// <summary>
        /// Retorna um resultado contendo código HTTP 400 - BadRequest e uma mensagem de erro.
        /// A mensagem de erro é transformada em um <see cref="Commons.Status"/>.
        /// </summary>
        /// <param name="error">Mensagem de erro a ser retornada.</param>
        /// <returns>Resultado com um objeto de <see cref="Commons.Status"/> contendo a mensagem de erro.</returns>
        [NonAction]
        public BadRequestObjectResult BadRequest(string error)
        {
            var status = new Status(error);
            return base.BadRequest(status);
        }

        /// <summary>
        /// Retorna um resultado contendo código HTTP 400 - BadRequest e uma <see cref="Exception"/>.
        /// A mensagem de erro é transformada em um <see cref="Commons.Status"/>.
        /// </summary>
        /// <param name="exception"><see cref="Exception"/> a ser retornada.</param>
        /// <returns>Resultado com um objeto de <see cref="Commons.Status"/> contendo a <see cref="Exception"/>.</returns>
        [NonAction]
        public BadRequestObjectResult BadRequest(Exception exception)
        {
            var status = new Status(exception);
            return base.BadRequest(status);
        }

        /// <summary>
        /// Retorna um resultado contendo código HTTP 400 - BadRequest e um objeto de erro contendo uma mensagem.
        /// O objeto de erro é transformado em um <see cref="Commons.Status"/>.
        /// </summary>
        /// <param name="error">Objeto de erro a ser retornado.</param>
        /// <returns>Resultado com um objeto de <see cref="Commons.Status"/> contendo o objeto de erro e uma mensagem de erro padrão.</returns>
        [NonAction]
        public override BadRequestObjectResult BadRequest(object error)
        {
            return this.BadRequest(error, GenericBadRequestErrorMessage);
        }

        /// <summary>
        /// Retorna um resultado contendo código HTTP 400 - BadRequest e um objeto de erro contendo uma mensagem.
        /// O objeto de erro é transformado em um <see cref="Commons.Status"/>.
        /// </summary>
        /// <param name="error">Objeto de erro a ser retornado.</param>
        /// <param name="errorMessage">Mensagem de erro a ser retornada junto do objeto.</param>
        /// <returns>Resultado com um objeto de <see cref="Commons.Status"/> contendo o objeto de erro e sua mensagem.</returns>
        [NonAction]
        public BadRequestObjectResult BadRequest(object error, string errorMessage)
        {
            if (!(error is Status))
                error = new Status<object>(error);

            var status = (Status)error;

            if (status.Succeeded)
                status.ErrorMessage = errorMessage;

            return base.BadRequest(status);
        }

        /// <summary>
        /// Retorna um resultado contendo código HTTP 404 - NotFound e uma mensagem de erro.
        /// A mensagem de erro é transformada em um <see cref="Commons.Status"/>.
        /// </summary>
        /// <param name="error">Mensagem de erro a ser retornada.</param>
        /// <returns>Resultado com um objeto de <see cref="Commons.Status"/> contendo a mensagem de erro.</returns>
        [NonAction]
        public NotFoundObjectResult NotFound(string error)
        {
            var status = new Status(error);
            return base.NotFound(status);
        }

        /// <summary>
        /// Retorna um resultado contendo código HTTP 404 - NotFound e uma <see cref="Exception"/>.
        /// A mensagem de erro é transformada em um <see cref="Commons.Status"/>.
        /// </summary>
        /// <param name="exception"><see cref="Exception"/> a ser retornada.</param>
        /// <returns>Resultado com um objeto de <see cref="Commons.Status"/> contendo a <see cref="Exception"/>.</returns>
        [NonAction]
        public NotFoundObjectResult NotFound(Exception exception)
        {
            var status = new Status(exception);
            return base.NotFound(status);
        }

        /// <summary>
        /// Retorna um resultado contendo código HTTP 404 - NotFound e um objeto de erro contendo uma mensagem.
        /// O objeto de erro é transformado em um <see cref="Commons.Status"/>.
        /// </summary>
        /// <param name="value">Objeto a ser retornado.</param>
        /// <returns>Resultado com um objeto de <see cref="Commons.Status"/> contendo o objeto e uma mensagem de erro padrão.</returns>
        [NonAction]
        public override NotFoundObjectResult NotFound(object value) 
            => NotFound(value, GenericNotFoundErrorMessage);

        /// <summary>
        /// Retorna um resultado contendo código HTTP 404 - NotFound e um objeto de erro contendo uma mensagem.
        /// O objeto de erro é transformado em um <see cref="Commons.Status"/>.
        /// </summary>
        /// <param name="value">Objeto a ser retornado.</param>
        /// <param name="errorMessage">Mensagem de erro a ser retornada junto do objeto.</param>
        /// <returns>Resultado com um objeto de <see cref="Commons.Status"/> contendo o objeto e sua mensagem.</returns>
        [NonAction]
        public NotFoundObjectResult NotFound(object value, string errorMessage)
        {
            if (!(value is Status))
                value = new Status<object>(value);

            var status = (Status)value;

            if (status)
                status.ErrorMessage = errorMessage;

            return base.NotFound(status);
        }
    }
}
