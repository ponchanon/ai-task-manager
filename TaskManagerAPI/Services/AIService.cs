using OpenAI;
using OpenAI.Chat;

namespace TaskManagerAPI.Services
{
    public class AIService
    {
        private readonly OpenAIClient _openAiClient;

        public AIService(string apiKey)
        {
            _openAiClient = new OpenAIClient(new OpenAIAuthentication(apiKey));
        }

        public async Task<string> CategorizeTask(string taskDescription)
        {
            // Set up a chat-based request (if using a chat model)
            var result = await _openAiClient.Completions.CreateCompletionAsync(new CompletionRequest
            {
                Prompt = $"Categorize this task: {taskDescription}",
                MaxTokens = 10
            });

            // Return the result from the completion response
            return result.Choices[0].Text.Trim();
        }
    }
}
