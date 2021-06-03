using System;

namespace Message_Dispatcher
{
     public interface IPersistable
     {
          void BackUp(Dispatcher dispatcher);
          void Reload(Dispatcher dispatcher);
     }
}
