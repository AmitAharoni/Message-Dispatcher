using System.Collections.Generic;

namespace Message_Dispatcher
{
     public interface IReceiverOperations
     {
          Message PullMSG(int receiverID, int msgID);
          Dictionary<int, Message> PullBox(int receiverID);
     }
}
