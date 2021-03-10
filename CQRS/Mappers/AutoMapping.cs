using AutoMapper;
using CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<StudentModel, Student >(); // means you want to map from StudentModel to Student 
        }
    }
}
