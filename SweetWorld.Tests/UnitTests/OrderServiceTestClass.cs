using NUnit.Framework;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Tests.UnitTests
{
    [TestFixture]
    public class OrderServiceTestClass : UnitTestsBase
    {
        private IOrderService orderService;

        [SetUp]
        public async Task SetUp() { this.orderService = new OrderService(this.context); }


    }
}
