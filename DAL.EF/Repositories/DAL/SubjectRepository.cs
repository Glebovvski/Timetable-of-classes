using Schedule_CodeFirstModel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Repositories
{
    public class SubjectRepository : IRepository<Subject>
    {
        private string connectionString;
        private SqlConnection connection;
        public SubjectRepository()
        {
            connectionString = "Data Source=DESKTOP-50OOFA6;Initial Catalog=ScheduleDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connection = new SqlConnection(connectionString);
        }

        public void Create(Subject data)
        {
            SqlCommand newSubject = new SqlCommand("AddSubject", connection);
            newSubject.CommandType = CommandType.StoredProcedure;

            newSubject.Parameters.Add(new SqlParameter("@SubjectName", SqlDbType.VarChar,100));
            newSubject.Parameters["@SubjectName"].Value = data.SubjectName;

            newSubject.Parameters.Add(new SqlParameter("@TeacherId", SqlDbType.Int));
            newSubject.Parameters["@TeacherId"].Value = data.TeacherId;

            using (connection)
            {
                connection.Open();
                newSubject.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            SqlCommand delete = new SqlCommand("DeleteSubject", connection);
            delete.CommandType = CommandType.StoredProcedure;

            delete.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
            delete.Parameters["@Id"].Value = id;

            using (connection)
            {
                connection.Open();
                delete.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Subject> Read()
        {
            connectionString = "Data Source=DESKTOP-50OOFA6;Initial Catalog=ScheduleDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connection = new SqlConnection(connectionString);
            List<Subject> subjects = new List<Subject>();
            SqlCommand readplan = new SqlCommand("GetSubjects", connection);
            readplan.CommandType = CommandType.StoredProcedure;
            using (connection)
            {
                connection.Open();
                using (SqlDataReader reader = readplan.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        subjects.Add(new Subject()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            SubjectName = reader["SubjectName"].ToString(),
                            Teacher = new Teacher()
                            {
                                Id = int.Parse(reader["TeacherId"].ToString()),
                                Name = reader["Name"].ToString()
                            }
                        });
                    }
                }
                connection.Close();
                return subjects;
            }
        }

        public Subject Read(int id)
        {
            connectionString = "Data Source=DESKTOP-50OOFA6;Initial Catalog=ScheduleDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connection = new SqlConnection(connectionString);
            SqlCommand readplan = new SqlCommand("GetSubjectById", connection);
            readplan.CommandType = CommandType.StoredProcedure;
            readplan.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
            readplan.Parameters["@Id"].Value = id;
            Subject plan = null;
            using (connection)
            {
                connection.Open();
                using (SqlDataReader reader = readplan.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        plan = new Subject()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            TeacherId = int.Parse(reader["TeacherId"].ToString()),
                            SubjectName = reader["SubjectName"].ToString(),
                            Teacher = new Teacher()
                            {
                                Id = int.Parse(reader["TeacherId"].ToString()),
                                Name = reader["Name"].ToString()
                            }
                        };
                    }
                    connection.Close();
                    return plan;
                }
            }
        }

        public void Update(Subject data)
        {
            connectionString = "Data Source=DESKTOP-50OOFA6;Initial Catalog=ScheduleDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connection = new SqlConnection(connectionString);
            SqlCommand readplan = new SqlCommand("UpdateSubject", connection);
            readplan.CommandType = CommandType.StoredProcedure;
            readplan.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
            readplan.Parameters["@Id"].Value = data.Id;

            readplan.Parameters.Add(new SqlParameter("@SubjectName", SqlDbType.VarChar, 100));
            readplan.Parameters["@SubjectName"].Value = data.SubjectName;
            
            readplan.Parameters.Add(new SqlParameter("@TeacherId", SqlDbType.Int));
            readplan.Parameters["@TeacherId"].Value = data.TeacherId;

            using (connection)
            {
                connection.Open();
                readplan.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Subject> GetSubjectsForUniversity(int id)
        {
            SqlCommand readplan = new SqlCommand("GetSubjectsForUniversity", connection);
            readplan.CommandType = CommandType.StoredProcedure;
            readplan.Parameters.Add(new SqlParameter("@univerId", SqlDbType.Int));
            readplan.Parameters["@univerId"].Value = id;
            List<Subject> subjects = new List<Subject>();

            using (connection)
            {
                connection.Open();
                using (SqlDataReader reader = readplan.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        subjects.Add(new Subject()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            SubjectName = reader["SubjectName"].ToString(),
                            Teacher = new Teacher()
                            {
                                Id = int.Parse(reader["TeacherId"].ToString()),
                                Name = reader["Name"].ToString()
                            }
                        });
                    }
                }
                connection.Close();
                return subjects;
            }
        }
    }
}