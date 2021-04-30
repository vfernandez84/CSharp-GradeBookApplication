using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks {
    public class RankedGradeBook : BaseGradeBook {
        public RankedGradeBook(string name) : base(name) {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) {
            if (Students.Count < 5) {
                throw new InvalidOperationException();
            }

            var segment = Students.Count / 5;

            IList<double> grades = new List<double>();

            foreach (Student student in Students) {
                grades.Add(student.AverageGrade);
            }

            grades.OrderByDescending(c => c);

            int rank = 0;

            for (int pos = 0; grades[pos] > averageGrade; pos++) {
                rank++;
            }

            if (rank < segment) {
                return 'A';
            }
            else if (rank < segment * 2) {
                return 'B';
            }
            else if (rank < segment * 3) {
                return 'C';
            }
            else if (rank < segment * 4) {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics() {
            if (Students.Count < 5) {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name) {
            if (Students.Count < 5) {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else {
                base.CalculateStudentStatistics(name);
            }
        }

    }
}



