using ConnectWithDadata.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ConnectWithDadata.Services;
using AutoMapper;

namespace ConnectWithDadata.Controllers
{
	public class MainController : Controller
	{
		private readonly ILogger<MainController> _logger;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;


		public MainController(ILogger<MainController> logger, IMapper mapper, IConfiguration configuration)
		{
			_logger = logger;
			_mapper = mapper;
			_configuration = configuration;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddressConversion(string address)
		{
			AddressModel result;
			try
			{
				result = await new DadataConnect(_mapper,_configuration).GetAddressAsync(address);
			}
			catch
			{
				return DadataError();
			}
			return View("Index",result);
		}
		public IActionResult DadataError()
		{
			return View("DadataError");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}