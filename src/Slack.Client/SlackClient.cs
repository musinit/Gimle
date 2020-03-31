using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Slack.Client.Models;
using Slack.Client.Models.SlackApi;
using Slack.Client.Settings;

namespace Slack.Client
{
    internal class SlackClient : ISlackClient
    {
        private readonly ILogger logger;
        private readonly IHttpClientFactory httpClientFactory;
        private const string testChannelId = "CR4P37JL9";

        public SlackClient(IHttpClientFactory httpClientFactory, ILogger logger = null)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger ?? new NullLogger<ISlackClient>();
        }

        public async Task<bool> SendMessageAsync(SendMessageRequest request, CancellationToken cancellationToken = default)
        {
            using (var httpClient = httpClientFactory.CreateClient(nameof(ISlackClient)))
            {
                httpClient.DefaultRequestHeaders.Authorization = request.AppToken != null
                    ? new AuthenticationHeaderValue("Bearer", request.AppToken)
                    : httpClient.DefaultRequestHeaders.Authorization;

                var channel = await OpenChannelWithUserAsync(request.SlackId, httpClient);
                
                SlackResponse slackResponse = await SendMessageInChannelAsync(channel.Id,
                    request.Text,
                    httpClient,
                    "chat.postMessage",
                    request.CallbackId,
                    request.Attachments,
                    request.Blocks,
                    cancellationToken);
                if (!slackResponse.Ok)
                {
                    logger.LogError(slackResponse.Error);
                    return false;
                }
                logger.LogInformation(
                    "Sending slack message for user with Id: {@id}, with message: {@message}, test = {@isTest}", request.SlackId, request.Text);


                return true;
            }
        }

        public async Task SendResponseMessageAsync(string responseUrl, Block[] blocks, 
            CancellationToken cancellationToken = default)
        {
            using (var httpClient = httpClientFactory.CreateClient(nameof(ISlackClient)))
            {
                httpClient.BaseAddress = new Uri(responseUrl);
                var updateViewSerialized = JsonConvert.SerializeObject(new MessageResponse
                {
                    Text = "Ачивка открыта!",
                    Blocks = blocks
                });  
                var response = await httpClient.PostAsync("", new StringContent(updateViewSerialized, 
                    Encoding.UTF8, "application/json"), cancellationToken);

                var responseMessage = await response.Content.ReadAsStringAsync();
                logger.LogInformation(responseMessage);
            }
        }

        public async Task<SlackResponse> UpdateViewAsync<T>(UpdateViewRequest<T> request, 
            string requestUrl = "views.publish", CancellationToken cancellationToken = default)
        {
            using (var httpClient = httpClientFactory.CreateClient(nameof(ISlackClient)))
            {
                HttpResponseMessage response;
                SlackResponse slackResponse = new SlackResponse();
                try
                {
                    var updateViewSerialized = JsonConvert.SerializeObject(request);
                    response = await httpClient.PostAsync(requestUrl, new StringContent(updateViewSerialized, 
                        Encoding.UTF8, "application/json"), cancellationToken);

                    var responseMessage = await response.Content.ReadAsStringAsync();
                    logger.LogInformation(responseMessage);
                    slackResponse = JsonConvert.DeserializeObject<SlackResponse>(responseMessage);
                    if (!response.IsSuccessStatusCode)
                    {
                        logger.LogError($"Error occured while sending message in slack with code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError($"Couldn't update view for user with Id: {request.UserId}. Error: {ex.Message}");
                    return slackResponse;
                }

                return slackResponse;
            }
        }

        public async Task<SlackUser> GetUserIfExistAsync(string email)
        {
            using (var httpClient = httpClientFactory.CreateClient(nameof(ISlackClient)))
            {
                string response = await httpClient.GetStringAsync($"users.lookupByEmail?email={email}");
                var userResponse = JsonConvert.DeserializeObject<LookUpUserResponse>(response);

                return userResponse.User;
            }
        }

        private async Task<SlackChannel> OpenChannelWithUserAsync(string userId, HttpClient httpClient)
        {
            string response;
            try
            {
                response = await httpClient.GetStringAsync($"im.open?user={userId}");
            }
            catch (Exception ex)
            {
                logger.LogError($"Couldn't create channel for user with Id: {userId}. Error: {ex.Message}");
                throw;
            }
            var channelResponse = JsonConvert.DeserializeObject<OpenChannelResponse>(response);
            if (!channelResponse.Ok)
            {
                logger.LogError(channelResponse.Error);
                throw new Exception(channelResponse.Error);
            }

            return channelResponse.Channel;
        }

        private async Task<SlackResponse> SendMessageInChannelAsync(string channelId,
                                                                    string message, 
                                                                    HttpClient httpClient,
                                                                    string requestUrl="chat.postMessage",
                                                                    string callbackId = null, 
                                                                    Attachment[] attachments = null,
                                                                    Block[] blocks = null,
                                                                    CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response;
            var slackMessage = new SlackMessage()
            {
                Channel = SlackClientConfiguration.Options.IsTest ? testChannelId : channelId,
                Text = SlackClientConfiguration.Options.IsTest ? message + $" (for {channelId})" : message,
                CallbackId = callbackId,
                Attachments = attachments,
                Blocks = blocks
            };
            try
            {
                //response = await httpClient.GetStringAsync($"chat.postMessage?channel={channelId}&text={message}");
                var messageSerialized = JsonConvert.SerializeObject(slackMessage);
                response = await httpClient.PostAsync(requestUrl, 
                    new StringContent(messageSerialized, Encoding.UTF8, "application/json"), cancellationToken);
                var responseMessage = response.Content.ReadAsStringAsync().Result;
                logger.LogInformation(responseMessage);
                if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"Error occured while sending message in slack with code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Couldn't send message in channel with Id: {channelId}. Error: {ex.Message}");
                throw;
            }
            var slackResponse = JsonConvert.DeserializeObject<SlackResponse>(await response.Content.ReadAsStringAsync());

            return slackResponse;
            
        }
    }
}
