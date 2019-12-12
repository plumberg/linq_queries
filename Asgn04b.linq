<Query Kind="Program" />

/*
	Assignment 4
	Enter your name here: ________________
	Due Tuesday 3/26/19
	60 Points
*/

void Main()
{
	Student[] students = new Student[]
	{
		new Student("Mike Thompson", 3, true, "CS", new double[] { 3.4, 2.8, 3.9, 4.0, 3.77, 3.65 }),
		new Student("Len Peters", 2, true, "CS", new double[] { 2.6, 3.2, 3.1, 2.0, 3.1 }),
		new Student("Sara Calhoon", 1, false, "Accounting", new double[] { 2.1, 4.0, 3.5, 3.6, 3.77 }),
		new Student("Henry Long", 2, true, "CS", new double[] { 3.4, 4.0, 2.1, 2.2, 2.1, 2.6, 2.7 }),
		new Student("Friedrich Nelson", 2, true, "Accounting", new double[] { 1.5, 1.7, 1.66, 2.2, 1.0 }),
		new Student("Donald Rivet", 1, false, "Psychology", new double[] { 2.3, 3.9, 3.4, 3.55, 3.4 }),
		new Student("George Lank", 4, false, "Accounting", new double[] { 1.5, 1.8, 2.1, 2.2, 1.1 }),
		new Student("Martha Wing", 3, true, "Psychology", new double[] { 3.5, 3.6, 3.4, 3.6, 2.9, 3.2 }),
		new Student("Sally Kruth", 3, false, "CS", new double[] { 2.1, 3.9, 2.2, 2.4, 2.6 }),
		new Student("Leo Flute", 2, true, "CS", new double[] { 3.2, 3.9, 4.0, 4.0, 3.77 }),
		new Student("Mitch Walters", 1, true, "Psychology", new double[] { 2.3, 2.9, 2.1, 2.2, 2.2, 2.0 }),
		new Student("Kelly Samuels", 3, false, "CS", new double[] { 2.4, 2.8, 2.2, 2.8, 2.8, 3.0 }),
		new Student("Jerry Hop", 4, false, "Accounting", new double[] { 3.45, 2.25, 2.75, 2.99 }),
		new Student("Jenny Latoon", 3, true, "Accounting", new double[] { 1.5, 1.77, 2.01, 1.88 }),
		new Student("Candice Kalwater", 2, true, "CS", new double[] { 4.0, 4.0, 4.0, 3.99, 3.88, 4.0 }),
		new Student("Sam Mitchel", 3, false, "CS", new double[] { 2.9, 3.01, 3.2, 3.3, 2.8, 3.2 })
	};
	
	/* Question 1
	   Use the GroupBy extension method with a lambda expression to group all students by their Year property
	   and then display the number of students with financial aid and the number of students without for each group.
	   
	   CORRECT OUTPUT (order may vary):
	   ********************************
	   Year 3 has 3 students on financial aid, and 3 students not on financial aid.
	   Year 2 has 5 students on financial aid, and 0 students not on financial aid.
	   Year 1 has 1 students on financial aid, and 2 students not on financial aid.
	   Year 4 has 0 students on financial aid, and 2 students not on financial aid.  
	   
	*/
			 var s = students.GroupBy(x => x.Year).Select(y => new
            {
                Year = y.Key,
                HasAid = y.Where(g => g.FinancialAid == true).Select(g => g).Count(),
                NoAid = y.Where(g => g.FinancialAid == false).Select(g => g).Count()             
            });

            foreach (var has in s)
            {
                Console.WriteLine("Year " + has.Year +" has " + has.HasAid +" students on financial aid, and "
       			+ has.NoAid +" students not on financial aid.");
            }
            Console.WriteLine();
	
	/* Question 2
	   Use the GroupBy entension method with a lambda expression to get all students into groups based on how
	   many elements there are in their "Grades" property array. Note, you may have to use the Length property
	   for this, Count may not work.
	   	   
	   CORRECT OUTPUT (order may vary):
	   ********************************
		Students with 6 grades:
		Mike Thompson
		Martha Wing
		Mitch Walters
		Kelly Samuels
		Candice Kalwater
		Sam Mitchel
		Students with 5 grades:
		Len Peters
		Sara Calhoon
		Friedrich Nelson
		Donald Rivet
		George Lank
		Sally Kruth
		Leo Flute
		Students with 7 grades:
		Henry Long
		Students with 4 grades:
		Jerry Hop
		Jenny Latoon	  
	*/
	var s2 = students.GroupBy(x => x.Grades.Length).Select(x => new
            {
				Grades = x.Key,
                Name = x.Select(g => g.FullName).ToList()
            });
     
            foreach (var has in s2)
            {
                Console.WriteLine("Students with " + has.Grades + " grades:");
                Console.WriteLine(has.Name);
               
            }
	Console.WriteLine();
	
	/* Question 3a
	   Use GroupBy with a lambda expression to group all students by their GPA which is the avearge of the 
	   elements in their Grades property array (Note that you can use an extension method to get this value, 
	   you should not need to do the math manually).
	   
	   As you will see, this is not very useful because there are no two students with the same GPA. You will
	   improve on this in the next question.
	   	   
	   CORRECT OUTPUT (order may vary):
	   ********************************	   
		Students with 3.58666666666667 gpa:
			Mike Thompson
		Students with 2.8 gpa:
			Len Peters
		Students with 3.394 gpa:
			Sara Calhoon
		Students with 2.72857142857143 gpa:
			Henry Long
		Students with 1.612 gpa:
			Friedrich Nelson
		Students with 3.31 gpa:
			Donald Rivet
		Students with 1.74 gpa:
			George Lank
		Students with 3.36666666666667 gpa:
			Martha Wing
		Students with 2.64 gpa:
			Sally Kruth
		Students with 3.774 gpa:
			Leo Flute
		Students with 2.28333333333333 gpa:
			Mitch Walters
		Students with 2.66666666666667 gpa:
			Kelly Samuels
		Students with 2.86 gpa:
			Jerry Hop
		Students with 1.79 gpa:
			Jenny Latoon
		Students with 3.97833333333333 gpa:
			Candice Kalwater
		Students with 3.06833333333333 gpa:
			Sam Mitchel
	*/
	var s3 = students.GroupBy(x => x.Grades.Average()).Select(x => new
            {
				Aver = x.Key,
                Name = x.Select(g => g.FullName).ToList()
            });
            foreach (var sgroup in s3)
            { 
                Console.WriteLine("Students with " + sgroup.Aver + " gpa:");
                Console.WriteLine(sgroup.Name);
            } 
            Console.WriteLine();
			
	
	/* Question 3b
	   Improve on the last question by grouping the students according to the their rounded GPA. You will use
	   the Math.Round function for this. For example, Math.Round(3.2) evaluates to 3.0. So students will all
	   fall neatly into categories of 4, 3, and 2.
	   
	   CORRECT OUTPUT (order may vary):
	   ********************************
	   	Students with 4 gpa:
			Mike Thompson
			Leo Flute
			Candice Kalwater
		Students with 3 gpa:
			Len Peters
			Sara Calhoon
			Henry Long
			Donald Rivet
			Martha Wing
			Sally Kruth
			Kelly Samuels
			Jerry Hop
			Sam Mitchel
		Students with 2 gpa:
			Friedrich Nelson
			George Lank
			Mitch Walters
			Jenny Latoon	   
	*/
		    var s3b = students.GroupBy(x => new
            {
                Aver = Math.Round(x.Grades.Average())
            }).Select(x => new
            {
                Name = x.Select(g => g.FullName),
                Aver = x.Key.Aver
            });
			
			foreach (var sgroup in s3b)
            {    
                Console.WriteLine("Students with " + sgroup.Aver + " gpa:");
                Console.WriteLine(sgroup.Name);
            } 
            Console.WriteLine();
	
	/* Question 4
	   Use the ForEach extension method to display the full name of all students with a GPA above 3.0.
	   Make sure you use the ForEach method, do NOT enumerate the collection with a separate foreach loop.
	   
	   CORRECT OUTPUT (order may vary):
	   ********************************
	    Mike Thompson
		Sara Calhoon
		Donald Rivet
		Martha Wing
		Leo Flute
		Candice Kalwater
		Sam Mitchel
	*/
	students.GroupBy(x => x.Grades.Average()>3).Select(x => new
            {
                Name = x.Where(y=>y.Grades.Average()>3).Select(g => g.FullName)
            }).ToList().ForEach(
                x => { Console.WriteLine(x.Name); }
              );
	
	/* Question 5 
	   Use the SelectMany extension method to get a collection of all students' grades, then display the average
	   of all of these numbers
	   
	   CORRECT OUTPUT:
	   ***************
       The avearge of all grades for all students is: 2.88081395348837	   
	*/ 
	var allgrades = students.SelectMany(x => x.Grades).Average();
            Console.WriteLine("The average of all grades for all students is: " + allgrades);
            Console.WriteLine();
	
	/* Question 6
	   Use SelectMany and ForEach to display the rounded off grade of all elements of all Grade
	   arrays, in ascending order, with a space after each one. Again, make sure to use the ForEach
	   method and not to enumerate the collection with a separate foreach loop.
	   
	   CORRECT OUTPUT:
	   ********************************
	   1 1 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 
	*/
	students.SelectMany(x => x.Grades).OrderBy(x=>x).ToList().ForEach(
                x=> { Console.Write(Math.Round(x)+ " "); });
	
}

// Define other methods and classes here
class Student
{
	public string FullName { get; set; }
	public int Year { get; set; }
	public bool FinancialAid { get; set; }
	public string Major { get; set; }
	public double[] Grades { get; set; }
	
	public Student(string fullName, int year, bool financialAid, string major, double[] grades)
	{
		FullName = fullName; Year = year; FinancialAid = financialAid; Major = major; Grades = grades;
	}
}