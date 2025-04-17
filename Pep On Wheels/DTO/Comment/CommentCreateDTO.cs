using System.ComponentModel.DataAnnotations;

namespace Pep_On_Wheels.DTO.Comment
{
    public class CommentCreateDTO
    {
        [Required]
        public string Text { get; set; } = string.Empty;
        public int ProductId { get; set; }
    }
}
