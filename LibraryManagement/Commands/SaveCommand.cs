using LibraryManagement.Models;

namespace LibraryManagement.Commands
{
    public class SaveCommand : ICommand
    {
        private readonly Library _library;

        public SaveCommand(Library library)
        {
            _library = library;
        }

        public void Execute(string[] args)
        {
            // 修改为正确的路径：Data/library.json
            var filePath = "Data/library.json";  // 数据文件夹中的路径

            Console.WriteLine("Saving library data to file...");
            _library.SaveToFile(filePath);  // 将图书数据保存到 JSON 文件
        }
    }
}
