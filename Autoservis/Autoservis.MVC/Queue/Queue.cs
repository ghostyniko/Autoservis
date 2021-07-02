using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Messaging;

namespace Autoservis.MVC.Queue
{
    public class Queue
    {
      

        public static MessageQueue GetClientMQ(int id)
        {
            return new MessageQueue(".\\private$\\"+id);
        }

        public static MessageQueue GetAutoservisMQ()
        {
            if (!MessageQueue.Exists(".\\private$\\Autoservis"))
            {
              
                MessageQueue.Create(".\\private$\\Autoservis");
            }
            return new MessageQueue(".\\private$\\Autoservis");
        }
       

        public static bool Exists(int id)
        {
            return MessageQueue.Exists(".\\private$\\" + id);
        }

        public static void Create (int id)
        {
            MessageQueue.Create(".\\private$\\" + id);
        }

        public static void Delete(int id)
        {
            if (Exists(id))
            {
                MessageQueue.Delete(".\\private$\\" + id);
            }
        }
    }
}