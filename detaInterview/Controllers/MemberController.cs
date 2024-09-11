using AutoMapper;
using detaInterview.Models;
using detaInterview.Serivce;
using detaInterview.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace detaInterview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : Controller
    {
        private readonly IDetailService _detailService;
        private readonly IMapper _mapper;
        public MemberController(IDetailService detailService, IMapper mapper)
        {
            _detailService = detailService;
            _mapper = mapper;
        }
        /// <summary>
        /// 取得全部資料
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var data = _detailService.GetList();

            return Ok(_mapper.Map<List<DetailViewModel>>(data));
        }


        /// <summary>
        /// 取得單一資料
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        public IActionResult Get(string pk)
        {
            var data = _detailService.Get(pk);

            return Ok(_mapper.Map<DetailViewModel>(data));
        }



        /// <summary>
        /// 新增或是修改資料
        /// </summary>
        /// <returns></returns>
        [HttpPost("Set")]
        public IActionResult Set(DetailViewModel model)
        {
            var data = _mapper.Map<Detail>(model);
            _detailService.Set(data);

            return Ok();
        }


        /// <summary>
        /// 新增或是修改資料
        /// </summary>
        /// <returns></returns>
        [HttpPost("Delete")]
        public IActionResult Delete(string pk)
        {
            _detailService.Delete(pk);

            return Ok();
        }
    }
}
