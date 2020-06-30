using MainApp.Core;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MainApp
{
    class Program
    {
        static IConsumeService _service;
        static IListWrapper _list;

        static void Main(string[] args)
        {
            string option = string.Empty;
            _list = new ListWrapper(GenerateValues());

            _service = new ConsumeService(_list);

            var t1 = new Thread(() => _service.Consume()) { Name = "t1", IsBackground = true };
            var t2 = new Thread(() => _service.Consume()) { Name = "t2", IsBackground = true };

            Run(t1, t2);

            do
            {
                Console.Write("Add values? (y/n):");
                option = Console.ReadLine();

                Populate();

            } while (option.Equals("y"));

        }

        static void Run(Thread t1, Thread t2)
        {
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }

        static IList<string> GenerateValues()
        {
            var values = new List<string>();

            for (var x = 1; x < 100; x++)
                values.Add(x.ToString());

            return values;
        }

        static void Populate()
        {
            for (var x = 1; x < 10; x++)
                _list.Enqueue(x.ToString());
        }
    }
}
