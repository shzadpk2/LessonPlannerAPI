using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LessonPlanner.Common.ResponseModel;
using LessonPlanner.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LessonPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizMakerController : ControllerBase
    {
        private readonly ILogger<QuizMakerController> _logger;
        private IQuizMakerRepository _quizMakerRepository;
        public QuizMakerController(ILogger<QuizMakerController> logger,
            IQuizMakerRepository quizMakerRepository
            )
        {
            _logger = logger;
            _quizMakerRepository = quizMakerRepository;
        }

        [HttpGet]
        [Route("GetAllQuizMakers")]
        public async Task<ActionResult<QuizMakerResponseModel>> GetAllQuizMakers()
        {
            QuizMakerResponseModel quizMakerResponseModel = new QuizMakerResponseModel();
            quizMakerResponseModel = await Task.Run(() => _quizMakerRepository.GetAllQuizMakers());

            return Ok(quizMakerResponseModel);
        }

        [HttpGet]
        [Route("GetQuizMakerTopicNumberDetail")]
        public async Task<ActionResult<QuizMakerTopicNumberDetailResponseModel>> GetQuizMakerTopicNumberDetail(long gradeID, long subjectID)
        {
            QuizMakerTopicNumberDetailResponseModel quizMakerTopicNumberDetailResponseModel = new QuizMakerTopicNumberDetailResponseModel();
            quizMakerTopicNumberDetailResponseModel = await Task.Run(() => _quizMakerRepository.GetQuizMakerTopicNumberDetail(gradeID,subjectID));

            return Ok(quizMakerTopicNumberDetailResponseModel);
         
        }

        [HttpGet]
        [Route("GetAllQuizMakersByMainTopicID")]
        public async Task<ActionResult<QuizMakerResponseModel>> GetAllQuizMakersByMainTopicID(long mainTopicID)
        {
            QuizMakerResponseModel quizMakerResponseModel = new QuizMakerResponseModel();
            quizMakerResponseModel = await Task.Run(() => _quizMakerRepository.GetAllQuizMakersByMainTopicID(mainTopicID));

            return Ok(quizMakerResponseModel);
        }

        [HttpGet]
        [Route("GetAllQuizMakersBySubTopicID")]
        public async Task<ActionResult<QuizMakerResponseModel>> GetAllQuizMakersBySubTopicID(long subTopicID)
        {
            QuizMakerResponseModel quizMakerResponseModel = new QuizMakerResponseModel();
            quizMakerResponseModel = await Task.Run(() => _quizMakerRepository.GetAllQuizMakersBySubTopicID(subTopicID));

            return Ok(quizMakerResponseModel);
        }

        [HttpGet]
        [Route("GetMaxQuixNumber")]
        public async Task<ActionResult<long>> GetMaxQuixNumber(long gradeID, long subjectID, string topicNumber)
        {
            long quizNumber = 0;
            quizNumber = await Task.Run(() => _quizMakerRepository.GetMaxQuixNumber(gradeID, subjectID, topicNumber));

            return Ok(quizNumber);
        }

        [HttpGet]
        [Route("GetAllMultipleQuestionsByQuizMakerID")]
        public async Task<ActionResult<MultipleQuestionResponseModel>> GetAllMultipleQuestionsByQuizMakerID(long quizMakerID)
        {
            MultipleQuestionResponseModel multipleQuestionResponseModel = new MultipleQuestionResponseModel();
            multipleQuestionResponseModel = await Task.Run(() => _quizMakerRepository.GetAllMultipleQuestionsByQuizMakerID(quizMakerID));

            return Ok(multipleQuestionResponseModel);
        }

        [HttpGet]
        [Route("GetAllTrueFalseQuestionsByQuizMakerID")]
        public async Task<ActionResult<TrueFalseQuestionResponseModel>> GetAllTrueFalseQuestionsByQuizMakerID(long quizMakerID)
        {
            TrueFalseQuestionResponseModel trueFalseQuestionResponseModel = new TrueFalseQuestionResponseModel();
            trueFalseQuestionResponseModel = await Task.Run(() => _quizMakerRepository.GetAllTrueFalseQuestionsByQuizMakerID(quizMakerID));

            return Ok(trueFalseQuestionResponseModel);
        }

        [HttpGet]
        [Route("GetAllFillBlankQuestionsByQuizMakerID")]
        public async Task<ActionResult<FillBlankQuestionResponseModel>> GetAllFillBlankQuestionsByQuizMakerID(long quizMakerID)
        {
            FillBlankQuestionResponseModel fillBlankQuestionResponseModel = new FillBlankQuestionResponseModel();
            fillBlankQuestionResponseModel = await Task.Run(() => _quizMakerRepository.GetAllFillBlankQuestionsByQuizMakerID(quizMakerID));

            return Ok(fillBlankQuestionResponseModel);
        }
    }
}
