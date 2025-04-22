namespace ApiYtb.Models
{
    /* Propriedades buscadas da API externa */
    public class DetalhesVd
    { 
        // "?" permite que o valor recebido seja nulo. Get e set são o equivalente aos getters e setters no Java
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public string? ThumbnailUrl { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}
