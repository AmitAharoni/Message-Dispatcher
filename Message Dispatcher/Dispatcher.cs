using System;
using System.Collections.Generic;

namespace Message_Dispatcher
{
     public class Dispatcher : ISenderOperations, IReceiverOperations, IPersistable
     {
          private Dictionary<int, Dictionary<int, Message>> msgBoxes = new Dictionary<int, Dictionary<int, Message>>();

          Dictionary<int, Action> informActions = new Dictionary<int, Action>();

          public bool Put(Message msg)
          {
               if(ReceiverDoesntHaveBox(msg.ReceiverID))
               {
                    CreateReceiverBox(msg.ReceiverID);
               }

               if(MSGAlreadyExistInBox(msg))
               {
                    return false;
               }
               else
               {
                    AddMSGToBox(msg);
                    return true;
               }
          }

          private bool ReceiverDoesntHaveBox(int receiverID)
          {
               return !msgBoxes.ContainsKey(receiverID);
          }

          private void CreateReceiverBox(int receiverID)
          {
               msgBoxes.Add(receiverID, new Dictionary<int, Message>());
          }

          private bool MSGAlreadyExistInBox(Message msg)
          {
               return msgBoxes[msg.ReceiverID].ContainsKey(msg.MsgID);
          }

          private void AddMSGToBox(Message msg)
          {
               msgBoxes[msg.ReceiverID].Add(msg.MsgID, msg);
          }

          public bool IsWaitingMSG(int msgToSearchID)
          {
               foreach(Dictionary<int, Message> box in msgBoxes.Values)
               {
                    foreach(Message msg in box.Values)
                    {
                         if(msg.MsgID == msgToSearchID)
                         {
                              return true;
                         }
                    }
               }

               return false;
          }

          public bool DeleteMSG(int msgToDeleteID)
          {
               foreach(Dictionary<int, Message> box in msgBoxes.Values)
               {
                    foreach(Message msg in box.Values)
                    {
                         if(msg.MsgID == msgToDeleteID)
                         {
                              if(msg.IsListener == true)
                              {
                                   informActions[msgToDeleteID]();
                              }

                              box.Remove(msgToDeleteID);
                              return true;
                         }
                    }
               }

               return false;
          }

          public bool ListenToMSG(int msgID, Action doWhenPulled)
          {
               Message MSG = GetMSG(msgID);

               if(MSG != null)
               {
                    MSG.IsListener = true;
                    informActions.Add(msgID, doWhenPulled);
                    return true;
               }

               return false;
          }

          private Message GetMSG(int msgID)
          {
               Message msgToReturn = null;

               foreach(Dictionary<int, Message> box in msgBoxes.Values)
               {
                    foreach(Message msg in box.Values)
                    {
                         if(msg.MsgID == msgID)
                         {
                              msgToReturn = msg;
                              break;
                         }
                    }
               }

               return msgToReturn;
          }

          public Message PullMSG(int receiverToPullFromID, int msgToPullID)
          {
               Message pulledMSG = null;

               foreach(Message msg in msgBoxes[receiverToPullFromID].Values)
               {
                    if(msg.MsgID == msgToPullID)
                    {
                         pulledMSG = msgBoxes[receiverToPullFromID][msgToPullID];
                         msgBoxes[receiverToPullFromID].Remove(msgToPullID);
                         if(msg.IsListener == true)
                         {
                              informActions[msgToPullID]();
                         }
                         break;
                    }
               }

               return pulledMSG;
          }

          public Dictionary<int, Message> PullBox(int receiverID)
          {
               Dictionary<int, Message> pulledBox = null;

               if(msgBoxes.ContainsKey(receiverID))
               {
                    pulledBox = msgBoxes[receiverID];
                    foreach(Message msg in msgBoxes[receiverID].Values)
                    {
                         if(msg.IsListener == true)
                         {
                              informActions[msg.MsgID]();
                         }
                    }
                    msgBoxes[receiverID].Clear();
               }

               return pulledBox;
          }

          public void BackUp(Dispatcher dispatcher)
          {

          }

          public void Reload(Dispatcher dispatcher)
          {

          }
     }
}
