using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiTimeBeisebol.Models
{
    public class IRepositorioProd : Controller
    {
        // GET: RepositorioProd
        internal interface IIRepositorioProd
        {
            IEnumerable<Time> GetAll();
            Time Get(int id);
            Time Add(Time item);
            void Remove(int id);
            bool Update(Time item);
        }
    }
}