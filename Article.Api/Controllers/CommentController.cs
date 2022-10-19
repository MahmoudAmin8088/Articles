using Article.core.IUnitOfWork;
using Article.core.Model;
using Article.core.Model.ModelDto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace Article.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CommentDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllComment()
        {
            var comments = _unitOfWork.Comments.GetAll();

            if (comments is null)
                return NotFound();
            var commentDto = new List<CommentDto>();

            foreach (var obj in comments)
            {
                commentDto.Add(_mapper.Map<CommentDto>(obj));
            }

            return Ok(commentDto);
        }

        [HttpGet("{commentId}", Name = "GetComment")]
        [ProducesResponseType(200, Type = typeof(CommentDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult GetComment(string commentId)
        {
            var comment = _unitOfWork.Comments.GetById(commentId);

            if (comment is null)
                return NotFound();
            var commentDto = _mapper.Map<CommentDto>(comment);

            return Ok(commentDto);

        }

        [HttpGet("[action]/{articleId}")]
        [ProducesResponseType(200, Type = typeof(List<CommentDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetArticleComments(string articleId)
        {
            var comments = _unitOfWork.Comments.GetArticleComments(articleId);
            if (comments is null)
                return NotFound();

            var commentDto = new List<CommentDto>();

            foreach (var obj in comments)
            {
                commentDto.Add(_mapper.Map<CommentDto>(obj));
            }

            return Ok(commentDto);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(CommentDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult Create([FromBody] CommentDto commentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = _mapper.Map<Comment>(commentDto);
            comment.CommentTime = DateTime.Now;

            if (_unitOfWork.Comments.Create(comment) is null)
            {
                ModelState.AddModelError("", "Something Went Wrong When Saving The Record");
                return StatusCode(500, ModelState);
            }
            _unitOfWork.Complete();

            commentDto.CommentTime = comment.CommentTime;
            commentDto.CommentId = comment.CommentId;
            return Ok(commentDto);
        }

        [HttpPut("[action]")]
        [ProducesResponseType(200, Type = typeof(CommentDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update( [FromBody] CommentUpdateDto commentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var obj = _unitOfWork.Comments.GetById(commentDto.CommentId);

            var comment = _mapper.Map<CommentUpdateDto, Comment>(commentDto, obj);

            if (_unitOfWork.Comments.Update(comment) is null)
            {
                ModelState.AddModelError("", "Something Went Wrong When Updating The Record");
                return StatusCode(500, ModelState);
            }
            _unitOfWork.Complete();

            return Ok(_mapper.Map<CommentDto>(comment));
        }

        [HttpDelete("{commentId}", Name = "DeleteComment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult Delete(string commentId)
        {
            var comment = _unitOfWork.Comments.GetById(commentId);

            if (comment is null)
                return NotFound();

            if (_unitOfWork.Comments.Delete(comment) is null)
            {
                ModelState.AddModelError("", "Something Went Wrong When deleting The Record");
                return StatusCode(500, ModelState);
            }
            _unitOfWork.Complete();
            return NoContent();
        }

    }
}
