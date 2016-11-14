using System;

namespace inetr
{
    public interface ISimplFigure
    {
        double fhight { get; set; }
        double fbase { get; set; }
        double angle { get; set; }
        int numberofsides { get; }
        double lengthofsides { get; set; }
        double rsquare { get; }
        double rperimetr { get; }
    }
    abstract class GFigure
    {
        protected double _fhight;
        protected double _fbase;
        protected double _angle;
        protected int _numberofsides;
        protected double _lengthofsides;
        protected double _fsquare;
        protected double _fperimetr;
        public GFigure() { }
        public double readfsquare
        {
            get { return _fsquare; }
        }
        public double readfperimetr
        {
            get { return _fperimetr; }
        }
    }
    class Square : GFigure, ISimplFigure
    {
        public Square() { }
        public Square(double size)
        {
            if (size <= 0)
                throw new GFigureExeption("Invalid value for base!");
            else
            {
                _fbase = size;
                _fhight = size;
                _fsquare = size * size;
                _fperimetr = size * 4;
                _angle = 90;
                _numberofsides = 4;
                _lengthofsides = size;
            }
        }
        void PropertySet(double fvalue)
        {
            _fbase = fvalue;
            _fhight = fvalue;
            _fsquare = fvalue * fvalue;
            _fperimetr = fbase * 4;
            _lengthofsides = fvalue;
        }
        public double rsquare { get { return _fsquare; } }
        public double rperimetr { get { return _fperimetr; } }
        public double fhight
        {
            get { return _fhight; }
            set
            {
                if (value <= 0)
                    throw new GFigureExeption("Invalid value for height!");
                else
                {
                    PropertySet(value);
                }
            }
        }
        public double fbase
        {
            get { return _fbase; }
            set
            {
                if (value <= 0)
                    throw new GFigureExeption("Invalid value for base!");
                else
                {
                    PropertySet(value);
                }
            }
        }
        public double angle
        {
            get { return _angle; }
            set { throw new GFigureExeption("Impossible to change the angle"); }
        }
        public int numberofsides
        {
            get { return _numberofsides; }
        }
        public double lengthofsides
        {
            get { return _lengthofsides; }
            set
            {
                if (value <= 0)
                    throw new GFigureExeption("Invalid value for lengthofsides!");
                else
                {
                    PropertySet(value);
                }
            }
        }
    }
    class Rhomb : GFigure, ISimplFigure
    {
        public Rhomb() { }
        public Rhomb(double size, double hight)
        {
            if (size <= 0 || hight <= 0)
                throw new GFigureExeption("Invalid value for size or hight!");
            else
            {
                _fhight = hight;
                _fbase = size;
                _fsquare = size * hight;
                _fperimetr = size * 4;
                _angle = Math.Asin(_fhight / _fbase);
                _numberofsides = 4;
                _lengthofsides = size;
            }
        }
        void PropertySet(double fvalue)
        {
            _fbase = fvalue;
            _fhight = Math.Sin(angle) * fvalue;
            _fsquare = fvalue * _fhight;
            _fperimetr = fvalue * 4;
            _lengthofsides = fvalue;
        }
        public double rsquare { get { return _fsquare; } }
        public double rperimetr { get { return _fperimetr; } }
        public double fhight
        {
            get { return _fhight; }
            set
            {
                if (value > _fbase || value < 0)
                    throw new GFigureExeption("Invalid value for height!");
                else
                {
                    _fhight = value;
                    _fsquare = _fbase * value;
                    _angle = Math.Asin(_fsquare / (_fbase * _fbase));
                }
            }
        }
        public double fbase
        {
            get { return _fbase; }
            set
            {
                if (value <= 0)
                    throw new GFigureExeption("Invalid value for base!");
                else
                {
                    PropertySet(value);
                }
            }
        }
        public double angle
        {
            get { return _angle; }
            set
            {
                if (value <= 0 || value == 0)
                    throw new GFigureExeption("Invalid value for angle!");
                else
                {
                    angle = value;
                    _fhight = Math.Sin(value) * _fbase;
                    _fsquare = _fbase * _fhight;
                }
            }
        }
        public int numberofsides
        {
            get { return _numberofsides; }
        }
        public double lengthofsides
        {
            get { return _lengthofsides; }
            set
            {
                if (value <= 0)
                    throw new GFigureExeption("Invalid value for lengthofsides!");
                else
                {
                    PropertySet(value);
                }
            }
        }
    }
    class Triangle : GFigure, ISimplFigure
    {
        double _sizeA;
        double _sizeB;
        double _sizeC;
        public Triangle() { }
        public Triangle(double sizeA, double sizeB, double sizeC)
        {
            if ((sizeA <= 0 || sizeB <= 0 || sizeC <= 0) ||
            ((sizeA + sizeB) < sizeC || (sizeB + sizeC) < sizeA || (sizeC + sizeA) < sizeB))
                throw new GFigureExeption("Invalid value for size!");
            else
            {
                _sizeA = sizeA;
                _sizeB = sizeB;
                _sizeC = sizeC;
                _fbase = sizeA;
                _fperimetr = sizeA + sizeB + sizeC;
                _fsquare = Math.Sqrt(((_fperimetr / 2 - sizeA) * (_fperimetr / 2 - sizeB) * (_fperimetr / 2 - sizeC) * _fperimetr / 2));
                _fhight = _fsquare / (sizeA * 0.5);
                _angle = Math.Asin(_fhight / sizeC);
                _numberofsides = 3;
            }
        }
        public double rsquare { get { return _fsquare; } }
        public double rperimetr { get { return _fperimetr; } }
        public double fhight
        {
            get { return _fhight; }
            set
            {
                if (value > _fbase || value < 0)
                    throw new GFigureExeption("Invalid value for height!");
                else
                {
                    _fhight = value;
                    _fsquare = _fbase * value * 0.5;
                    _angle = Math.Atan(_fhight / (Math.Cos(_angle) * _sizeC));
                    _sizeC = _fhight / Math.Sin(_angle);
                    _sizeB = _fhight / (Math.Sin(Math.Acos(_sizeA - (_fhight / Math.Tan(_angle)) / _fhight)));
                    _fperimetr = _sizeA + _sizeB + _sizeC;
                }
            }
        }
        public double fbase
        {
            get { return _fbase; }
            set
            {
                if (value > 0)
                {
                    _fbase = value;
                    _sizeA = value;
                    _fsquare = _fhight * value * 0.5;
                    _angle = Math.Asin(_fhight / _sizeB);
                    _sizeC = (_fsquare * 2) / (_sizeA * Math.Sin(_angle));
                    _fperimetr = _sizeA + _sizeB + _sizeC;
                }
            }
        }
        public double angle
        {
            get { return _angle; }
            set
            {
                if (value <= 0 || value > 90)
                    throw new GFigureExeption("Invalid value for angle!");
                else
                {
                    _angle = value;
                    _sizeC = _fhight / Math.Sin(value);
                    _angle = Math.Asin(_fhight / _sizeB);
                    _sizeA = Math.Cos(Math.Asin(_fhight / _sizeB)) * _sizeB + _fhight / _sizeC;
                    _fperimetr = _sizeA + _sizeB + _sizeC;
                    _fsquare = _fhight * _sizeA * 0.5;
                }
            }
        }
        public int numberofsides
        {
            get { return _numberofsides; }
        }
        public double lengthofsides
        {
            get { return _sizeC; }
            set
            { throw new GFigureExeption("Impossible to change the number of lengthofsides"); }
        }
    }
    class Rectangle : GFigure, ISimplFigure
    {
        double _sizeA;
        double _sizeB;
        public Rectangle() { }
        public Rectangle(double sizeA, double sizeB)
        {
            if (sizeA <= 0 || sizeB <= 0)
                throw new GFigureExeption("Invalid value for size!");
            else
            {
                _sizeA = sizeA;
                _sizeB = sizeB;
                _fhight = sizeB;
                _fbase = sizeA;
                _fsquare = sizeA * sizeB;
                _fperimetr = (sizeA + sizeB) * 2;
                _angle = 90;
                _numberofsides = 4;
                _lengthofsides = sizeB;
            }
        }
        void PropertySet(double fvalue)
        {
            _lengthofsides = fvalue;
            _fhight = fvalue;
            _sizeB = fvalue;
            _fsquare = _sizeA * fvalue;
            _fperimetr = (_sizeA + fvalue) * 2;
        }
        public double rsquare { get { return _fsquare; } }
        public double rperimetr { get { return _fperimetr; } }
        public double fhight
        {
            get { return _fhight; }
            set
            {
                if (value <= 0)
                    throw new GFigureExeption("Invalid value for height!");
                else
                {
                    PropertySet(value);
                }
            }
        }
        public double fbase
        {
            get { return _fbase; }
            set
            {
                if (value <= 0)
                    throw new GFigureExeption("Invalid value for height!");
                else
                {
                    _fbase = value;
                    _sizeA = value;
                    _fsquare = _sizeB * value;
                    _fperimetr = (value + _sizeB) * 2;
                }
            }
        }
        public double angle
        {
            get { return _angle; }
            set { throw new GFigureExeption("Impossible to change the angle"); }
        }
        public int numberofsides
        {
            get { return _numberofsides; }
        }
        public double lengthofsides
        {
            get { return _lengthofsides; }
            set
            {
                if (value <= 0)
                    throw new GFigureExeption("Invalid value for lengthofsides!");
                else
                {
                    PropertySet(value);
                }
            }
        }
    }
    class Parallelogram : GFigure, ISimplFigure
    {
        double _sizeA;
        double _sizeB;
        public Parallelogram() { }
        public Parallelogram(double hight, double sizeA, double sizeB)
        {
            if (hight <= 0 || sizeA <= 0 || sizeB <= 0)
                throw new GFigureExeption("Invalid value for size or hight!");
            else
            {
                _sizeA = sizeA;
                _sizeB = sizeB;
                _fhight = hight;
                _fbase = sizeA;
                _fsquare = sizeA * hight;
                _fperimetr = (sizeA + sizeB) * 2;
                _angle = Math.Asin(hight / sizeB);
                _numberofsides = 4;
                _lengthofsides = sizeB;
            }
        }
        public double rsquare { get { return _fsquare; } }
        public double rperimetr { get { return _fperimetr; } }
        public double fhight
        {
            get { return _fhight; }
            set
            {
                if (value <= 0)
                    throw new GFigureExeption("Invalid value for height!");
                else
                {
                    _fhight = value;
                    _angle = Math.Atan(_fhight / (Math.Cos(_angle) * _sizeB));
                    _sizeB = _fhight / Math.Sin(_angle);
                    _fsquare = _sizeA * _fhight;
                    _fperimetr = (_sizeA + _sizeB) * 2;
                }
            }
        }
        public double fbase
        {
            get { return _fbase; }
            set
            {
                if (value <= 0)
                    throw new GFigureExeption("Invalid value for height!");
                else
                {
                    _fbase = value;
                    _sizeA = value;
                    _fsquare = _sizeA * _fhight;
                    _fperimetr = (_sizeA + _sizeB) * 2;
                }
            }
        }
        public double angle
        {
            get { return _angle; }
            set { throw new GFigureExeption("Impossible to change the angle"); }
        }
        public int numberofsides
        {
            get { return _numberofsides; }
        }
        public double lengthofsides
        {
            get { return _lengthofsides; }
            set
            {
                if (value <= 0)
                    throw new GFigureExeption("Invalid value for lengthofsides!");
                else
                {
                    _lengthofsides = value;
                    _sizeB = value;
                    _fhight = Math.Sin(_angle) * _sizeB; ;
                    _fsquare = _sizeA * _fhight;
                    _fperimetr = (_sizeA + _sizeB) * 2;
                }
            }
        }
    }
    class Round : GFigure
    {
        double _radius;
        public Round() { }
        public Round(double radius)
        {
            if (radius <= 0)
                throw new GFigureExeption("Invalid value for radius!");
            else
            {
                _radius = radius;
                _fsquare = Math.Pow(radius, 2) * Math.PI;
                _fperimetr = Math.PI * 2 * radius;
            }
        }
        public double radius
        {
            get { return _radius; }
            set
            {
                if (value <= 0)
                    throw new GFigureExeption("Invalid value for radius!");
                else
                {
                    radius = value;
                    _fsquare = Math.Pow(radius, 2) * Math.PI;
                    _fperimetr = Math.PI * 2 * radius;
                }
            }
        }
    }
    class CompoundShapes
    {
        private double _fsquare;
        public CompoundShapes() { }
        public CompoundShapes(params ISimplFigure [] objs) 
        {
            for (int i = 0; i < objs.Length;++i)
                _fsquare += objs[i].rsquare;
        }
        public void AddFigure(ISimplFigure obj)
        {
            if (obj.rsquare == 0)
                throw new GFigureExeption();
            else
                _fsquare += obj.rsquare;
        }
        public void RemoveFigure(ISimplFigure obj)
        {
            if (obj.rsquare == 0)
                throw new GFigureExeption("Error to remove an empty figure!");
            else
                _fsquare -= obj.rsquare;
        }
        public double ReturnSquare()
        {
            return _fsquare;
        }
    }
    class GFigureExeption : ApplicationException
    {
        public GFigureExeption() : base() { }
        public GFigureExeption(string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }
    class MainClass
    {
        public static void Main()
        {
            try
            {
                Rhomb R = new Rhomb(10, 5);
                Console.WriteLine("Rhomb:\nhight:{0}\nbase:{1}\nangle:{2}\nnumberofsides:{3}\nlengthofsides:{4}\nsquare:{5}\nperimetr:{6}\n",
                           R.fhight, R.fbase, R.angle, R.numberofsides, R.lengthofsides, R.readfsquare, R.readfperimetr);
                Parallelogram P = new Parallelogram(5, 10, 11);
                Console.WriteLine("Parallelogram:\nhight:{0}\nbase:{1}\nangle:{2}\nnumberofsides:{3}\nlengthofsides:{4}\nsquare:{5}\nperimetr:{6}\n",
                           P.fhight, P.fbase, P.angle, P.numberofsides, P.lengthofsides, P.readfsquare, P.readfperimetr);
                Triangle T = new Triangle(12, 5, 8);
                Console.WriteLine("Triangle:\nhight:{0}\nbase:{1}\nangle:{2}\nnumberofsides:{3}\nlengthofsides:{4}\nsquare:{5}\nperimetr:{6}\n",
                           T.fhight, T.fbase, T.angle, T.numberofsides, T.lengthofsides, T.readfsquare, T.readfperimetr);
                Rectangle Rec = new Rectangle(10, 15);
                Console.WriteLine("Rectangle:\nhight:{0}\nbase:{1}\nangle:{2}\nnumberofsides:{3}\nlengthofsides:{4}\nsquare:{5}\nperimetr:{6}\n",
                           Rec.fhight, Rec.fbase, Rec.angle, Rec.numberofsides, Rec.lengthofsides, Rec.readfsquare, Rec.readfperimetr);
                Square S = new Square(10);
                Console.WriteLine("Square:\nhight:{0}\nbase:{1}\nangle:{2}\nnumberofsides:{3}\nlengthofsides:{4}\nsquare:{5}\nperimetr:{6}\n",
                           S.fhight, S.fbase, S.angle, S.numberofsides, S.lengthofsides, S.readfsquare, S.readfperimetr);
                Round Rou = new Round(10);
                Console.WriteLine("Round:\nsquare:{0}\nperimetr:{1}\n", S.readfsquare, S.readfperimetr);
                CompoundShapes CS = new CompoundShapes();
                CS.AddFigure(R);
                CS.AddFigure(P);
                CS.AddFigure(T);
                CS.AddFigure(Rec);
                CS.AddFigure(S);
                Rhomb Rq = new Rhomb();
                CS.AddFigure(Rq);
                Console.WriteLine(CS.ReturnSquare());
                CS.RemoveFigure(S);
                Console.WriteLine(CS.ReturnSquare());
            }
            catch (GFigureExeption exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
