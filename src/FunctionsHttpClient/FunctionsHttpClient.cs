﻿using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionsHttpClient
{
    public class FunctionsHttpClient : IDisposable
    {
        private static HttpClient _httpClient = new HttpClient(_delegatingHandler, true);
        private static InnerHttpMessageHandler _delegatingHandler = new InnerHttpMessageHandler();
        public FunctionsHttpClient()
        {
        }

        public FunctionsHttpClient(HttpMessageHandler handler)
        {
            _delegatingHandler.InnerHandler = handler;
        }

        public static FunctionsHttpClient AuthPassthrough(HttpRequestMessage req, bool overrideAuth = false, HttpMessageHandler handler = null)
        {
            return new FunctionsHttpClient(new AuthPassthroughHandler(req.Headers.Authorization, overrideAuth, handler));
        }

        public HttpRequestHeaders DefaultRequestHeaders { get => _httpClient.DefaultRequestHeaders; }
        public Uri BaseAddress { get => _httpClient.BaseAddress; set => _httpClient.BaseAddress = value; }
        public long MaxResponseContentBufferSize { get => _httpClient.MaxResponseContentBufferSize; set => _httpClient.MaxResponseContentBufferSize = value; }
        public TimeSpan Timeout { get => _httpClient.Timeout; set => _httpClient.Timeout = value; }

        public void CancelPendingRequests() => _httpClient.CancelPendingRequests();
        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken) =>
            _httpClient.DeleteAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken) =>
            _httpClient.DeleteAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> DeleteAsync(string requestUri) =>
            _httpClient.DeleteAsync(requestUri);
        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri) =>
            _httpClient.DeleteAsync(requestUri);
        public Task<HttpResponseMessage> GetAsync(string requestUri) =>
            _httpClient.GetAsync(requestUri);
        public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption) =>
            _httpClient.GetAsync(requestUri, completionOption);
        public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) =>
            _httpClient.GetAsync(requestUri, completionOption, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken) =>
            _httpClient.GetAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(Uri requestUri) =>
            _httpClient.GetAsync(requestUri);
        public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption) =>
            _httpClient.GetAsync(requestUri, completionOption);
        public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) =>
            _httpClient.GetAsync(requestUri, completionOption, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken) =>
            _httpClient.GetAsync(requestUri, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(string requestUri) =>
            _httpClient.GetByteArrayAsync(requestUri);
        public Task<byte[]> GetByteArrayAsync(Uri requestUri) =>
            _httpClient.GetByteArrayAsync(requestUri);
        public Task<Stream> GetStreamAsync(string requestUri) =>
            _httpClient.GetStreamAsync(requestUri);
        public Task<Stream> GetStreamAsync(Uri requestUri) =>
            _httpClient.GetStreamAsync(requestUri);
        public Task<string> GetStringAsync(string requestUri) =>
            _httpClient.GetStringAsync(requestUri);
        public Task<string> GetStringAsync(Uri requestUri) =>
            _httpClient.GetStringAsync(requestUri);
        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content) =>
            _httpClient.PostAsync(requestUri, content);
        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken) =>
            _httpClient.PostAsync(requestUri, content, cancellationToken);
        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content) =>
            _httpClient.PostAsync(requestUri, content);
        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken) =>
            _httpClient.PostAsync(requestUri, content, cancellationToken);
        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content) =>
            _httpClient.PutAsync(requestUri, content);
        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken) =>
            _httpClient.PutAsync(requestUri, content, cancellationToken);
        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content) =>
            _httpClient.PutAsync(requestUri, content);
        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken) =>
            _httpClient.PutAsync(requestUri, content, cancellationToken);
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request) =>
            _httpClient.SendAsync(request);
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption) =>
            _httpClient.SendAsync(request, completionOption);
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken) =>
            _httpClient.SendAsync(request, completionOption, cancellationToken);
        public virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) =>
            _httpClient.SendAsync(request, cancellationToken);

        public void Dispose()
        {
            _delegatingHandler.Dispose();
            _delegatingHandler = new InnerHttpMessageHandler();
        }
    }
}
