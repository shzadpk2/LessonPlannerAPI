using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LessonPlanner.Assemblers;
using LessonPlanner.Common.ResponseModel;
using LessonPlanner.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LessonPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonPlannerController : ControllerBase
    {
        private readonly ILogger<LessonPlannerController> _logger;
        private ILessonPlannerRepository _lessonPlannerRepository;
        private ISubjectRepository _subjectRepository;
        private IGradeRepository _gradeRepository;
        public LessonPlannerController(ILogger<LessonPlannerController> logger,
            ILessonPlannerRepository lessonPlannerRepository,
            ISubjectRepository subjectRepository,
            IGradeRepository gradeRepository
            )
        {
            _logger = logger;
            _lessonPlannerRepository = lessonPlannerRepository;
            _subjectRepository = subjectRepository;
            _gradeRepository = gradeRepository;
        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index() { return Ok("Index"); }

        [HttpGet]
        [Route("GetStringTest")]
        public async Task<ActionResult<string>> GetStringTest()
        {
            string result2 = await Task.Run(() => _lessonPlannerRepository.GetTestString());

            return result2;
        }

        [HttpGet]
        [Route("GetAllLessons")]
        public async Task<ActionResult<LessonPlannerResponseModel>> GetAllLessonPlanners()
        {
            LessonPlannerResponseModel lessonPlannerResponseModel = new LessonPlannerResponseModel();
            //lessonPlannerResponseModel = await Task.Run(() => _lessonPlannerRepository.GetAllLessonPlanners());
            lessonPlannerResponseModel = await Task.Run(() => _lessonPlannerRepository.GetAllLessonPlanners());

            return Ok(lessonPlannerResponseModel);
        }

        [HttpGet]
        [Route("GetAllLessonPlannersByGradeIDandSubjectID")]
        public async Task<ActionResult<LessonPlannerResponseModel>> GetAllLessonPlannersByGradeIDandSubjectID(long gradeID, long subjectID)
        {
            LessonPlannerResponseModel lessonPlannerResponseModel = new LessonPlannerResponseModel();
            //lessonPlannerResponseModel = await Task.Run(() => _lessonPlannerRepository.GetAllLessonPlanners());
            lessonPlannerResponseModel = await Task.Run(() => _lessonPlannerRepository.GetAllLessonPlannersByGradeIDandSubjectID(gradeID, subjectID));

            return Ok(lessonPlannerResponseModel);
        }

        [HttpGet]
        [Route("GetAllGrades")]
        public async Task<ActionResult<GradeResponseModel>> GetAllGrades()
        {
            GradeResponseModel gradeResponseModel = new GradeResponseModel();
            gradeResponseModel = await Task.Run(() => _gradeRepository.GetAllGrades());

            return Ok(gradeResponseModel);
        }

        [HttpGet]
        [Route("GetAllSubjects")]
        public async Task<ActionResult<SubjectResponseModel>> GetAllSubjects()
        {
            SubjectResponseModel subjectResponseModel = new SubjectResponseModel();
            subjectResponseModel = await Task.Run(() => _subjectRepository.GetAllSubjects());

            return Ok(subjectResponseModel);
        }


        [HttpGet]
        [Route("GetAllSubjectsByGradeID")]
        public async Task<ActionResult<SubjectResponseModel>> GetAllSubjectsByGradeID(long gradeID)
        {
            SubjectResponseModel subjectResponseModel = new SubjectResponseModel();
            subjectResponseModel = await Task.Run(() => _subjectRepository.GetAllSubjectsByGradeID(gradeID));

            return Ok(subjectResponseModel);
        }

        [HttpGet]
        [Route("GetAllSubTopicByMainTopicID")]
        public async Task<ActionResult<SubTopicResponseModel>> GetAllSubTopicByMainTopicID(long mainTopicID)
        {
            SubTopicResponseModel subTopicResponseModel = new SubTopicResponseModel();
            subTopicResponseModel = await Task.Run(() => _lessonPlannerRepository.GetAllSubTopicByMainTopicID(mainTopicID));

            return Ok(subTopicResponseModel);
        }

        [HttpGet]
        [Route("GetAllMovies")]
        public async Task<ActionResult<MoviesResponseModel>> GetAllMovies()
        {
            MoviesResponseModel moviesResponseModel = new MoviesResponseModel();
            moviesResponseModel = await Task.Run(() => _lessonPlannerRepository.GetAllMovies());

            return Ok(moviesResponseModel);
        }

        [HttpGet]
        [Route("GetAllDocumentaries")]
        public async Task<ActionResult<DocumentariesResponseModel>> GetAllDocumentaries()
        {
            DocumentariesResponseModel documentariesResponseModel = new DocumentariesResponseModel();
            documentariesResponseModel = await Task.Run(() => _lessonPlannerRepository.GetAllDocumentaries());

            return Ok(documentariesResponseModel);
        }

        [HttpGet]
        [Route("GetAllGames")]
        public async Task<ActionResult<GamesResponseModel>> GetAllGames()
        {
            GamesResponseModel gamesResponseModel = new GamesResponseModel();
            gamesResponseModel = await Task.Run(() => _lessonPlannerRepository.GetAllGames());

            return Ok(gamesResponseModel);
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public async Task<ActionResult<BooksResponseModel>> GetAllBooks()
        {
            BooksResponseModel booksResponseModel = new BooksResponseModel();
            booksResponseModel = await Task.Run(() => _lessonPlannerRepository.GetAllBooks());

            return Ok(booksResponseModel);
        }
    }
}