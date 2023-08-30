using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace U4_W1_D3
{
    internal class ContoCorrente
    {
        private bool isAccountOpened;
        private double saldo;

        public double Saldo => saldo;

        public ContoCorrente()
        {
            isAccountOpened = false;
            saldo = 0;
        }

        public void ApriConto(double primoVersamento)
        {
            if (isAccountOpened)
            {
                throw new InvalidOperationException("Il conto è già stato aperto.");
            }

            if (primoVersamento < 1000)
            {
                throw new ArgumentException("È necessario un primo versamento di almeno 1000 euro.");
            }

            isAccountOpened = true;
            saldo += primoVersamento;
            Console.WriteLine($"Conto aperto con successo. Saldo iniziale: {saldo:C}.");
        }

        public void EffettuaTransazione(double importo, string tipoTransazione)
        {
            if (!isAccountOpened)
            {
                throw new InvalidOperationException("Il conto non è ancora stato aperto.");
            }

            switch (tipoTransazione)
            {
                case "versamento":
                    saldo += importo;
                    Console.WriteLine($"Versamento effettuato. Nuovo saldo: {saldo:C}.");
                    break;
                case "prelevamento":
                    if (saldo < importo)
                    {
                        Console.WriteLine("Saldo insufficiente per il prelevamento.");
                    }
                    else
                    {
                        saldo -= importo;
                        Console.WriteLine($"Prelevamento effettuato. Nuovo saldo: {saldo:C}.");
                    }
                    break;
                default:
                    throw new ArgumentException("Tipo di transazione non valido.");
            }
        }
    }
}
