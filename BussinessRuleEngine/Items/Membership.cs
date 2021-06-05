using BussinessRuleEngine.Interfaces;

namespace BussinessRuleEngine.Items
{
    public class Membership : IMembership, IItemOrder
    {
        private readonly INotifaction _notification;
        private readonly bool _isUpgrade;

        public Membership(INotifaction notification, bool isUpgrade)
        {
            _notification = notification;
            _isUpgrade = isUpgrade;
        }

        public void ActivateMembership()
        {
            //Activate Membership  and send notification
            _notification.SendEmailNotification("email id of the owner");
        }

        public void UpgradeMembership()
        {
            //Upgrade Membership and send notification
            _notification.SendEmailNotification("email id of the owner");
        }

        public void ExecuteOrder()
        {
            if (_isUpgrade)
                UpgradeMembership();
            else
                ActivateMembership();
        }
    }
}