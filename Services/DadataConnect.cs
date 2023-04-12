using AutoMapper;
using ConnectWithDadata.Models;
using Dadata;
using Dadata.Model;


namespace ConnectWithDadata.Services
{
	public class DadataConnect
	{
		private readonly IConfiguration _config;
		private readonly IMapper _mapper;
		public DadataConnect(IMapper mapper, IConfiguration config)
		{
			_mapper=mapper;
			_config = config;
		}
		public async Task<AddressModel> GetAddressAsync(string address)
		{
			var token = _config["token"];
			var secret = _config["secret"];
			var api = new CleanClientAsync(token, secret);
			var resConnect = await api.Clean<Address>(address);
			return _mapper.Map<AddressModel>(resConnect);
		}
	}
}

