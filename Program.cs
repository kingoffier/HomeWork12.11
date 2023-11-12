using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //запись в файл
            using (StreamWriter sw = new StreamWriter("result.txt", true))
            {
                //чтение из файла
                using (StreamReader sr = new StreamReader("client_import.txt", Encoding.UTF8))
                {
                    string line;
                    string[] result = new string[9];
                    while ((line = sr.ReadLine()) != null)
                    {
                        StringBuilder numberResult = new StringBuilder();
                        string photoRez = string.Empty;
                        string genderRez = string.Empty;
                        int n = 0;
                        string[] array = line.Trim().Split(';');
                        string secondname = array[0].Trim();
                        string name = array[1].Trim();
                        string patronymic = array[2].Trim();
                        string gender = array[3].Trim();
                        string number = array[4].Trim();
                        string photo = array[5].Trim();
                        string dateofbitrh = array[6].Trim();
                        string email = array[7].Trim();
                        string dateofreg = array[8].Trim();
                        int Length = photo.Length;
                        if (photo.Contains("\\"))
                        {
                            n = photo.IndexOf("\\");
                            photoRez = photo.Substring(n + 1);
                        }
                        genderRez = gender.Substring(0, 1).ToLower();
                        if (genderRez.Contains("м"))
                        {
                            genderRez = "1";
                        }
                        else
                        {
                            genderRez = "2";
                        }
                        foreach (var item in number)
                        {
                            if (Char.IsDigit(item))
                            {
                                numberResult.Append(item);
                            }

                        }
                        string rez = @"^\w+\s\w+\s\w+$";
                        if (Regex.Match(secondname, rez,
                        RegexOptions.IgnoreCase).Success)
                        {
                            string[] split = secondname.Split();
                            secondname = split[0].Trim();
                            name = split[1].Trim();
                            patronymic = split[2].Trim();
                        }
                        result[0] = secondname;
                        result[1] = name;
                        result[2] = patronymic;
                        result[3] = genderRez.ToLower();
                        result[4] = numberResult.ToString();
                        result[5] = photoRez.ToString();
                        result[6] = dateofbitrh;
                        result[7] = email;
                        result[8] = dateofreg;
                        sw.WriteLine($"{String.Join(";", result)}");
                    }

                }
            }
            Console.ReadKey();
        }
    }
}
