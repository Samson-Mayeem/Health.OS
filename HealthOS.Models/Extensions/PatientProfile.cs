using AutoMapper;
using HealthOS.Models.DTOs;
using HealthOS.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models.Extensions
{

    public class PatientProfile :Profile
    {
        public PatientProfile() 
        {
            CreateMap<Patient, PatientCreateDto>();
            CreateMap<PatientCreateDto, Patient>();
        }
    }
}
