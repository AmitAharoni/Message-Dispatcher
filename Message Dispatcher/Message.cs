using System.Collections;

namespace Message_Dispatcher
{
     public class Message
     {
          private static int MSGID = 0;

          public int MsgID { get; set; }
          public int ReceiverID { get; set; }
          public string Subject { get; private set; }
          public Hashtable Parameters { get; private set; }
          public bool IsListener { get; set; }

          public Message(int receiverID, string subject, Hashtable parameters)
          {
               MsgID = MSGID++;
               ReceiverID = receiverID;
               Subject = subject;
               Parameters = parameters;
               IsListener = false;
          }
     }
}
