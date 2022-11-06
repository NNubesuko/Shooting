using System;
using System.Runtime.Serialization;

namespace Systemk.Exceptions {

    [Serializable()]
    public class BulletTypeNotFoundException : SystemException {

        public BulletTypeNotFoundException()
            : base() {
        }

        public BulletTypeNotFoundException(string message)
            : base (message) {
        }

        public BulletTypeNotFoundException(string message, Exception innerException)
            : base(message, innerException) {
        }

        protected BulletTypeNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
        
    }


}