using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anarchy_in_the_hospital
{
    class Program
    {
        static void Main ( string [] args )
        {
            Work work = new Work ();
            work.Works ();
        }
    }

    class Work
    {
        private List<Patient> _patients = new List<Patient> ();

        public Work ()
        {
            _patients.Add ( new Patient ( "Абрам Роман Петрович", 55, "ОРВИ" ) );
            _patients.Add ( new Patient ( "Грозный Иван Иванович", 21, "ГРИП" ) );
            _patients.Add ( new Patient ( "Вова Викторович Колбасин", 49, "ГРИП" ) );
            _patients.Add ( new Patient ( "Сергей Алексеевич Федоров", 25, "Спид" ) );
            _patients.Add ( new Patient ( "Султан Никитович Носков", 30, "ЗУБЫ" ) );
            _patients.Add ( new Patient ( "Кирилл Николаевич Юдин",38, "ОРВИ" ) );
            _patients.Add ( new Patient ( "Алексей Викторович Папонин",71, "СПИД" ) );
            _patients.Add ( new Patient ( "Алах Аламович Алахич", 33, "ЗУБЫ" ) );
            _patients.Add ( new Patient ( "Александр Тимурович Гарбов",18, "ПАЛЕЦ" ) );
            _patients.Add ( new Patient ( "Пётр Александрович Головач", 60, "ОРВИ" ) );
            _patients.Add ( new Patient ( "Хабиб Хабибович Хабибов",52, "ПАЛЕЦ" ) );
            _patients.Add ( new Patient ( "Вова Викторович Колбасин", 27, "СПИД" ) );
            _patients.Add ( new Patient ( "Вадим Петрович Хлебкин",20, "ПАЛЕЦ" ) );
        }

        public void Works ()
        {
            bool isWork = true;
            string input;

            while ( isWork == true )
            {
                Console.WriteLine ( "Анархия в больнице" +
                    "\nВыбирете пункт действий!" +
                    "\n1 - Посмотреть список всех больных!" +
                    "\n2 - Отсортировать всех больных по фио." +
                    "\n3 - Отсортировать всех больных по возрасту." +
                    "\n4 - Вывести больных с определенным заболеванием." +
                    "\n5 - Exit" );

                input = Console.ReadLine ();

                switch ( input )
                {
                    case "1":
                        ListOfPatients ();
                        break;
                    case "2":
                        SortEveryoneByFillName ();
                        break;
                    case "3":
                        SortEveryoneByAge ();
                        break;
                    case "4":
                        SortEveryoneByIllness ();
                        break;
                            case "5":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine ("Кмх... Кажется что-то пошло не так!");
                        break;
                }
                Console.ReadLine ();
                Console.Clear ();
            }
        }

        private void ListOfPatients ()
        {
            foreach ( var patient in _patients )
            {
                patient.ShowInfo ();
            }
        }

        private void SortEveryoneByFillName ()
        {
            Console.WriteLine ( "\nСортировка по ФИО\t" );

            var patientBulastName = _patients.OrderBy ( Patient => Patient.FIO );

            foreach ( var patient in patientBulastName )
            {
                patient.ShowInfo ();
            }
        }

        private void SortEveryoneByAge ()
        {
            Console.WriteLine ( "\nСортировка по Возросту\t" );

            var patientByAge = _patients.OrderBy ( Patient => Patient.Growth );

            foreach ( var patient in patientByAge )
            {
                patient.ShowInfo ();
            }
        }

        private void SortEveryoneByIllness ()
        {
            Console.Write ( "\nДля сортировки введите название болезни:\t" );
            string input = Console.ReadLine ().ToUpper();

            var foundPatient = _patients.Where ( Patient => Patient.Disease == input );

            foreach ( var patient in foundPatient )
            {
                patient.ShowInfo ();
            }
        }
    }

    class Patient
    {
        public Patient( string fIO, int growth, string disease )
        {
            FIO = fIO;
            Growth = growth;
            Disease = disease;
        }

        public string FIO { get; private set; }
        public int Growth { get; private set; }
        public string Disease { get; private set; }

        public void ShowInfo ()
        {
            Console.WriteLine ($"Поциент {FIO}, возрос {Growth}, болен {Disease}");
        }
    }
}
/*Задача:
У вас есть список больных(минимум 10 записей)
Класс больного состоит из полей: ФИО, возраст, заболевание.
Требуется написать программу больницы, в которой перед пользователем будет меню со следующими пунктами:
1)Отсортировать всех больных по фио
2)Отсортировать всех больных по возрасту
3)Вывести больных с определенным заболеванием
(название заболевания вводится пользователем с клавиатуры)*/