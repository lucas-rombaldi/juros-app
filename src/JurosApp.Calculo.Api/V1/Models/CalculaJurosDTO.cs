using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JurosApp.Calculo.Api.V1.Models
{
    /// <summary>
    /// Representa a entrada de informações para o cálculo de juros.
    /// </summary>
    public class CalculaJurosDTO
    {
        /// <summary>
        /// Valor base para o cálculo de juros. 
        /// </summary>
        [Required]
        [FromQuery(Name = "valorinicial")]

        public decimal? ValorInicial { get; set; }

        /// <summary>
        /// Quantidade de meses para aplicar o cálculo.
        /// </summary>
        [Required]
        [FromQuery(Name = "meses")]
        public int? Meses { get; set; }
    }
}
