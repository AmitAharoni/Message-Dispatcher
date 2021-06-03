using System.Collections.Generic;

namespace Message_Dispatcher
{
     public class Receiver
     {
          public Message PullMSG(IReceiverOperations dispatcher, int receiverToPullFromID, int msgToPullID)
          {
               return dispatcher.PullMSG(receiverToPullFromID, msgToPullID);
          }

          public Dictionary<int, Message> PullBox(IReceiverOperations dispatcher, int receiverID)
          {
               return dispatcher.PullBox(receiverID);
          }
     }
}
