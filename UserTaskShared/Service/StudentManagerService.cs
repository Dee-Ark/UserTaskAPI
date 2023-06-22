using UserTaskShared.DTO;
using UserTaskShared.DTO.UserRequest;
using UserTaskShared.DTO.UserResponse;
using UserTaskShared.Model;
using UserTaskShared.Respository.UnitofWork;
using UserTaskShared.Service.IService;

namespace UserTaskShared.Service
{
    public class StudentManagerService : IStudentManagerService
    {
        private readonly IUnitOfWork _unitOfWork;


        public StudentManagerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Response> SubmitStudentDetails(StudentRequest request)
        {
            var response = new Response(hasError: true, responseCode: ResponseCode.INVALID_STUDENT_DETAILS);
            try
            {
                if (String.IsNullOrEmpty(request.Surname) || 
                    String.IsNullOrEmpty(request.Name) || 
                    String.IsNullOrEmpty(request.StudentNumber))
                {
                    return new Response
                    {
                        ResponseCode = ResponseCode.INVALID_STUDENT_DETAILS,
                        ResponseMessage = "All Students Details are required"
                    };
                }
                else
                {
                    var studentDetails = new Student()
                    {
                        Surname = request.Surname,
                        Name = request.Name,
                        StudentNumber = request.StudentNumber,
                        DateofBirth = request.DateofBirth,
                        NationalID = (int)(string.IsNullOrEmpty(request.NationalID.ToString()) ? (int?)null : int.Parse(request.NationalID.ToString())),
                    };


                    //Save Student Details to db
                    await _unitOfWork.StudentDetailsRepository.AddAsync(studentDetails);
                    await _unitOfWork.SaveAsync();
                }
                
                return new Response
                {
                    HasError = false,
                    ResponseCode = "00",
                    ResponseMessage = "Successful",
                    Data = new InitializeStudentResponseData
                    {
                        Surname = request.Surname,
                        Name = request.Name,
                        StudentNumber = request.StudentNumber,
                        DateofBirth = request.DateofBirth,
                        NationalID = request.NationalID
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
