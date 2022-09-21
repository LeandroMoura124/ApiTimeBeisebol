using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using static ApiTimeBeisebol.Controllers.BdConnector;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using ActionNameAttribute = System.Web.Http.ActionNameAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using ApiBeisebol.Models;
using ApiTimeBeisebol.Controllers;
using ApiTimeBeisebol.Models;


namespace ApiTimeBeisebol.Controllers
{
    public class TimeController : Controller
    {
        // GET: Time
        List<Time> times = new List<Time>();

        //exemplo de método com busca em Banco de dados

        // api/Cantada/MostraTodas
        [HttpGet]
        //Pode mudar o nome que vai ser usado na Url
        [ActionName("MostraTodas")]
        public IEnumerable<Time> GetAllLivros()
        {
            //tenta conectar ao banco
            try
            {
                BdConector db = new BdConector();
                var cants = db.BuscaTodos();
                db.Fechar();
                return cants;
            }
            catch (Exception)
            {
                //se der erado o banco retorna erro de desautorizado 
                var resp = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(resp);
            }
        }

        // usar swegger


        //importande colocar parametros no BODY
        // POST: api/Cantada/addCantada
        [HttpPost]
        [ActionName("addTime")]
        public HttpResponseMessage Post([FromBody] List<Time> itens)
        {
            if (itens == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

            //manda adicionar o item 
            //recebe uma lista, faz um laço para recbe um valor de cada vez
            BdConector db = new BdConector();
            foreach (var item in itens)
            {
                db.adicionaTime(item);
            }

            //fecha banco
            db.Fechar();

            //retorna mensagem de sucesso
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            return response;
        }

        //update
        // PUT: api/Cantada/atualiza/{id}
        //Obs:tem que passar id, txt e categoria no body
        [HttpPut]
        [ActionName("atualiza")]
        public HttpResponseMessage Put(int id, [FromBody] Time item)
        {

            if (item == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

            BdConector db = new BdConector();
            db.UpdateTime(item);
            db.Fechar();

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        //Delete
        //api/Cantada/delete?idCant={id}
        [HttpDelete]
        [ActionName("delete")]
        public HttpResponseMessage Delete(int idCant)
        {
            BdConector db = new BdConector();
            db.RemoveTime(idCant);
            db.Fechar();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}