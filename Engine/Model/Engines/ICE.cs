using System;
using Engine.Model.Base;
using System.Configuration;
using System.Linq;

namespace Engine.Model.Engines
{
    internal class ICE : BaseEngine, IGetConfigureData
    {
        #region Реализация методов
        public override double Acceleration()
        {
            return M / I;
        }
        public override double EngineCoolingRate(double Tenv)
        {
            return C * (Tenv - Te);
        }
        public override double EngineHeatingRate()
        {
            return M * Hm + V * V + Hv;
        }
        public override double EngineRate()
        {
            return Vc + Vh;
        }
        public override void GetEngineTemperature(double Tdif, double Tenv)
        {
            Vh = EngineHeatingRate();
            Vc = EngineCoolingRate(Tenv);
            var Vhc = EngineRate();
            Te += Vhc * Tdif;
            V += A * Tdif;
            M += Interpolation.LinearInterpolation(VList, MList, Index, V);
            A = Acceleration();
            if (Index < MList.Count - 1)
                Index += V < VList[Index + 1] ? 0 : 1;
        }
        #endregion

        #region Реализация интерфейса
        public void GetData()
        {
            I = double.Parse(ConfigurationManager.AppSettings["I"]);
            To = double.Parse(ConfigurationManager.AppSettings["To"]);
            Hm = double.Parse(ConfigurationManager.AppSettings["Hm"]);
            Hv = double.Parse(ConfigurationManager.AppSettings["Hv"]);
            C = double.Parse(ConfigurationManager.AppSettings["C"]);
            var _MList = ConfigurationManager.AppSettings["M"];
            var _VList = ConfigurationManager.AppSettings["V"];
            MList = _MList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select((item) => double.Parse(item))
                .ToArray();
            VList = _VList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select((item) => double.Parse(item))
                .ToArray();
        }
        #endregion

        public ICE(double Tenv)
        {
            GetData();
            Te = Tenv;
            V = VList[Index];
            M = MList[Index];
            A = Acceleration();
        }
    }
}
