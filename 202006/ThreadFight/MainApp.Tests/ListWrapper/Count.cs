using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MainApp.Tests.ListWrapper
{
    public class Count
    {
        private Core.ListWrapper _list => new Core.ListWrapper(new[] { "item 1", "item 2", "item 3" });


        [Fact]
        public void Count_Number_Of_Items()
        {
            var result = _list.Count();

            Assert.Equal(3, result);
        }
    }
}
