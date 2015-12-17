using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.UW.Models
{
    public class Mapping
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.CreateMap<Paging, Services.Models.Paging>()
               .ForMember(dest => dest.Page, opts => opts.MapFrom(src => src.Current))
               .ForMember(dest => dest.Rows, opts => opts.MapFrom(src => src.PerPage));

            AutoMapper.Mapper.CreateMap<Services.Models.Paging, Paging>()
               .ForMember(dest => dest.Current, opts => opts.MapFrom(src => src.Page))
               .ForMember(dest => dest.PerPage, opts => opts.MapFrom(src => src.Rows))
               .ForMember(dest => dest.Total, opts => opts.MapFrom(src => src));


            AutoMapper.Mapper.CreateMap<Total, Services.Models.Paging>()
                .ForMember(dest => dest.TotalItems, opts => opts.MapFrom(src => src.Items));

            AutoMapper.Mapper.CreateMap<Services.Models.Paging, Total>()
                .ForMember(dest => dest.Items, opts => opts.MapFrom(src => src.TotalItems))
                .ForMember(dest => dest.Pages, opts => opts.MapFrom(src => src.Rows > 0 ? Convert.ToInt32(Math.Ceiling(((double)src.TotalItems / src.Rows))) : 0));
        }
    }
}