using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface ISubject
    {
        void registerObserver(IObserver o);
        void removeObserver(IObserver o);
        void notifyObserver();
    }
    public interface IObserver
    {
        void update(int i);
    }
    public class MySubject: ISubject
    {
        List<IObserver> ObserverList;
        int i;
        public MySubject()
        {
            ObserverList = new List<IObserver>();
        }
        public void notifyObserver()
        {
            foreach (IObserver o in ObserverList)
            {
                o.update(i);
            }
        }
        public void ChangeI(int i)
        {
            this.i = i;
            notifyObserver();
        }
        public void registerObserver(IObserver o)
        {
            ObserverList.Add(o);
        }

        public void removeObserver(IObserver o)
        {
            ObserverList.Remove(o);
        }
    }
    public class MyObserver : IObserver
    {
        int i;
        public void update(int i)
        {
            this.i = i;
            updateAnnounce();
        }
        public void updateAnnounce()
        {
            Console.WriteLine("Ого! Переменная i теперь = {0}", i);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MySubject Subj = new MySubject();
            MyObserver obs1 = new MyObserver();
            MyObserver obs2 = new MyObserver();
            Subj.registerObserver(obs1);
            Subj.registerObserver(obs2);
            Subj.ChangeI(3);
            Subj.removeObserver(obs2);
            Subj.ChangeI(5);
            Console.ReadKey();
        }
    }

}
