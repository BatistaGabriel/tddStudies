using Bogus;
using ExpectedObjects;
using OnlineCourses.Domain.Test._Builder;
using System;
using Xunit;
using Xunit.Abstractions;

namespace OnlineCourses.Domain.Test.Courses
{
	public class CoursesTest : IDisposable
	{
		private readonly ITestOutputHelper _output;
		private readonly string _courseName;
		private readonly double _courseHours;
		private readonly CoursePublic _coursePublic;
		private readonly double _coursePrice;
		private readonly Faker _faker;

		/// <summary>
		/// Startup.
		/// </summary>
		public CoursesTest(ITestOutputHelper output)
		{
			_faker = new Faker();

			_output = output;
			_output.WriteLine("Startup executed!");

			_courseName = _faker.Random.Words();
			_courseHours = _faker.Random.Double(10, 500);
			_coursePublic = CoursePublic.Student;
			_coursePrice = _faker.Random.Double(100, 1000);

		}
		
		/// <summary>
		/// User Story:
		/// <para />As an Administrator I want to create and edit new courses to get new registrations to it.
		/// <para />
		/// Acceptance Criteria: 
		/// <para />- Create a course with a name, amount of hours, public and price.
		/// <para />- The public should be: Student, University Student, Employee or Executive.
		/// <para />- All fields are required.
		/// </summary>
		[Fact(DisplayName = "Should Create a Course")]
		public void ShouldCreateACourse()
		{
			// Arrange
			var expectedCourse = new 
			{
				Name = (string)_courseName,
				Hours = (double)_courseHours,
				Public = _coursePublic,
				Price = (double)_coursePrice
			};

			// Act
			var course = new Course(expectedCourse.Name, expectedCourse.Hours, expectedCourse.Public, expectedCourse.Price);

			// Assert
			expectedCourse
				.ToExpectedObject()
				.ShouldMatch(course);
		}

		/// <summary>
		/// User Story:
		/// <para />As an Administrator I want to create and edit new courses to get new registrations to it.
		/// <para />
		/// Acceptance Criteria: 
		/// <para />- A Course can not be created within a empty or null value for the name.
		/// </summary>
		[Theory(DisplayName = "Course Name Should Not Be Invalid")]
		[InlineData("")]
		[InlineData(null)]
		public void CourseNameShouldNotBeInvalid(string invalidCourseName) 
		{
			// Arrange

			// Act

			// Assert
			Assert.Throws<ArgumentException>(() => 
				CourseBuilder
				.NewCourseBuilder()
				.CreateWithName(invalidCourseName)
				.Build()
			);
		}

		/// <summary>
		/// User Story:
		/// <para />As an Administrator I want to create and edit new courses to get new registrations to it.
		/// <para />
		/// Acceptance Criteria: 
		/// <para />- A Course can not have the amount of hours less then an hour of duration.
		/// </summary>
		[Theory(DisplayName = "Course Name Should Not Be Less Then One Hour")]
		[InlineData(0)]
		[InlineData(-2)]
		[InlineData(-100)]
		public void CourseHoursShouldNotBeLessThenOneHour(double invalidCourseHours)
		{
			// Arrange

			// Act

			// Assert
			Assert.Throws<ArgumentException>(() => 
				CourseBuilder
				.NewCourseBuilder()
				.CreateWithHours(invalidCourseHours)
				.Build()
			);
		}

		/// <summary>
		/// User Story:
		/// <para />As an Administrator I want to create and edit new courses to get new registrations to it.
		/// <para />
		/// Acceptance Criteria: 
		/// <para />- A Course can not have the price equals or less then zero.
		/// </summary>
		[Theory(DisplayName = "Course Price Should Not Be Equals or Less Then Zero")]
		[InlineData(0)]
		[InlineData(-2)]
		[InlineData(-100)]
		public void CoursePriceShouldNotBeLessThenZero(double invalidCoursePrice)
		{
			// Arrange

			// Act

			// Assert
			Assert.Throws<ArgumentException>(() => 
				CourseBuilder
				.NewCourseBuilder()
				.CreateWithPrice(invalidCoursePrice)
				.Build()
			);
		}

		/// <summary>
		/// Cleanup
		/// </summary>
        public void Dispose()
        {
			_output.WriteLine("Cleanup executed!");
        }
    }

	/// <summary>
	/// Enumerator used to handle the public for the courses.
	/// </summary>
	public enum CoursePublic 
	{
		Student, 
		UniversityStudent, 
		Employee,
		Executive
	}

	public class Course
	{
		public Course(string courseName, double courseHours, CoursePublic coursePublic, double coursePrice)
		{
			if (string.IsNullOrEmpty(courseName))
				throw new ArgumentException(message: "A course can not be created within a invalid name!");

			if (courseHours < 1)
				throw new ArgumentException(message: "A course can not be created with less then one hour of duration!");

			if (coursePrice <= 0)
				throw new ArgumentException(message: "A course can not be created with the price equals or less then zero!");

			this.Name = courseName;
			this.Hours = courseHours;
			this.Public = coursePublic;
			this.Price = coursePrice;
		}

		public string Name { get; private set; }
		public double Hours { get; private set; }
		public CoursePublic Public { get; private set; }
		public double Price { get; private set; }
	}
}
