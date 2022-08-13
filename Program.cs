using System;

class Program
{
    const string PathDest = $@"C:\Users\T-Gamer\Documents\Backups\";
    static void Main(string[] args)
    {
        try
        {
            string[] PathsSrc = new string[4]
            {
                "acd","schedule","bal21","tss"
            };

            int cont = 0;

            while (cont <= PathsSrc.Length)
            {
                foreach (string str in PathsSrc)
                {
                    string Src = $@"C:\{str}\appserver.txt";
                    string Dest = $@"{PathDest}\{str}";

                    if (ValidPath(str) == false)
                    {
                        Directory.CreateDirectory(Dest);
                    }

                    if (ValidFile(NameFile(Dest)) == false)
                    {
                        File.Copy(sourceFileName: Src,
                                destFileName: NameFile(Dest),
                                overwrite: true);
                    }
                }
                cont++;
            }
        }catch (Exception)
        {
            Console.WriteLine("Erro");
            throw;
        }
    }
    static string NameFile(string a)
    {
        DateTime dt = DateTime.Now;
        string DateFormat = dt.ToString("yyyyMMdd");
        string cNameFile = $"{a}/appserver_backup_{DateFormat}.ini";
        return cNameFile;
    }
    static bool ValidFile(string a)
    {
        Boolean file = File.Exists(a);
        return file;
    }

    static bool ValidPath(string a)
    {
        Boolean path = Directory.Exists($@"{PathDest}\{a}");
        return path;
    }
}