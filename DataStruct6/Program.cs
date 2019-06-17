using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataStruct6
{
    class DataStruct6
    {
        static void Main(string[] args)
        {
            Huffman h = null;
            Console.WriteLine("哈夫曼编码解码器");
            Console.WriteLine("1.建立哈夫曼树");
            Console.WriteLine("2.打印哈夫曼树");
            Console.WriteLine("3.编码");
            Console.WriteLine("4.译码");
            Console.WriteLine("输入（1-4）操作：");
            string opt;
            while(true)
            {
                opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        h = new Huffman();
                        h.create();
                        break;
                    case "2":
                        if(h == null)
                        {
                            Console.WriteLine("请先建立哈夫曼树");
                            break;
                        }
                        h.print(h.huff[0]);
                        break;
                    case "3":
                        if (h == null)
                        {
                            Console.WriteLine("请先建立哈夫曼树");
                            break;
                        }
                        try
                        {
                            Console.WriteLine("输入字符串来编码：");
                            Console.WriteLine("编码结果：" + h.encode(Console.ReadLine()));
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "4":
                        if (h == null)
                        {
                            Console.WriteLine("请先建立哈夫曼树");
                            break;
                        }
                        try
                        {
                            Console.WriteLine("输入编码来解码：");
                            Console.WriteLine("解码结果：" + h.decode(Console.ReadLine()));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    default:
                        return;
                }
                Console.WriteLine("输入（1-4）操作：");
            }
        }
    }
    internal class Node
    {
        internal Node left = null;  //左右节点
        internal Node right = null;
        internal int weight;        //权重和值
        internal char ch;
        internal Node() { }
        internal Node(int weight, char ch)  //有权有值的节点
        {
            this.weight = weight;
            this.ch = ch;
        }
        internal Node(int weight)   //只有权的节点
        {
            this.weight = weight;
            this.ch = '\0';
        }
    }
    internal class Huffman
    {
        internal Hashtable ht1 = null;      //哈夫曼编码组，通过键值对的方式存储
        internal Hashtable ht2 = null;      //译码组
        internal List<Node> huff = null;   //哈夫曼树节点数组
        internal int depth = 0;   //深度和最大子节点数
        internal int maxnode = 0;
        internal void create()
        {
            Console.WriteLine("输入字符串建立哈夫曼树：");
            char[] str = Console.ReadLine().ToCharArray();   //转换为char数组
            if (str.Equals(""))                              //不能输入空的字符串
            {
                Console.WriteLine("请正确输入");
                return;
            }
            huff = new List<Node>();
            huff.AddRange(str.GroupBy(a => a).Select(same => (new Node { weight = same.Count(), ch = same.Key })));  
            //LINQ语句可简化操作，在数组str根据字符分组，同一个字符分到一组，选出该组字符及其频数，加入哈夫曼树节点数组

            while(huff.Count > 1)    //从此处开始移除节点，被移除的节点将会成为父节点的左右节点，直到数组里只剩最顶处的根节点
            {
                var sort = huff.OrderBy(a => a.weight);   //将节点数组根据权重排序，权重小的在前
                var min = sort.Take(2).ToArray();         //取走最前面的2个最小的
                huff.Add(new Node { left = min[0], right = min[1], weight = min[0].weight + min[1].weight });//添加新的权重相加后的父节点，被取走的两个节点作为父节点的左右节点，较小的是左节点
                huff.Remove(min[0]);   //移除这两个节点
                huff.Remove(min[1]);
            }
            ht1 = new Hashtable();
            ht2 = new Hashtable();
            depth = getDepth(huff[0]);              
            maxnode = (int)Math.Pow(2, depth) - 1;
            createCode(huff[0], new int[20], 0);    //建立编码组和译码组
        }
        internal int getDepth(Node n)  //获取深度
        {
            if (n == null) return 0;
            int left = 1;
            int right = 1;
            left += getDepth(n.left);
            right += getDepth(n.right);
            return left > right ? left : right;
        }

        internal void print(Node n)
        {
            string[] s = new string[maxnode];
            for (int i = 0; i < s.Length; i++) s[i] = "null"; //这里值为null等效于变量为null，便于识别
            convert(n, s, 0);
            string stemp = "";
            foreach(var s1 in s)    //分割，由于dll之间string传参可能存在兼容性问题，转换成char数组
            {
                stemp += s1;
                stemp += "FG";
            }
            stemp = stemp.Substring(0, stemp.Length - 2);
            Console.WriteLine(TreePrinter.Printer.print(stemp.ToCharArray()));  //调用直观打印树的dll，返回打印的字符串，输出
            foreach(DictionaryEntry h in ht1)
            {
                Console.WriteLine("字符为'" + h.Key + "'的哈夫曼编码为：" + h.Value);
            }
        }
        internal void convert(Node n, string[] s, int pos)
        {
            if (n == null)        //pos:在数组中的下标位置
            {
                return;
            }
            if (n.ch != '\0') s[pos] = n.ch.ToString() + n.weight.ToString();
            else s[pos] = n.weight.ToString();
            if (pos * 2 + 1 < maxnode)
            {
                convert(n.left, s, pos * 2 + 1);
            }
            if (pos * 2 + 2 < maxnode)
            {
                convert(n.right, s, pos * 2 + 2);
            }
        }
        internal void createCode(Node n, int[] a, int len)  //a临时数组，len编码长度
        {
            if (n != null)
            {
                if (n.left == null && n.right == null)   //如果是叶子节点就存储a中存储的编码
                {
                    char c = n.ch;
                    string s = "";
                    for (int i = 0; i < len; i++)    //值和编码存进键值对
                    {
                        s += a[i].ToString();
                    }
                    ht1.Add(c, s);
                    ht2.Add(s, c);
                }
                else
                {
                    a[len] = 0;
                    createCode(n.left, a, len + 1);  //向左右节点递归，向左的编码为0，右为1
                    a[len] = 1;
                    createCode(n.right, a, len + 1);
                }
            }
        }
        internal string encode(string str)   //编码
        {
            string code = "";
            foreach(char c in str)                                          //根据编码组，把对应码添加到返回值中
            {
                if (!ht1.ContainsKey(c)) throw new Exception("无法编码！");
                code += ht1[c];
            }
            return code;
        }
        internal string decode(string code)   //解码
        {
            string codetemp = "";
            string str = "";
            for(int i = 0;i < code.Length;i++)
            {
                codetemp += code[i];
                if(ht2.ContainsKey(codetemp))    //逐个编码比对
                {
                    str += ht2[codetemp];
                    if (i == code.Length-1 && !ht2.ContainsKey(codetemp))   //遍历后还找不到键值
                    {
                        throw new Exception("无法解码！");
                    }
                    codetemp = "";
                }
                
            }
            return str;
        }
    }

}
