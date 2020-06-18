
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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

                var fieldName = myField.Name;
                var fieldType = myField.FieldType.Name;


                if (fieldType.Equals("String[]"))
                {

                    String[] array = (string[])(myField.GetValue(obj) as Array);
                  String arrayValues=  string.Join(",", array);
                    info.Add(arrayValues);

                }

                else
                   {
                       var values = myField.GetValue(obj).ToString();

                        info.Add(values);
                   }


                info.Add(fieldName);
             //   info.Add(fieldType);
               
            }

            var json = "";

            for (int i = 0; i < info.Count; i = i + 2)
            {

                json += "{\"" + info[i] + "\":" + info[i + 1] + "\",";

               

            }
            Console.WriteLine(json);
            for (int i = 0; i < info.Count; i++)
            {
                Console.WriteLine(info[i]);
                
            }


        
        }
    
    }
}
    