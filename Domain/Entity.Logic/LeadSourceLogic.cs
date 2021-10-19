using Domain.Abstract.Entities;
using Domain.Abstract.Entity.Logic;
using Domain.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Logic
{
    public class LeadSourceLogic : ILeadSourceLogic
    {
        ILeadSourceRepository _leadSourceRepository;

        public LeadSourceLogic(ILeadSourceRepository leadSourceRepository)
        {
            _leadSourceRepository = leadSourceRepository;
        }
        public List<ILeadSource> GetLeadSources()
        {
            var sources = _leadSourceRepository.GetLeadSources();
            return sources;
        }

        public void InsertLeadSource(ILeadSource leadSource)
        {
            _leadSourceRepository.InsertLeadSource(leadSource);
        }
    }
}
