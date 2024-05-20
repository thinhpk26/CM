using Repo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Context
{
    public interface ICMHttpContext
    {
        /// <summary>
        /// Set người dùng
        /// </summary>
        /// <param name="user"></param>
        public void SetUser(UserContext user);

        /// <summary>
        /// Lấy người dùng
        /// </summary>
        /// <returns></returns>
        public UserContext? GetUser();

        /// <summary>
        /// Lấy công ty
        /// </summary>
        /// <returns></returns>
        public CompanyContext GetCompany();

        /// <summary>
        /// Set công ty
        /// </summary>
        /// <param name="company"></param>
        public void SetCompany(CompanyContext company);

        /// <summary>
        /// Lấy httpContext
        /// </summary>
        /// <returns></returns>
        public HttpContext GetHttpContext();

        /// <summary>
        /// Set httpcontext
        /// </summary>
        public void SetHttpContext(HttpContext httpContext);
    }
}
