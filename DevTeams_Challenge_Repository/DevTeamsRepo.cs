using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DevTeamsRepo
    {
        //This is our Repository class that will hold our directory (which will act as our database) and methods that will directly talk to our directory.

        private List<Developer> _devDirectory = new List<Developer>();

        // Create
        public bool AddDeveloperToDirectory(Developer newDev)
        {
            int startingCount = _devDirectory.Count;

            _devDirectory.Add(newDev);

            bool wasAdded = (_devDirectory.Count > startingCount) ? true : false;

            return wasAdded;
        }

        // Read
        public List<Developer> GetMembers()
        {
            return _devDirectory;
        }
        
        public Developer GetDeveloperByFirstName(string firstName)
        {
            foreach (Developer name in _devDirectory)
            {
                if (name.FirstName.ToLower() == firstName.ToLower())
                {
                    return name;
                }
            }
            return null;
        }

        // Update
        public bool UpdateExistingDeveloper(string oldMember, Developer newMemberValues)
        {
            Developer oldValues = GetDeveloperByFirstName(oldMember);

            if (oldValues != null)
            { 
                oldValues.ID = newMemberValues.ID;
                oldValues.FirstName = newMemberValues.FirstName;
                oldValues.LastName = newMemberValues.LastName;
                oldValues.TeamAssingment = newMemberValues.TeamAssingment;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool DeleteExistingDeveloper(string nameToDelete)
        {
            Developer devToDelete = GetDeveloperByFirstName(nameToDelete);
            if (devToDelete == null)
            {
                return false;
            }
            else
            {
                _devDirectory.Remove(devToDelete);
                return true;
            }
        }
    }
}
