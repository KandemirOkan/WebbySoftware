using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebbySoftware
{
    public static class ErrorMessages
    {
        public const string requireID = "ID is required.";
        public const string invalidID = "Invalid  ID. Please provide a valid integer.";
        public const string zeroID = "ID must be greater than 0.";
        public const string NotFoundID = "ID not found. Please provide an available ID No.";
        public const string pNameError = "Project Name is required.";
        public const string pDescError = "Project Description is required.";
        public const string pGitError = "Project Git Link is required.";
        public const string ThumbError = "The maximum number of thumbnails is 5.";
        public const string uNameError = "User Name/Surname is required";
        public const string ReplicateError = "Module already exists with this name.";
    }
}

