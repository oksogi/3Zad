using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _3Zad
{
    class Matrix
    {
        private int n;
        private int[,] mas;

        // Создаем конструкторы матрицы
        public Matrix() { }
        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }

     
        public Matrix(int n)
        {
            this.n = n;
            mas = new int[this.n, this.n];
        }
        public int this[int i, int j]
        {
            get
            { return mas[i, j];}
            set
            { mas[i, j] = value;}

        }

        // Ввод матрицы с клавиатуры
        public void WriteMat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("Введите элемент матрицы {0}:{1}", i + 1, j + 1);
                    mas[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        // Вывод матрицы с клавиатуры
        public void ReadMat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mas[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void transp()
        {
            int tmp;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    tmp = mas[i, j];
                    mas[i, j] = mas[j, i];
                    mas[j, i] = tmp;
                    Console.WriteLine(mas[i, j] + "\t");
                }
            }
        }
        public static Matrix cmult(Matrix a, int c)
        {
            Matrix resMas = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.N; j++)
                {
                    resMas[i, j] = a[i, j] * c;
                }
            }
            return resMas;
        }

        // Умножение матрицы А на матрицу Б
        public static Matrix mult(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
                for (int j = 0; j < b.N; j++)
                    for (int k = 0; k < b.N; k++)
                        resMass[i, j] += a[i, k] * b[k, j];

            return resMass;
        }

        // Метод вычитания матрицы Б из матрицы А
        public static Matrix razn(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] - b[i, j];
                }
            }
            return resMass;
        }
        public static Matrix Sum(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] + b[i, j];
                }
            }
            return resMass;
        }
        // перегрузка операторов
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return Matrix.mult(a, b);
        }

        public static Matrix operator *(Matrix a, int b)
        {
            return Matrix.cmult(a, b);
        }
        
        public static Matrix operator -(Matrix a, Matrix b)
        {
            return Matrix.razn(a, b);
        }
        
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Matrix.Sum(a, b);
        }
        // Деструктор Matrix
        ~Matrix()
        {
            Console.WriteLine("Очистка");
        }


        class MainProgram
        {

            static void Main(string[] args)
            {
                Console.WriteLine("размерность матрицы: ");
                int nn = Convert.ToInt32(Console.ReadLine());
                // Инициализация
                Matrix a = new Matrix(nn);
                Matrix b = new Matrix(nn);
                Matrix c = new Matrix(nn);
                Matrix d = new Matrix(nn);
                Matrix f = new Matrix(nn);
                Matrix s = new Matrix(nn);
                
               
                Console.WriteLine("Матрица А: ");
                a.WriteMat();
                Console.WriteLine("Матрица B: ");
                b.WriteMat();

                Console.WriteLine("МАТРИЦА А: ");
                a.ReadMat();
                Console.WriteLine();
                Console.WriteLine("МАТРИЦА В: ");
                Console.WriteLine();
                b.ReadMat();
                
                Console.WriteLine("Транспонированная А: ");
                a.transp();
                a.ReadMat();

                Console.WriteLine(" А + B: ");
                c = (a + b);
                c.ReadMat();

                Console.WriteLine(" A - B: ");
                d = (a - b);
                d.ReadMat();

                Console.WriteLine(" А * Б: ");
                f = (a * b);
                f.ReadMat();

                

               
                Console.ReadKey();
            }
        }
    }
}
