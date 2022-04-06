using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utils.Exceptions
{
    public class BusinessRuleValidationException : Exception
    {
        public InternalExceptionCode ErrorId { get; set; }

        public object MetaData { get; set; }

        public ErrorResponseModel ResponseModel { get; set; }

        public BusinessRuleValidationException(InternalExceptionCode errorId, object metaData = null) : base(errorId.ToString())
        {
            ErrorId = errorId;
            MetaData = metaData;

            ResponseModel = new ErrorResponseModel
            {
                ErrorId = errorId,
                Message = errorId.ToString(),
                MetaData = metaData
            };
        }
    }

    public class ErrorResponseModel
    {
        public InternalExceptionCode ErrorId { get; set; }

        public object MetaData { get; set; }

        public string Message { get; set; }
    }
}