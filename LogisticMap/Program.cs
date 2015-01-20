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
            public double r0 { get; set; }
            public double rf { get; set; }
            public int Decimals { get; set; }
            public int Iterations { get; set; }


            public Ecuation(/*double iniX, double finX, double iniR, double finR, int decimals, int iterations*/)
            {
                //Decimals = decimals;
                //x0 = Math.Round(iniX, Decimals);
                //xf = Math.Round(finX, Decimals);
                //r0 = Math.Round(iniR, Decimals);
                //rf = Math.Round(finR, Decimals);
                //Iterations = iterations;
            }
            public void Run()
            {
               
                Console.WriteLine("Ingrese x0:");
                x0 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Ha ingresado el valor " + x0);

                xf = this.getXFInal();

                Console.WriteLine("Ingrese R:");
                r0 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Ha ingresado el valor " + r0);

                Console.WriteLine("Ingrese el nro de iteraciones:");
                Iterations = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ha ingresado el valor " + Iterations);

                Console.WriteLine("Ingrese el maximo nro de decimales con los que va a trabajar:");
                Decimals = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ha ingresado el valor " + Decimals);

                x0 = Math.Round(x0, Decimals);
                xf = Math.Round(xf, Decimals);
                r0 = Math.Round(r0, Decimals);
                //rf = Math.Round(rf, Decimals);

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
                double r = r0;
                Console.WriteLine("{0:N20} se redondea a {0}", x0);
                Console.Read();
                Console.WriteLine("Plots from x0 = " + x0 + " to xf = " + xf + " through " + Iterations + " Iterations");
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("");
                double sum = 1.0/(10^Decimals);
                sum = Math.Round(sum, Decimals);
                int iter = 0;
                for (double x = x0; x <= xf; x+=sum)
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

