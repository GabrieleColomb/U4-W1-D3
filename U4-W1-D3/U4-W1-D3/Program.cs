using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4_W1_D3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seleziona un esercizio da eseguire:");
            Console.WriteLine("1. Conto Corrente");
            Console.WriteLine("2. Ricerca di un nome nell'array");
            Console.WriteLine("3. Calcolo somma e media di numeri in un array");
            Console.Write("Inserisci il numero dell'esercizio: ");

            int scelta = Convert.ToInt32(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    EsercizioContoCorrente();
                    break;
                case 2:
                    EsercizioRicercaNomi();
                    break;
                case 3:
                    EsercizioSommaMediaArray();
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        static void EsercizioContoCorrente()
        {
            ContoCorrente conto = new ContoCorrente();

            Console.Write("Inserisci il primo versamento: ");
            double primoVersamento = Convert.ToDouble(Console.ReadLine());

            try
            {
                conto.ApriConto(primoVersamento);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
                WaitForUser();
                return;
            }

            Console.Write("Inserisci l'importo del versamento: ");
            double importoVersamento = Convert.ToDouble(Console.ReadLine());

            try
            {
                conto.EffettuaTransazione(importoVersamento, "versamento");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }

            Console.Write("Inserisci l'importo del prelevamento: ");
            double importoPrelevamento = Convert.ToDouble(Console.ReadLine());

            try
            {
                conto.EffettuaTransazione(importoPrelevamento, "prelevamento");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }

            WaitForUser();
        }

        static void EsercizioRicercaNomi()
        {
            Console.Write("Inserisci il numero di nomi da memorizzare: ");
            int numNomi = Convert.ToInt32(Console.ReadLine());

            string[] nomi = new string[numNomi];

            for (int i = 0; i < numNomi; i++)
            {
                Console.Write($"Inserisci il nome {i + 1}: ");
                nomi[i] = Console.ReadLine();
            }

            Console.Write("Inserisci il nome da cercare: ");
            string nomeDaCercare = Console.ReadLine();

            bool presente = false;

            foreach (string nome in nomi)
            {
                if (nome.Equals(nomeDaCercare, StringComparison.OrdinalIgnoreCase))
                {
                    presente = true;
                    break;
                }
            }

            if (presente)
            {
                Console.WriteLine($"Il nome '{nomeDaCercare}' è presente nell'array.");
            }
            else
            {
                Console.WriteLine($"Il nome '{nomeDaCercare}' non è presente nell'array.");
            }

            Console.WriteLine("Premi un tasto per uscire...");
            Console.ReadKey();
        }

        static void EsercizioSommaMediaArray()
        {
            Console.Write("Inserisci la dimensione dell'array: ");
            int dimensioneArray = Convert.ToInt32(Console.ReadLine());

            int[] numeri = new int[dimensioneArray];

            for (int i = 0; i < dimensioneArray; i++)
            {
                Console.Write($"Inserisci il numero {i + 1}: ");
                numeri[i] = Convert.ToInt32(Console.ReadLine());
            }

            int somma = 0;
            foreach (int numero in numeri)
            {
                somma += numero;
            }

            double media = (double)somma / dimensioneArray;

            Console.WriteLine($"Somma dei numeri: {somma}");
            Console.WriteLine($"Media dei numeri: {media}");

            Console.WriteLine("Premi un tasto per uscire...");
            Console.ReadKey();
        }

        static void WaitForUser()
        {
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }
    }
}