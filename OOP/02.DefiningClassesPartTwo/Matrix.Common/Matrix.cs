using System;
using System.Linq;
using System.Text;

namespace Matrix.Common
{
    [Version(2.11)]
    public class Matrix<T> where T:IComparable
    {
        // Fields
        private readonly T[,] matrix;
        private readonly int rows;
        private readonly int columns;

        // Constructors
        public Matrix(int rows, int columns)
        {
            this.matrix = new T[rows, columns];
            this.rows = rows;
            this.columns = columns;
        }

        // Properties

        public int Columns
        {
            get
            {
                return this.columns;
            }
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }
        }

        // Methods
        public void DisplayAttributes(Matrix<T> a)
        {
            object[] attributeArray = a.GetType().GetCustomAttributes(true);
            foreach (var attribute in attributeArray)
            {
                Console.WriteLine(attribute);
            }
        }

        // Indexer declaration
        public T this[int row, int col]
        {
            get
            {
                if (row < this.matrix.GetLength(0) && col < this.matrix.GetLength(1))
                {
                    return this.matrix[row, col];
                }
                else
                {
                    throw new IndexOutOfRangeException(string.Format("Invalid index: {0},{1}", row, col));
                }
            }
            set
            {
                if (row < this.matrix.GetLength(0) && col < this.matrix.GetLength(1))
                {
                    if (value != null)
                    {
                        this.matrix[row, col] = value;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input");
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException(string.Format("Invalid index: {0},{1}", row, col));
                }
            }
        }

        // Operator overloading
        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
        {
            Matrix<T> result = new Matrix<T>(a.rows, a.columns);
            dynamic valueA;
            dynamic valueB;
            if (a.rows == b.rows && a.columns == b.columns)
            {
                for (int rows = 0; rows < a.rows; rows++)
                {
                    for (int cols = 0; cols < a.columns; cols++)
                    {
                        valueA = a[rows,cols];
                        valueB = b[rows, cols];
                        result[rows, cols] = valueA + valueB;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Matrices are not equal");
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
        {
            Matrix<T> result = new Matrix<T>(a.rows, a.columns);
            dynamic valueA;
            dynamic valueB;
            if (a.rows == b.rows && a.columns == b.columns)
            {
                for (int rows = 0; rows < a.rows; rows++)
                {
                    for (int cols = 0; cols < a.columns; cols++)
                    {
                        valueA = a[rows, cols];
                        valueB = b[rows, cols];
                        result[rows, cols] = valueA - valueB;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Matrices are not equal");
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            Matrix<T> result = new Matrix<T>(a.rows, b.columns);
            dynamic valueA;
            dynamic valueB;
            dynamic valueC = 0;
            if (a.columns == b.rows)
            {
                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < b.columns; j++)
                    {
                        valueC = 0;
                        result[i, j] = valueC;
                        for (int k = 0; k < a.columns; k++)
                        {
                            valueA = a[i, k];
                            valueB = b[k, j];
                            valueC = valueA * valueB;
                            result[i, j] += valueC;
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Invalid operation");
            }
            return result;
        }

        // Overloading true operator to return true if there are
        // no elements equal to zero
        public static bool operator true(Matrix<T> a)
        {
            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                {
                    dynamic temp = a[i, j];
                    if (temp == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // Overloading false operator to return false if there are
        // no elements equal to zero
        public static bool operator false(Matrix<T> a)
        {
            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                {
                    dynamic temp = a[i, j];
                    if (temp == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Overriding ToString()
        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    myBuilder.AppendFormat("{0}\t", this.matrix[i, j]);
                }
                myBuilder.AppendLine();
            }
            return myBuilder.ToString();
        }
    }
}
