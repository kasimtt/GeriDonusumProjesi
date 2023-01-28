using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concretes
{
    public class OperationClaim:IEntity
    {
        public int OperationClaimId { get; set; }
        public string Name { get; set; }
    }
}
