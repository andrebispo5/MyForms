using System;
using System.Threading.Tasks;
using MyForms.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace MyForms.Services
{
    public class AppDataService : IAppDataService
    {
        private static UserProfile _userProfile;

        public UserProfile UserProfile
        {
            get
            {
                if (_userProfile != null)
                {
                    return _userProfile;
                }

                string json = Preferences.Get(nameof(UserProfile), string.Empty);
                _userProfile = json == string.Empty ? new UserProfile() : JsonConvert.DeserializeObject<UserProfile>(json);
                return _userProfile;
            }

            set
            {
                _userProfile = value;
                var json = JsonConvert.SerializeObject(value);
                Preferences.Set(nameof(UserProfile), json);
            }
        }

        public Task<string> SecureGetAsync(string key)
        {
            bool isSimulator = DeviceInfo.DeviceType == DeviceType.Virtual;
            if (isSimulator)
            {
                var value = Preferences.Get(key, string.Empty);
                return Task.FromResult(value);
            }

            return SecureStorage.GetAsync(key);
        }

        public void SecureRemove(string key)
        {
            bool isSimulator = DeviceInfo.DeviceType == DeviceType.Virtual;
            if (isSimulator)
            {
                Preferences.Remove(key);
                return;
            }

            SecureStorage.Remove(key);
        }

        public Task SecureSetAsync(string key, string value)
        {
            bool isSimulator = DeviceInfo.DeviceType == DeviceType.Virtual;
            if (isSimulator)
            {
                Preferences.Set(key, value);
                return Task.CompletedTask;
            }

            return SecureStorage.SetAsync(key, value);
        }

        public void Set(string key, string value) => Preferences.Set(key, value);

        public void Set(string key, bool value) => Preferences.Set(key, value);

        public void Set(string key, int value) => Preferences.Set(key, value);

        public void Set(string key, DateTime value) => Preferences.Set(key, value);
    }
}
