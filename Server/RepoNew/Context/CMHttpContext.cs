using Repo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Context
{
    public class CMHttpContext : ICMHttpContext
    {
        public CMHttpContext(IHttpContextAccessor httpContext)
        {

        }
        public required HttpContext HttpContext { get; set; }

        private UserContext _user;
        private CompanyContext _company;

        public CompanyContext GetCompany()
        {
            return _company;
        }

        public HttpContext GetHttpContext()
        {
            return HttpContext;
        }

        public UserContext? GetUser()
        {
            return _user;
        }

        public void SetCompany(CompanyContext company)
        {
            _company = company;
        }

        public void SetHttpContext(HttpContext httpContext)
        {
            HttpContext = httpContext;
        }

        public void SetUser(UserContext user)
        {
            _user = user;
        }
    }
}
