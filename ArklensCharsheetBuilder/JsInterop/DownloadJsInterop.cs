using Microsoft.JSInterop;

namespace ArklensCharsheetBuilder.JsInterop;

[RegisterScoped]
public class DownloadJsInterop(IJSRuntime jsRuntime) : JsInteropBase(jsRuntime)
{
    protected override string JsFilePath => "js/download.js";

    public async ValueTask DownloadAsync(Stream stream, string fileName)
    {
        var module = await GetModuleAsync();
        DotNetStreamReference streamRef = new(stream);

        await module.InvokeVoidAsync("downloadFile", streamRef, fileName);
    }
}