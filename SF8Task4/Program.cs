using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {


            List<string> Group = new List<string>();
            Student[] Students;
            string path = @"H:\Downloads\Students.dat";

            BinaryFormatter binaryFormater = new BinaryFormatter();

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {

                Students = binaryFormater.Deserialize(fs) as Student[];
            }

            if (Directory.Exists(@"C:\Users\BarsS\Desktop\Students"))
            {
                //Directory.Delete(@"C:\Users\BarsS\Desktop\Students", true);
            }
            Directory.CreateDirectory(@"C:\Users\BarsS\Desktop\Students");

            foreach (Student student in Students)
            {
                Console.WriteLine(student.Group);
                if (!File.Exists(@"C:\Users\BarsS\Desktop\Students\" + student.Group + ".txt"))
                {
                    File.Create(@"C:\Users\BarsS\Desktop\Students\" + student.Group + ".txt");
                    //File.Delete(@"C:\Users\BarsS\Desktop\Students\" + student.Group + ".txt");
                }

            }
            string[] files = Directory.GetFiles(@"C:\Users\BarsS\Desktop\Students");
            foreach (string f in files)
            {
                Console.WriteLine(f);
                FileInfo file = new FileInfo(@"C:\Users\BarsS\Desktop\Students\" + f);
                using (StreamWriter sw = new StreamWriter(f))
                {
                    foreach (Student student in Students)
                    {
                        if (@"C:\Users\BarsS\Desktop\Students\" + student.Group + ".txt" == f)
                        {
                            Console.WriteLine("Совпад");

                            {
                                sw.WriteLine($"Имя: {student.Name}, дата рождения: {student.DateOfBirth}");

                            }
                        }
                    }

                }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }
    }
}


