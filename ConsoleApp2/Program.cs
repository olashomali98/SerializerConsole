
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



        //static string ConvertStringArrayToString(string[] array)
        //{
        //    // Concatenate all the elements into a StringBuilder.
        //    StringBuilder builder = new StringBuilder();
        //    foreach (string value in array)
        //    {
        //        builder.Append(value);
        //        builder.Append('.');
        //    }
        //    return builder.ToString();
        //}

        //static string ConvertStringArrayToStringJoin(string[] array)
        //{
        //    // Use string Join to concatenate the string elements.
        //    string result = string.Join(".", array);
        //    return result;
        //}

        private static void Call(object obj)
        {
            List<string> info = new List<string>();


            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields();

            Console.WriteLine("Fields are: ");
            foreach (FieldInfo myField in fields)
            {

        object obj1 = myField.GetValue(obj);

                if (obj1 == "String[]")
                {

                    string[] s = (string[])obj1;

                  //  string result1 = ConvertStringArrayToString(s);
                  //  string result2 = ConvertStringArrayToStringJoin(s);


               }

                      else
                   {
                        var values = myField.GetValue(obj).ToString();

                        info.Add(values);
                   }

    

                info.Add(myField.Name);
                info.Add(myField.FieldType.Name);
            }

            for (int i = 0; i < info.Count; i++)
            {
                Console.WriteLine(info[i]);
                
            }

        
        }
    
    }
}
    