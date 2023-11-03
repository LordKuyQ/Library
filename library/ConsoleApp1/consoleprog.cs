using System;
using USQLCSharpProject1;
namespace ConsoleApp1
{
    public class consoleprog
    {
        public static List<book> listbooks = new List<book>();
        public static List<reader> listreaders = new List<reader>();

        public static void Main()
        {
            Menu();
        }

        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\nМеню:\n1. Добавить книгу\n2. Добавить читателя\n3. Поиск книги\n4. Выдать книгу\n5. Выход\n");

                int выбор = int.Parse(Console.ReadLine());

                switch (выбор)
                {
                    case 1:
                        addbook();
                        break;
                    case 2:
                        addreader();
                        break;
                    case 3:
                        search();
                        break;
                    case 4:
                        taking();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
        }
        public static void addbook()
        {
            //int hart,string hauthor,string hnaming,int hyear,int hcolv;

            Console.WriteLine("Введите артикул:");
            int hart = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите автора:");
            string hauthor = Console.ReadLine();

            Console.WriteLine("Введите название:");
            string hnaming = Console.ReadLine();

            Console.WriteLine("Введите год издания:");
            int hyear = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество экземпляров:");
            int hcolv = int.Parse(Console.ReadLine());

            book newbook = new book(hart, hauthor, hnaming, hyear, hcolv);
            

            listbooks.Add(newbook);
            Console.WriteLine("Книга успешно добавлена.");
        }
        public static void addreader()
        {
            Console.WriteLine("Введите Ф.И.О. читателя:");
            string hname = Console.ReadLine();

            Console.WriteLine("Введите номер группы:");
            string hnum = Console.ReadLine();

            reader newreader = new reader
            {
                name = hname,
                num = hnum
            };

            listreaders.Add(newreader);
            Console.WriteLine("Читатель успешно добавлен.");
        }
        public static void search()
        {
            Console.WriteLine("Выберите критерий поиска:\n1. По артиклю\n2. По автору\n3. По названию");

            int point = int.Parse(Console.ReadLine());

            switch (point)
            {
                case 1:
                    Console.WriteLine("Введите артикул для поиска:");
                    int art = int.Parse(Console.ReadLine());
                    var seabooks = listbooks.FindAll(book => book.art == art);
                    seesearch(seabooks);
                    break;
                case 2:
                    Console.WriteLine("Введите автора для поиска:");
                    string author = Console.ReadLine();
                    seabooks = listbooks.FindAll(book => book.author == author);
                    seesearch(seabooks);
                    break;
                case 3:
                    Console.WriteLine("Введите название для поиска:");
                    string naming = Console.ReadLine();
                    seabooks = listbooks.FindAll(book => book.naming == naming);
                    seesearch(seabooks);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }

        public static void seesearch(List<book> seabooks)
        {
            if (seabooks.Count > 0)
            {
                foreach (var book in seabooks)
                {
                    Console.WriteLine($"Артикул: {book.art}, Автор: {book.author}, Название: {book.naming}, Год издания: {book.year}, Количество экземпляров: {book.colv}");
                }
            }
            else
            {
                Console.WriteLine("Книги не найдены.");
            }
        }
        public static void taking()
        {
            Console.WriteLine("Введите Ф.И.О. читателя:");
            string name = Console.ReadLine();

            reader seareader = listreaders.Find(raeder => raeder.name == name);

            if (seareader != null)
            {
                Console.WriteLine("Выберите книгу для выдачи (введите артикул):");
                int art = int.Parse(Console.ReadLine());

                book book = listbooks.Find(book => book.art == art);

                if (book != null && book.colv > 0)
                {
                    seareader.listbook.Add(book);
                    book.colv--;
                    Console.WriteLine("Книга успешно выдана.");
                }
                else if (book == null)
                {
                    Console.WriteLine("Книга с указанным артикулом не найдена.");
                }
                else if (book.colv <= 0)
                {
                    Console.WriteLine("Извините, но все экземпляры этой книги уже выданы.");
                }
            }
            else
            {
                Console.WriteLine("Читатель не найден.");
            }
        }
    }
}