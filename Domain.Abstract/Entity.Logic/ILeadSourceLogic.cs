using Domain.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract.Entity.Logic
{
    public interface ILeadSourceLogic
    {
        List<ILeadSource> GetLeadSources();

        void InsertLeadSource(ILeadSource leadSource);
    }
}
