using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStruct4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static List<T> Clone<T>(object List)                //对象的复制
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, List);
                objectStream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(objectStream) as List<T>;
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            if(g != null)
                g.Clear(Color.White);
            if (count <= 500)
            {
                for (int i = 0; i < count; i++)
                {
                    g.DrawLine(new Pen(Color.Black, 1), new Point((i) * 2 + 25, 490), new Point((i) * 2 + 25, 490 - list[i]));
                }
            }
        }

        List<int> list = null;
        List<int> listbac = null;
        Graphics g;
        Random r;
        DateTime dt;
        int count;
        int compare;
        private void SortNumber_KeyPress(object sender, KeyPressEventArgs e)//避免输入其他数字
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void Restore_Click(object sender, EventArgs e)     //使数组恢复到未排序之前的状态
        {
            if (count <= 500)
            {
                g.Clear(Color.White);
                list = Clone<int>(listbac);
                Pen p = new Pen(Color.Black, 1);
                for (int i = 0; i < count; i++)
                {
                    g.DrawLine(p, new Point((i) * 2 + 25, 490), new Point((i) * 2 + 25, 490 - list[i]));
                }
            }
            else
            {
                list = Clone<int>(listbac);
            }
            Time.AppendText("已恢复" + Environment.NewLine);
        }
        private void random_Click(object sender, EventArgs e)      //生成随机数，未生成随机数前不启用排序按钮
        {
            count = int.Parse(SortNumber.Text);
            int randnum;
            if (count <= 0)
            {
                MessageBox.Show("输入至少大于1的整数");
                return;
            }
            r = new Random();
            shell.Enabled = true;
            bubble.Enabled = true;
            insert.Enabled = true;
            merge.Enabled = true;
            refresh.Enabled = true;
            quick.Enabled = true;
            heap.Enabled = true;
            select.Enabled = true;
            restore.Enabled = true;
            reverse.Enabled = true;
            if (count <= 500)          //若总数小于等于500，生成较小的随机数存入list，在面板上演示，否则不演示，并生成1-500000的随机数
            {
                g = groupBox1.CreateGraphics();
                g.Clear(Color.White);
                list = new List<int>();
                listbac = new List<int>();
                Pen p = new Pen(Color.Black, 1);
                for (int i = 0; i < count; i++)
                {
                    randnum = r.Next(1, 481);
                    list.Add(randnum);
                    listbac.Add(randnum);
                    g.DrawLine(p, new Point((i) * 2 + 25, 490), new Point((i) * 2 + 25, 490 - list[i]));
                }
            }
            else
            {
                list = new List<int>();
                listbac = new List<int>();
                for (int i = 0; i < count; i++)
                {
                    randnum = r.Next(1, 500001);
                    list.Add(randnum);
                    listbac.Add(randnum);
                }
            }
            Time.AppendText("已生成" + count + "个随机数。"+Environment.NewLine);
        }
        private void Bubble_Click(object sender, EventArgs e) //冒泡排序点击
        {
            string Text = "";
            if (count <= 500)
            {
                Text = "冒泡排序（演示）用时：" + BubblePresent();
            }
            else
            {
                Text = "冒泡排序用时：" + Bubble();
            }
            Text += "时间复杂度：O(n^2)，比较次数 " + compare;
            Time.AppendText(Text + Environment.NewLine);
        }
        private string BubblePresent() //冒泡排序演示版
        {
            compare = 0;
            int temp;
            Pen p = new Pen(Color.Red, 1);
            dt = DateTime.Now;
            for (int i = 0; i < list.Count(); i++)
            {
                for (int j = 0; j < list.Count() - 1 - i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        p.Color = Color.White;
                        g.DrawLine(p, new Point((j) * 2 + 25, 490), new Point((j) * 2 + 25, 490 - list[j]));
                        g.DrawLine(p, new Point((j + 1) * 2 + 25, 490), new Point((j + 1) * 2 + 25, 490 - list[j + 1]));
                        temp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = temp;
                        p.Color = Color.Black;
                        g.DrawLine(p, new Point((j + 1) * 2 + 25, 490), new Point((j + 1) * 2 + 25, 490 - list[j + 1]));
                        g.DrawLine(p, new Point((j) * 2 + 25, 490), new Point((j) * 2 + 25, 490 - list[j]));
                    }
                    compare++;
                }
            }
            string time = (DateTime.Now - dt).TotalMilliseconds.ToString();
            return time + "ms，";
        }
        private string Bubble()         //冒泡排序
        {
            compare = 0;
            dt = DateTime.Now;
            for (int i = 0; i < list.Count(); i++)
            {
                for (int j = 0; j < list.Count() - 1 - i; j++)
                {
                    if (list[j] > list[j + 1])         //若前数大于后数则调换
                    {
                        int temp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = temp;
                    }
                    compare++;
                }
            }
            string time = (DateTime.Now - dt).TotalMilliseconds.ToString();
            return time + "ms，";
        }

        private void Shell_Click(object sender, EventArgs e)
        {
            string Text = "";
            if (count <= 500)
            {
                Text = "希尔排序（演示）用时：" + ShellPresent();
            }
            else
            {
                Text = "希尔排序用时：" + Shell();
            }
            Text += "时间复杂度：O(nlogn)，比较次数 " + compare;
            Time.AppendText(Text + Environment.NewLine);
        }
        private string ShellPresent()     //希尔排序演示
        {
            compare = 0;
            int gap = count / 2;
            Pen p = new Pen(Color.Red, 1);
            dt = DateTime.Now;
            while (gap >= 1)
            {
                for (int i = gap; i < count; i++)
                {
                    int j = 0;
                    var temp = list[i];
                    for (j = i - gap; j >= 0 && temp < list[j]; j = j - gap)
                    {
                        p.Color = Color.White;
                        g.DrawLine(p, new Point((j + gap) * 2 + 25, 490), new Point((j + gap) * 2 + 25, 10));
                        list[j + gap] = list[j];
                        p.Color = Color.Black;
                        g.DrawLine(p, new Point((j + gap) * 2 + 25, 490), new Point((j + gap) * 2 + 25, 490 - list[j + gap]));
                        compare++;
                    }
                    p.Color = Color.White;
                    g.DrawLine(p, new Point((j + gap) * 2 + 25, 490), new Point((j + gap) * 2 + 25, 10));
                    list[j + gap] = temp;
                    p.Color = Color.Black;
                    g.DrawLine(p, new Point((j + gap) * 2 + 25, 490), new Point((j + gap) * 2 + 25, 490 - list[j + gap]));
                }
                gap = gap / 2;
            }
            string time = (DateTime.Now - dt).TotalMilliseconds.ToString();
            return time + "ms，";
        }
        private string Shell()     //希尔排序
        {
            compare = 0;
            int gap = count / 2;  //每趟增量
            dt = DateTime.Now;
            while (gap >= 1)      //增量不为0时继续排序
            {
                for (int i = gap; i < count; i++)    //分组，距离为gap的元素分为一组
                {
                    int j = 0;
                    var temp = list[i];
                    for (j = i - gap; j >= 0 && temp < list[j]; j = j - gap)   //距离为gap的元素进行插入排序
                    {
                        list[j + gap] = list[j];
                        compare++;
                    }
                    list[j + gap] = temp;
                }
                gap = gap / 2; // 减小增量
            }
            string time = (DateTime.Now - dt).TotalMilliseconds.ToString();
            return time + "ms，";
        }


        private void Insert_Click(object sender, EventArgs e)
        {
            string Text = "";
            if (count <= 500)
            {
                Text = "直接插入排序（演示）用时：" + InsertPre();
            }
            else
            {
                Text = "直接插入排序用时：" + Insert();
            }
            Text += "时间复杂度：O(n^2)，比较次数 " + compare;
            Time.AppendText(Text + Environment.NewLine);
        }
        private string InsertPre()    //直接插入排序演示
        {
            compare = 0;
            Pen p = new Pen(Color.Red, 1);
            dt = DateTime.Now;
            for (int i = 1; i < count; i++)
            {
                if (list[i] < list[i - 1])
                {
                    int temp = list[i];
                    int j = 0;
                    for (j = i - 1; j >= 0 && temp < list[j]; j--)
                    {
                        p.Color = Color.White;
                        g.DrawLine(p, new Point((j + 1) * 2 + 25, 490), new Point((j + 1) * 2 + 25, 10));
                        list[j + 1] = list[j];
                        p.Color = Color.Black;
                        g.DrawLine(p, new Point((j + 1) * 2 + 25, 490), new Point((j + 1) * 2 + 25, 490 - list[j + 1]));
                        compare++;
                    }
                    p.Color = Color.White;
                    g.DrawLine(p, new Point((j + 1) * 2 + 25, 490), new Point((j + 1) * 2 + 25, 10));
                    p.Color = Color.Black;
                    list[j + 1] = temp;
                    g.DrawLine(p, new Point((j + 1) * 2 + 25, 490), new Point((j + 1) * 2 + 25, 490 - list[j + 1]));
                }
                compare++;
            }
            string time = (DateTime.Now - dt).TotalMilliseconds.ToString();
            return time + "ms，";
        }

        private string Insert()  //插入排序
        {
            compare = 0;
            dt = DateTime.Now;
            for (int i = 1; i < count; i++)
            {
                if (list[i] < list[i - 1])
                {
                    int temp = list[i];
                    int j = 0;
                    for (j = i - 1; j >= 0 && temp < list[j]; j--) //从第i-1位开始遍历，直到找到比第i位小的
                    {
                        list[j + 1] = list[j];
                        compare++;
                    }
                    list[j + 1] = temp;   //插入第i位
                }
                compare++;
            }
            string time = (DateTime.Now - dt).TotalMilliseconds.ToString();
            return time + "ms，";
        }

        private void Quick_Click(object sender, EventArgs e)
        {
            string Text = "";
            compare = 0;
            if (count <= 500)
            {
                dt = DateTime.Now;
                QuickPre(0, count - 1);
                Text = "快速排序（演示）用时：" + (DateTime.Now - dt).TotalMilliseconds.ToString() + "ms，";
            }
            else
            {
                dt = DateTime.Now;
                Quick(0, count - 1);
                Text = "快速排序用时：" + (DateTime.Now - dt).TotalMilliseconds.ToString() + "ms，";
            }
            Text += "时间复杂度：O(nlogn)，比较次数 " + compare;
            Time.AppendText(Text + Environment.NewLine);
        }
        private int QuickPreUnit(int low, int high)   //快速排序演示
        {
            Pen p = new Pen(Color.Black, 1);
            var key = list[low];
            while (low < high)
            {
                while (list[high] >= key && high > low)
                {
                    --high;
                    compare++;
                }
                list[low] = list[high];
                p.Color = Color.White;
                g.DrawLine(p, new Point((low) * 2 + 25, 490), new Point((low) * 2 + 25, 10));
                p.Color = Color.Black;
                g.DrawLine(p, new Point((low) * 2 + 25, 490), new Point((low) * 2 + 25, 490 - list[low]));
                while (list[low] <= key && high > low)
                {
                    ++low;
                    compare++;
                }
                list[high] = list[low];
                p.Color = Color.White;
                g.DrawLine(p, new Point((high) * 2 + 25, 490), new Point((high) * 2 + 25, 10));
                p.Color = Color.Black;
                g.DrawLine(p, new Point((high) * 2 + 25, 490), new Point((high) * 2 + 25, 490 - list[high]));
                compare++;
            }
            list[low] = key;
            p.Color = Color.White;
            g.DrawLine(p, new Point((low) * 2 + 25, 490), new Point((low) * 2 + 25, 10));
            p.Color = Color.Black;
            g.DrawLine(p, new Point((low) * 2 + 25, 490), new Point((low) * 2 + 25, 490 - list[low]));
            return high;
        }
        private void QuickPre(int low, int high)
        {
            if (low >= high)
            {
                compare++;
                return;
            }
            int index = QuickPreUnit(low, high);  //分割成两边，分别排序
            QuickPre(low, index - 1);
            QuickPre(index + 1, high);
        }
        private int QuickUnit(int low, int high)   //快速排序
        {
            var key = list[low];
            while (low < high)
            {
                while (list[high] >= key && high > low)    //高位向前移动查找比key更小的
                {
                    --high;
                    compare++;
                }
                list[low] = list[high];
                while (list[low] <= key && high > low)   //低位向后移动查找比key更大的
                {
                    ++low;
                    compare++;
                }
                list[high] = list[low];
                compare++;
            }
            list[low] = key;
            return high;
        }
        private void Quick(int low, int high)
        {
            if (low >= high)
            {
                compare++;
                return;
            }
            int index = QuickUnit(low, high);  //分割成两边，分别排序
            Quick(low, index - 1);
            Quick(index + 1, high);
        }

        private void Select_Click(object sender, EventArgs e)
        {
            string Text = "";
            compare = 0;
            if (count <= 500)
            {
                Text = "选择排序（演示）用时：" + SelectPre();
            }
            else
            {
                Text = "选择排序用时：" + Select();
            }
            Text += "时间复杂度：O(n^2)，比较次数 " + compare;
            Time.AppendText(Text + Environment.NewLine);
        }
        private string SelectPre()    //选择排序演示
        {
            Pen p = new Pen(Color.Black, 1);
            int temp;
            int pos = 0;
            compare = 0;
            dt = DateTime.Now;
            for (int i = 0; i < count - 1; i++)
            {
                pos = i;
                for (int j = i + 1; j < count; j++)
                {
                    if (list[j] < list[pos])
                    {
                        pos = j;
                    }
                    compare++;
                }
                p.Color = Color.White;
                g.DrawLine(p, new Point((i) * 2 + 25, 490), new Point((i) * 2 + 25, 490 - list[i]));
                g.DrawLine(p, new Point((pos) * 2 + 25, 490), new Point((pos) * 2 + 25, 490 - list[pos]));
                temp = list[i];
                list[i] = list[pos];
                list[pos] = temp;
                p.Color = Color.Black;
                g.DrawLine(p, new Point((i) * 2 + 25, 490), new Point((i) * 2 + 25, 490 - list[i]));
                g.DrawLine(p, new Point((pos) * 2 + 25, 490), new Point((pos) * 2 + 25, 490 - list[pos]));
            }
            string time = (DateTime.Now - dt).TotalMilliseconds.ToString();
            return time + "ms，";
        }
        private string Select()    //选择排序
        {
            int temp;
            int pos = 0;
            compare = 0;
            dt = DateTime.Now;
            for (int i = 0; i < count - 1; i++)
            {
                pos = i;
                for (int j = i + 1; j < count; j++)
                {
                    if (list[j] < list[pos])
                    {
                        pos = j;
                    }
                    compare++;
                }
                temp = list[i];
                list[i] = list[pos];
                list[pos] = temp;
            }
            string time = (DateTime.Now - dt).TotalMilliseconds.ToString();
            return time + "ms，";
        }
        private void Merge_Click(object sender, EventArgs e)
        {
            string Text = "";
            compare = 0;
            if (count <= 500)
            {
                dt = DateTime.Now;
                MergePre(0, count - 1);
                Text = "归并排序（演示）用时：" + (DateTime.Now - dt).TotalMilliseconds.ToString() + "ms，";
            }
            else
            {
                dt = DateTime.Now;
                Merge(0, count - 1);
                Text = "归并排序用时：" + (DateTime.Now - dt).TotalMilliseconds.ToString() + "ms，";
            }
            Text += "时间复杂度：O(nlogn)，比较次数 " + compare;
            Time.AppendText(Text + Environment.NewLine);
        }

        private void MergeUnitPre(int low, int mid, int high)  //归并排序演示
        {
            int indexA = low;
            int indexB = mid + 1;
            int[] temp = new int[high + 1];
            int tempIndex = 0;
            Pen p = new Pen(Color.Black, 1);
            while (indexA <= mid && indexB <= high)
            {
                if (list[indexA] <= list[indexB])
                {
                    temp[tempIndex++] = list[indexA];
                    p.Color = Color.White;
                    g.DrawLine(p, new Point((indexA) * 2 + 25, 490), new Point((indexA) * 2 + 25, 10));
                    indexA++;
                }
                else
                {
                    temp[tempIndex++] = list[indexB];
                    p.Color = Color.White;
                    g.DrawLine(p, new Point((indexB) * 2 + 25, 490), new Point((indexB) * 2 + 25, 10));
                    indexB++;
                }
                compare ++;
            }
            while (indexA <= mid)
            {
                temp[tempIndex++] = list[indexA];
                p.Color = Color.White;
                g.DrawLine(p, new Point((indexA) * 2 + 25, 490), new Point((indexA) * 2 + 25, 10));
                indexA++;
                compare++;
            }
            while (indexB <= high)
            {
                temp[tempIndex++] = list[indexB];
                p.Color = Color.White;
                g.DrawLine(p, new Point((indexB) * 2 + 25, 490), new Point((indexB) * 2 + 25, 10));
                indexB++;
                compare++;
            }
            tempIndex = 0;
            for (int i = low; i <= high; i++)
            {
                p.Color = Color.White;
                g.DrawLine(p, new Point((i) * 2 + 25, 490), new Point((i) * 2 + 25, 10));
                list[i] = temp[tempIndex++];
                p.Color = Color.Black;
                g.DrawLine(p, new Point((i) * 2 + 25, 490), new Point((i) * 2 + 25, 490 - list[i]));
            }
        }
        private void MergePre(int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergePre(low, mid);
                MergePre(mid + 1, high);
                MergeUnitPre(low, mid, high);
            }
        }

        private void MergeUnit(int low, int mid, int high)  //归并排序
        {
            int indexA = low;
            int indexB = mid + 1;
            int[] temp = new int[high + 1]; //临时数组
            int tempIndex = 0;
            while (indexA <= mid && indexB <= high)     //遍历左右子表，比较左右子表的数，小的数放在前，存入临时数组
            {
                if (list[indexA] <= list[indexB])
                {
                    temp[tempIndex++] = list[indexA++];
                }
                else
                {
                    temp[tempIndex++] = list[indexB++];
                }
                compare ++;
            }
            //有一侧子表遍历完后，跳出循环，将另外一侧子表剩下的数一次放入暂存数组中（有序）
            while (indexA <= mid)
            {
                temp[tempIndex++] = list[indexA++];
                compare++;
            }
            while (indexB <= high)
            {
                temp[tempIndex++] = list[indexB++];
                compare++;
            }
            tempIndex = 0;
            for (int i = low; i <= high; i++)
            {
                list[i] = temp[tempIndex++];
            }
        }
        private void Merge(int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                Merge(low, mid);         //划分左右子表
                Merge(mid + 1, high);
                MergeUnit(low, mid, high);   //整合
            }
        }

        private void Heap_Click(object sender, EventArgs e)
        {
            string Text = "";
            compare = 0;
            if (count <= 500)
            {
                Text = "堆排序（演示）用时：" + HeapPre();
            }
            else
            {
                Text = "堆排序用时：" + Heap();
            }
            Text += "时间复杂度：O(nlogn)，比较次数 " + compare;
            Time.AppendText(Text + Environment.NewLine);
        }
        private string HeapPre()    //堆排序演示
        {
            Pen p = new Pen(Color.Black, 1);
            dt = DateTime.Now;
            MaxHeapPre();    //创建大顶推
            for (int i = count - 1; i > 0; i--)
            {
                //将堆顶元素依次与无序区的最后一位交换（使堆顶元素进入有序区）
                p.Color = Color.White;
                g.DrawLine(p, new Point(25, 490), new Point(25, 10));
                g.DrawLine(p, new Point((i) * 2 + 25, 490), new Point((i) * 2 + 25, 10));
                int temp = list[0];
                list[0] = list[i];
                list[i] = temp;
                p.Color = Color.Black;
                g.DrawLine(p, new Point(25, 490), new Point(25, 490 - list[0]));
                g.DrawLine(p, new Point((i) * 2 + 25, 490), new Point((i) * 2 + 25, 490 - list[i]));
                HeapifyPre(0, i); //重新将无序区调整为大顶堆
            }
            string time = (DateTime.Now - dt).TotalMilliseconds.ToString();
            return time + "ms，";
        }
        private void MaxHeapPre()   //建立大顶堆
        {
            //数组的前半段的元素为根节点
            for (int i = count / 2 - 1; i >= 0; i--)  //从最底层的根节点开始调整
            {
                HeapifyPre(i, count);
            }
        }
        private void HeapifyPre(int now, int heapcount)   //调整大顶堆
        {
            Pen p = new Pen(Color.Black, 1);
            int left = now * 2 + 1;  //左右子节点
            int right = now * 2 + 2;
            int root = now;  //根节点
            if (left < heapcount && list[left] > list[root])  //与左子节点进行比较
            {
                root = left;
                compare++;
            }
            if (right < heapcount && list[right] > list[root])    //与右子节点进行比较
            {
                root = right;
                compare++;
            }
            if (now != root)   //左右节点有比根节点大的就换上去
            {
                p.Color = Color.White;
                g.DrawLine(p, new Point((now) * 2 + 25, 490), new Point((now) * 2 + 25, 10));
                g.DrawLine(p, new Point((root) * 2 + 25, 490), new Point((root) * 2 + 25, 10));
                int temp = list[now];
                list[now] = list[root];
                list[root] = temp;
                p.Color = Color.Black;
                g.DrawLine(p, new Point((now) * 2 + 25, 490), new Point((now) * 2 + 25, 490 - list[now]));
                g.DrawLine(p, new Point((root) * 2 + 25, 490), new Point((root) * 2 + 25, 490 - list[root]));
                compare++;
                HeapifyPre(root, heapcount);
            }
        }
        private string Heap()    //堆排序
        {
            dt = DateTime.Now;
            MaxHeap();    //创建大顶推
            for (int i = count - 1; i > 0; i--)
            {
                //将堆顶元素依次与无序区的最后一位交换（使堆顶元素进入有序区）
                int temp = list[0];
                list[0] = list[i];
                list[i] = temp;
                Heapify(0, i); //重新将无序区调整为大顶堆
            }
            string time = (DateTime.Now - dt).TotalMilliseconds.ToString();
            return time + "ms，";
        }
        private void MaxHeap()   //建立大顶堆
        {
            //数组的前半段的元素为根节点
            for (int i = count / 2 - 1; i >= 0; i--)  //从最底层的根节点开始调整
            {
                Heapify(i, count);
            }
        }
        private void Heapify(int now, int heapcount)   //调整大顶堆
        {
            int left = now * 2 + 1;  //左右子节点
            int right = now * 2 + 2;
            int root = now;  //根节点
            if (left < heapcount && list[left] > list[root])  //与左子节点进行比较
            {
                root = left;
                compare++;
            }
            if (right < heapcount && list[right] > list[root])    //与右子节点进行比较
            {
                root = right;
                compare++;
            }
            if (now != root)   //左右节点有比根节点大的就换上去
            {
                int temp = list[now];
                list[now] = list[root];
                list[root] = temp;
                compare++;
                Heapify(root, heapcount);
            }
        }

        private void SortClear_Click(object sender, EventArgs e)
        {
            Time.Text = "";
        }

        private void Reverse_Click(object sender, EventArgs e)
        {
            list.Sort();
            list.Reverse();
            Refresh_Click(null, null);
            Time.AppendText("已逆序" + Environment.NewLine);
        }
    }
}
