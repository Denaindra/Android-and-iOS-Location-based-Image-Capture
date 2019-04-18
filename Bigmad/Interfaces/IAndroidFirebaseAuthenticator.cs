using System;
using System.Threading.Tasks;

namespace XamarinKit.Interfaces
{
    public interface IAndroidFirebaseAuthenticator
    {
        void LoginWithEmailPassword(string email, string password);
        void UserRegisteration(string email, string password);
        void GetDataFromDatabased();
        void SendMessages(string messages);
    }
}
