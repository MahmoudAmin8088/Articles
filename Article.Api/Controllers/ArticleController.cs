using Article.core.IUnitOfWork;
using Article.core.Model;
using Article.core.Model.ModelDto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Article.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ArticleDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetAll()
        {
            var articles = _unitOfWork.Articles.GetAll();

            if(articles is null)
                return NotFound();
            
            var articleDto = new List<ArticleDto>();
            foreach (var article in articles)
            {
                
                articleDto.Add(_mapper.Map<ArticleDto>(article));
                
            }
            return Ok(articleDto);
        }

        [HttpGet("[action]/{catagoryId}")]
        [ProducesResponseType(200, Type = typeof(List<ArticleDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetArticlesByCatagory(string catagoryId)
        {
            var articles = _unitOfWork.Articles.GetArticlesByCatagory(catagoryId);
            if (articles is null)
                return NotFound();

            var articleDto = new List<ArticleDto>();
            foreach (var article in articles)
            {
                articleDto.Add(_mapper.Map<ArticleDto>(article));
            }

            return Ok(articleDto);
        }

        [HttpGet("{articleId}", Name = "GetArticle")]
        [ProducesResponseType(200, Type = typeof(ArticleDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Get(string articleId)
        {
            var article = _unitOfWork.Articles.GetById(articleId);
            if (article is null)
                return NotFound();

            var articleDto = _mapper.Map<ArticleDto>(article);

            return Ok(articleDto);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(ArticleDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] ArticleDto articleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var article = _mapper.Map<Articles>(articleDto);
            article.ArticleTime = DateTime.Now;
            if (_unitOfWork.Articles.Create(article) is null)
            {
                ModelState.AddModelError("", "Something Went Wrong When Saving The Record");
                return StatusCode(500, ModelState);
            }
            _unitOfWork.Complete();
            articleDto.ArticleTime = article.ArticleTime;
            articleDto.ArticleId = article.ArticleId;
            return Ok(articleDto);

        }

        [HttpPut("[action]")]
        [ProducesResponseType(200, Type = typeof(ArticleDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update([FromBody] ArticleUpdateDto articleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var obj = _unitOfWork.Articles.GetById(articleDto.ArticleId);

            var article = _mapper.Map<ArticleUpdateDto, Articles>(articleDto, obj);

            if (_unitOfWork.Articles.Update(article) is null)
            {
                ModelState.AddModelError("", "Something Went Wrong When Updating The Record");
                return StatusCode(500, ModelState);
            }
            _unitOfWork.Complete();

            return Ok(_mapper.Map<ArticleDto>(article));
        }

        [HttpDelete("{articleId}", Name = "DeleteArticle")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult Delete(string articleId)
        {
            var article = _unitOfWork.Articles.GetById(articleId);

            if (article is null)
                return NotFound(ModelState);
            if (_unitOfWork.Articles.Delete(article) is null)
            {
                ModelState.AddModelError("", "Something Went Wrong When deleting The Record");
                return StatusCode(500, ModelState);
            }
            _unitOfWork.Complete();

            return NoContent();
        }

    }
}
