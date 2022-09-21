namespace Web;

public static class FileHelper
{
    private static readonly Dictionary<string, string> MimeDic;

    static FileHelper()
    {
        MimeDic = new Dictionary<string, string>
        {
            {".jpg", "image/jpeg"},
            {".png", "image/png"},
            {".xls", "application/vnd.ms-excel"},
            {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
            {".pdf", "application/pdf"},
            {".doc", "application/msword"},
            {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
            {".rar", "application/octet-stream"},
            {".zip", "application/x-zip-compressed"},
            {".txt", "text/plain"},
            {".cdf", "application/x-netcdf"},
            {".cdr", "application/vnd.corel-draw"},
            {".wav", "audio/x-wav"},
            {".wax", "audio/x-ms-asx"},
            {".aiff", "audio/x-aiff"},
            {".mp3", "audio/mpeg"},
            {".mp4", "video/mp4"},
            {".flac", "audio/x-flac"},
            {".xm", "audio/x-xm"},
            {".xmf", "audio/x-xmf"},
            {".mpp", "audio/x-musepack"},
            {".oga", "audio/ogg"},
            {".wv", "audio/x-wavpack"},
            {".wvc", "audio/x-wavpack-correction"},
            {".wvp", "audio/x-wavpack"},
            {".wvx", "audio/x-ms-asx"},
            {".wmv", "video/x-ms-wmv"},
            {".wmx", "audio/x-ms-asx"},
            {".vob", "video/mpeg"},
            {".vivo", "video/vivo"},
            {".viv", "video/vivo"},
            {".webm", "video/webm"},
            {".rv", "video/vnd.rn-realvideo"},
            {".rvx", "video/vnd.rn-realvideo"},
            {".ogg", "video/x-theora+ogg"},
            {".mpe", "video/mpeg"},
            {".mpeg", "video/mpeg"},
            {".mpg", "video/mpeg"}
        };
    }

    public static string GetMimeType(string extension)
    {
        if (MimeDic.ContainsKey(extension))
        {
            return MimeDic[extension];
        }

        return "";
    }
}