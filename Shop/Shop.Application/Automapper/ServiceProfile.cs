﻿using System;
using System.Linq;
using AutoMapper;
using Shop.DTOs;
using Shop.Entities;

namespace Shop.Application.Automapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<ItemEntity, ItemDTO>()
                .ForMember(dest => dest.AvailableQuantity, opc => opc.MapFrom(src=>src.available_quantity))
                .ForMember(dest => dest.SoldQuantity, opc => opc.MapFrom(src => src.sold_quantity))
                .ForMember(dest => dest.ItemLargeDescription,
                    opc => opc.MapFrom(src => src.ItemLargeDescription == null ? string.Empty : src.ItemLargeDescription.plain_text))
                .ForMember(dest => dest.PicturesUrl,
                    opc => opc.MapFrom(src => src.pictures.Select(i => i.url).ToList()))
                .ForMember(dest => dest.Attributes, opc => opc.MapFrom(src => src.attributes
                    .Select(c => new {c.name, c.value_name})
                    .AsEnumerable()
                    .Select(c => new Tuple<string, string>(c.name, c.value_name))
                    .ToList()));


            CreateMap<ItemResultEntity, ItemResultDTO>()
                .ForMember(dest => dest.FreeShipping, opc => opc.MapFrom(src => src.shipping.free_shipping));
            CreateMap<SearchResultEntity, SearchResultDTO>()
                .ForMember(dest=>dest.TotalItemCount,opc=>opc.MapFrom(src => src.paging.total));
        }
    }
}
