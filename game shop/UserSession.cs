using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game_shop
{
    public static class UserSession
    {
        public static string CurrentUsername = null;

        public static bool IsLoggedIn
        {
            get { return !string.IsNullOrEmpty(CurrentUsername); }
        }
    }

}
