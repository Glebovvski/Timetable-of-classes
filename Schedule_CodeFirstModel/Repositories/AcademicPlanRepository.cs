﻿using Schedule_CodeFirstModel.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace Schedule_CodeFirstModel.Models
{
    public class AcademicPlanRepository:IRepository<AcademicPlan>
    {
        private string connectionString;
        private SqlConnection connection;
        public AcademicPlanRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ScheduleContext"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        
        public void Create(AcademicPlan data)
        {
            SqlCommand addNewAcademPlan = new SqlCommand("AddAcademicPlan", connection);
            addNewAcademPlan.CommandType = CommandType.StoredProcedure;

            addNewAcademPlan.Parameters.Add(new SqlParameter("@SemestreId", SqlDbType.Int));
            addNewAcademPlan.Parameters["@SemestreId"].Value = data.SemestreId;

            addNewAcademPlan.Parameters.Add(new SqlParameter("@SpecialityId", SqlDbType.Int));
            addNewAcademPlan.Parameters["@SpecialityId"].Value = data.SpecialityId;

            addNewAcademPlan.Parameters.Add(new SqlParameter("@SubjectId", SqlDbType.Int));
            addNewAcademPlan.Parameters["@SubjectId"].Value = data.SubjectId;

            using (connection)
            {
                connection.Open();
                addNewAcademPlan.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            SqlCommand delete = new SqlCommand("DeleteAcademicPlan", connection);
            delete.CommandType = CommandType.StoredProcedure;

            delete.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
            delete.Parameters["@Id"].Value = id;

            using (connection)
            {
                connection.Open();
                delete.ExecuteNonQuery();
            }
        }

        public List<AcademicPlan> Read()
        {
            List<AcademicPlan> academicPlans = new List<AcademicPlan>();
            SqlCommand readplan = new SqlCommand("GetAcademicPlan", connection);
            readplan.CommandType = CommandType.StoredProcedure;

            using(SqlDataReader reader = readplan.ExecuteReader())
            {
                if (reader.Read())
                {
                    academicPlans.Add(new AcademicPlan(){
                        Id = int.Parse(reader["Id"].ToString()),
                        SemestreId = int.Parse(reader["SemestreId"].ToString()),
                        SpecialityId = int.Parse(reader["SpecialityId"].ToString()),
                        SubjectId = int.Parse(reader["SubjectId"].ToString()),
                        Semestre = new Semestre()
                        {
                            Id = int.Parse(reader["SemestreId"].ToString()),
                            Number = int.Parse(reader["Number"].ToString()),
                        },
                        Speciality = new Speciality()
                        {
                            Id=int.Parse(reader["SpecialityId"].ToString()),
                            Name=reader["Name"].ToString()
                        },
                        Subject = new Subject()
                        {
                            Id=int.Parse(reader["SubjectId"].ToString()),
                            TeacherId = int.Parse(reader["TeacherId"].ToString()),
                            SubjectName = reader["SubjectName"].ToString()
                        }
                    });
                }
            }
            return academicPlans;
        }

        public AcademicPlan Read(int id)
        {
            SqlCommand readplan = new SqlCommand("GetAcademicPlanById", connection);
            readplan.CommandType = CommandType.StoredProcedure;
            readplan.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
            readplan.Parameters["@Id"].Value = id;
            AcademicPlan plan = null;
            using (SqlDataReader reader = readplan.ExecuteReader())
            {
                if (reader.Read())
                {
                    plan = new AcademicPlan()
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        SemestreId = int.Parse(reader["SemestreId"].ToString()),
                        SpecialityId = int.Parse(reader["SpecialityId"].ToString()),
                        SubjectId = int.Parse(reader["SubjectId"].ToString()),
                        Semestre = new Semestre()
                        {
                            Id = int.Parse(reader["SemestreId"].ToString()),
                            Number = int.Parse(reader["Number"].ToString()),
                        },
                        Speciality = new Speciality()
                        {
                            Id = int.Parse(reader["SpecialityId"].ToString()),
                            Name = reader["Name"].ToString()
                        },
                        Subject = new Subject()
                        {
                            Id = int.Parse(reader["SubjectId"].ToString()),
                            TeacherId = int.Parse(reader["TeacherId"].ToString()),
                            SubjectName = reader["SubjectName"].ToString()
                        }
                    };
                }
                return plan;
            }
            
        }

        public void Update(AcademicPlan data)
        {
            SqlCommand readplan = new SqlCommand("UpdateAcademicPlan", connection);
            readplan.CommandType = CommandType.StoredProcedure;
            readplan.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
            readplan.Parameters["@Id"].Value = data.Id;

            readplan.Parameters.Add(new SqlParameter("@SpecId", SqlDbType.Int));
            readplan.Parameters["@SpecId"].Value = data.SpecialityId;

            readplan.Parameters.Add(new SqlParameter("@SemestreId", SqlDbType.Int));
            readplan.Parameters["@SemestreId"].Value = data.SemestreId;

            readplan.Parameters.Add(new SqlParameter("@SubjectId", SqlDbType.Int));
            readplan.Parameters["@SubjectId"].Value = data.SemestreId;

            using (connection)
            {
                readplan.ExecuteNonQuery();
            }
        }
    }
}