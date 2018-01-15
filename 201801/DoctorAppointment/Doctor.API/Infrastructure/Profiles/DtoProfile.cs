using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Doctor.API.Models;
using Doctor.Core.DTOs;

namespace Doctor.API.Infrastructure.Profiles
{
	public class DtoProfile : Profile
	{
		public DtoProfile()
		{
			CreateMap<SlotRequest, SlotDto>();
			CreateMap<Patient, PatientDto>();
		}
	}
}
