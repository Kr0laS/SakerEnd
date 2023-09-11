namespace SakerEnd.Dto
{
    public record DeviceDto
    {
        [Required]
        public string IP { get; set; }
        [Required]
        public string Port { get; set; }
    }
}
