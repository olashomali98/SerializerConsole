
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

            Configuration obj = new Configuration(55, "www.training.com", new[] { "192.168.1.8", "192.168.1.2" });

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

                info.Add(fieldName);

                if (fieldType.Equals("String[]"))
                {

                    String[] array = (string[])(myField.GetValue(obj) as Array);
                    String arrayValues = string.Join(",", array);

                  

                    info.Add(arrayValues);

                }

                else
                {
                    var values = myField.GetValue(obj).ToString();
                    info.Add(values);

                }

            }

            var json = "{";

            for (int i = 0; i < info.Count; i = i + 2)
            {

                json += "\"" + info[i] + "\":" + info[i + 1] + "\",";

               

            }
            json += "}";

            Console.WriteLine(json);
            for (int i = 0; i < info.Count; i++)
            {
                Console.WriteLine(info[i]);
                
            }


        
        }
    
    }
}
    