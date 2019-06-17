using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp9
{
    class DataStruct1
    {
        public static void Copy(poly[] source, poly[] des)
        {
            poly p;
            for(int i = 0; i<source.Length;i++)
            { 
                p = new poly(source[i].co, source[i].pow);
                des[i] = p;
            }
        }
        static void Root()   //显示菜单
        {
            Console.Clear();
            Console.WriteLine("一元多项式计算器");
            Console.WriteLine("1.输入多项式A");
            Console.WriteLine("2.输入多项式B");
            Console.WriteLine("3.显示多项式A");
            Console.WriteLine("4.显示多项式B");
            Console.WriteLine("5.显示式A+式B结果");
            Console.WriteLine("6.显示式A-式B结果");
            Console.WriteLine("7.显示式B-式A结果");
            Console.WriteLine("8.显示式A的导数");
            Console.WriteLine("9.显示式B的导数");
            Console.WriteLine("10.代入X，计算式A");
            Console.WriteLine("11.代入X，计算式B");
            Console.WriteLine("输入选项前的数字（1-11）进行相应操作：");
        }
        static void Main(string[] args)
        {
            int select = 1;                        //选项
            Root();
            Calculator c = new Calculator();   //初始化计算器
            a:
            try
            {
                select = int.Parse(Console.ReadLine());
                if (select < 1 || select > 11)                       //检验选项正确性
                {
                    throw new ArgumentException("请输入正确的选项");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(1500);
                Main(args);
            }
            switch(select)
            {
                case 1:
                    Console.WriteLine("输入多项式A");
                    c.create(1);
                    break;
                case 2:
                    Console.WriteLine("输入多项式B");
                    c.create(2);
                    break;
                case 3:
                    Console.WriteLine("显示多项式A");
                    c.show(c.polyA);
                    break;
                case 4:
                    Console.WriteLine("显示多项式B");
                    c.show(c.polyB);
                    break;
                case 5:
                    Console.WriteLine("显示式A+式B结果");
                    c.plus();
                    break;
                case 6:
                    Console.WriteLine("显示式A-式B结果");
                    if (c.polyA == null)
                    {
                        Console.WriteLine("式子A还没有输入");
                        break;
                    }
                    if (c.polyB == null)
                    {
                        Console.WriteLine("式子B还没有输入");
                        break;
                    }
                    poly[] pA = new poly[c.polyA.Length];
                    poly[] pB = new poly[c.polyB.Length];
                    DataStruct1.Copy(c.polyA, pA);
                    DataStruct1.Copy(c.polyB, pB);
                    c.minus(pA, pB);
                    break;
                case 7:
                    Console.WriteLine("显示式B-式A结果");
                    if (c.polyA == null)
                    {
                        Console.WriteLine("式子A还没有输入");
                        break;
                    }
                    if (c.polyB == null)
                    {
                        Console.WriteLine("式子B还没有输入");
                        break;
                    }
                    poly[] pA1 = new poly[c.polyA.Length];
                    poly[] pB1 = new poly[c.polyB.Length];
                    DataStruct1.Copy(c.polyA, pA1);
                    DataStruct1.Copy(c.polyB, pB1);
                    c.minus(pB1, pA1);
                    break;
                case 8:
                    Console.WriteLine("显示式A导数");
                    c.der(c.polyA);
                    break;
                case 9:
                    Console.WriteLine("显示式B导数");
                    c.der(c.polyB);
                    break;
                case 10:
                    Console.Write("输入X:");
                    try
                    {
                        double x = double.Parse(Console.ReadLine());
                        c.calX(c.polyA, x);
                    }catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case 11:
                    Console.Write("输入X:");
                    try
                    {
                        double x = double.Parse(Console.ReadLine());
                        c.calX(c.polyB, x);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }
            Console.WriteLine("输入（1-11）继续进行相应操作：");
            goto a;
        }
    }
    //数据结构部分
    public class poly   //一元多项式类，以对象的
    {
        public double co;     //系数
        public double pow;    //次方
        poly() { }
        public poly(double co, double pow)  //构造函数
        {
            this.co = co;
            this.pow = pow;
        }
    }
    //算法部分
    public class Calculator
    {
        public poly[] polyA = null;       //式A和式B默认置空
        public poly[] polyB = null;
        public bool create(int i)    //创建多项式
        {
            int count;
            Console.WriteLine("请输入项数(1-15):");
            try
            {
                count = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);           //输入失败重新输入
                create(i);
                return true;
            }
            if (count<1||count>15)
            {
                Console.WriteLine("请输入正确的项数。");
                create(i);
                return true;
            }
            poly[] p = new poly[count];    //声明多项式项数等的数组
            for(int j = 0;j < count;j++)
            {
                double co = 0;
                double pow = 0;
                Console.WriteLine("输入第"+ (j+1) +"项：");
                Console.Write("输入系数：");
                try
                {
                    co = double.Parse(Console.ReadLine());
                    Console.Write("输入次数：");
                    pow = double.Parse(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);           //输入失败重新输入
                    j--;
                    continue;
                }
                foreach(var temp in p)   //检查是否有相同次数的
                {
                    if (temp != null && pow == temp.pow)
                    {
                        temp.co += co;
                        co = 0;
                        pow = 0;
                    }
                }
                p[j] = new poly(co, pow);    //存入数组
            }
            sort(p);
            if (i == 1) polyA = p;
            else polyB = p;
            return true;
        }
        public void sort(poly[] p)  //按次数排序
        {
            poly temp;
            for (int i = 0; i < p.Length - 1; i++)
            {
                for (int j = 0; j < p.Length - 1 - i; j++)
                {
                    if (p[j].pow < p[j + 1].pow)
                    {
                        temp = p[j + 1];
                        p[j + 1] = p[j];
                        p[j] = temp;
                    }
                }
            }
        }
        public void show(poly[] p)    //显示多项式
        {
            if (p == null)
            {
                Console.WriteLine("式子还没有输入");
                return;
            }
            int j = 0;   //标记，第一个数不显示+号
            foreach(var p1 in p)
            {
                if (p1.co < 0)             //系数小于0
                {
                    if (p1.pow == 0)    //次数为0不输出x
                    {
                        Console.Write(p1.co);
                        j = 1;
                    }
                    else
                    {
                        Console.Write(p1.co + "x^" + p1.pow);
                        j = 1;
                    }
                }
                else if(p1.co > 0)   //系数大于0，输出+号
                {
                    if (p1.pow == 0 && j == 0)
                    {
                        Console.Write(p1.co);
                        j = 1;
                        continue;
                    }
                    else if (p1.pow != 0 && j == 0)
                    {
                        Console.Write(p1.co + "x^" + p1.pow);
                        j = 1;
                        continue;
                    }
                    if (p1.pow == 0 && j != 0)
                        Console.Write("+" + p1.co);
                    else if (p1.pow != 0 && j != 0)
                        Console.Write("+" + p1.co + "x^" + p1.pow);
                }
            }
            Console.WriteLine();
        }
        public void plus()  //相加，时间复杂度为O(n^2)
        {
            if(polyA == null)
            {
                Console.WriteLine("式子A还没有输入");
                return;
            }
            if(polyB == null)
            {
                Console.WriteLine("式子B还没有输入");
                return;
            }
            double co;
            double pow;
            poly[] pA = new poly[polyA.Length];
            poly[] pB = new poly[polyB.Length];
            DataStruct1.Copy(polyA, pA);
            DataStruct1.Copy(polyB, pB);
            poly[] plusr = new poly[polyA.Length + polyB.Length];
            foreach(var p in pA)
            { 
                foreach(var p1 in pB)
                {
                    if(p.pow == p1.pow)       //遍历两式查找相同的次数，相同加到A式，并且B式相同次数项作废
                    {
                        p.co += p1.co;
                        p1.co = 0;
                        p1.pow = 0;
                    }
                }
            }
            int i = 0;              //位置
            foreach(var p in pA)
            {
                co = p.co;
                pow = p.pow;
                plusr[i] = new poly(co, pow);
                i++;
            }
            foreach (var p in pB)
            {
                co = p.co;
                pow = p.pow;
                plusr[i] = new poly(co, pow);
                i++;
            }
            sort(plusr);
            show(plusr);
        }
        public void minus(poly[] pA, poly[] pB)  //相减，时间复杂度为O(n^2)
        {
            double co;
            double pow;
            poly[] plusr = new poly[polyA.Length + polyB.Length];
            foreach (var p in pA)
            {
                foreach (var p1 in pB)
                {
                    if (p.pow == p1.pow)       //遍历两式查找相同的次数，相同减去后式，并且后式相同次数项作废
                    {
                        p.co -= p1.co;
                        p1.co = 0;
                        p1.pow = 0;
                    }
                }
            }
            int i = 0;              //位置
            foreach (var p in pA)
            {
                co = p.co;
                pow = p.pow;
                plusr[i] = new poly(co, pow);
                i++;
            }
            foreach (var p in pB)
            {
                co = p.co;
                pow = p.pow;
                plusr[i] = new poly(co*-1, pow);    //被减*-1
                i++;
            }
            sort(plusr);
            show(plusr);
        }
        public void der(poly[] p)
        {
            if (p == null)
            {
                Console.WriteLine("式子还没有输入");
                return;
            }
            poly[] p1 = new poly[p.Length];
            DataStruct1.Copy(p, p1);
            foreach(var temp in p1)
            {
                if(temp.pow == 0)
                {
                    temp.co = 0;
                }
                if(temp.co != 0)
                {
                    temp.co *= temp.pow;
                    temp.pow -= 1;
                }
            }
            show(p1);
        }
        public void calX(poly[] p, double x)
        {
            if (p == null)
            {
                Console.WriteLine("式子还没有输入");
                return;
            }
            double result = 0;
            foreach(var temp in p)
            {
                result += (temp.co * Math.Pow(x, temp.pow));
            }
            Console.WriteLine("结果为：" + result);
        }
    }
}
