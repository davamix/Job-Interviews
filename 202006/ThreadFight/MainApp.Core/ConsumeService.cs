using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MainApp.Core
{
    public interface IConsumeService
    {
        string Consume();
    }

    public class ConsumeService : IConsumeService
    {
        private readonly IListWrapper _listWrapper;

        public ConsumeService(IListWrapper listWrapper)
        {
            _listWrapper = listWrapper;
            _listWrapper.OnItemEnqueued += OnItemEnqueued;
        }

        public string Consume()
        {
            while (_listWrapper.Count() > 0)
            {
                var item = _listWrapper.Dequeue();

                Console.WriteLine($"{item} - {Thread.CurrentThread.Name}");
            }

            return string.Empty;
        }

        private void OnItemEnqueued(object sender, EventArgs e)
        {
            Consume();
        }
    }
}
