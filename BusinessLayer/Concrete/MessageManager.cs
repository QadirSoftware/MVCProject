using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal message)
        {
            _messageDal = message;
        }

        public Message GetID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
            
        }

       

        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.ReceiveMail == "admin@gmail.com");
           
        }

        public void MessageAddBL(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
