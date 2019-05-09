using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.SL.Controllers
{
    public class FormatController : ApiController
    {
        FormatList formatList;
        // GET: api/Format
        public IEnumerable<Format> Get()
        {
            formatList = new FormatList();
            formatList.Load();
            return formatList;
        }

        // GET: api/Format/5
        public Format Get(int id)
        {
            Format format = new Format { Id = id };
            format.LoadById();
            return format;
        }

        // POST: api/Format
        public void Post([FromBody]Format format)
        {
            format.Insert();
        }

        // PUT: api/Format/5
        public void Put(int id, [FromBody]Format format)
        {
            format.Update();
        }

        // DELETE: api/Format/5
        public void Delete(int id)
        {
            Get(id).Delete();
        }
    }
}
