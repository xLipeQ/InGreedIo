using InGreed_API.DataContext;
using InGreed_API.Dtos.Requests;
using InGreed_API.Enums;
using InGreed_API.Services.UserService;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InGreed_Api_Tests.ServiceTests
{
    public class OpinionServiceTests
    {
        private Mock<InGreedDataContext> dbContextMock;
        public OpinionServiceTests()
        {
            dbContextMock = new Mock<InGreedDataContext>();
        }
    }
}
