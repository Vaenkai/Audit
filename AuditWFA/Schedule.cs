using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditWFA
{
    //fields
    class Schedule
    {
        private enum engWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
        private enum ruWeek { Понедельник, Вторник, Среда, Четверг, Пятница, Суббота, Воскресенье };
        //dayName,Teacher info, Subjects for Teacher
        //Понедельник, Скрипник Ирина Анатольевна, <ДС,КДМ...>
        private List<Teacher> teachers;
        private List<Subject> subjects;
        
        Dictionary<Enum ,List<Teacher>> dcDayTeach;

        public Schedule()
        {
            //есть список для предметов
            subjects = new List<Subject>();
            //есть список для учета преподавателей
            teachers = new List<Teacher>();


            //добавляем несколько предметов в список
            subjects.Add(new Subject("English", new Auditory()));
            subjects.Add(new Subject("English", new Auditory()));
            subjects.Add(new Subject("English", new Auditory()));
            //закрепляем список уроков за преподавателем
            Teacher t1 = new Teacher("Irina", "Skripnik", "Anatolievna", subjects);
            teachers.Add(t1);
            //subjects.Clear(); // работает криво - список удаляется а позже переприсваивает другой>.<
            subjects = new List<Subject>();

            subjects.Add(new Subject("English", new Auditory(),new Group(15,"SP-16-2")));
            subjects.Add(new Subject("", new Auditory()));
            subjects.Add(new Subject("English", new Auditory(),new Group("SP-17-3")));

            //закрепляем список уроков за преподавателем
            Teacher t2 = new Teacher("Valeriy", "Boldirev", "Nikolayivech", subjects);
            teachers.Add(t2);

            //есть словарь для хранения дня недели и списка преподавателей
            dcDayTeach = new Dictionary<Enum , List<Teacher>>();
            dcDayTeach.Add(engWeek.Friday, teachers);
        }

        //methods
        public Dictionary<Enum, List<Teacher>> getDictionary()
        {
            return this.dcDayTeach;
        }

        //возврат дня недели
        public string getDay()
        {
            return Enum.GetName(typeof(engWeek),4);
        }

        //возвращаем список преподавателей такого-то дня
        public List<Teacher> getListOfteachers()
        {
            return dcDayTeach[engWeek.Friday];
        }

        //возвращаем список имен преподавателей одной строкой
        public string getNamesOfTeachers()
        {
            String tmp = "";
            foreach (Teacher teach in dcDayTeach[engWeek.Friday])
            {
                tmp += teach.ToString();
            }
            return tmp;
        }

        //возвращаем список предметов преподавателей в такой-то день одной строкой
        public string getListOfSubjects()
        {
            String tmp = "";
            foreach(Teacher teacher in dcDayTeach[engWeek.Friday])
            {
                tmp+=teacher.SubjectsToString();
            }
            return tmp;

            //return dcDayTeach[engWeek.Friday][0].SubjectsToString(); - для отладки
        }
    }
}
