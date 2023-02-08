using System.Diagnostics;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            Console.CursorVisible = false;
            Arrow_Menu Arrow_Menu = new Arrow_Menu();

            List<string> drew_element = new List<string>();
            List<string> save_element = new List<string>();

            foreach (var element in DriveInfo.GetDrives())
            {
                drew_element.Add(Convert.ToString(element));
            }

            bool start = true;

            while (start)
            {
                Files.DrewElement(drew_element, save_element);
                Console.SetCursorPosition(50, 0);
                Console.WriteLine("F1 - Создать файл");
                Console.SetCursorPosition(50, 1);
                Console.WriteLine("F2 - Создать директорию");
                Console.SetCursorPosition(50, 2);
                Console.WriteLine("F3 - Удалить");
                List<dynamic> DopList = Arrow_Menu.DrewMenu(drew_element);
                Console.SetCursorPosition(0, 0);

                if (DopList[1].Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    if (save_element.Count() != 0)
                    {
                        if (save_element.Count() == 1)
                        {
                            save_element.Clear();
                            drew_element.Clear();
                            foreach (var element in DriveInfo.GetDrives())
                            {
                                drew_element.Add(Convert.ToString(element));
                            }
                        }
                        else
                        {
                            save_element.RemoveAt(save_element.Count() - 1);
                            drew_element = Files.GetFile(save_element[save_element.Count() - 1]);
                        }
                    }
                    else
                    {
                        start = false;
                    }
                }
                else if (DopList[1].Key == ConsoleKey.Enter)
                {
                    if (File.Exists(drew_element[DopList[0]]))
                    {
                        Process.Start(new ProcessStartInfo {FileName = drew_element[DopList[0]], UseShellExecute = true });
                    }
                    else
                    {
                        Console.Clear();
                        save_element.Add(drew_element[DopList[0]]);
                        drew_element = Files.GetFile(drew_element[DopList[0]]);
                    }
                }
                else if (DopList[1].Key == ConsoleKey.F1)
                {
                    if (save_element.Count() != 0)
                    {
                        drew_element = Files.CreateFile(save_element, drew_element);
                    }
                }
                else if (DopList[1].Key == ConsoleKey.F2)
                {
                    if (save_element.Count() != 0)
                    {
                        drew_element = Files.CreateDirectory(save_element, drew_element);
                    }
                }
                else if (DopList[1].Key == ConsoleKey.F3)
                {
                    if (save_element.Count() != 0)
                    {
                        drew_element = Files.DeleteFileAndDirectory(save_element, drew_element, DopList[0]);
                    }
                }
            }
        }
    }
}