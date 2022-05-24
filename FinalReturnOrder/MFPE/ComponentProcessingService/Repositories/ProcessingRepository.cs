using ComponentProcessingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingService.Repositories
{
    public class ProcessingRepository: IProcessingRepository
    {
        
        public List<ProcessResponse> responses;                
        public ComponentProcessingContext _context;

        public ProcessingRepository(ComponentProcessingContext context)
        {
            _context = context;            
            responses = new List<ProcessResponse>();            
            
        }
        
        public int GenerateId()
        {
            Random random = new Random();
            int temp = random.Next(10000, 99999);
            return temp;
        }
       
        

        public void AddCompleteProcess(ProcessFinalResponse processPayment)
        {
            _context.Add(processPayment);
            _context.SaveChanges();
        }
        
       
    }
}
