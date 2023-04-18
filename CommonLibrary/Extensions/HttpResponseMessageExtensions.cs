namespace CommonLibrary.Extensions;
public static class HttpResponseMessageExtensions
{
    public static async Task EnsureSuccessWithContentAsync(this HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Status code: {response.StatusCode}, Content: {content}");
        }
    }
}