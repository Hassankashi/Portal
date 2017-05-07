using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

public class MahsaController : ApiController
{
    // GET api/<controller>
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };

        //List<Chat_Conversation> chatmsg = Chat_Conversation.GetChat_ConversationByPartId(id);

        //IEnumerable<Chat_Conversation> myquery = from s in chatmsg select s;
        //List<string> bst = new List<string>();

        //foreach (Chat_Conversation item in myquery)
        //{
        //    bst.Add(item.ConversationId.ToString());
        //}


        //return bst;
    }

    // GET api/<controller>/5
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<controller>
    public void Post([FromBody]string value)
    {
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
    }
}
