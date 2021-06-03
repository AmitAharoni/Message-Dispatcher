using System.Collections.Generic;

namespace Message_Dispatcher
{
     public interface IReceiverOperations
     {
          /*
           * Pull MSG: Retrieves a specific message that are waiting for that receiver.
           * Pull Box: Retrieves all messages that are waiting for that receiver.
          */
           
          Message PullMSG(int receiverID, int msgID);
          Dictionary<int, Message> PullBox(int receiverID);
     }
}
