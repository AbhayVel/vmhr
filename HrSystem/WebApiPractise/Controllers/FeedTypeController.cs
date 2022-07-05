using HREntity;
using HRModels;
using HRRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApiPractise.Controllers
{
   public class Dummy
    {
        public int Id { get; set; }
    }


    [ApiController]

    [EnableCors("local")]
    [Route("api/[controller]")]

    [Route("api/[controller]/[action]")]
    //[Route("sneha/[controller]")]
    //[Route("ketaki/[controller]")]
    //[Route("mathan/[controller]")]

    [Authorize]
    public class FeedTypeController : ControllerBase
    {

        IFeedTypeRepository _feedTypeRepository;

        public FeedTypeController(IFeedTypeRepository feedTypeRepository)
        {
            _feedTypeRepository = feedTypeRepository;
        }

        [HttpPost]
        [Consumes("application/json")]
        [AllowAnonymous]
        public ActionResult<FeedTypeModel> Dummy(Dummy dummy)
        {
            return Ok("I am ok");
        }



            [HttpPost]   
            
        public ActionResult<FeedTypeModel> Index([FromBody] FeedTypeModel feedTypeModel)
        {
           // FeedTypeModel feedTypeModel= new FeedTypeModel();
            List<FeedType> feed = _feedTypeRepository.GetAll(feedTypeModel);
            feedTypeModel.FeedType = feed;
            return Ok(feedTypeModel);
        }


        [HttpGet]
        [Route("XYZ")]
       
        public FeedTypeModel XYZ()
        {
            FeedTypeModel feedTypeModel = new FeedTypeModel();
            List<FeedType> feed = _feedTypeRepository.GetAll(feedTypeModel);
            feedTypeModel.FeedType = feed;
          return feedTypeModel;
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public ActionResult<FeedType>  GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = _feedTypeRepository.Get(id);
            if (result == null)
            {
                    return NotFound();
            }
            return Ok(result);

             
        }

        

        //public IActionResult Index(FeedModel feedModel)
        //{
        //    List<Feed> feed = _feedRepository.GetAll(feedModel);
        //    ViewBag.Model = feedModel;

        //    //feed = feedModel.Where(feed);
        //    //feed = feedModel.Sort(feed);
        //    //feedModel.PageModel.SetValues(feed);
        //    //feed = feed.Skip(feedModel.PageModel.StartIndex).Take(feedModel.PageModel.RowPerPage).ToList();

        //    return View(feed);
        //}
    }
}
