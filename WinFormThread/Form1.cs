using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormThread
{
    /// <summary>
    /// 多线程的应用场景:
    /// 某种操作可以拆分为多个子操作,子操作跑在单独的线程上
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 同步方法的调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnSync_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            int l = 3;
            int m = 4;
            int n = l + m;
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format($"btnSync_Click_{i}");
                this.DoSomethingLong(name);
            }
            Console.WriteLine($"****************btnSync_Click   End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
        }

        private void btnAsyn_Click(object sender, EventArgs e)
        {
            // Console.WriteLine($"****************btnAsync_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            // Action<string> action = this.DoSomethingLong;
            // IAsyncResult result = null;//用来描述异步操作的信息

            //Thread thread= Thread.CurrentThread;
            //int threadId=thread.ManagedThreadId;

            // //异步回调
            // AsyncCallback callback = c => {
            //     Console.WriteLine($"{object.ReferenceEquals(result,c)}");
            //     Console.WriteLine($@"btnAsync_Click 操作完成,{c.AsyncState}
            //     {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            // };

            ////返回的异步结果信息,并将其作为参数进行异步回调
            //result= action.BeginInvoke("btnAsyn_Click",callback,"test demo");

            //2 通过IsComplate等待，卡界面--主线程在等待，边等待边提示
            //（ Thread.Sleep(200);位置变了，少了一句99.9999）
            //int i = 0;
            //while (!result.IsCompleted)
            //{
            //    if (i < 9)
            //    {
            //        Console.WriteLine($"中华民族复兴完成{++i * 10}%....");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"中华民族复兴完成99.999999%....");
            //    }
            //    Thread.Sleep(200);
            //}
            //Console.WriteLine("中华民族复兴已完成，沉睡的东方雄狮已觉醒！");


            //WaitOne等待，即时等待  限时等待
            //result.AsyncWaitHandle.WaitOne();//直接等待任务完成
            //result.AsyncWaitHandle.WaitOne(-1);//直接等待任务完成
            //result.AsyncWaitHandle.WaitOne(1000);//直接等待任务完成

            //action.EndInvoke(result);//等待异步调用操作结束

            //Action泛型委托同时调用多个方法
            //Action<string> action02 = s => {
            //    this.DoSomethingLong("test demo");
            //    this.TestActionCallMethod("test demo01");
            //};

            //action02.Invoke("");//这里参数传入只是为了通过编译,


            //action.Invoke("btnAsync_Click_1");
            //action("btnAsync_Click_1");

            //委托自身需要的参数+2个异步参数
            //action.BeginInvoke("btnAsync_Click_1", null, null);

            //for (int i = 0; i <5; i++)
            //{
            //    string name = string.Format($"btnAsync_Click_{i}");
            //    action.BeginInvoke(name, null, null);
            //}

            //没有输入参数
            Func<int> func = () =>
            {
                Thread.Sleep(200);
                return DateTime.Now.Hour;
            };

            int result = func.Invoke();

            IAsyncResult asyncResult = func.BeginInvoke(a =>
            {

            }, null);
            //会返回异步调用的结果
            int endResult = func.EndInvoke(asyncResult);
            //Console.WriteLine($"****************btnAsync_Click End   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
        }

        /// <summary>
        /// 一个比较耗时的方法
        /// </summary>
        /// <param name="name"></param>
        private void DoSomethingLong(string name)
        {
            Console.WriteLine($"****************DoSomethingLong Start  {name}  {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            long lResult = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                lResult += i;
            }
            //Thread.Sleep(2000);

            Console.WriteLine($"****************DoSomethingLong   End  {name}  {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {lResult}***************");
        }


        private void TestActionCallMethod(string msg)
        {
            Console.WriteLine("Message:" + msg);
        }


        private string TestFuncMethodCalled(string msg)
        {
            if (msg == "ok")
            {
                return "yes";
            }
            return "No";
        }

        private string TestFuncMethodCalled02(string msg)
        {
            if (msg == "baby")
            {
                return "Hi";
            }
            return "Bye";
        }

        private void btnThread_Click(object sender, EventArgs e)
        {

            //ThreadStart threadStart = () => {
            //    Thread.Sleep(5000);
            //    Console.WriteLine("Test Thread Start!");
            //    Thread.Sleep(5000);
            //};
            //Thread thread = new Thread(threadStart);
            //thread.Priority = ThreadPriority.Highest;//设置线程的优先级
            ////thread.IsBackground =false;//前台线程:进程结束,线程执行完才退出
            //thread.IsBackground = true;//后台线程:进程结束,线程直接退出
            //thread.Start();//启动线程

            //thread.Suspend();//暂停
            //thread.Resume();//恢复

            //thread.Abort();//终止线程
            //Join等待
            //thread.Join();//阻塞当前应用的主线程,等待当前线程执行完成
            //Console.WriteLine(" Whether Current Thread is Completed");


            ThreadStart threadStart = () => this.DoSomethingLong("btnThread_Click");
            Action callBackAction = () =>
            {
                Thread.Sleep(2000);
                Console.WriteLine($"This is callBack {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            };
            this.ThreadWithCallBack(threadStart, callBackAction);
        }


        //基于Thread封装一个回调
        //启动一个子线程执行指定的操作A(不阻塞)--A执行完毕后会执行B操作(去调用回调函数)
        private void ThreadWithCallBack(ThreadStart threadStart, Action callBackAction)
        {
            //Thread thread = new Thread(threadStart);
            //thread.Start();
            //thread.Join();//不行,会阻塞主线程,页面卡死
            //callBackAction.Invoke();

            //外层再使用ThreadStart委托进行包装,会依次执行外层委托指向的操作,
            //一个操作会等待另一个操作完成再执行,且不阻塞
            //ThreadStart method = () => {
            //    threadStart.Invoke();
            //    callBackAction.Invoke();
            //};
            //new Thread(method).Start();//启动线程

            //List<Thread> threadList = new List<Thread>();
            //for (int i=0;i<100;i++) {//需要执行100个任务,每10个任务执行完后再开启新的线程
            //    if (threadList.Count(t => t.ThreadState == ThreadState.Running) < 10)
            //    {
            //        Thread thread = new Thread(
            //         new ThreadStart(() => { }));
            //        thread.Start();
            //        threadList.Add(thread);
            //    }
            //    else {
            //        Thread.Sleep(5000);
            //    }
            //}

            Func<int> func = () =>
            {
                Thread.Sleep(5000);
                return DateTime.Now.Year;
            };
            Func<int> returnedFunc = this.ThreadWithReturnedResult(func);
            int result = returnedFunc.Invoke();

        }

        /// <summary>
        /// 异步(非阻塞):有返回结果
        /// 封装一个线程执行完毕返回泛型委托Func的方法
        /// 在该委托中返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        private Func<T> ThreadWithReturnedResult<T>(Func<T> func)
        {

            T t = default(T);
            ThreadStart threadStart = () =>
            {
                t = func.Invoke();
            };
            Thread thread = new Thread(threadStart);
            thread.Start();
            ////直接return不行,因为此行是跑在主线程上直接运行,
            ////而返回值是在独立的线程上运行
            //return t;

            return new Func<T>(() =>
            {
                thread.Join();//阻塞,直到线程执行完毕
                return t;
            });
        }

        private void TestThread01(string str)
        {
            Console.WriteLine(str);
        }

        /// <summary>
        /// 线程池:ThreadPool类
        /// https://blog.csdn.net/qq_33337811/article/details/72844254
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnThreadPool_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            {
                //ThreadPool.GetMaxThreads(out int workerThreads,out int completionPortThreads);
                //Console.WriteLine($@"当前电脑最大 workerThreads={workerThreads} 
                //completionPortThreads={completionPortThreads}
                //");

                //ThreadPool.GetMinThreads(out int workerThreadsMin, out int completionPortThreadsMin);
                //Console.WriteLine($@"当前电脑最小 workerThreads={workerThreadsMin} 
                //completionPortThreads={completionPortThreadsMin}
                //");


                //Console.WriteLine("***********设置最大最小可以请求的Threads**************");
                //ThreadPool.SetMaxThreads(8, 8);//设置的最大值，必须大于CPU核数，否则设置无效
                //ThreadPool.SetMinThreads(2, 2);


                //ThreadPool.GetMaxThreads(out int workerThreads2, out int completionPortThreads2);
                //Console.WriteLine($@"当前电脑最大 workerThreads={workerThreads2} 
                //completionPortThreads={completionPortThreads2}
                //");

                //ThreadPool.GetMinThreads(out int workerThreadsMin2, out int completionPortThreadsMin2);
                //Console.WriteLine($@"当前电脑最小 workerThreads={workerThreadsMin2} 
                //completionPortThreads={completionPortThreadsMin2}
                //");
            }


            {
                /** 线程池的等待操作
                 线程池的线程属于后台线程
                ManualResetEvent初始化时:
                param:false--->未收到信号,所监听的所有线程会被阻塞
                需要调用Set()方法,将事件状态设置为已收到信息,解除阻塞

                true: --->已收到信号,所监听的所有线程不会被阻塞
                可以调用Reset()方法,将事件状态设置为未收到信号
                阻塞监听的所有线程

                ThreadPool.QueueUserWorkItem()方法:当线程池中有可获得的线程资源,
                使用请求到的线程执行方法
                Queues a method for execution. 
                The method executes when a thread pool thread becomes available


                **/

                //    ManualResetEvent mre = new ManualResetEvent(true);
                //    mre.Reset();
                //    ThreadPool.QueueUserWorkItem(q =>
                //    {
                //        this.DoSomethingLong("btnThreadPool_Click");
                //        mre.Set();//设置mre的事件状态设置为已收到信号
                //        //mre.Reset();
                //    });
                //    Console.WriteLine("Do Something Else .............");
                //    Console.WriteLine("Do Something Else .............");
                //    Console.WriteLine("Do Something Else .............");

                //    mre.WaitOne();//阻塞当前线程池执行的线程,直到收到信息
                //    Console.WriteLine("任务已经完成...........");
                //}
            }

            {
                //设置线程池的线程最大数为8
                //这种情况出现死锁:
                ThreadPool.SetMaxThreads(8, 8);
                ManualResetEvent mre = new ManualResetEvent(false);
                for (int i = 0; i < 10; i++)
                {
                    int k = i;
                    //出现死锁:线程池中只有8个线程,且都处于挂起状态
                    //再次请求将发现没有可请求的资源,只能处于排队等待状态
                    ThreadPool.QueueUserWorkItem(t =>
                    {
                        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId.ToString("00")} show {k}");
                        if (k == 9)
                        {
                            mre.Set();
                        }
                        else
                        {
                            mre.WaitOne();
                        }
                    });
                }
                if (mre.WaitOne())
                {
                    Console.WriteLine("任务全部执行成功！");
                }


            }
        }

        /// <summary>
        /// Task任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTask_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"**************** btnTask_Click {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");

            //{
            //    //1.创建Task对象,并指定委托操作
            //    Task task = new Task(() => {
            //        this.DoSomethingLong("btnTask_Click");
            //    });
            //    task.Start();//启动任务

            //    //2.在线程池中运行指定的工作
            //    Task.Run(() => { this.DoSomethingLong("btnTask_Click_RunMethod"); });
            //    //3.使用工厂创建并启动新的任务
            //    Task.Factory.StartNew(() => {
            //        this.DoSomethingLong("btnTask_Click_Factory");
            //    });
            //}

            //{
            //    //线程池是单例的,全局唯一的
            //    //设置后只有8个,重新复用的
            //    //Task的线程是基于线程池的
            //    ThreadPool.SetMaxThreads(8,8);
            //    for (int i=0;i<100;i++) {
            //        int k = i;
            //        Task.Run(()=> {
            //        Console.WriteLine($"This is {k} running ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            //        Thread.Sleep(2000);
            //        });
            //    }
            //}


            //{
            //    Stopwatch stopwatch = new Stopwatch();
            //    stopwatch.Start();
            //    Console.WriteLine("线程休眠之前........");
            //    Thread.Sleep(2000);//休眠2秒(同步会阻塞主线程)
            //    Console.WriteLine("线程休眠之后........");
            //    stopwatch.Stop();
            //    Console.WriteLine($"休眠耗时:{stopwatch.ElapsedMilliseconds}");
            //}

            //{
            //    Stopwatch stopwatch = new Stopwatch();
            //    stopwatch.Start();
            //    Console.WriteLine("Delay之前........");
            //    //创建一个任务在2000毫秒后执行完成,继续执行异步操作
            //    Task.Delay(2000).ContinueWith(c=> {
            //        stopwatch.Stop();
            //    });
            //    Console.WriteLine("Delay之后........");
            //    Console.WriteLine($"Delay耗时:{stopwatch.ElapsedMilliseconds}");
            //}

            {
                /**
                 * 多线程;应用在需要并发执行操作
                 * 提升执行效率,改善用户体验
                 * 
                 * */
                //Console.WriteLine("开课了,伙计们!");
                ////单线程-->有先后执行顺序
                //this.Teach("Lesson 1");
                //this.Teach("Lesson 2");
                //this.Teach("Lesson 3");

                //Console.WriteLine("---------------------------------------");

                //项目需要团队成员同时开发完成-->并发操作,使用多线程操作
                //开启多线程进行并发访问
                //多个模块可以同时进行操作-->多线程
                TaskFactory taskFactory = new TaskFactory();
                List<Task> taskList = new List<Task>();

                taskList.Add(taskFactory.StartNew(o => {
                    this.Coding("沙漠之空", "web");
                }, "沙漠之空"));
                taskList.Add(taskFactory.StartNew(o =>
                {
                    this.Coding("平平静静", "BackServer");
                }, "平平静静"));

                taskList.Add(taskFactory.StartNew(o => {
                    this.Coding("三月", "Client");
                }, "三月"));

                taskList.Add(taskFactory.StartNew(o => {
                    this.Coding("不忘初心", "WeChat");
                }, "不忘初心"));

                //我们发现使用ContinueWhen的方法去执行延续操作
                //是使用taskList中的子线程去执行操作,用哪个线程是由系统随机分配

                taskFactory.ContinueWhenAny(taskList.ToArray(), t =>
                {
                    Console.WriteLine($@"{t.AsyncState}开发完成, 给点奖励{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                });

                //项目完成后,去庆祝一下(所有Task任务执行完成后的继续操作)
                taskList.Add(taskFactory.ContinueWhenAll(taskList.ToArray(), t => {

                    Console.WriteLine($@"开发完成之后, 一起庆祝一下 {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                }));
                //非阻塞式的回调:而且使用的线程可能是新线程
                //也可能是刚完成任务的线程,唯一不可能是主线程


                ////阻塞当前线程--等待有任意一个任务执行完成(解除阻塞,继续往下执行)
                Task.WaitAny(taskList.ToArray());
                Console.WriteLine("有模块已开发完毕,准备部署!");

                //等待所有的任务执行完毕--阻塞当前线程
                Task.WaitAll(taskList.ToArray());
                Console.WriteLine("所有模块都以开发完毕,集中开个会");//所有任务执行完之后

                /***
                 * 要保证"所有模块都以开发完毕,集中开个会"  在 "开发完成之后, 一起庆祝一下"
                 之后执行,所以使用线程的等待完成,前提是操作有先后顺序要求
                 * * **/

                int returnedResult = 0;
                ManualResetEvent mre = new ManualResetEvent(false);//控制线程是否阻塞的开关事件
                Task task = Task.Run<int>(() => {
                    Thread.Sleep(2000);
                    return DateTime.Now.Year;
                }).ContinueWith(t => {
                    returnedResult = t.Result;
                    mre.Set();
                });//t指向前面执行完返回的Task对象
                mre.WaitOne();//阻塞当前运行它的线程(没有用Task进行包装运行,是跑在主线程上所以页面会卡死)
                Console.WriteLine("Returned Result:" + returnedResult);
            }
        }

        private void Teach(string lesson)
        {
            Console.WriteLine($"{lesson}开始讲。。。");
            //long lResult = 0;
            //for (int i = 0; i < 1_000_000_000; i++)
            //{
            //    lResult += i;
            //}
            Console.WriteLine($"{lesson}讲完了。。。");
        }
        /// <summary>
        /// 模拟Coding过程
        /// </summary>
        /// <param name="name"></param>
        /// <param name="projectName"></param>
        private void Coding(string name, string projectName)
        {
            Console.WriteLine($"****************Coding Start  {name} {projectName}  {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            long lResult = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                lResult += i;
            }

            Console.WriteLine($"****************Coding   End  {name} {projectName} {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {lResult}***************");
        }

        /// <summary>
        /// 如何解决多线程并发问题数量的限制? 
        /// 现在需要循环执行1W个任务,比如只允许同时并发20个线程去执行任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMultiTasks_Click(object sender, EventArgs e)
        {

            {
                List<Task> taskList = new List<Task>();

                for (int i = 0; i < 10000; i++)
                {
                    int k = i;
                    if (taskList.Count(t => t.Status != TaskStatus.RanToCompletion) >= 20)//检测Task集合中是否已有等于或者大于20个还在running的线程
                    {
                        Task.WaitAny(taskList.ToArray());//等待任意一个线程执行完毕
                        taskList = taskList.Where(t => t.Status != TaskStatus.RanToCompletion).ToList();
                    }
                    taskList.Add(Task.Run(() => {
                        Console.WriteLine($"This is {k} running ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                        Thread.Sleep(2000);
                    }));
                }
            }
        }

        /// <summary>
        /// Parallel的并发操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnParallel_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnParallel_Click Start   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            {

                /**Parallel类的Invoke()方法:阻塞方法
                 * 多线程并发执行多个Action操作
                 * 主线程参加操作,会阻塞页面
                 * 当所有的线程任务执行完毕后,该方法才返回
                 * */

                Parallel.Invoke(() => this.DoSomethingLong("btnParallel_Click_1"),
                    () => this.DoSomethingLong("btnParallel_Click_2"),
                    () => this.DoSomethingLong("btnParallel_Click_3"),
                    () => this.DoSomethingLong("btnParallel_Click_4"),
                    () => this.DoSomethingLong("btnParallel_Click_5"));
            }

            {
                //Parallel类的For方法
                Parallel.For(0, 5, i => this.DoSomethingLong($"btnParallel_Click_{i}"));
            }

            {
                /**Parallel类的ForEach方法:
                 * 多线程并发地从数据源中取出数据,然后并发地执行对应的线程任务
                 * */
                Parallel.ForEach(new int[] { 0, 1, 2, 3, 4 }, i => this.DoSomethingLong($"btnParallel_Click_{i}"));
            }

            //多线程中并发问题的处理

            {   
                //ParallelOptions类提供对Parallel的配置操作
                ParallelOptions parallelOptions = new ParallelOptions();
                //设置并发任务的最大线程数目
                parallelOptions.MaxDegreeOfParallelism = 3;

                Parallel.Invoke(parallelOptions,() => this.DoSomethingLong("btnParallel_Click_1"),
                   () => this.DoSomethingLong("btnParallel_Click_2"),
                   () => this.DoSomethingLong("btnParallel_Click_3"),
                   () => this.DoSomethingLong("btnParallel_Click_4"),
                   () => this.DoSomethingLong("btnParallel_Click_5"));
            }

            {
                //ParallelOptions类提供对Parallel的配置操作
                ParallelOptions options = new ParallelOptions();
                options.MaxDegreeOfParallelism = 3;//设置并发任务的最大线程数目
                Parallel.For(0, 10, options, i => this.DoSomethingLong($"btnParallel_Click_{i}"));
            }

            {
                ParallelOptions parallelOptions = new ParallelOptions();
                parallelOptions.MaxDegreeOfParallelism = 4;
                Parallel.ForEach(new int[] { 0, 1, 2, 3, 4 }, parallelOptions,i => this.DoSomethingLong($"btnParallel_Click_{i}"));

            }

            {  
            /***
            * 以上三个方法都属于线程的阻塞方法,都将等待所有的线程任务完成后
            * 才解除对当前线程的阻塞(默认情况下是主线程)
            * 但我们可以使用Task包装线程,嵌套线程,解除对主线程的依赖
            * */
                //有没有办法不阻塞？

                Task.Run(() =>
                {
                    ParallelOptions options = new ParallelOptions();
                    options.MaxDegreeOfParallelism = 3;
                    Parallel.For(0, 10, options, i => this.DoSomethingLong($"btnParallel_Click_{i}"));
                });
            }
            Console.WriteLine($"****************btnParallel_Click End   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
        }
    }
}
