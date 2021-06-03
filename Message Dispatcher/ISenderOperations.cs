using System;

namespace Message_Dispatcher
{
     public interface ISenderOperations
     {
          bool Put(Message msgToPut);
          bool IsWaitingMSG(int msgID);
          bool DeleteMSG(int msgID);
          bool ListenToMSG(int msgID, Action doWhenPulled);
     }
}
