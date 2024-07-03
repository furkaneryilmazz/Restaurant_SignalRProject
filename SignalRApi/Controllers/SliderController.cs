using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService,IMapper mapper)
        {
			_sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            Slider slider = new Slider()
            {
                Title1 = createSliderDto.Title1,
                Desciption1 = createSliderDto.Desciption1,
                Title2 = createSliderDto.Title2,
                Desciption2 = createSliderDto.Desciption2,
                Title3 = createSliderDto.Title3,
                Desciption3 = createSliderDto.Desciption3
			};
			_sliderService.TAdd(slider);
            return Ok("Özellik başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var values = _sliderService.TGetByID(id);
			_sliderService.TDelete(values);
            return Ok("Özellik başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            Slider slider = new Slider()
            {
                SliderID = updateSliderDto.SliderID,
				Title1 = updateSliderDto.Title1,
				Desciption1 = updateSliderDto.Desciption1,
				Title2 = updateSliderDto.Title2,
				Desciption2 = updateSliderDto.Desciption2,
				Title3 = updateSliderDto.Title3,
				Desciption3 = updateSliderDto.Desciption3
			};
            _sliderService.TUpdate(slider);
            return Ok("Özellik başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var values = _sliderService.TGetByID(id);
            return Ok(values);
        }
    }
}
