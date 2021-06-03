using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_Dispatcher
{
     public class Sender
     {
          public void Put(ISenderOperations dispatcher, Message msg)
          {
               dispatcher.Put(msg);
          }

          public void IsWaitingMSG(ISenderOperations dispatcher, int msgID)
          {
               dispatcher.IsWaitingMSG(msgID);
          }

          public void DeleteMSG(ISenderOperations dispatcher, int msgID)
          {
               dispatcher.DeleteMSG(msgID);
          }

          public void ListenToMSG(ISenderOperations dispatcher, int msgID, Action doWhenPulled)
          {
               dispatcher.ListenToMSG(msgID, doWhenPulled);
          }
     }
}
