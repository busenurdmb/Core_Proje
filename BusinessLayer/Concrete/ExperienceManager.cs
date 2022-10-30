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
    public class ExperienceManager : IExperienceService
    {
        IExperienceDal _IexperienceDal;

        public ExperienceManager(IExperienceDal ıexperienceDal)
        {
            _IexperienceDal = ıexperienceDal;
        }

        public void TAdd(Experience t)
        {
            _IexperienceDal.Insert(t);
        }

        public void TDelete(Experience t)
        {
            _IexperienceDal.Delete(t);
        }

        public Experience TGetByID(int id)
        {
          return  _IexperienceDal.GetByID(id);
        }

        public List<Experience> TGetList()
        {
            return _IexperienceDal.GetList();
        }

        

        public void Tupdate(Experience t)
        {
            _IexperienceDal.update(t);
        }
    }
}
