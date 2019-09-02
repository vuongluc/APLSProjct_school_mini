using ProjectDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain.Business.Evaluate
{
    public interface IEvaluatesBusiness
    {
        List<EvaluateDTO> findAllEvaluate();
        EvaluateDTO findById(string evaluaId);
        void createEvaluate(EvaluateDTO newEvalua);
        void updateEvaluate(EvaluateDTO updateEvalua);
        List<EvaluateDTO> search(string query);
        
    }
}
