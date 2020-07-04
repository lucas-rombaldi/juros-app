namespace JurosApp.SharedKernel.Api.OpenApi
{
    /// <summary>
    /// Responsável por manter algumas informações utilizadas na página do Swagger.
    /// </summary>
    public class OpenApiDocumentDescription
    {
        public OpenApiDocumentDescription(string title, string description)
        {
            Title = title;
            Description = description;
        }

        /// <summary>
        /// Título da página.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Descrição da página.
        /// </summary>
        public string Description { get; set; }
    }
}
