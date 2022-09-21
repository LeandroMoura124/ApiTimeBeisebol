using ApiTimeBeisebol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiBeisebol.Models
{
    public class TimeRepository : Controller
    {
        // GET: TimeRepository
        private List<Time> times = new List<Time>();
        private int nextId = 1;


        //Adiconndo dados a api
        public TimeRepository()
        {
            //o ideal que seja um banco de dados
            Add(new Time { nomeTime = "Baltimore Orioles" });
            Add(new Time { nomeTime = "Boston Red Sox" });
            Add(new Time { nomeTime = "New York Yankees" });
        }
        public Time Add(Time item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.IdTime = nextId++;
            times.Add(item);
            return item;
        }

        public Time Get(int id)
        {
            return times.Find(p => p.IdTime == id);
        }

        public IEnumerable<Time> GetAll()
        {
            return times;
        }

        public void Remove(int id)
        {
            times.RemoveAll(p => p.IdTime == id);
        }

        public bool Update(Time item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = times.FindIndex(p => p.IdTime == item.IdTime);
            if (index == -1)
            {
                return false;
            }
            times.RemoveAt(index);
            times.Add(item);
            return true;
        }
    }
}

