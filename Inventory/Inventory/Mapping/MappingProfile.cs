using AutoMapper;
using Inventory.ModelResources;
using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){

            //ModelResources to Model

            CreateMap<ItemModel, ItemResource>()
              .ForMember(mr => mr.ItemId, opt => opt.MapFrom(m => m.ItemId))
              .ForMember(mr => mr.ItemCode, opt => opt.MapFrom(m => m.ItemCode))
              .ForMember(mr => mr.ItemName, opt => opt.MapFrom(m => m.ItemName))
              .ForMember(mr => mr.ItemPrice, opt => opt.MapFrom(m => m.ItemPrice))
              .ForMember(mr => mr.ItemQty_InGms, opt => opt.MapFrom(m => m.ItemQty_InGms));

            //model to Modelresource

            CreateMap<ItemResource, ItemModel>()
              .ForMember(m => m.ItemId, opt => opt.MapFrom(mr => mr.ItemId))
              .ForMember(m => m.ItemCode, opt => opt.MapFrom(mr => mr.ItemCode))
              .ForMember(m => m.ItemName, opt => opt.MapFrom(mr => mr.ItemName))
              .ForMember(m => m.ItemPrice, opt => opt.MapFrom(mr => mr.ItemPrice))
              .ForMember(m => m.ItemQty_InGms, opt => opt.MapFrom(mr => mr.ItemQty_InGms));

        }
    }
}
