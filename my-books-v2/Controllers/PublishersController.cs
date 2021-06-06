using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books_v2.Data.Services;
using my_books_v2.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublisherService _publishersService;

        public PublishersController(PublisherService publisherService)
        {
            _publishersService = publisherService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string sortBy, string searchString)
        {
            try
            {
                var _result = _publishersService.GetAllPublishers(sortBy, searchString);
                return Ok(_result);
            }
            catch (Exception)
            {
                return BadRequest("Sorry, we could not load the publishers");
            }
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publishersService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _publishersService.DeletePublisherById(id);
            return Ok();
        }
    }
}
