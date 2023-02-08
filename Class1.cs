using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    internal class Files
    {
        public static void DrewElement(List<string> drew_element, List<string> save_element)
        {
            if (save_element.Count() == 0)
            {
                foreach (var element in DriveInfo.GetDrives())
                {
                    Console.WriteLine("  " + element + " " + (element.TotalFreeSpace/ 1073741824) + "Гб свободно");
                }
            }
            else
            {
                foreach (var element in drew_element)
                {
                    Console.WriteLine("  " + element + " " + File.GetCreationTime(element));
                }
            }
        }
        public static List<string> GetFile(string element)
        {
            List<string> list = new List<string>();

            foreach (var elem in Directory.GetDirectories(element))
            {
                list.Add(elem);
            }
            foreach (var elem in Directory.GetFiles(element))
            {
                list.Add(elem);
            }

            return (list);
        }

        public static List<string> CreateFile(List<string> save_element, List<string> drew_element)
        {
            string element = "";
            bool start = true;
            while (start)
            {
                Console.Clear();
                Console.WriteLine("Создание файла");
                Console.Write("  Введите название : ");
                element = Console.ReadLine();
                if (File.Exists(save_element[save_element.Count() - 1] + @"\" + element))
                {
                    Console.WriteLine("Файл с таким названием уже существует, нажмите любую клавишу, чтобы продолжить");
                    ConsoleKeyInfo ket = Console.ReadKey();
                }
                else 
                {
                    start = false;
                }
            }

            using (FileStream fs = new FileStream(save_element[save_element.Count() - 1] + @"\" + element, FileMode.Create))

            drew_element = Files.GetFile(save_element[save_element.Count() - 1]);

            Console.Clear();
            return (drew_element);
        }

        public static List<string> CreateDirectory(List<string> save_element, List<string> drew_element)
        {
            string element = "";
            bool start = true;
            while (start)
            {
                Console.Clear();
                Console.WriteLine("Создание директории");
                Console.Write("  Введите название : ");
                element = Console.ReadLine();
                if (Directory.Exists(save_element[save_element.Count() - 1] + @"\" + element))
                {
                    Console.WriteLine("Такая папка уже существует, нажмите любую клавишу, чтобы продолжить");
                    ConsoleKeyInfo ket = Console.ReadKey();
                }
                else
                {
                    start = false;
                }
            }
            Directory.CreateDirectory(save_element[save_element.Count() - 1] + @"\" + element);
            drew_element = Files.GetFile(save_element[save_element.Count() - 1]);

            Console.Clear();
            return (drew_element);
        }
        public static List<string> DeleteFileAndDirectory(List<string> save_element, List<string> drew_element, int y_pos_cursor)
        {

            if (File.Exists(drew_element[y_pos_cursor]))
            {
                File.Delete(drew_element[y_pos_cursor]);
            }
            else
            {
                Directory.Delete(drew_element[y_pos_cursor],true);
            }

            drew_element = Files.GetFile(save_element[save_element.Count() - 1]);

            Console.Clear();

            return (drew_element);
        }
    }
    internal class Arrow_Menu
    {
        private int y_pos_cursor;
        private int y_pos_cursor_dop;

        public List<dynamic> DrewMenu(List<string> arr)
        {
            Console.SetCursorPosition(0, y_pos_cursor);
            Console.WriteLine("->");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                y_pos_cursor_dop = y_pos_cursor--;
                if (y_pos_cursor < 0)
                {
                    y_pos_cursor = arr.Count() - 1;
                }
                else if (y_pos_cursor > arr.Count() - 1)
                {
                    y_pos_cursor = 0;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                y_pos_cursor_dop = y_pos_cursor++;
                if (y_pos_cursor < 0)
                {
                    y_pos_cursor = arr.Count() - 1;
                }
                else if (y_pos_cursor > arr.Count() - 1)
                {
                    y_pos_cursor = 0;
                }
            }
            ClearArrow(y_pos_cursor_dop);
            List<dynamic> list = new List<dynamic>();
            list.Add(y_pos_cursor);
            list.Add(key);
            return (list);
        }
        private void ClearArrow(int y_pos_cursor_dop)
        {
            Console.SetCursorPosition(0, y_pos_cursor_dop);
            Console.Write("  ");
        }
    }
}
