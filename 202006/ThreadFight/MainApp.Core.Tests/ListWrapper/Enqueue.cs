using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MainApp.Tests.ListWrapper
{
    public class Enqueue
    {
        private Core.ListWrapper _list = new Core.ListWrapper(new[] { "item 1", "item 2", "item 3" });

        [Fact]
        public void Enqueue_Will_Add_An_Item_To_The_List()
        {
            var expected = 4;
            _list.Enqueue("item 5");

            Assert.Equal(expected, _list.Count());
        }
    }
}
