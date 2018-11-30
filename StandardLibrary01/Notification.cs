using System;
using System.Collections.Generic;
using System.Text;

namespace StandardLibrary01
{
    public class EmailClassic
    {
        public void SendEmail()
        {
            // code
        }
    }

    //in this case, the notification creates an instance of the e-mail directly inside of the notifications constructor and 
    // knows exactly what kind of email class it’s creating and consuming. It's violate DIP.
    public class NotificationClassic
    {
        private EmailClassic _email;
        public NotificationClassic()
        {
            _email = new EmailClassic();
        }

        public void PromotionalNotification()
        {
            _email.SendEmail();
        }
    }

    //https://www.codeproject.com/Articles/495019/Dependency-Inversion-Principle-and-the-Dependency
    //https://lostechies.com/derickbailey/2011/09/22/dependency-injection-is-not-the-same-as-the-dependency-inversion-principle/
    //The basic idea of this article is that how we can make our code loosely coupled
    //the code that relies on the interface should only ever know about the interface. 
    //It should not know about any of the specific classes that implement the interface.
    public interface IMessage
    {
        void SendMessage();
    }
    public class Email : IMessage
    {
        public void SendMessage()
        {
            throw new NotImplementedException();
        }
    }
    public class Sms : IMessage
    {
        public void SendMessage()
        {
            throw new NotImplementedException();
        }
    }

    // Dependency Inversion Principle with DI in application
    public class Notification
    {
        private readonly IMessage _message;

        //Constructor Injection
        public Notification(IMessage message)
        {
            _message = message;
        }
        public void Send01()
        {
            _message.SendMessage();
        }

        //Method Injection
        public void InjectViaMethod_Send02(IMessage messag)
        {
            messag.SendMessage();
        }

        //Property Injection
        public IMessage InjectViaProperty { get; set; }

        public void Send03()
        {
            InjectViaProperty.SendMessage();
        }
    }
}
