using Moq;
using OnlineCourses.Domain.Courses;
using Xunit;

namespace OnlineCourses.Domain.Test.Courses
{
    public class CoursesCareTakerTest
    {
        [Fact]
        public void MustAddCourse()
        {
            var courseDto = new CourseDto
            {
                Name = "New Course",
                Hours = 80,
                PublicId = 1,
                Price = 200
            };

            var courseRepositoryMock = new Mock<ICourseRepository>();

            var courseCareTaker = new CoursesCareTaker(courseRepositoryMock.Object);
            courseCareTaker.Store(courseDto);

            courseRepositoryMock.Verify(r => r.Add(It.IsAny<Course>()));
        }
    }

    public interface ICourseRepository
    {
        void Add(Course course);
    }

    public class CoursesCareTaker
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesCareTaker(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void Store(CourseDto courseDto)
        {
            var course = new Course(
                courseDto.Name,
                courseDto.Hours,
                CoursePublic.Student,
                courseDto.Price
            );

            _courseRepository.Add(course);
        }
    }

    public class CourseDto
    {
        public string Name { get; set; }
        public double Hours { get; set; }
        public int PublicId { get; set; }
        public double Price { get; set; }
    }
}