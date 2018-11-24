﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace AuditWFA
{
    public class Courses
    {
        //private string fileWithCourses = "C:\\Users\\aNs\\Documents\\Visual Studio 2015\\Projects\\Audit\\AuditWFA\\DataBase\\ФЕЕИТ\\ПЗАС";
        //private string FacultiesDirectory = "C:\\Users\\aNs\\Documents\\Visual Studio 2015\\Projects\\Audit\\AuditWFA\\DataBase";
        private string FacultiesDirectory = "D:\\User\\Desktop\\Audit-master\\AuditWFA\\DataBase";
        List<string> courses;

        public Courses()
        {
            this.courses = new List<string>();
        }

        public Courses(List<string> courses)
        {
            this.courses = courses;
        }

        public List<string> getCourses()
        {
            return this.courses;
        }

        public void ReadCoursesFromFile(Dictionary<string, List<string>> courseDC)
        {
            foreach (string file in Directory.EnumerateFiles(FacultiesDirectory, "*.txt"))
            {
                string[] courses = File.ReadAllLines(file, Encoding.GetEncoding(1251));
                List<string> names = new List<string>();
                string tmpKey = "";

                for(int i = 0; i<courses.Length; i++)
                {
                    string s = courses[i];

                    if (s.Contains("course") || s.Contains("Course") || s.Contains("Masters"))
                    {
                        tmpKey = s;
                    }
                    else if (s != " " && s != "")
                    {
                        names.Add(s);
                    }
                    if (s == "" || s == " " || i == courses.Length-1)
                    {
                        courseDC.Add(tmpKey, names);
                        names = new List<string>();
                        tmpKey = "";
                    }
                }
            }

            foreach(KeyValuePair<string,List<string>> s in courseDC)
            {
                foreach (string str in s.Value)
                {
                    MessageBox.Show(str);
                }
            }
        }

        public void ReadAllCourses(Dictionary<string, List<string>> coursesDC,
        Dictionary<string, Dictionary<string, List<string>>> cathDC,
        Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>> facultDC)
        {
            var faculties = Directory.GetDirectories(FacultiesDirectory);

            foreach(string faculty in faculties)
            {
                var cathedras = Directory.GetDirectories(faculty);

                foreach(string cathedra in cathedras)
                {
                    courseLogic(File.ReadAllLines(cathedra + "\\courses.txt", Encoding.GetEncoding(1251)), coursesDC);
                    cathDC.Add(Path.GetFileName(cathedra), coursesDC);
                }
                facultDC.Add(Path.GetFileName(faculty), cathDC);
            }
        }

        public void courseLogic(string[] courses, Dictionary<string,List<string>> courseDC)
        {
            List<string> names = new List<string>();
            string tmpKey = "";

            for (int i = 0; i < courses.Length; i++)
            {
                string s = courses[i];

                if (s.Contains("course") || s.Contains("Course") || s.Contains("Masters"))
                {
                    tmpKey = s;
                }
                else if (s != " " && s != "")
                {
                    names.Add(s);
                }
                if (s == "" || s == " " || i == courses.Length - 1)
                {
                    courseDC.Add(tmpKey, names);
                    names = new List<string>();
                    tmpKey = "";
                }
            }
        }
    }
}
