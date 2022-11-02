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
    public class ContactManager : IContactService
    {
        IContactDal _IcontactDal;

        public ContactManager(IContactDal ıcontactDal)
        {
            _IcontactDal = ıcontactDal;
        }

        public void TAdd(Contact t)
        {
            _IcontactDal.Insert(t);
        }

        public void TDelete(Contact t)
        {
            _IcontactDal.Delete(t);
        }

        public Contact TGetByID(int id)
        {
            return _IcontactDal.GetByID(id);
        }

        public List<Contact> TGetList()
        {
            return _IcontactDal.GetList();
        }

        

        public void Tupdate(Contact t)
        {
            _IcontactDal.update(t);
        }
    }
}
