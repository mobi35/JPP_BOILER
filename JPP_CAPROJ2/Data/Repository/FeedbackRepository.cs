using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Repository
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        private readonly JPPDbContext _context;

        public FeedbackRepository(JPPDbContext context) : base(context)
        {
            _context = context;
        }

        public Feedback FindFeedback(Func<Feedback, bool> predicate)
        {
            return _context.Feedbacks
                  .FirstOrDefault(predicate);
        }
    }
}
