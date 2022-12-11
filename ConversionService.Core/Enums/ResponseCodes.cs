﻿namespace ConversionService.Core.Enums
{
    public enum ResponseCodes:short
    {
        /// <summary>
        /// Success
        /// </summary>
        SUCCESS = 00,
        /// <summary>
        /// Failure
        /// </summary>
        NO_DATA_AVAILABLE = 01,

        /// <summary>
        /// Some failure of some sort
        /// </summary>
        FAILURE = 02,
        SYSTEM_ERROR_OCCURRED = 03,
        NO_USER_PROFILE_FOUND = 04,
        INVALID_LOGIN_DETAILS = 05,
    }
}
