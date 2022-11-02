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
        IMessageDal _ImessageDal;

        public MessageManager(IMessageDal ımessageDal)
        {
            _ImessageDal = ımessageDal;
        }

        public void TAdd(Message t)
        {
            _ImessageDal.Insert(t);

        }

        public void TDelete(Message t)
        {
            _ImessageDal.Delete(t);
        }

        public Message TGetByID(int id)
        {
            return _ImessageDal.GetByID(id);
        }

        public List<Message> TGetList()
        {
            return _ImessageDal.GetList();
        }

        public List<Message> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void Tupdate(Message t)
        {
            _ImessageDal.update(t);
        }
    }
}
