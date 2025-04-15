using AutoMapper;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.DTO.Comment;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentReadDTO>();
        CreateMap<CommentCreateDTO, Comment>();
    }
}
