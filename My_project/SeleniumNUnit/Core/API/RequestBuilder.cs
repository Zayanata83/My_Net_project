using RestSharp;

namespace SeleniumNUnit.Core.API
{
    public class RequestBuilder : IRequestBuilder
    {
        private readonly string _resource;
        private readonly Dictionary<string, string> _headers;
        private readonly List<Parameter> _parameters;
        private DataFormat _dataFormat;
        private Method _method;
        private object _body;
        private int _timeOut;

        private string _fileName;
        private string _filePath;
        private string _fileType;

        public RequestBuilder(string resource)
        {
            if (string.IsNullOrEmpty(resource))
            {
                throw new ArgumentNullException(nameof(resource));
            }

            _resource = resource;
            _headers = new Dictionary<string, string>();
            _parameters = new List<Parameter>();
            _method = Method.Get;
            _dataFormat = DataFormat.Json;
            _timeOut = 0;
        }

        public IRequestBuilder AddBody(object body)
        {
            if (body is null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            _body = body;
            return this;
        }

        public IRequestBuilder SetFormat(DataFormat dataFormat)
        {
            _dataFormat = dataFormat;
            return this;
        }

        public IRequestBuilder AddHeader(string name, string value)
        {
            string headerValue = string.Empty;

            if (_headers.TryGetValue(name, out headerValue))
            {
                if (value != headerValue)
                {
                    _headers[name] = value;
                }

                return this;
            }

            _headers.Add(name, value);
            return this;
        }

        public IRequestBuilder SetMethod(Method method)
        {
            _method = method;
            return this;
        }

        public RestRequest Create()
        {
            var request = new RestRequest()
            {
                Resource = _resource,
                Method = _method,
                RequestFormat = _dataFormat
            };

            foreach (var param in _parameters)
            {
                request.AddParameter(param);
            }

            if (_body != null)
            {
                request.AddBody(_body);
            }

            foreach (var header in _headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            if (!string.IsNullOrEmpty(_fileName) && !string.IsNullOrEmpty(_filePath))
            {
                request.AddFile(_fileName, _filePath, _fileType);
            }

            request.Timeout = _timeOut;

            return request;
        }
    }
}