using System;

namespace JurosApp.SharedKernel.Commons
{
    /// <summary>
    /// Representa um objeto de sucesso ou falha de uma operação.
    /// </summary>
    public class Status
    {
        public Status()
        { }

        public Status(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public Status(Exception exception)
        {
            Exception = exception;
            ErrorMessage = exception.Message;
        }

        public static implicit operator bool(Status status)
            => (status != null && status.Succeeded);

        /// <summary>
        /// Mensagem de erro da operação.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// <see cref="Exception"/> da operação.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Indica se a operação foi um sucesso.
        /// </summary>
        public bool Succeeded { get => string.IsNullOrEmpty(ErrorMessage) && Exception == null; }
    }
}
