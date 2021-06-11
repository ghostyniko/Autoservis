using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Web;

namespace Autoservis.MVC.Services
{
    public abstract class NotifyAutoservis : AsyncCodeActivity
    {
        public InArgument<TerminPregleda> NoviTermin { get; set; }

        public abstract string GetMessage(TerminPregleda p);

        //  public abstract string GetMessage(TerminPregleda t);

        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            Action<TerminPregleda> asyncWork = t => SendNotification(t);
            context.UserState = asyncWork;
            return asyncWork.BeginInvoke(NoviTermin.Get(context), callback, state);
        }

        protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            ((Action<TerminPregleda>)context.UserState).EndInvoke(result);
        }

        private void SendNotification(TerminPregleda t)
        {
         
            var queue = Queue.Queue.GetAutoservisMQ();
            // queue.Formatter = new XmlMessageFormatter(new Type[] { (typeof(string)) });
            // var message = (string)queue.Receive().Body;
            Message message = new Message();

            var sadrzaj = GetMessage(t);


            message.Body = sadrzaj;

            queue.Send(message);
            queue.Close();

        }
    }
}