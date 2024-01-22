using RestSharp;

namespace SeleniumNUnit.Core.API
{
    public interface IRequestBuilder
    {
        IRequestBuilder AddHeader(string name, string value);

        IRequestBuilder SetMethod(Method method);

        IRequestBuilder SetFormat(DataFormat dataFormat);

        IRequestBuilder AddBody(object body);

        RestRequest Create();
    }
}