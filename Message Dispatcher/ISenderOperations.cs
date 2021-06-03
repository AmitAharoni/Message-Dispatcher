using System;

namespace Message_Dispatcher
{
     public interface ISenderOperations
     {
          /*
           * Put: puts a new message at the dispatcher. intended for a specific receiver to pull it.
           * IsWaitingMSG: Checks whether a specific message is still waiting at the dispatcher.
           * DeleteMSG: Deletes a specific message if it is still waiting at the dispatcher.
           * ListenToMSG: request to be informed by the dispatcher via a dedicated event once a specific message is pulled.
          */

          bool Put(Message msgToPut);
          bool IsWaitingMSG(int msgID);
          bool DeleteMSG(int msgID);
          bool ListenToMSG(int msgID, Action doWhenPulled);
     }
}
