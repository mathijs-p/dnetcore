using AutoMapper;
using dnetcore.Models.DomainModels;
using dnetcore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnetcore.Mappings
{
    public class DomainToViewModelProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelProfile";

        public DomainToViewModelProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Store, StoreViewModel>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
