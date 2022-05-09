using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Common
{
    /// <summary>
    /// Common file to store constant variable and messages to use across the application.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Encryption options
        /// </summary>
        public enum EncryptionType
        {
            Sha1 = 0,
            Sha2 = 1
        };
        /// <summary>
        /// User roles
        /// </summary>
        [Flags]
        public enum UserType
        {
            None,
            Receptionist,
            Seller,
            Owner,
            SuperAdmin,
            Dev
             
        };

        /// <summary>
        /// Action Types
        /// </summary>
        public enum ActionType
        {
            Viewed,
            Created,
            Modified,
            Deleted
        };
        #region "Regular Expression"
       // public static string _passwordPattern = "^(?=.*\d).{4,8}$";
        #endregion

        #region Constants - User Login Audit Event Constants
        public static string LOGIN_SUCCESS = "1";
        public static string LOGIN_FAILURE_WITH_VALID_USERNAME = "2";
        public static string LOGIN_FAILURE_WITH_INVALID_USERNAME = "3";

        public static string LOGIN_IMPERSONATED = "5";

        public static string LOGIN_SUCCESS_DESC = "Successful login";
        public static string LOGIN_SUCCESS_IN_ABNORMAL_HOURS_DESC = "Successful login during abnormal hours";
        public static string LOGIN_FAILURE_WITH_VALID_USERNAME_DESC = "Login failure with valid username";
        public static string LOGIN_FAILURE_WITH_INVALID_USERNAME_DESC = "Login failure with invalid username";

        public static string USER_NOT_AUTHORIZED = "0";
        public static string USER_AUTHORIZED = "1";
        public static string USER_NOT_IN_SYSTEM = "7";

        public static string LoginForceChangePdMessage = "You need to change your password in order to continue";
        public static string MIN_NUMERIC_CHAR_MISSING_MESSAGE = " Password must be between 4 and 8 digits long and include at least one numeric digit.";
        public static string SameAsOldPdMessage = "New password is same as old password";
        public static string OldPdMismatchMessage = "Old password entered is not correct";
        public static string NewConfirmPdMismatchMessage = "The new password and confirmation password do not match";
        public static string PdContainsInOldPwdsMessage = "Your new password can not contain your previous passwords";
        public static string ChangePdInstructionMessage = "Password should contain at least {0} digit(s) and {1} alphabet(s)";
        public static string IncorrectLogin = "Username and password are incorrect, try again.";
        public static string InputFieldMissingMessage = "Please enter Username and Password";
        public static string PdConfirmMessage = "Please enter Confirm Password";
        public static string PdAndConfirmSameMessage = "Password and Confirm Password should be same";
        public static string UserCreationMessage = "User created Successfully";
        public static string ErrorOccurred = "An error occurred, check logs or contact administrator";
        public static string PdSuccessfulChange = "Password changed successfully";
        public static string PdUnsuccessfulChange = "Unable to change password";

        #endregion
        #region "Regular expression"
        public static string OnlyAllowString = "^[a-zA-Z]+$";
        #endregion

    }
}
