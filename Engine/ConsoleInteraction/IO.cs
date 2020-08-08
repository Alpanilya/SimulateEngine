using Engine.Model.SimulateModel;
using System;
using System.Text.RegularExpressions;

namespace Engine.ConsoleInteraction
{
    internal class IO
    {
        private static double Input()
        {
            Console.Write("Введите текущую температуру окружающей среды: \n");
            var input = Console.ReadLine();
            if(Regex.IsMatch(input, @"^(\d(?:[.,]\d)?)+$"))
            {
                var Tenv = double.Parse(input);
                return Tenv;
            }
            throw new FormatException();
        }
        public static void Output()
        {
            var Tenv = Input();
            TestBench _TestBench = new TestBench(Tenv);
            Console.WriteLine("Время перегрева двигателя на тестовом стенде \n{0}", _TestBench.TestStartICE());
        }
    }
}
