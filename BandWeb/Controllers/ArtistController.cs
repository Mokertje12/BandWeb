using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandWeb.Models;
using Newtonsoft.Json;
using BandWeb.Logic;
using BandWeb.Factory;
using BandWeb.Models.ViewModels;
using BandWeb.Logic.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BandWeb.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistLogic _iartistLogic;
        private readonly IConfiguration _iconfiguration;
        public ArtistController(IConfiguration configuration)
        {
            _iconfiguration = configuration;
            _iartistLogic = ArtistFactory.CreateSqlLogic(_iconfiguration);
        }
        public IActionResult ArtistForm()
        {
            return View();
        }
        public IActionResult ArtistList()
        {
            var model = new GetArtistViewModel()
            {
                Artist = _iartistLogic.GetAllArtist().ToList(),
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Detail(string id)
        {
            //var accObject = HttpContext.Session.GetString("Account");

            Artist art = _iartistLogic.GetDetailArtist(id);
            ArtistDetailViewModel model = new ArtistDetailViewModel
            {
                Artist = art,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Post(string nameArtist, string descriptionArtist,
           string listenersArtist, IFormFile image_pathArtist)
        {
            try
            {
                if (image_pathArtist != null)
                {
                    var path = Path.Combine
                    (
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "images",
                        image_pathArtist.FileName
                    );

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image_pathArtist.CopyToAsync(stream);
                    }
                }

                Artist art = new Artist(nameArtist, descriptionArtist, listenersArtist, image_pathArtist.FileName);

                _iartistLogic.NewArtist(art);
                return RedirectToAction("ArtistList");
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }
    }
}
