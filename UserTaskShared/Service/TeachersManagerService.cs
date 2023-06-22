using UserTaskShared.DTO.UserRequest;
using UserTaskShared.DTO.UserResponse;
using UserTaskShared.DTO;
using UserTaskShared.Model;
using UserTaskShared.Respository.UnitofWork;
using UserTaskShared.Service.IService;

namespace UserTaskShared.Service
{
    public class TeachersManagerService : ITeachersManagerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeachersManagerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> SubmitTeacherDetails(TeacherRequest request)
        {
            var response = new Response(hasError: true, responseCode: ResponseCode.INVALID_STUDENT_DETAILS);
            try
            {
                if (string.IsNullOrEmpty(request.Surname) ||
                    string.IsNullOrEmpty(request.Name) ||
                    string.IsNullOrEmpty(request.TeacherNumber) ||
                    string.IsNullOrEmpty(request.Title))
                {
                    return new Response
                    {
                        ResponseCode = ResponseCode.INVALID_TEACHER_DETAILS,
                        ResponseMessage = "All Teacher Details are required"
                    };
                }

                var teachersDetails = new Teacher()
                {
                    Title = request.Title,
                    Surname = request.Surname,
                    Name = request.Name,
                    TeacherNumber = request.TeacherNumber,
                    DateofBirth = request.DateofBirth,
                    NationalID = (int)(string.IsNullOrEmpty(request.NationalID.ToString()) ? (int?)null : int.Parse(request.NationalID.ToString())),
                    Salary = request.Salary
                };

                // Save Teachers details to db
                await _unitOfWork.TeachersDetailsRepository.AddAsync(teachersDetails);
                await _unitOfWork.SaveAsync();

                return new Response
                {
                    HasError = false,
                    ResponseCode = "00",
                    ResponseMessage = "Successful",
                    Data = new InitializeTeachersResponseData
                    {
                        Title = request.Title,
                        Surname = request.Surname,
                        Name = request.Name,
                        TeacherNumber = request.TeacherNumber,
                        DateofBirth = request.DateofBirth,
                        NationalID = request.NationalID,
                        Salary = request.Salary
                    }
                };
            }
            catch (Exception ex)
            {
                return response;
            }
        }
    }
}
