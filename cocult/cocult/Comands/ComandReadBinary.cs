using MessagePack;
using MessagePack.Resolvers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cocult.Comands
{
    class ComandReadBinary : IComand
    {
        /// <summary>
        /// список со всеми сохраненными файлами
        /// </summary>
        private List<string> _paths;

        /// <summary>
        /// список для хранения фигур
        /// </summary>
        ListFigure<Figure> _listEnteredShapes;

        /// <summary>
        /// название команды
        /// </summary>
        public string NameComand { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="paths">список сохраненных файлов</param>
        public ComandReadBinary(List<string> paths, ListFigure<Figure> _listEnteredShapes)
        {
            NameComand = "читать_бинар";
            this._paths = paths;
            this._listEnteredShapes = _listEnteredShapes;
        }

        /// <summary>
        /// команда для вывода сохраненных фигур в бинарном файле
        /// </summary>
        /// <param name="data">путь файла</param>
        public void Execute(string data)
        {
            Console.Clear();
            _listEnteredShapes.Clear();
            try
            {
                using (FileStream fs = new FileStream(data, FileMode.Open))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    
                    while (reader.PeekChar() > -1)
                    {
                        byte typeByte = reader.ReadByte();
                        switch ((Figurs)typeByte)
                        {
                            case Figurs.Rectengle:
                                Rectangle rectangle = new Rectangle();
                                rectangle.ReaderBinary(reader, _listEnteredShapes);
                                break;

                            case Figurs.Tringle:
                                Triangle triangle = new Triangle();
                                triangle.ReaderBinary(reader, _listEnteredShapes);
                                break;

                            case Figurs.Square:
                                Square square = new Square();
                                square.ReaderBinary(reader, _listEnteredShapes);
                                break;

                            case Figurs.Polygon:
                                int length = reader.ReadInt32();
                                Polygon polygon = new Polygon();
                                polygon.ReaderBinary(reader, _listEnteredShapes, length);
                                break;

                            case Figurs.Circle:
                                Circle circle = new Circle();
                                circle.ReaderBinary(reader, _listEnteredShapes);
                                break;

                            default:
                                throw new InvalidOperationException("Unknown figure type");
                        }
                    }
                }

                Console.WriteLine($"Файл загружен");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Не корректный файл {ex}");
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("не правильно введен файл или такого не существует");
            }
        }

        
    }
}
