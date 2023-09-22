using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private IMessageDal messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }

        public List<Message> GetListInbox(string mail)
        {
            return messageDal.List(x => x.ReceiverMail == mail);
        }

        public Message GetById(int id)
        {
            return messageDal.Get(x=>x.MessageId == id);
        }

        public List<Message> GetListSendbox(string mail)
        {
            return messageDal.List(x => x.SenderMail == mail);
        }

        public void MessageAdd(Message message)
        {
            messageDal.Add(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
