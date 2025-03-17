using WApp.Application.DTO;
using WApp.Domain.Interfaces;



namespace WApp.Application.Use_Cases
{
    public class GetSubjectUseCase
    {
        private readonly ISubjectRepository _repository;

        public GetSubjectUseCase(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SubjectDto>> Execute (int stream , int year)
        {
          
            return await _repository.GetSubjectAsync(stream, year);
        }
    }
}
