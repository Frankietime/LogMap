using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticMap
{
    class Program
    {
        static void Main(string[] args)
        {
            Ecuation LogMap = new Ecuation(/*0.9, 0.9, 2, 1.3, 1, 20*/);
            Console.WriteLine("Press ENTER to start application...");
            Console.ReadKey();
            LogMap.Run();
        }
        public class Ecuation
        {
            public double x0 { get; set; }
            public double xf { get; set; }
            public double R { get; set; }
            public int Decimals { get; set; }
            public int Iterations { get; set; }


            public Ecuation()
            {

            }

            public void Run()
            {
               
                Console.WriteLine("Ingrese x0:");
                x0 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Ha ingresado el valor " + x0);

                xf = this.getXFInal();

                Console.WriteLine("Ingrese R:");
                R = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Ha ingresado el valor " + R);

                Console.WriteLine("Ingrese el nro de iteraciones:");
                Iterations = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ha ingresado el valor " + Iterations);

                Console.WriteLine("Ingrese el maximo nro de decimales con los que va a trabajar:");
                Decimals = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ha ingresado el valor " + Decimals);

                x0 = Math.Round(x0, Decimals);
                xf = Math.Round(xf, Decimals);
                R = Math.Round(R, Decimals);

                this.RunEcuation();
            }
            public double getXFInal() 
            {
                Console.WriteLine("Ingrese xf:");
                double xf = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Ha ingresado el valor " + xf);
                
                if(xf < x0)
                {
                    Console.WriteLine("xf no puede ser mayor a x0 = " + x0);
                    this.getXFInal();
                }
                return xf;
            }
            public void RunEcuation()
            {
                double[] plot = new double[20];
                // Iterations R fijo
                double r = R;
                Console.WriteLine("{0:N20} se redondea a {0}", x0);
                Console.Read();
                Console.WriteLine("Plots from x0 = " + x0 + " to xf = " + xf + " through " + Iterations + " Iterations");
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("");
                double incremental = 1 / (Math.Pow(10.0, Decimals));
                Console.WriteLine("Cada iteracion incrementará a x en " + incremental);
                
                incremental = Math.Round(incremental, Decimals);
                int iter = 0;
                for (double x = x0; x <= xf; x+=incremental)
                {
                    double xt = x;
                    for (int j = 0; j < Iterations; j++)
                    {
                        xt = r * xt * (1 - xt);
                        xt = Math.Round(xt, Decimals+1);
                        plot[j] = xt;
                    }
                    Console.WriteLine("Interación nro " + iter);
                    Console.WriteLine("Plot para X = " + x);
                    for (int o = 0; o < Iterations; o++)
                    {
                        Console.WriteLine("\t X" + o + " = " + plot[o]);
                    }
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.ReadKey();
                    iter ++;
                }
                Console.WriteLine("-----------------------------------------------");
                Console.ReadKey();

            }
        }        
    }
}

