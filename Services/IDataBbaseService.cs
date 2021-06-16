using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAS_semestral_project_MVS.DataBaseModels;

namespace MAS_semestral_project_MVS.Services
{
    public interface IDataBbaseService
    {
        public ClassAttributesInColumn GetClassAttributesInColumn();
    }
}
