using LibraryManagement.Models;

namespace LibraryManagement.Commands;

public class ReadJsonCommand : ICommand
{
    private readonly Library _library;

    // 构造函数：传入 Library 实例
    public ReadJsonCommand(Library library)
    {
        _library = library;
    }

    public void Execute(string[] args)
    {
        // 检查是否提供了文件路径
        if (args == null || args.Length < 1)
        {
            Console.WriteLine("Usage: read_json [file path]");
            return;
        }

        var filePath = args[0]; // 从命令参数中获取文件路径

        try
        {
            // 调用 Library 的 LoadFromFile 方法加载数据
            _library.LoadFromFile(filePath);
            Console.WriteLine($"Library data successfully loaded from: {filePath}");
        }
        catch (Exception ex)
        {
            // 捕获并显示加载失败的错误信息
            Console.WriteLine($"Failed to read JSON file. Error: {ex.Message}");
        }
    }
}
