using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMX.WorkersBenefits.ProxyServices.Managers;

namespace EMX.WorkersBenefits.BL.Managers
{
    /// <summary>
    /// Handles all actions around phone approval codes.
    /// </summary>
    public class ApprovalCodeManager
    {
        private const string StateKeyPrefix = "APPROVE_{USER_ID}";
        private IUserStateManager _stateManager;
        public ApprovalCodeManager(IUserStateManager pStateManager)
        {
            _stateManager = pStateManager;
        }

        /// <summary>
        /// Sends code in sms
        /// </summary>
        public void SendCode(string userId, string phoneNumber)
        {
            string code = GenerateSixDigitCode();
            SMSSender.SendRegular(phoneNumber, code);
            StoreUserCode(userId, code);
        }

        private void StoreUserCode(string userId, string code)
        {
            _stateManager.Set(StateKeyPrefix.Replace("{USER_ID}", userId), code);
        }

        private string FetchUserCode(string userId)
        {
            return _stateManager.Get(StateKeyPrefix.Replace("{USER_ID}", userId));
        }

        private string GenerateSixDigitCode()
        {
            return RandomGenerator.GetNextCode(6);
        }

        public bool CheckCode(string userId, string tryCode)
        {
            return FetchUserCode(userId) == tryCode;
        }
    }

    /// <summary>
    /// Defines properties and methods for user-session-state management.
    /// </summary>
    public interface IUserStateManager
    {
        string Get(string key);
        void Set(string key, string value);
    }
}
