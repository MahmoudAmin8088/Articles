using Article.core.Model;
using Article.core.Model.ModelDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.core.Mapping
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Articles, ArticleDto>();
            CreateMap<ArticleDto, Articles>().ForMember(a => a.ArticleTime, opt => opt.Ignore());

            CreateMap<Articles, ArticleUpdateDto>();
            CreateMap<ArticleUpdateDto, Articles>().ForMember(a => a.ArticleTime, opt => opt.Ignore());

            CreateMap<Comment, CommentUpdateDto>();
            CreateMap<CommentUpdateDto, Comment>().ForMember(a => a.CommentTime, opt => opt.Ignore());

            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>().ForMember(x => x.CommentTime, opt => opt.Ignore());

            CreateMap<RegisterModel, ApplicationUser>().ReverseMap();
        }
    }
}
