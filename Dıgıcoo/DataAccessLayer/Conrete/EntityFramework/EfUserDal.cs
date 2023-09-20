using Core.DataAccess.EntityFramework;
using Core.Entities.Concrate;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Conrete.EntityFramework
{
    public class EfUserDal : EntityRepositoryBase<User, StockContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new StockContext())
            {
                var result = from OperationClaim in context.operationClaims
                             join UserOperationClaim in context.userOperationClaims
                             on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                             where UserOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = OperationClaim.Id, Name = OperationClaim.Name };
                return result.ToList();


            }
        }
    }
}
