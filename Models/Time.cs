using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiTimeBeisebol.Models
{
    public class Time : Controller
    {
        // GET: Time
        public Time()
        {

        }

        public Time(int idTime, string NomeTime, string CidadeTime)
        {
            IdTime = idTime;
            nomeTime = NomeTime;
            cidadeTime = CidadeTime;
        }

        public int IdTime { get; set; }
        public string nomeTime { get; set; }
        public string cidadeTime { get; set; }




    }
}
