using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fractions
{
    class Fractions
    {
        private int Nomerator;
        private int Denomirator;
        public void Swap(ref int _first, ref int _second)
        {
            (_first, _second) = (_second, _first);
        }
        public Fractions()
        {
            Nomerator = 0;
            Denomirator = 1;
        }
        public void setNomerator(int _nomerator)
        {
            this.Nomerator = _nomerator;
        }
        public int nomerator
        {
            get { return Nomerator; }
        }
        public int denomirator
        {
            get { return Denomirator; }
        }

        public bool setDenomirator(int _denomirator)
        {
            bool _result = false;
            if (_denomirator > 0)
            {
                this.Denomirator = _denomirator;
                _result = true;
            }
            else
            {
                this.Denomirator = 1;
            }
            return _result;
        }
        static private int LCM(int _first, int _second) 
        {
            int _result = 0;
            if (_first < _second)
            {
                (_first, _second) = (_second, _first);
            }
            for (int i = _first; i < _first * _second; i++)
            {
                if ((i % _second == 0) & (i % _first == 0))
                {
                    return i;
                }
            }
            _result = _first * _second;

            return _result;
        }
        static public Fractions operator /(Fractions _first, Fractions _second)
        {
            Fractions _result = new Fractions();
            _result.Nomerator = _first.Nomerator * _second.Denomirator;
            _result.Denomirator = _first.Denomirator * _second.Nomerator;
            return _result;
        }
        static public Fractions operator *(Fractions _first, Fractions _second)
        {
            Fractions _result = new Fractions();
            _result.Nomerator = _first.Nomerator * _second.Nomerator;
            _result.Denomirator = _first.Denomirator * _second.Denomirator;
            return _result;
        }
        static public Fractions operator +(Fractions _first, Fractions _second)
        {
            Fractions _result = new Fractions();
            _result.Denomirator = LCM(_first.Denomirator, _second.Denomirator);
            _result.Nomerator = (_first.Nomerator * _second.Denomirator) + (_second.Nomerator * _first.Denomirator);
            return _result;
        }
        static public Fractions operator -(Fractions _first, Fractions _second)
        {
            Fractions _result = new Fractions();
            _result.Denomirator = LCM(_first.Denomirator, _second.Denomirator);
            _result.Nomerator = (_first.Nomerator * _second.Denomirator) - (_second.Nomerator * _first.Denomirator);
            return _result;
        }

        static public bool operator >(Fractions _first, Fractions _second)
        {
            Fractions _difference = _first - _second;
            bool _result = (_difference.Nomerator > 0);

            if (_result)
            {
                return true;
            }
            return false;
        }
        static public bool operator <(Fractions _first, Fractions _second)
        {
            Fractions _difference = _first - _second;
            bool _result = (_difference.Nomerator < 0);

            if (_result)
            {
                return true;
            }
            return false;
        }
    }
    class SearchResult
    {
        public Fractions InputtingFractions1()
        {
            Fractions fract01 = new Fractions();
            Console.Write("Введите числитель 1-ой дроби: ");
            int nom = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите знаменатель 1-ой дроби: ");
            int denom = Convert.ToInt32(Console.ReadLine());
            fract01.setNomerator(nom);
            fract01.setDenomirator(denom);
            return fract01;
        }
        public Fractions InputtingFractions2()
        {
            
            Fractions fract02 = new Fractions();
            Console.Write("Введите числитель 2-ой дроби: ");
            int nom = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите знаменатель 2-ой дроби: ");
            int denom = Convert.ToInt32(Console.ReadLine());
            fract02.setNomerator(nom);
            fract02.setDenomirator(denom);
            return fract02;
        }
        public void ShowResult()
        {

            Fractions fract01 = new Fractions();
            Fractions fract02 = new Fractions();
            fract01 = InputtingFractions1();
            fract02 = InputtingFractions2();
            Console.Write("Введите математическую опрерацию (<, >, +, -, * или /): ");
            char Sign = Convert.ToChar(Console.ReadLine());
            if (Sign == '-')
            {
                var fract03 = fract01 - fract02;
                Console.WriteLine(fract03.nomerator);
                Console.WriteLine("-");
                Console.WriteLine(fract03.denomirator);
            }
            else if (Sign == '+')
            {
                var fract03 = fract01 + fract02;
                Console.WriteLine(fract03.nomerator);
                Console.WriteLine("-");
                Console.WriteLine(fract03.denomirator);
            }
            if (Sign == '/')
            {
                var fract03 = fract01 / fract02;
                Console.WriteLine(fract03.nomerator);
                Console.WriteLine("-");
                Console.WriteLine(fract03.denomirator);
            }
            else if (Sign == '*')
            {
                var fract03 = fract01 * fract02;
                Console.WriteLine(fract03.nomerator);
                Console.WriteLine("-");
                Console.WriteLine(fract03.denomirator);
            }
            else if (Sign == '<')
            {
                var fract03 = fract01 < fract02;
                if (fract03)
                {
                    Console.WriteLine("Первая дробь меньше второй.");
                }
                else
                {
                    Console.WriteLine("Первая дробь больше второй.");
                }
            }
            else if (Sign == '>')
            {
                var fract03 = fract01 > fract02;
                if (fract03)
                {
                    Console.WriteLine("Первая дробь больше второй.");
                }
                else
                {
                    Console.WriteLine("Первая дробь меньше второй.");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tПрограмма расчитана на ввод, только правильных простых дробей");
            SearchResult searchResult = new SearchResult();
            searchResult.ShowResult();
        }
    }
}
