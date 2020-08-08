using Engine.Model.Engines;

namespace Engine.Model.SimulateModel
{
    internal class TestBench
    {
        #region Поля
        // ДВС
        private ICE _ICE = new ICE(Tenv);
        // Шаг
        private double _Tdif = 0.01;
        #endregion

        #region Свойства
        // Время
        public double Time { get; private set; } = 0;
        // Температура окружающей среды
        public static double Tenv { get; set; }
        #endregion

        #region Тест ДВС
        public double TestStartICE()
        {
            while (true)
            {
                if (_ICE.IsOverHeat()) break;
                _ICE.GetEngineTemperature(_Tdif, Tenv);
                Time++;
            }
            return Time;
        }
        #endregion

        public TestBench(double T)
        {
            Tenv = T;
        }
    }
}
