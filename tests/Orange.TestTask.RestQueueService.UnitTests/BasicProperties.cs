using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace Orange.TestTask.RestQueueService.UnitTests
{
    public sealed class BasicProperties : IBasicProperties
    {
        private string _contentType;
        private string _contentEncoding;
        private IDictionary<string, object> _headers;
        private byte _deliveryMode;
        private byte _priority;
        private string _correlationId;
        private string _replyTo;
        private string _expiration;
        private string _messageId;
        private AmqpTimestamp _timestamp;
        private string _type;
        private string _userId;
        private string _appId;
        private string _clusterId;

        private bool _contentTypePresent = false;
        private bool _contentEncodingPresent = false;
        private bool _headersPresent = false;
        private bool _deliveryModePresent = false;
        private bool _priorityPresent = false;
        private bool _correlationIdPresent = false;
        private bool _replyToPresent = false;
        private bool _expirationPresent = false;
        private bool _messageIdPresent = false;
        private bool _timestampPresent = false;
        private bool _typePresent = false;
        private bool _userIdPresent = false;
        private bool _appIdPresent = false;
        private bool _clusterIdPresent = false;

        public string ContentType
        {
            get => _contentType;
            set
            {
                _contentTypePresent = value != null;
                _contentType = value;
            }
        }

        public string ContentEncoding
        {
            get => _contentEncoding;
            set
            {
                _contentEncodingPresent = value != null;
                _contentEncoding = value;
            }
        }

        public IDictionary<string, object> Headers
        {
            get => _headers;
            set
            {
                _headersPresent = value != null;
                _headers = value;
            }
        }

        public byte DeliveryMode
        {
            get => _deliveryMode;
            set
            {
                _deliveryModePresent = true;
                _deliveryMode = value;
            }
        }

        public bool Persistent
        {
            get { return DeliveryMode == 2; }
            set { DeliveryMode = value ? (byte)2 : (byte)1; }
        }

        public byte Priority
        {
            get => _priority;
            set
            {
                _priorityPresent = true;
                _priority = value;
            }
        }

        public string CorrelationId
        {
            get => _correlationId;
            set
            {
                _correlationIdPresent = value != null;
                _correlationId = value;
            }
        }

        public string ReplyTo
        {
            get => _replyTo;
            set
            {
                _replyToPresent = value != null;
                _replyTo = value;
            }
        }

        public string Expiration
        {
            get => _expiration;
            set
            {
                _expirationPresent = value != null;
                _expiration = value;
            }
        }

        public string MessageId
        {
            get => _messageId;
            set
            {
                _messageIdPresent = value != null;
                _messageId = value;
            }
        }

        public AmqpTimestamp Timestamp
        {
            get => _timestamp;
            set
            {
                _timestampPresent = true;
                _timestamp = value;
            }
        }

        public string Type
        {
            get => _type;
            set
            {
                _typePresent = value != null;
                _type = value;
            }
        }

        public string UserId
        {
            get => _userId;
            set
            {
                _userIdPresent = value != null;
                _userId = value;
            }
        }

        public string AppId
        {
            get => _appId;
            set
            {
                _appIdPresent = value != null;
                _appId = value;
            }
        }

        public string ClusterId
        {
            get => _clusterId;
            set
            {
                _clusterIdPresent = value != null;
                _clusterId = value;
            }
        }

        public void ClearContentType() => _contentTypePresent = false;

        public void ClearContentEncoding() => _contentEncodingPresent = false;

        public void ClearHeaders() => _headersPresent = false;

        public void ClearDeliveryMode() => _deliveryModePresent = false;

        public void ClearPriority() => _priorityPresent = false;

        public void ClearCorrelationId() => _correlationIdPresent = false;

        public void ClearReplyTo() => _replyToPresent = false;

        public void ClearExpiration() => _expirationPresent = false;

        public void ClearMessageId() => _messageIdPresent = false;

        public void ClearTimestamp() => _timestampPresent = false;

        public void ClearType() => _typePresent = false;

        public void ClearUserId() => _userIdPresent = false;

        public void ClearAppId() => _appIdPresent = false;

        public void ClearClusterId() => _clusterIdPresent = false;

        public bool IsContentTypePresent() => _contentTypePresent;

        public bool IsContentEncodingPresent() => _contentEncodingPresent;

        public bool IsHeadersPresent() => _headersPresent;

        public bool IsDeliveryModePresent() => _deliveryModePresent;

        public bool IsPriorityPresent() => _priorityPresent;

        public bool IsCorrelationIdPresent() => _correlationIdPresent;

        public bool IsReplyToPresent() => _replyToPresent;

        public bool IsExpirationPresent() => _expirationPresent;

        public bool IsMessageIdPresent() => _messageIdPresent;

        public bool IsTimestampPresent() => _timestampPresent;

        public bool IsTypePresent() => _typePresent;

        public bool IsUserIdPresent() => _userIdPresent;

        public bool IsAppIdPresent() => _appIdPresent;

        public bool IsClusterIdPresent() => _clusterIdPresent;

        public PublicationAddress ReplyToAddress
        {
            get { return PublicationAddress.Parse(ReplyTo); }
            set { ReplyTo = value.ToString(); }
        }

        public BasicProperties() { }
        public ushort ProtocolClassId => 60;
        public string ProtocolClassName => "basic";

        public void AppendPropertyDebugStringTo(StringBuilder sb)
        {
            sb.Append("(");
            sb.Append("content-type="); sb.Append(_contentTypePresent ? (_contentType == null ? "(null)" : _contentType.ToString()) : "_"); sb.Append(", ");
            sb.Append("content-encoding="); sb.Append(_contentEncodingPresent ? (_contentEncoding == null ? "(null)" : _contentEncoding.ToString()) : "_"); sb.Append(", ");
            sb.Append("headers="); sb.Append(_headersPresent ? (_headers == null ? "(null)" : _headers.ToString()) : "_"); sb.Append(", ");
            sb.Append("delivery-mode="); sb.Append(_deliveryModePresent ? _deliveryMode.ToString() : "_"); sb.Append(", ");
            sb.Append("priority="); sb.Append(_priorityPresent ? _priority.ToString() : "_"); sb.Append(", ");
            sb.Append("correlation-id="); sb.Append(_correlationIdPresent ? (_correlationId == null ? "(null)" : _correlationId.ToString()) : "_"); sb.Append(", ");
            sb.Append("reply-to="); sb.Append(_replyToPresent ? (_replyTo == null ? "(null)" : _replyTo.ToString()) : "_"); sb.Append(", ");
            sb.Append("expiration="); sb.Append(_expirationPresent ? (_expiration == null ? "(null)" : _expiration.ToString()) : "_"); sb.Append(", ");
            sb.Append("message-id="); sb.Append(_messageIdPresent ? (_messageId == null ? "(null)" : _messageId.ToString()) : "_"); sb.Append(", ");
            sb.Append("timestamp="); sb.Append(_timestampPresent ? _timestamp.ToString() : "_"); sb.Append(", ");
            sb.Append("type="); sb.Append(_typePresent ? (_type == null ? "(null)" : _type.ToString()) : "_"); sb.Append(", ");
            sb.Append("user-id="); sb.Append(_userIdPresent ? (_userId == null ? "(null)" : _userId.ToString()) : "_"); sb.Append(", ");
            sb.Append("app-id="); sb.Append(_appIdPresent ? (_appId == null ? "(null)" : _appId.ToString()) : "_"); sb.Append(", ");
            sb.Append("cluster-id="); sb.Append(_clusterIdPresent ? (_clusterId == null ? "(null)" : _clusterId.ToString()) : "_");
            sb.Append(")");
        }
    }
}
