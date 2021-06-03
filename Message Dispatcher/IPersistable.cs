using System;

namespace Message_Dispatcher
{
     public interface IPersistable
     {
          /*
           * A persistency provider may be implemented in any technique for saving data.
           * The dispatcher may be initialized with a persistency provider, for saving the state of any waiting messages as a backup.
           * The dispatcher may reload backup during recovery from critical failures.
          */

          void BackUp(Dispatcher dispatcher);
          void Reload(Dispatcher dispatcher);
     }
}
