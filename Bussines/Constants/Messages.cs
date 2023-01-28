using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Bussines.Constants
{
    public static class Messages
    {
        public static string AddedMessages = "Adding successful";
        public static string DeletedMessages = "Deletion successful";
        public static string UpdatedMessages = "Update successful";
        public static string GetAllMessages = "Listing successful";
        public static string GetMessages = "Result brought";
        public static string ProductNameInvalid = "Product name is invalid";
        public static string MaintenanceTime = "System in Maintenance";
        public static string NotAddedMessages = "Add failed";

        public static string PersonDetailsListed = "Contact details listed";

        public static string AuthorizationDenied = "You are not authorized";

        public static string UserRegistered = "User registered";
        public static string UserNotFound = "User Not Found";
        public static string PasswordError = "Password Error";
        public static string SuccessfulLogin = "Sucessful Login";
        public static string UserAlreadyExists = "User Already Exists";
        public static string AccessTokenCreated = "Access Token Created";
    }

}
