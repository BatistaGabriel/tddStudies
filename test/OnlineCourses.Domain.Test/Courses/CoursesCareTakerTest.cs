using Bogus;
using Moq;
using OnlineCourses.Domain.Courses;
using Xunit;

namespace OnlineCourses.Domain.Test.Courses
{
    public class CoursesCareTakerTest
    {
        private readonly CourseDto _courseDto;
        private readonly CoursesCareTaker _courseCareTaker;
        private readonly Mock<ICourseRepository> _courseRepositoryMock;

        public CoursesCareTakerTest()
        {
            var faker = new Faker();
            _courseDto = new CourseDto
            {
                Name = faker.Random.Words(),
                Hours = faker.Random.Double(10, 1000),
                PublicId = 1,
                Price = faker.Random.Double(10, 1000)
            };

            _courseRepositoryMock = new Mock<ICourseRepository>();
            _courseCareTaker = new CoursesCareTaker(_courseRepositoryMock.Object);
        }

        [Fact(DisplayName = "Must Add a Course Based on the Dto")]
        public void MustAddCourse()
        {
            _courseCareTaker.Store(_courseDto);

            _courseRepositoryMock.Verify(r => r.Add(It.Is<Course>(
                        c => c.Name == _courseDto.Name &&
                        c.Hours == _courseDto.Hours &&
                        c.Price == _courseDto.Price
                    )
                )
            );
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