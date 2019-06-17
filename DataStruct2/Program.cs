using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct2
{
    class DataStruct2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("文章编辑");
            Console.WriteLine("1.输入文章");
            Console.WriteLine("2.输出文章");
            Console.WriteLine("3.输出文章各种字符数");
            Console.WriteLine("4.匹配子串");
            Console.WriteLine("5.删除文章子串");
            Console.WriteLine("输入（1-5）：");
            art a = null;
            begin:
            string opt = Console.ReadLine();
            switch(opt)
            {
                case "1":
                    try
                    {
                        Console.WriteLine("输入文章");
                        Console.WriteLine("输入文章行数：");
                        int i = int.Parse(Console.ReadLine());
                        if (i <= 0) throw new Exception("请输入正确的数字");
                        a = new art(i);
                    }
                    catch (Exception e) { Console.WriteLine(e.Message);break; }
                    break;
                case "2":
                    if (a == null)
                    {
                        Console.WriteLine("请先输入文章");
                        break;
                    }
                    Console.WriteLine("输出文章");
                    a.show();
                    break;
                case "3":
                    if (a == null)
                    {
                        Console.WriteLine("请先输入文章");
                        break;
                    }
                    Console.WriteLine("输出文章各种字符数");
                    a.countingall();
                    break;
                case "4":
                    if (a == null)
                    {
                        Console.WriteLine("请先输入文章");
                        break;
                    }
                    Console.WriteLine("匹配");
                    a.matchall();
                    break;
                case "5":
                    if (a == null)
                    {
                        Console.WriteLine("请先输入文章");
                        break;
                    }
                    Console.WriteLine("删除字串");
                    a.delete();
                    break;
                default:
                    return;
            }
            Console.WriteLine("继续输入（1-5）：");
            goto begin;
        }
    }
    internal class art //文章
    {
        internal charlist[] article;
        internal int letter = 0;   //总的字母、数字、空格、总字数
        internal int number = 0;
        internal int space = 0;
        internal int length = 0;
        internal art(int n)
        {
            article = new charlist[n];
            for(int i = 0;i<n;i++)
            {
                Console.WriteLine("输入第" + (i + 1) + "行");
                article[i] = new charlist(Console.ReadLine());
            }
            Console.WriteLine("输入完成");
        }
        internal void countingall()  //输出各种字数
        {
            letter = 0;
            number = 0;
            space = 0;
            length = 0;
            foreach(var a in article)
            {
                a.counting();
                letter += a.letter;
                number += a.number;
                space += a.space;
                length += a.length;
            }
            Console.WriteLine("字母数：" + letter);
            Console.WriteLine("数字数：" + number);
            Console.WriteLine("空格数：" + space);
            Console.WriteLine("总字数：" + length);
        }
        internal void matchall()    //匹配
        {
            int result = 0;
            Console.WriteLine("输入匹配字符串：");
            char[] matcher = Console.ReadLine().ToCharArray();
            foreach (var a in article)
            {
                result += a.match(matcher);
            }
            Console.WriteLine("匹配数：" + result);
        }
        internal void delete()     //删除
        {
            Console.WriteLine("输入删除字符串：");
            char[] matcher = Console.ReadLine().ToCharArray();
            foreach (var a in article)
            {
                if (a.delete(matcher))
                {
                    Console.WriteLine("已删除");
                    return;
                }
            }
            Console.WriteLine("未删除");
        }
        internal void show()     //输出
        {
            foreach(var a in article)
            {
                foreach (var c in a.str)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            }
        }
    }
    internal class charlist   //字符串类型
    {
        internal char[] str;   //段落
        internal int letter = 0;   //字母、数字、空格、总字数
        internal int number = 0;
        internal int space = 0;
        internal int length = 0;
        charlist() { }
        internal charlist(string s)
        {
            str = new char[80];
            int length = s.Length;         //判断长度是否大于80，大于就截取前80个字符
            if (length > 80)
            {
                Console.WriteLine("此段多于80个字符，截取前80个。");
                length = 80;
            }
            str = s.ToCharArray(0, length);
            counting();
        }
        internal int match(char[] matcher)     //计算某一字符串出现次数
        {
            int number = 0;
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i; j < str.Length && j < i + matcher.Length; j++)
                {
                    if(str[j] != matcher[j-i])
                    {
                        break;
                    }
                    if (j == i + matcher.Length - 1)
                    {
                        number++;
                    }
                }
            }
            return number;
        }
        internal bool delete(char[] matcher)    //删除字符串
        {
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i; j < str.Length && j < i + matcher.Length; j++)
                {
                    if (str[j] != matcher[j - i])
                    {
                        break;
                    }
                    if (j == i + matcher.Length - 1)
                    {
                        for(j = i + matcher.Length ; j < str.Length; j++)
                        {
                            str[j - matcher.Length] = str[j];
                        }
                        for(int k = j - matcher.Length + 1;k < str.Length; k++)
                        {
                            str[k] = '\0';
                        }
                        counting();
                        return true;
                    }
                }
            }

            return false;
        }
        internal void counting()
        {
            letter = 0; 
            number = 0;
            space = 0;
            length = 0;
            for (int i = 0; i < str.Length; i++)   //计算各个字符
            {
                if (str[i] != '\0')
                {
                    length++;
                }
                if ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z'))
                {
                    letter++;
                    continue;
                }
                if (str[i] >= '0' && str[i] <= '9')
                {
                    number++;
                    continue;
                }
                if (str[i] == ' ')
                {
                    space++;
                    continue;
                }
            }
        }
    }
}
