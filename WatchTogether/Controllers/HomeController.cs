using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WatchTogether.Application.Contracts;
using WatchTogether.Application.Interfaces;
using WatchTogether.Models;
using WatchTogether.Presentation.Models;

namespace WatchTogether.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IRoomService roomService, IMapper mapper)
        {
            _logger = logger;
            _roomService = roomService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Rooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            try
            {
                var rooms = await _roomService.GetAllRooms();
                var result = _mapper.Map<List<RoomDto>, List<RoomViewModel>>(rooms);
                return View(result);
            }
            catch (Exception ex) 
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("Room/{id}")]
        public async Task<IActionResult> Room(string id)
        {
            try
            {
                ViewBag.id = id;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}