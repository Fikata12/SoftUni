using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        private string codeName;
        private string state;
        public string CodeName
        {
            get { return codeName; }
            private set { codeName = value; }
        }
        public string State
        {
            get { return state; }
            private set
            {
                if (value == "inProgress" || value == "Finished")
                {
                    state = value;
                }
            }
        }
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }
        public void CompleteMission(Mission mission)
        {
            if (mission.State == "inProgress")
            {
                mission.State = "Finished";
            }
        }
        public override string ToString()
        {
            return $"  Code Name: {CodeName} State: {State}";
        }
    }
}
