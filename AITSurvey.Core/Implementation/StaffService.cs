using AITSurvey.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITSurvey.Core.Implementation
{
    public class StaffService
    {
        private readonly StaffReporsitory _staffReporsitory;
        public StaffService()
        {
            _staffReporsitory = new StaffReporsitory();
        }
        public int Login(string userName, string password)
        {
            return _staffReporsitory.Login(userName, password);
        }
    }
}
