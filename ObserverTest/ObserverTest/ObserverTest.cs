using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTest
{
    class ObserverTest
    {
        static void Main(string[] args)
        {
            Teacher Teacher = new Teacher( "Валерий Георгиевич" );
            Student Vlad = new Student( "Владислав Бойченко" );
            Student Pasha = new Student( "Павел Адаменко" );
            Student Dasha = new Student("Дарья Езерович" );
            Teacher.registerObserver(Vlad);
            Teacher.registerObserver(Pasha);
            Teacher.registerObserver(Dasha);
            Teacher.notifyObservers();
            Console.ReadKey();
        }
    }
    interface Subject{
        void notifyObservers();
        void registerObserver( Observer O);
        void removeObserver(Observer O);

    }
    interface Observer {
        void update( Teacher S);
    }
    class Teacher : Subject
    {
        private String FullName;
        public Teacher( String FullName)
        {
            this.FullName = FullName;
        }
        private List<Observer> Students = new List<Observer>();
        public void registerObserver(Observer O)
        {
            Students.Add(O);
        }
        public void removeObserver(Observer O)
        {
            Students.Remove(O);
        }
        public String getTeacher()
        {
            return this.FullName;
        }
        public void notifyObservers()
        {
            foreach( Observer X in Students)
            {
                X.update(this);
            }
        }
    }
    class Student : Observer{

        private String FullName;

        public Student ( String FullName)
        {
            this.FullName = FullName;
        } 

        public void update( Teacher S )
        {
            Console.WriteLine("Слышу Вас, " + S.getTeacher() + " by " + this.FullName);
        }
    }
}
