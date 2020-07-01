using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MainApp.Tests.ListWrapper
{
    public class Dequeue
    {
        private Core.ListWrapper _list = new Core.ListWrapper(new[] { "item 1", "item 2", "item 3" });

        [Fact]
        public void Dequeue_One_Element_Returns_The_First_Element_In_The_List()
        {
            var expected = "item 1";
            var result = _list.Dequeue();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Dequeue_Twice_Returns_The_Second_Element_From_The_Original_List()
        {
            var expected = "item 2";
            _ = _list.Dequeue();
            var result = _list.Dequeue();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Dequeue_From_An_Empty_List_Returns_Null()
        {
            var result = new Core.ListWrapper().Dequeue();

            Assert.Null(result);
        }

    }
}
