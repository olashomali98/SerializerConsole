
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows.Markup;

namespace JsonSerializer2
{
   public class Ola
    {
      

        public static String Serialize(object obj)
        {
            try{
                List<string> info = new List<string>();


                Type type = obj.GetType();
                FieldInfo[] fields = type.GetFields();

                NewMethod(obj, info, fields);

                String result = WriteJson(info);
                return (result);

            }
            catch(Exception ex){
                return "Error has occured";
            }
            }

        private static void NewMethod(object obj, List<string> info, FieldInfo[] fields)
        {
            foreach (FieldInfo myField in fields)
            {

                var fieldName = myField.Name;
                var fieldType = myField.FieldType.Name;

                info.Add(fieldName);
                info.Add(fieldType);

                if (fieldType.Equals("String[]"))
                {

                    String[] array = (string[])(myField.GetValue(obj) as Array);




                    for (int j = 0; j < array.Length; j++)
                    {

                        array[j] = "\"" + array[j] + "\"";

                        if (j == 0)
                        {

                            array[j] = "[" + array[j];


                        }

                        else if (j == array.Length - 1)
                        {
                            array[j] = array[array.Length - 1] + "]";
                        }

                    }
                    String arrayValues = string.Join(",", array);
                    info.Add(arrayValues);

                }

                else
                {
                    var values = myField.GetValue(obj).ToString();
                    info.Add(values);

                }

            }
        }

        public static String WriteJson(List<string> info)
        {
            var json = "{";

            for (int A = 0; A < info.Count; A = A + 3)
            {
                if (A == info.Count - 3)
                {


                    if (info[A + 1].Equals("Int32"))
                    {
                        json += "\"" + info[A] + "\":" + info[A + 2];

                    }
                    else if (info[A + 1].Equals("String"))
                    {
                        json += "\"" + info[A] + "\":\"" + info[A + 2] + "\"";

                    }
                    else if (info[A + 1].Equals("String[]"))
                    {
                        json += "\"" + info[A] + "\":" + info[A + 2];

                    }

                }

                else
                {
                    if (info[A + 1].Equals("Int32"))
                    {
                        json += "\"" + info[A] + "\":" + info[A + 2];

                    }
                    else if (info[A + 1].Equals("String"))
                    {
                        json += "\"" + info[A] + "\":\"" + info[A + 2] + "\"";

                    }
                    else if (info[A + 1].Equals("String[]"))
                    {
                        json += "\"" + info[A] + "\":" + info[A + 2];



                    }
                    json += ",";



                }


            }


            json += "}";


            return(json);
        }
    }
}
