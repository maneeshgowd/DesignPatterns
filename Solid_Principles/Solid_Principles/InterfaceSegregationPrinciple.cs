using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Principles
{
    // Avoid one Big interface and segregate into smaller interface as per client requirements.
    // No Client should be forced to implement the method which they wont use.



    // Problem Statement
    interface IPrinter
    {
        void PerformScan(string content);
        void PerformPrint(string content);
        void PerformFax(string content);
        void PerformXerox(string content);
    }

    public class HPPrinter : IPrinter
    {
        public void PerformFax(string content)
        {
            Console.WriteLine("Performing Fax..." + content);
        }

        public void PerformPrint(string content)
        {
            Console.WriteLine("Performing Print..." + content);
        }

        public void PerformScan(string content)
        {
            Console.WriteLine("Performing Scan..." + content);
        }

        public void PerformXerox(string content)
        {
            Console.WriteLine("Performing Xerox..." + content);
        }
    }

    public class CanonPrinter : IPrinter
    {
        public void PerformPrint(string content)
        {
            Console.WriteLine("Performing Print..." + content);
        }

        public void PerformScan(string content)
        {
            Console.WriteLine("Performing Scan..." + content);
        }

        public void PerformXerox(string content)
        {
            throw new NotImplementedException();
        }
        public void PerformFax(string content)
        {
            throw new NotImplementedException();
        }

    }


    // Solution
    interface IPrinterSol
    {
        void PerformScan(string content);
        void PerformPrint(string content);
    }

    interface IXerox
    {

        void PerformXerox(string content);
    }
    interface IFax
    {
        void PerformFax(string content);
    }


    public class HPPrinterSol : IPrinterSol, IXerox, IFax
    {
        public void PerformFax(string content)
        {
            Console.WriteLine("Performing Fax..." + content);
        }

        public void PerformPrint(string content)
        {
            Console.WriteLine("Performing Print..." + content);
        }

        public void PerformScan(string content)
        {
            Console.WriteLine("Performing Scan..." + content);
        }

        public void PerformXerox(string content)
        {
            Console.WriteLine("Performing Xerox..." + content);
        }
    }

    // We are Elimination Unused Methods which are not used/required by the client
    public class CanonPrinterSol : IPrinterSol
    {
        public void PerformPrint(string content)
        {
            Console.WriteLine("Performing Print..." + content);
        }

        public void PerformScan(string content)
        {
            Console.WriteLine("Performing Scan..." + content);
        }

    }

}
