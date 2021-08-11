using System.ComponentModel.DataAnnotations;

namespace Realtorist.RetsClient.Implementations.Crea.Models.Enums
{
    /// <summary>
    /// Describes reply codes from the CREA DDF. Refer to Appendix L - Reply Codes in DDF documentation
    /// </summary>
    public enum ReplyCode
    {
        /// <summary>
        /// Operation successful
        /// </summary> 
        [Display(Name = "Operation successful", Description = "Operation successful")]
        Success = 0,

        /// <summary>
        /// Login - There is already a user logged in with this user name, and this server does not permit multiple logins. 
        /// </summary>
        [Display(Name = "Additional login not permitted", Description = "Login - There is already a user logged in with this user name, and this server does not permit multiple logins.")]
        Login_AdditionalLoginNotPermitted = 20022,

        /// <summary>
        /// The quoted-string of the body-start-line contains text that SHOULD be displayed to the user
        /// </summary>
        [Display(Name = "Miscellaneous server login error", Description = "Login - The quoted-string of the body-start-line contains text that SHOULD be displayed to the user.")]
        Login_MiscellaneousServerLoginError = 20036,

        /// <summary>
        /// Search - No matching records were found.
        /// </summary>
        [Display(Name = "No Records Found", Description = "Search - There is already a user logged in with this user name, and this server does not permit multiple logins.")]
        Search_NoRecordsFound = 20201,

        /// <summary>
        /// Search - The quoted-string of the body-start-line contains text that MAY be displayed to the user. 
        /// </summary>
        [Display(Name = "Miscellaneous Search Error", Description = "Search - The quoted-string of the body-start-line contains text that MAY be displayed to the user.")]
        Search_MiscellaneousSearchError = 20203,

        /// <summary>
        /// Search - The query could not be understood due to a syntax error. 
        /// </summary>
        [Display(Name = "Invalid Query Syntax", Description = "Search - The query could not be understood due to a syntax error.")]
        Search_InvalidQuerySyntax = 20206,

        /// <summary>
        /// GetObject - The request could not be understood due to an unknown resource.
        /// </summary>
        [Display(Name = "Invalid Resource ", Description = "GetObject - The request could not be understood due to an unknown resource.")]
        Object_InvalidResource = 20400,

        /// <summary>
        /// GetObject - The request could not be understood due to an unknown object type for the resource. 
        /// </summary>
        [Display(Name = "Invalid Type", Description = "GetObject - The request could not be understood due to an unknown object type for the resource.")]
        Object_InvalidType = 20401,

        /// <summary>
        /// GetObject - The identifier does not match the KeyField of any data in the resource.
        /// </summary>
        [Display(Name = "Invalid Identifier", Description = "GetObject - The identifier does not match the KeyField of any data in the resource.")]
        Object_InvalidIdentifier = 20402,

        /// <summary>
        /// GetObject - No matching object was found to satisfy the request.
        /// </summary>
        [Display(Name = "No Object Found", Description = "GetObject - No matching object was found to satisfy the request.")]
        Object_NoOjectFound = 20403,

        /// <summary>
        /// GetObject - The server encountered an internal error.
        /// </summary>
        [Display(Name = "Miscellaneous Error", Description = "GetObject - The server encountered an internal error.")]
        Object_MiscellaneousError = 20413,

        /// <summary>
        /// Metadata - The request could not be understood due to an unknown resource.
        /// </summary>
        [Display(Name = "Invalid Resource", Description = "Metadata - The request could not be understood due to an unknown resource.")]
        Metadata_InvalidResource = 20500,

        /// <summary>
        /// Metadata - The request could not be understood due to an unknown metadata type.
        /// </summary>
        [Display(Name = "Invalid Type", Description = "Metadata - The request could not be understood due to an unknown metadata type.")]
        Metadata_InvalidType = 20501,

        /// <summary>
        /// Metadata - The identifier is not known inside the specified resource. 
        /// </summary>
        [Display(Name = "Invalid Identifier", Description = "Metadata - The identifier is not known inside the specified resource.")]
        Metadata_InvalidIdentifier = 20502,

        /// <summary>
        /// Metadata - No matching metadata of the type requested was found.
        /// </summary>
        [Display(Name = "No Metadata Found", Description = "Metadata - No matching metadata of the type requested was found.")]
        Metadata_NoMetadataFound = 20503,

        /// <summary>
        /// Metadata - The requested metadata is currently unavailable.
        /// </summary>
        [Display(Name = "Metadata Unavailable ", Description = "Metadata - The requested metadata is currently unavailable.")]
        Metadata_MetadataUnavailable = 20509,

        /// <summary>
        /// Metadata - The server encountered an internal error.
        /// </summary>
        [Display(Name = "Miscellaneous Error", Description = "Metadata - The server encountered an internal error.")]
        Metadata_MiscellaneousError = 20513,

        /// <summary>
        /// The server did not detect an active login for the session in which the Logout transaction was submitted.
        /// </summary>
        [Display(Name = "Not logged in", Description = "The server did not detect an active login for the session in which the Logout transaction was submitted.")]
        NotLoggedIn = 20701,

        /// <summary>
        /// Logout - The transaction could not be completed. The ReplyText gives additional information.
        /// </summary>
        [Display(Name = "Miscellaneous Error", Description = "Logout - The transaction could not be completed. The ReplyText gives additional information.")]
        LogOut_MiscellaneousError = 20702,
    }
}