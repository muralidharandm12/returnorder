using ComponentProcessingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingService.Repositories
{
    public interface IProcessingRepository
    {
       
        public int GenerateId();        
        
        public void AddCompleteProcess(ProcessFinalResponse processPayment);



    }
}
