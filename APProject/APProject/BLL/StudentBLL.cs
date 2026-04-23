using System.Data;
using APProject.DAL;

namespace APProject.BLL
{
    public class StudentBLL
    {
        StudentDAL dal = new StudentDAL();

        // ADD STUDENT
        public void AddStudent(string name, string email, string phone)
        {
            dal.AddStudent(name, email, phone);
        }

        // GET STUDENTS
        public DataTable GetStudents()
        {
            return dal.GetStudents();
        }
    }
}