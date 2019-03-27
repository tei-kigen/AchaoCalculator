using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int j;
            float m, n, sum;//定义float变量，用float是为了让sum%1==0可以筛掉出现小数的结果
            string str;//定义字符串，用来储存和打印算式
            Console.WriteLine("请输入需要生成的算式总数：");
            j = int.Parse(Console.ReadLine());//记下用户需要的算式数量
            for (int i = 0; i < j; i++)
            {
                Random a = new Random(Guid.NewGuid().GetHashCode());//使用random类生成随机数，用Guid的哈希码作为种子值避免重复
                m =a.Next(0, 100);
                str = m.ToString();
                sum = m;
                for (int z=0; z< a.Next(2, 4); z++)//这个for循环用来随机生成2到3个运算符号
                {
                    switch (a.Next(1, 5))//随机生成四则运算符号
                    {
                        case 1:
                            n = a.Next(0, 100);
                            str =  str + "+" + n.ToString() ;
                            sum = sum + n;
                            break;
                        case 2:
                            n = a.Next(0, 100);
                            str = str + "-" + n.ToString();
                            sum = sum - n;
                            break;
                        case 3:
                            n = a.Next(0, 100);
                            if (str.Contains('+') || str.Contains('-'))
                                str = "(" + str + ")";
                            //这个If语句用来给出现优先级问题的算式添加括号防止出现数学符号的逻辑错误，case 4中同理
                            str = str + "÷" + n.ToString();
                            sum = sum / n;
                            break;
                        case 4:
                            n = a.Next(0, 100);
                            if (str.Contains('+') || str.Contains('-'))
                                str = "(" + str + ")";
                            str = str + "*" + n.ToString();
                            sum = sum * n;
                            break;
                    }
                }
                if (sum%1==0&&sum>=0&&sum<=100)//筛掉小数结果和超范围的结果
                {
                    Console.WriteLine(str + "=" + sum);
                }
                else//筛掉不要的结果时，不能影响生成的算式总数，故而i--
                {
                    i--;
                }
                    
            }
        }
    }
}
