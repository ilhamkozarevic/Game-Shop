using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game_shop
{
    public static class UserSession
    {
        public static string CurrentUsername { get; set; }
        public static int CurrentUserId { get; set; }

        public static string Role { get; set; }
    }

}
