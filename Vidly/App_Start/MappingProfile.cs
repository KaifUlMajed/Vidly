using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Models;
using Vidly.Models.DTOs;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            // In this way, we say that the DTO cannot change the ID property of DMO.
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(c => c.ID, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>().ForMember(m => m.ID, opt => opt.Ignore());


            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<MembershipTypeDTO, MembershipType>().ForMember(m => m.ID, opt => opt.Ignore());
        }
    }
}