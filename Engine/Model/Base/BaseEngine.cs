using System.Collections.Generic;

namespace Engine.Model.Base
{
    internal abstract class BaseEngine
    {
        #region Свойства
        // Температура двигателя
        public double Te { get; protected set; }
        // Температура перегрева
        public double To { get; protected set; }
        // Коэффициент зависимости скорости нагрева от крутящего момента
        public double Hm { get; protected set; }
        // Коэффициент зависимости скорости нагрева от скорости вращения коленвала
        public double Hv { get; protected set; }
        // Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды
        public double C { get; protected set; }
        // Ускорение
        public double A { get; protected set; }
        // Скорость нагрева двигателя
        public double Vh { get; protected set; }
        // Скорость охлаждения двигателя
        public double Vc { get; protected set; }
        // Момент инерции двигателя
        public double I { get; protected set; }
        // Текущее значение крутящего момента 
        public double M { get; protected set; }
        // Текущее значение скорости вращения коленвала
        public double V { get; protected set; }
        // Индекс
        public int Index { get; protected set; } = 0;
        // Значения крутящего момента 
        public IList<double> MList { get; protected set; }
        // Значения скорости вращения коленвала
        public IList<double> VList { get; protected set; }
        #endregion

        #region Методы
        // Ускорение
        public abstract double Acceleration();
        // Скорость нагрева двигателя
        public abstract double EngineHeatingRate();
        // Скорость охлаждения двигателя Tenv - температура окружающей среды
        public abstract double EngineCoolingRate(double Tenv);
        // Общая скорость
        public abstract double EngineRate();
        // Текущая температура двигателя
        public abstract void GetEngineTemperature(double Tdif, double Tenv);
        // Перегрет ли двигатель
        public bool IsOverHeat()
        {
            if (Te > To) return true;
            return false;
        }
        #endregion
    }
}
