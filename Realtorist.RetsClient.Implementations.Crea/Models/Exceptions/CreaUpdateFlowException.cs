using System;
using System.ComponentModel.DataAnnotations;
using Realtorist.Models.Helpers;
using Realtorist.RetsClient.Implementations.Crea.Models.Enums;

namespace Realtorist.RetsClient.Implementations.Crea.Models.Exceptions
{
    /// <summary>
    /// Describes exception which has occured during CREA update flow
    /// </summary>
    public class CreaUpdateFlowException : Exception
    {
        /// <summary>
        /// Status code of the exception
        /// </summary>
        public ReplyCode ReplyCode { get; }

        /// <summary>
        /// Gets name of the reply code
        /// </summary>
        public string ReplyCodeName => ReplyCode.GetLookupDisplayText();

        /// <summary>
        /// Gets description of the reply code
        /// </summary>
        public string ReplyCodeDescription => ReplyCode.GetLookupDisplayFieldFromObject(nameof(DisplayAttribute.Description));

        /// <summary>
        /// Creates new instance of <see cref="CreaUpdateFlowException"/>
        /// </summary>
        /// <param name="replyCode">Reply code of the exception</param>
        /// <param name="message">Exception's message</param>
        public CreaUpdateFlowException(ReplyCode replyCode, string message) : base(message)
        {
            this.ReplyCode = replyCode;
        }

        /// <summary>
        /// Creates new instance of <see cref="CreaUpdateFlowException"/>
        /// </summary>
        /// <param name="replyCode">Reply code of the exception</param>
        public CreaUpdateFlowException(ReplyCode replyCode) : base(replyCode.GetLookupDisplayFieldFromObject(nameof(DisplayAttribute.Description)))
        {
            this.ReplyCode = replyCode;
        }
    }
}