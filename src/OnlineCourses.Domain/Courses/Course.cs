using System;

namespace OnlineCourses.Domain.Courses
{
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