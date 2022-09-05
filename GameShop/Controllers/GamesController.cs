﻿using GameShop.Application.Catalog.Games;
using GameShop.ViewModels.Catalog.GameImages;
using GameShop.ViewModels.Catalog.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        //https:://localhost:port/game
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await _gameService.GetAll();
            return Ok(games);
        }

        /* https:://localhost:port/game/paging */

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageGamePagingRequest request)
        {
            var games = await _gameService.GetAllPaging(request);
            return Ok(games);
        }

        /* https:://localhost:port/game/1 */

        [HttpGet("{GameID}")]
        public async Task<IActionResult> GetById(int GameID)
        {
            var games = await _gameService.GetById(GameID);
            if (games == null)
            {
                return NotFound();
            }
            return Ok(games);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] GameCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var gameID = await _gameService.Create(request);
            if (gameID == 0)
            {
                return BadRequest();
            }
            var game = await _gameService.GetById(gameID);
            return Created(nameof(GetById), game);
        }

        [HttpPut("{GameID}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int GameID,[FromForm] GameEditRequest request)
        {
            var affedtedResult = await _gameService.Update(GameID,request);
            if (affedtedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{GameID}")]
        public async Task<IActionResult> Delete(int GameID)
        {
            var affedtedResult = await _gameService.Delete(GameID);
            if (affedtedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPatch("price/{GameID}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int GameID, decimal newPrice)
        {
            var isSuccess = await _gameService.UpdatePrice(GameID, newPrice);
            if (isSuccess == false)
            {
                return BadRequest();
            }

            return Ok();
        }

        // Image
        [HttpPost("{GameID}/Images")]
        public async Task<IActionResult> CreateImage(int GameID, [FromForm] GameImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var imageid = await _gameService.AddImage(GameID, request);
                if (imageid == 0)
                {
                    return BadRequest();
                }
                var image = await _gameService.GetImageById(imageid);
                return CreatedAtAction(nameof(GetImageByID), new { ImageID = imageid, GameID = GameID }, image);
            }
        }

        [HttpGet("{GameID}/Images/{ImageID}")]
        public async Task<IActionResult> GetImageByID(int GameID, int ImageID)
        {
            var image = await _gameService.GetImageById(ImageID);
            if (image == null)
            {
                return BadRequest("Could not find this image");
            }
            return Ok(image);
        }

        [HttpGet("{GameID}/Images")]
        public async Task<IActionResult> GetListImages(int GameID)
        {
            var ListImage = await _gameService.GetListImages(GameID);
            if (ListImage == null)
            {
                return BadRequest("Could not find this image");
            }
            return Ok(ListImage);
        }

        [HttpPut("{GameID}/Images/{ImageID}")]
        public async Task<IActionResult> UpdateImage(int ImageID, [FromForm] GameImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _gameService.UpdateImage(ImageID, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{GameID}/Images/{ImageID}")]
        public async Task<IActionResult> DeleteImage(int ImageID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _gameService.RemoveImage(ImageID);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut("{id}/genres")]
        [Authorize]
        public async Task<IActionResult> CategoryAssign(int id, [FromBody] CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _gameService.CategoryAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}