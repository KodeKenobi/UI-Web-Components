using PolicyManagementDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyManagementDataAccess
{
    public interface IClientEngagementRepository
    {
        Guid AddCallMeBack(CallMeBack callMeBack);

        void UpdateCallMeBack(Guid id, string comment);

        void AddNotification(BrokerNotification brokerNotification);

        CallMeBack GetCallMeBackById(Guid id);

        List<CallMeBack> GetCallMeBackList();

        List<BrokerNotification> GetBrokerNotificationList();
    }
}
