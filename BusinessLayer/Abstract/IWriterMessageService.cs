using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public  interface IWriterMessageService : IGenericService<WriterMessage>
    {
        //sade bu sınıfa özel method
        List<WriterMessage> GetListSenderMessage(string p);
        List<WriterMessage> GetListReceverMessage(string p);
       
    }
}
