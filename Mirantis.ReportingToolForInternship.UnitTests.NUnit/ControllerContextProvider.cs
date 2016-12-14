namespace Mirantis.ReportingToolForInternship.UnitTests.NUnit
{
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    class ControllerContextProvider
    {
        public static Mock<ControllerContext> GetFakeControllerContext(int fakeUserId, string [] roles)
        {
            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity(fakeUserId.ToString());
            var principal = new GenericPrincipal(fakeIdentity, roles);

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);
            return controllerContext;
        }
    }
}
