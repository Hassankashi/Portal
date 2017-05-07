using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.UI;
using Pine.Bll;
using Pine.Dal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pine.Bll.Chat;



public class ChatController : ApiController
{

// GET api/<controller>
public IEnumerable<string> Get(int id)
    {
Guid userid=new Guid();
// return new string[] { "value1", "value2" };
var session = HttpContext.Current.Session;
Guid recID=new Guid();
string recGuid="aacff1cf-14a4-4ca2-888c-8775bd488da2";
        recID = Guid.Parse((recGuid));

// ch.FirstName = "mahsarferfe";
//id unique user
string username = "Admin";
MembershipUser u = Membership.GetUser(username);
if (u!=null)
     {
          userid=(Guid)u.ProviderUserKey;
     }

// Guid userId = Guid.NewGuid();

     Pine.Bll.Chat.Chat_Conversation chatConversation = Pine.Bll.Chat.Chat_Conversation.GetChat_ConversationBySenderIdAndReceiverId(userid, recID);
int convId;
if (chatConversation==null )
        {
            Pine.Bll.Chat.Chat_Conversation cnv = new Chat_Conversation();
            cnv.DomainId = 1;
            cnv.LanguageId = 1;
//cnv.PartId = partid;
//To Reza
            cnv.PartId = 2;
            cnv.SenderId = userid;
            cnv.ReceiverId = recID;
            cnv.Flag = 0;

            convId = cnv.Chat_ConversationInsert();
        }
else
        {
            chatConversation.Flag = 0;
            chatConversation.Chat_ConversationUpdate();
            convId = chatConversation.ConversationId;
        }
List<Chat_Message>ccc=  Chat_Message.GetChat_MessageByConversationIdAndUserIdAndIsRead(convId, userid, false);
foreach (Chat_Message item in ccc)
        {
            item.IsRead = true;
            item.Chat_MessageUpdate();
        }

return (from s in ccc select s.Comment ).ToList();
// return Chat_Message.GetChat_MessageByConversationId(chatConversation.ConversationId);
    }



//private void InsertMessage([FromBody]string  value)
//{
//  // // ConversationId, SenderId, ReceiverId, PartId, Flag, DomainId, LanguageId
//  //  int partId = 0;
//  //  Guid recID=new Guid();
//  //  string text = value;
//  //  string username = HttpContext.Current.User.Identity.Name;
//  //  MembershipUser u = Membership.GetUser(username);
//  //  if (u != null)
//  //  {
//  //      userid = (Guid)u.ProviderUserKey;
//  //  }
//  //  Pine.Bll.Chat.Chat_Conversation chatConversation = Pine.Bll.Chat.Chat_Conversation.GetChat_ConversationBySenderIdAndReceiverId(userId, recID);
//  //  int convId;
//  //  if (chatConversation == null)
//  //  {
//  //      Pine.Bll.Chat.Chat_Conversation cnv = new Chat_Conversation();
//  //      cnv.DomainId = 1;
//  //      cnv.LanguageId = 1;
//  //      cnv.PartId = partId;
//  //      cnv.SenderId = userid;
//  //      cnv.ReceiverId = recID;
//  //      cnv.Flag = 0;


//  //      convId = cnv.Chat_ConversationInsert();
//  //  }
//  //  else
//  //  {
//  //      chatConversation.Flag = 0;
//  //      chatConversation.Chat_ConversationUpdate();
//  //      convId = chatConversation.ConversationId;
//  //  }


//  //  Pine.Bll.Chat.Chat_Message msg = new Chat_Message();
//  //  msg.IsRead = false;
//  //  msg.Comment = text;
//  //  msg.UserId = userid;
//  //  msg.ConversationId = convId;
//  //  msg.DomainId = 1;
//  //  msg.LanguageId = 1;
//  //  msg.Username = username;

//  //  msg.Chat_MessageInsert();
//  ////  message.Insert((int)ViewState["ConversationId"], RadTextBox1.Text, (Guid)ViewState["SenderId"], User.Identity.Name, false);
//}
// GET api/<controller>/5
//public string Gets(int id)
//{
//    return "value";
//}

// POST api/<controller>
public void Post([FromBody]string value)
    {
// ConversationId, SenderId, ReceiverId, PartId, Flag, DomainId, LanguageId
int partId = 0;
Guid recID = new Guid();
string recGuid = "aacff1cf-14a4-4ca2-888c-8775bd488da2";
        recID = Guid.Parse((recGuid));
Guid userid=new Guid();

string text = value;
// string username = HttpContext.Current.User.Identity.Name;
string username = "Admin";
MembershipUser u = Membership.GetUser(username);
//if (u != null)
//{
            userid = (Guid)u.ProviderUserKey;
// }
            Pine.Bll.Chat.Chat_Conversation chatConversation = Pine.Bll.Chat.Chat_Conversation.GetChat_ConversationBySenderIdAndReceiverId(userid, recID);
int convId;
if (chatConversation == null)
        {
            Pine.Bll.Chat.Chat_Conversation cnv = new Chat_Conversation();
            cnv.DomainId = 1;
            cnv.LanguageId = 1;
//To Sale
// cnv.PartId = partId;
            cnv.PartId = 2;
            cnv.SenderId = userid;
            cnv.ReceiverId = recID;
            cnv.Flag = 0;


            convId = cnv.Chat_ConversationInsert();
        }
else
        {
            chatConversation.Flag = 0;
            chatConversation.Chat_ConversationUpdate();
            convId = chatConversation.ConversationId;
        }


        Pine.Bll.Chat.Chat_Message msg = new Chat_Message();
        msg.IsRead = false;
        msg.Comment = text;
        msg.UserId = userid;
        msg.ConversationId = convId;
        msg.DomainId = 1;
        msg.LanguageId = 1;
        msg.Username = username;

        msg.Chat_MessageInsert();
//  message.Insert((int)ViewState["ConversationId"], RadTextBox1.Text, (Guid)ViewState["SenderId"], User.Identity.Name, false);

    }

// PUT api/<controller>/5
public void Put(int id, [FromBody]string value)
    {
    }

// DELETE api/<controller>/5
public void Delete(int id)
    {
    }

public Guid userId { get; set; }


}


