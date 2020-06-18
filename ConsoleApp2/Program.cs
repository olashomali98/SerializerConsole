
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            Configuration obj = new Configuration(55, "Ola", new[] { "53", "52" });

            Call(obj);

            Console.ReadLine();
        }

        private static void Call(object obj)
        {
            List<string> info = new List<string>();


            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields();
            
            Console.WriteLine("Fields are: ");
            foreach (FieldInfo myField in fields)
            {
              

                var values =myField.GetValue(obj).ToString();
               


                info.Add(values);

                info.Add(myField.Name);
                info.Add(myField.FieldType.Name);
            }

            for (int i = 0; i < info.Count; i++)
            {
                Console.WriteLine(info[i]);
                
            }

         //hey
        }
    }
}