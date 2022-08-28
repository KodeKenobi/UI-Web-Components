using Microsoft.EntityFrameworkCore;
using PolicyManagementDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyManagementDataAccess.Repositories
{
    public class ClientEngagementRepository : IClientEngagementRepository
    {
        private BrkBaseContext context;
        private DbSet<CallMeBack> callMeBackEntity;
        private DbSet<BrokerNotification> brokerNotificationEntity;

        public ClientEngagementRepository(BrkBaseContext context)
        {
            this.context = context;
            callMeBackEntity = context.Set<CallMeBack>();
            brokerNotificationEntity = context.Set<BrokerNotification>();
        }

        public Guid AddCallMeBack(CallMeBack callMeBack)
        {
            try
            {
                var id = Guid.NewGuid();

                callMeBack.Id = id;

                context.Entry(callMeBack).State = EntityState.Added;

                context.SaveChanges();

                return id;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void AddNotification(BrokerNotification brokerNotification)
        {
            try
            {
                var id = Guid.NewGuid();

                brokerNotification.Id = id;
                brokerNotification.DateCreated = DateTime.Now;

                context.Entry(brokerNotification).State = EntityState.Added;

                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<BrokerNotification> GetBrokerNotificationList()
        {
            try
            {
                return brokerNotificationEntity.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<CallMeBack> GetCallMeBackList()
        {
            try
            {
                return callMeBackEntity.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public CallMeBack GetCallMeBackById(Guid id)
        {
            try
            {
                return callMeBackEntity.SingleOrDefault(s => s.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void UpdateCallMeBack(Guid id, string comment)
        {
            try
            {
                var callMeBack = GetCallMeBackById(id);

                callMeBack.Comment = comment;

                //update user
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
