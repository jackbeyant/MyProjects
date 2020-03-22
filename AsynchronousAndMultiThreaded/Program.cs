using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousAndMultiThreaded
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取当前正在执行的线程对象
            Thread mainThread = Thread.CurrentThread;
            string threadName = mainThread.Name;
            //获取当前操作线程所处的上下文
            Context context = Thread.CurrentContext;
            //获取当前操作线程的执行上下文
            ExecutionContext executionContext = mainThread.ExecutionContext;

            Action<string> action = new Action<string>(TestThread);
            action.BeginInvoke("The action delegate!", null, null);


        }

        public static void TestThread(string str)
        {
            Console.WriteLine("Message:" + str);
        }

    }
}
