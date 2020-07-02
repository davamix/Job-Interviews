using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Core
{
    public interface IListWrapper
    {
        void Enqueue(string item);
        string Dequeue();
        int Count();

        event EventHandler OnItemEnqueued;
    }

    public class ListWrapper : IListWrapper
    {
        List<string> _items;

        public event EventHandler OnItemEnqueued;

        public ListWrapper() : this(new List<string>())
        {
        }

        public ListWrapper(IList<string> items)
        {
            _items = new List<string>(items);
        }

        public int Count() => _items.Count;

        public string Dequeue()
        {
            lock (_items)
            {
                var value = _items.FirstOrDefault();
                if(value != null)
                    _items.RemoveAt(0);

                return value;
            }
        }

        public void Enqueue(string item)
        {
            lock (_items)
            {
                _items.Add(item);
                RaiseOnItemEnqueued(EventArgs.Empty);
            }
        }

        protected virtual void RaiseOnItemEnqueued(EventArgs e)
        {
            OnItemEnqueued?.Invoke(this, e);
        }
    }
}
