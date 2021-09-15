using OnlineCourses.Domain.Test.Courses;

namespace OnlineCourses.Domain.Test._Builder
{
    public class CourseBuilder
    {
        private string _courseName = "TDD Using XUNIT";
		private double _courseHours = 80;
		private CoursePublic _coursePublic = CoursePublic.Student;
		private double _coursePrice = 950;

        public static CourseBuilder NewCourseBuilder()
        {
            return new CourseBuilder();
        }

        public CourseBuilder CreateWithName(string courseName)
        {
            _courseName = courseName;
            return this;
        }
        
        public CourseBuilder CreateWithHours(double courseHours)
        {
            _courseHours = courseHours;
            return this;
        }
        
        public CourseBuilder CreateWithPublic(CoursePublic coursePublic)
        {
            _coursePublic = coursePublic;
            return this;
        }
        
        public CourseBuilder CreateWithPrice(double coursePrice)
        {
            _coursePrice = coursePrice;
            return this;
        }

        public Course Build()
        {
            return new Course(
                _courseName,
                _courseHours,
                _coursePublic,
                _coursePrice
            );
        }
    }
}