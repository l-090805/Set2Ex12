using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Set2Ex12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"C:\Users\falau\source\repos\setul2\Set2Ex12\TextFile1.txt");
            string continut  = load.ReadToEnd();

            string[] elemente = continut.Split(new[] { ' ', ',', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            int nrGrupuri = 0;
            bool inGrup = false;
            int? numarAnterior = null;

            foreach(string element in elemente)
            {
                if(int.TryParse(element, out int numar))
                {
                    if (numar != 0)
                    {
                        if (!inGrup && (numarAnterior.HasValue && numar == numarAnterior + 1))
                        {
                            if (!inGrup)
                            {
                            nrGrupuri++;
                            inGrup = true;
                            }
                        }

                        numarAnterior = numar;
                    }
                    else
                    {
                        inGrup = false;
                        numarAnterior = null;
                    }
                }
            }

            Console.WriteLine($"Numărul de grupuri formate din numere consecutive si diferite de zero este: {nrGrupuri}");

        }
    }
}
