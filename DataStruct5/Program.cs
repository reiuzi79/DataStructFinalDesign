using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct5
{
    class DataStruct5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("稀疏矩阵运算器");
            Console.WriteLine("1.输入矩阵A");
            Console.WriteLine("2.输入矩阵B");
            Console.WriteLine("3.输出矩阵A及其三元组表");
            Console.WriteLine("4.输出矩阵B及其三元组表");
            Console.WriteLine("5.输出A+B");
            Console.WriteLine("6.输出A-B");
            Console.WriteLine("7.输出B-A");
            Console.WriteLine("8.输出A×B");
            Console.WriteLine("9.输出B×A");
            Console.WriteLine("输入（1-9）操作：");
            Matrix A = null;
            Matrix B = null;
            while(true)
            {
                string i = Console.ReadLine();
                switch(i)
                {
                    case "1":
                        Console.WriteLine("输入矩阵A（行列不超过20，非零元数不超过行×列）");
                        Console.Write("请输入最大行数：（1-20）：");
                        reinput1: try
                        {
                            int row = int.Parse(Console.ReadLine());
                            Console.Write("请输入最大列数：（1-20）：");
                            int col = int.Parse(Console.ReadLine());
                            if (row < 1 || col < 1 || row > 20 || col > 20) throw new Exception("行列数不合法！");
                            int count = row * col;
                            Console.Write("请输入非零元数：（1-" + count + "）：");
                            count = int.Parse(Console.ReadLine());
                            if (count > row * col || count < 1)
                            {
                                throw new Exception("非零元数不合法！");
                            }
                            A = new Matrix(row, col, count);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("重新输入");
                            goto reinput1;
                        }
                        break;
                    case "2":
                        Console.WriteLine("输入矩阵B（行列不超过20，非零元数不超过行×列）");
                        Console.Write("请输入最大行数：（1-20）：");
                    reinput2: try
                        {
                            int row = int.Parse(Console.ReadLine());
                            Console.Write("请输入最大列数：（1-20）：");
                            int col = int.Parse(Console.ReadLine());
                            if (row < 1 || col < 1 || row > 20 || col > 20) throw new Exception("行列数不合法！");
                            int count = row * col;
                            Console.Write("请输入非零元数：（1-" + count + "）：");
                            count = int.Parse(Console.ReadLine());
                            if (count > row * col || count < 1)
                            {
                                throw new Exception("非零元数不合法！");
                            }
                            B = new Matrix(row, col, count);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("重新输入");
                            goto reinput2;
                        }
                        break;
                    case "3":
                        Console.WriteLine("打印矩阵A及其三元组表");
                        A.print();
                        Console.WriteLine();
                        A.printmatrix();
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine("打印矩阵B及其三元组表");
                        B.print();
                        Console.WriteLine();
                        B.printmatrix();
                        Console.WriteLine();
                        break;
                    case "5":
                        Console.WriteLine("打印矩阵A+B");
                        try
                        {
                            int[][] m = MatrixMethod.addOrMinus(A, B, 1);
                            printarray(m);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "6":
                        Console.WriteLine("打印矩阵A-B");
                        try
                        {
                            int[][] m = MatrixMethod.addOrMinus(A, B, 0);
                            printarray(m);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "7":
                        Console.WriteLine("打印矩阵B-A");
                        try
                        {
                            int[][] m = MatrixMethod.addOrMinus(B, A, 0);
                            printarray(m);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "8":
                        Console.WriteLine("打印矩阵A×B");
                        try
                        {
                            int[][] m = MatrixMethod.multiply(A, B);
                            printarray(m);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "9":
                        Console.WriteLine("打印矩阵B×A");
                        try
                        {
                            int[][] m = MatrixMethod.multiply(B, A);
                            printarray(m);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    default:return;
                }
                Console.WriteLine("输入（1-9）继续执行操作：");
            }
        }
        internal static void printarray(int[][] m)   //打印二维数组
        {
            for (int i = 0; i < m.Length; i++)
            {
                for (int j = 0; j < m[i].Length; j++)
                {
                    Console.Write(String.Format("{0,-3} ", m[i][j]));  //每个元素右边空3格，输出元素
                }
                Console.WriteLine();
            }
        }
    }
    internal class Tuple     //三元组
    {
        internal int row;    //行、列、值
        internal int col;
        internal int value;
    }
    internal class Matrix  //矩阵
    {
        internal int maxrow;   //最大行列数，非零元数
        internal int maxcol;
        internal int count;
        internal Tuple[] tuple = null;
        internal Matrix(int mr, int mc, int count)
        {
            tuple = new Tuple[count];            //初始化三元组数组，设定最大行列数和非零元数
            this.maxrow = mr;
            this.maxcol = mc;
            this.count = count;
            create();
        }
        internal void create()   //创建矩阵
        {
            int i = 0;
            Tuple temp = null;
            while(i < count)
            {
                Console.WriteLine("输入第" + (i+1) +"个非零值三元组（行列从0记起）");
                Console.Write("输入行：");
                try
                {
                    int r, c, v;                      //记录输入值
                    r = int.Parse(Console.ReadLine());
                    Console.Write("输入列：");
                    c = int.Parse(Console.ReadLine());
                    Console.Write("输入值：");
                    v = int.Parse(Console.ReadLine());
                    if (temp != null)
                    {
                        foreach(var t in tuple)
                        {
                            if (t != null && r == t.row && c == t.col) throw new ArgumentException("此处已经有非零值，请重新输入");
                        }
                    }
                    if (r < 0 || r >= maxrow || c < 0 || c >= maxcol || v == 0) throw new ArgumentException("这组输入不合法，请重新输入");  //检查是否越界
                    else
                    {
                        temp = new Tuple();     //存入该组三元组
                        temp.row = r;
                        temp.col = c;
                        temp.value = v;
                        tuple[i] = temp;
                        i++;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(e.Message);
                }
            }
            temp = tuple[0];
            Console.WriteLine("构造矩阵成功");
        }
        internal void print()
        {
            if (tuple == null)
            {
                Console.WriteLine("请先创建矩阵");
                return;
            }
            Console.WriteLine("打印三元组");
            Console.WriteLine("行\t列\t值");
            foreach(var t in tuple)
            {
                Console.WriteLine(t.row + "\t" +  t.col + "\t" + t.value);  //描述这个三元组
            }
        }
        internal void printmatrix()      //打印矩阵
        {
            if (tuple == null)
            {
                Console.WriteLine("请先创建矩阵");
                return;
            }
            Console.WriteLine("打印矩阵");
            int[][] matrix = MatrixMethod.toArray(this);   //转换为二维数组
            DataStruct5.printarray(matrix);   //打印二维数组
        }
        
    }
    internal class MatrixMethod    //对矩阵和三元组的操作方法
    {
        internal static int[][] toArray(Matrix m)    //三元组转换为二维数组的静态方法，返回这个二维数组
        {
            int[][] matrix = new int[m.maxrow][];         //构造二维数组
            for (int i = 0; i < m.maxrow; i++)
            {
                int[] column = new int[m.maxcol];
                for (int j = 0; j < m.maxcol; j++) column[j] = 0;            //所有元素初始化为0
                matrix[i] = column;
            }
            foreach (var t in m.tuple)
            {
                matrix[t.row][t.col] = t.value;   //读取三元组每个元素的位置和值，存入二维数组
            }
            return matrix;
        }
        internal static int[][] addOrMinus(Matrix A, Matrix B, int type)  //AB矩阵相加或相减，1为+，0为-
        {
            if(A == null || B == null || A.tuple == null || B.tuple == null)
            {
                throw new NullReferenceException("请先创建矩阵！");
            }
            if(A.maxcol != B.maxcol || A.maxrow != B.maxrow)  //判断是否可以相加减，否则抛出异常
            {
                throw new ArgumentException("这两个矩阵不可以相加减！");
            }
            int[][] result = new int[A.maxrow][];
            for (int i = 0; i < A.maxrow; i++)
            {
                int[] column = new int[A.maxcol];
                for (int j = 0; j < A.maxcol; j++) column[j] = 0;            //所有元素初始化为0
                result[i] = column;
            }
            foreach(var tA in A.tuple)
            {
                result[tA.row][tA.col] = tA.value;   //读取第一个三元组每个元素的位置和值，存入二维数组
            }
            if (type == 1) 
            foreach (var tB in B.tuple)
            {
                result[tB.row][tB.col] += tB.value;   //读取第二个三元组每个元素的位置和值，加到二维数组
            }
            else
            foreach (var tB in B.tuple)
            {
                result[tB.row][tB.col] -= tB.value;   //读取第二个三元组每个元素的位置和值，加到二维数组
            }
            return result;
        }
        internal static int[][] multiply(Matrix A, Matrix B)  //AB矩阵相乘
        {
            if (A == null || B == null || A.tuple == null || B.tuple == null)
            {
                throw new NullReferenceException("请先创建矩阵！");
            }
            if (A.maxcol != B.maxrow)  //A列数需要等于B行数
            {
                throw new ArgumentException("这两个矩阵不可以相乘！");
            }
            int[][] ArrayA = MatrixMethod.toArray(A);
            int[][] ArrayB = MatrixMethod.toArray(B);
            int[][] result = new int[A.maxrow][];            //根据矩阵定义可知相乘行数等于A行数，列数等于B列数
            for (int i = 0; i < A.maxrow; i++)
            {
                int[] column = new int[B.maxcol];
                for (int j = 0; j < B.maxcol; j++) column[j] = 0;            //所有元素初始化为0
                result[i] = column;
            }
            for(int i = 0; i < A.maxrow; i++)
            {
                for(int j = 0; j < B.maxcol; j++)
                {
                    for(int k = 0; k < B.maxrow; k++)
                    {
                        result[i][j] += ArrayA[i][k] * ArrayB[k][j]; //对应元素A行乘B列相加
                    }
                }
            }
            return result;
        }
    }
}
