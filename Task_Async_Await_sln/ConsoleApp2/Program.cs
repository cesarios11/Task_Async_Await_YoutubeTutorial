using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await MakeBreakFastAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                string errorInnerException = ex.InnerException!= null? ex.InnerException.Message: string.Empty;
                string errorStackTrace = ex.StackTrace;
                Console.WriteLine($"Error Message: {errorMessage}\nError InnerException: {errorInnerException}\n Error StackTrace:{errorStackTrace}");
            }
            finally 
            {
                Console.ReadLine();
            }
        }       

        static async Task MakeBreakFastAsync()
        {
            Console.WriteLine("Adding 1 to 2 teaspoons of coffee to a mug...");
            var boilingWater = BoilWaterAsync();
            var heatingMilk = HeatMilkAsync();
            Console.WriteLine("Add sugar ... ");
            Console.WriteLine("Set table ... ");

            var hotWater = await boilingWater;
            var hotMilk = await heatingMilk;

            Pour(hotWater);
            Pour(hotMilk);     
            
            Console.WriteLine("Drink!");
        }

        //TODO: Metodo servir
        static void Pour(string drink)
        {
            Console.WriteLine($"Pouring {drink} in mug ...");
        }       

        #region async methods
        //TODO:Metodo hervir el agua
        static async Task<string> BoilWaterAsync()
        {
            Console.WriteLine("Boiling water started...");
            Console.WriteLine("Waiting for water to be hot...");
            await Task.Delay(13000);
            Console.WriteLine("Boiling water completed...");

            return "Hot water";
        }

        //TODO:Metodo calentar la leche
        static async Task<string> HeatMilkAsync()
        {
            Console.WriteLine("Heating milk...");
            Console.WriteLine("Waiting for milk to be hot...");
            await Task.Delay(10000);
            Console.WriteLine("Heating milk completed...");

            return "Hot milk";
        }
        #endregion async methods
    }
}
