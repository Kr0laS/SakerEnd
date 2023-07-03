namespace SakerEnd.Dto
{
    public record ConfigurationDto
    {
        [Required]
        public string IP { get; set; }
        [Required]
        public string Port { get; set; }
        public string Name { get; set; }
    }
}
