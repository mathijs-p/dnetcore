using AutoMapper;
using dnetcore.Models.DomainModels;
using dnetcore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnetcore.Mappings
{
    public class ViewModelToDomainProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainProfile";

        public ViewModelToDomainProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<StoreViewModel, Store>();
            CreateMap<ProductViewModel, Product>();
        }
    }
}
