using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace cocult
{
    /// <summary>
    /// абстрактный базовый класс для всех фигур
    /// </summary>
    public abstract class Figure
    {
        
        /// <summary>
        /// обстрактный метод для вычисления площади
        /// </summary>
        /// <returns>возращает тип дабл</returns>
        public abstract double S();
        /// <summary>
        /// обстрактный метод для вычисления периметра
        /// </summary>
        /// <returns>возращает тип дабл</returns>
        public abstract double P();

        /// <summary>
        /// абстрактный метод который определяет запись фигуры
        /// </summary>
        /// <param name="writer"></param>
        public abstract void WriteBinary(BinaryWriter writer);
        /// <summary>
        /// абстрактный метод который определяет чтения фигуры
        /// </summary>
        /// <param name="writer"></param>
        public abstract void ReaderBinary(BinaryReader reader,List<Figure> figures,int n = 0);
    }
}
