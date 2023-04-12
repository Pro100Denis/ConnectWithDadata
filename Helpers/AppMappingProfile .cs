using AutoMapper;
using ConnectWithDadata.Models;
using Dadata.Model;

namespace ConnectWithDadata.Mapping
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<Address, AddressModel>();
		}
	}
}
